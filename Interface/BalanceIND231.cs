
using NTDCommon;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using NTDCommLib;

namespace NTDCommon
{
    public class BalanceIND231 : BalanceInterface
    {
        public BalanceIND231()
        {

        }

        #region 属性
        /// <summary>
        /// 定义事件
        /// </summary>
        public event EventHandler EventHandler;
   
        /// <summary>
        /// 锁
        /// </summary>
        static object Lock = new object();


        /// <summary>
        /// 秤台名称
        /// </summary>
        string BalanceName = "托利多231";

        /// <summary>
        /// 连接状态
        /// </summary>
        bool ConnectStatic;

        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        string MessageInfo = string.Empty;

        /// <summary>
        /// 读取称台的线程
        /// </summary>
        Thread ReadBalanceDataThread;

        /// <summary>
        /// 秤台数据
        /// </summary>
        NTDWeightCoreBean CurrentWCB = new NTDWeightCoreBean();


        /// <summary>
        /// 秤台实体类
        /// </summary>
        balance_entity CurrentBalance = new balance_entity();

        //socket连接服务器次数
        int ConnectCount = 0;
        //连接次数阀值
        int ConnectCountThreshold = 1;


        //当前socket通讯实例
        TcpClient CurrentTcpClient = null;
        //
        Socket CurrentSocket = null;
      
        //串口通讯实例
        SerialPort CurrentSerialPort = null;
        List<byte> ReceiveDatas = new List<byte>();

        /// <summary>
        /// Desc:通讯方式（内部通讯，串口，TCP/IP）
        /// Default:
        /// Nullable:True
        /// </summary>           
        string CommunicationMode=string.Empty;

        /// <summary>
        /// Desc:输出类型（continue，sice）
        /// Default:
        /// Nullable:True
        /// </summary>           
        string OutputType =string.Empty;

        /// <summary>
        /// Desc:串口
        /// Default:
        /// Nullable:True
        /// </summary>           
        string SerialPort = string.Empty;

        /// <summary>
        /// Desc:波特率
        /// Default:
        /// Nullable:True
        /// </summary>           
        int BaudRate;


        /// <summary>
        /// Desc:ip地址
        /// Default:
        /// Nullable:True
        /// </summary>           
        string Ip = string.Empty;

        /// <summary>
        /// Desc:端口
        /// Default:
        /// Nullable:True
        /// </summary>           
        int Port=1500;


        #endregion


        /// <summary>
        /// 设置单个秤台的显示的单位
        /// </summary>
        /// <param name="unit"></param>
        public void SetNTDMassUnitEnumUnit(string unit)
        {
          
        }

        public void SetSingleScaleDetails(balance_entity entity)
        {
            try
            {
                CurrentBalance = entity;

                CommunicationMode = CurrentBalance.communication_mode;
                OutputType = CurrentBalance.output_type;
                SerialPort = CurrentBalance.serial_port;
                BaudRate = IntHelper.Conversion(CurrentBalance.baud_rate);
                Ip = entity.ip;
                Port = IntHelper.Conversion(CurrentBalance.port);
            }
            catch (Exception)
            {

            }
        }
       
        public balance_entity GetSingleScaleDetails()
        {
            return CurrentBalance;
        }

       
        public bool InitAll()
        {
            return InitAll(1);
        }
        public bool InitAll(int platformCount)
        {
            try
            {
                //先关掉在打开
                Close();

                ConnectStatic = true;
                switch (CommunicationMode)
                {
           
                    case ("内部通讯"):
                    case ("串口"):
                        switch (OutputType)
                        {
                            case ("continu"):
                            case ("continue"):
                                CurrentSerialPort = new SerialPort();
                                CurrentSerialPort.PortName = SerialPort;
                                CurrentSerialPort.BaudRate = BaudRate;
                                CurrentSerialPort.Open();
                                ReadBalanceDataThread = new Thread(ReadBalanceDataThreadFunc);
                                ReadBalanceDataThread.IsBackground = true;
                                ReadBalanceDataThread.Start();
                                break;
                            case ("print"):
                                CurrentSerialPort = new SerialPort();
                                CurrentSerialPort.PortName = SerialPort;
                                CurrentSerialPort.BaudRate = BaudRate;
                                CurrentSerialPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                                CurrentSerialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);//必须手动添加事件处理程序
                                //开始委托的时间
                                EventHandlerCurrentStartTimeStamp = Environment.TickCount;//当前时间戳
                                CurrentSerialPort.ReceivedBytesThreshold = 1;  //必须一定要加上这句话，意思是接收缓冲区当中如果有一个字节的话就出发接收函数，如果不加上这句话，那就有时候触发接收有时候都发了好多次了也没有触发接收，有时候延时现象等等，
                                CurrentSerialPort.Open();
                                break;
                            default:
                                throw new Exception("未指定称台输出方式");
                        }
                        break;
                    case ("TCP/IP"):
                       
                        CurrentTcpClient = new TcpClient();
                        CurrentTcpClient.Connect(IPAddress.Parse(Ip), Port);
                        ReadBalanceDataThread = new Thread(ReadBalanceDataThreadFunc);
                        ReadBalanceDataThread.IsBackground = true;
                        ReadBalanceDataThread.Start();        
                        break;
                    default:
                        throw new Exception("未指定通讯方式");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageInfo += "失败原因：" + ex.Message;
                Close();
                return false;
            }
        }




        private int ReadBufferLenght;

        private  byte[] ReadBuffer=new byte[0];//获取的称台数据

        private string  ReadStr =string.Empty;//获取的称台数据

        void ReadBalanceDataThreadFunc()
        {
            while (ConnectStatic)
                {
                    try
                    {
                        switch (CommunicationMode.ToLower())
                        {
                            default:
                            case ("内部通讯"):
                            case ("串口"):
                            case ("serialport"):
                            
                                ReadBufferLenght = CurrentSerialPort.BytesToRead;
                                if (ReadBufferLenght > 0)
                                {
                                    ReadBuffer = new byte[ReadBufferLenght];
                                    CurrentSerialPort.Read(ReadBuffer, 0, ReadBuffer.Length);
                                    DecryptContinuReceiveData(ReadBuffer);
                                }

                                break;
                            case ("TCP/IP"):
                                ReadBuffer = new byte[18];
                                CurrentSocket = CurrentTcpClient.Client;
                                CurrentSocket.Receive(ReadBuffer, 0, ReadBuffer.Length, SocketFlags.None);
                                DecryptContinuReceiveData(ReadBuffer);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        Thread.Sleep(10);
                    }
                }
        }

        private void DecryptContinuReceiveData(byte[] bts)
        {
            if (bts.Length == 0) return;

            ReceiveDatas.AddRange(bts);

            // 去除前面无效数据
            while (ReceiveDatas.Count > 0)
            {
                if (ReceiveDatas[0] == 0x02)
                    break;
                else
                    ReceiveDatas.RemoveAt(0);
            }

            // 解析每包数据
            while (ReceiveDatas.Count >= 17)
            {
                int i = 0;
                foreach (byte b in ReceiveDatas)
                {
                    i++;
                    if (b == 0x0D) break;
                }
                if (i == 17)
                {
                    double dNet, dTare, dGross;
                    string ToStr = "";
                    byte[] CurrentData = new byte[17];
                    Array.Copy(ReceiveDatas.ToArray(), CurrentData, 17);

                    // 状态字A解析
                    byte SWA = CurrentData[1];
                    // 解析小数点位数
                    int x = SWA & 0x07;
                    double PointValue = 1;
                    switch (x)
                    {
                        case 3:
                            {
                                PointValue = 0.1;
                                ToStr = "0.0";
                                break;
                            }
                        case 4:
                            {
                                PointValue = 0.01;
                                ToStr = "0.00";
                                break;
                            }
                        case 5:
                            {
                                PointValue = 0.001;
                                ToStr = "0.000";
                                break;
                            }
                        case 6:
                            {
                                PointValue = 0.0001;
                                ToStr = "0.0000";
                                break;
                            }
                        default:
                            {
                                PointValue = 1;
                                ToStr = "";
                                break;
                            }
                    }

                    // 状态字B解析
                    byte SWB = CurrentData[2];
                    bool IsNet = true;                          // 是否净重 true=净重,false=毛重
                    bool IsPositiveNumber = true;               // 是否正数 true=正数,false=负数
                    bool IsOutLimit = false;                    // 是否上超或下超 true=超限,false=未超
                    bool IsStable = true;                       // 是否稳态值 true=稳定,false=不稳
                    bool IsTerminalInit = false;                // 仪表初始化 true=正在初始化,false=正常工作

                    int n0, n1, n2, n3, n4, n6;
                    n0 = (SWB & 0x01) == 0x01 ? 1 : 0;
                    n1 = (SWB & 0x02) == 0x02 ? 1 : 0;
                    n2 = (SWB & 0x04) == 0x04 ? 1 : 0;
                    n3 = (SWB & 0x08) == 0x08 ? 0 : 1;
                    n4 = (SWB & 0x10) == 0x10 ? 1 : 0;
                    n6 = (SWB & 0x40) == 0x40 ? 1 : 0;

                    IsNet = n0 == 1 ? true : false;
                    IsPositiveNumber = n1 == 0 ? true : false;
                    IsOutLimit = n2 == 1 ? true : false;
                    IsStable = n3 == 1 ? true : false;
                    CurrentWCB.Unit=(n4 == 1 ? "kg" : "g");
                    IsTerminalInit = n6 == 1 ? true : false;

                    CurrentWCB.Stable = IsStable;
                    //_Running = !IsTerminalInit;
                    //_Overload = _Underload = IsOutLimit;

                    // 解析重量
                    byte[] NetW = new byte[6];
                    byte[] TareW = new byte[6];

                    Array.Copy(CurrentData, 4, NetW, 0, 6);
                    Array.Copy(CurrentData, 10, TareW, 0, 6);

                    string n = Encoding.ASCII.GetString(NetW, 0, NetW.Length);
                    string t = Encoding.ASCII.GetString(TareW, 0, TareW.Length);

                    // 计算净重
                    if (DoubleHelper.Conversion(n, out dNet))
                    {
                        dNet = dNet * PointValue;
                        if (!IsPositiveNumber) dNet = 0 - dNet;
                        CurrentWCB.NetWeight = dNet.ToString(ToStr);
                    }
                    else
                    {
                        CurrentWCB.Stable = false;
                    }

                    // 计算皮重
                    if (DoubleHelper.Conversion(t, out dTare))
                    {
                        dTare = dTare * PointValue;
                        if (!IsPositiveNumber) dTare = 0 - dTare;

                        CurrentWCB.TareWeight = dTare.ToString(ToStr);
                    }
                    else
                    {
                        CurrentWCB.Stable = false;
                    }

                    // 计算毛重
                    CurrentWCB.GrossWeight = (dNet + dTare).ToString(ToStr);
                }

                ReceiveDatas.RemoveRange(0, i);
            }
        }





        private int EventHandlerCurrentStartTimeStamp = 0;//委托开始时间

        private int EventHandlerCurrentImplementTimeStamp = 0;//当前时间戳


        /// <summary>
        /// 获取串口数据时触发的委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (Lock)
                {
                    //判断是否串口输出的时间
                    EventHandlerCurrentImplementTimeStamp = Environment.TickCount;//当前时间戳
                    if (EventHandlerCurrentImplementTimeStamp - EventHandlerCurrentStartTimeStamp < 200)
                   {
                       EventHandlerCurrentStartTimeStamp = Environment.TickCount;
                       return;
                   }
                   else
                   {
                      // int i = EventHandlerCurrentImplementTimeStamp - EventHandlerCurrentStartTimeStamp;
                       EventHandlerCurrentStartTimeStamp = Environment.TickCount;
                   }



                    CurrentWCB = new NTDWeightCoreBean();
                    //解决多次触发问题
                    Thread.Sleep(200);
                    //开辟接收缓冲区
                    ReadBuffer = new byte[200];
                    ReadStr = string.Empty;
                    //从串口读取数据
                    CurrentSerialPort.Read(ReadBuffer, 0, ReadBuffer.Length);
                    //协议解析
                    ReadStr = Encoding.ASCII.GetString(ReadBuffer, 0, ReadBuffer.Length).Replace("\0", "").Replace("\r\n", "@");
                    var resultArray = ReadStr.Split('@');
                    foreach (string data in resultArray)
                    {
                        if (string.IsNullOrEmpty(data)) continue;
                        var str = data.Split(' ');
                        switch (str[0].Trim())
                        {
                            case "Date":
                            case "日期":
                                CurrentWCB.Date = str[str.Length - 1];
                                break;
                            case "Time":
                            case "时间":
                                CurrentWCB.Time= str[str.Length - 1];
                                break;
                            case "Gross":
                            case "毛重":
                                CurrentWCB.GrossWeight = str[str.Length - 2];
                                CurrentWCB.Unit=(str[str.Length - 1]);
                                break;
                            case "Tare":
                            case "皮重":
                                CurrentWCB.TareWeight = str[str.Length - 2];
                                CurrentWCB.Unit=(str[str.Length - 1]);
                                break;
                            case "Net":
                            case "净重":
                                CurrentWCB.NetWeight = str[str.Length - 2];
                                CurrentWCB.Unit=(str[str.Length - 1]);
                                break;
                        }

                    }

                
                    CurrentWCB.DateTime = CurrentWCB.Date.Replace(".", "-") + " " + CurrentWCB.Time;
                    Thread thread = new Thread(threadTest);
                    thread.IsBackground = true;
                    thread.Start();   
                    // 触发事件 OnPrintEventHandler(new SendDataEventArgs<MeterEntity>(meterEntity));
                    //    this.EventHandler(this, new BaseEvent<WeightCoreBean>(Wcb));
                    return;
                }
            }
            catch (Exception ex)
            {
               

            }
        }

        void threadTest()
        {
            try
            {
                this.EventHandler(this, new BaseEvent<NTDWeightCoreBean>(CurrentWCB));
            }
            catch (Exception)
            {
 
            }
        }

        /// <summary>
        /// 获取单个重量
        /// </summary>
        /// <returns></returns>
        public NTDWeightCoreBean GetSingleValue()
        {
            return CurrentWCB;
        }
     
     
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            try
            {
                ConnectStatic = false;
                //if (ReadBalanceDataThread != null) ReadBalanceDataThread.Abort();
                if (CurrentSerialPort != null) CurrentSerialPort.Close();
                if (CurrentTcpClient != null) CurrentTcpClient.Close();
                if (CurrentSocket != null)    CurrentSocket.Close();
             
            }
            catch (Exception ex)
            {
                throw new Exception("关闭秤台失败"+ ex.Message);
            }
        }

        /// <summary>
        /// 获取实例名称
        /// </summary>
        public string GetBalanceName()
        {
            return BalanceName;

        }

        /// <summary>
        /// 获取串口状态
        /// </summary>
        public bool GetStatus()
        {
            return ConnectStatic;

        }
        /// <summary>
        /// 获取串口错误信息
        /// </summary>
        public string GetMessageInfo()
        {
            return MessageInfo;

        }



        /// <summary>
        /// 预值皮重
        /// </summary>
        /// <param name="presetTareWeight"></param>
        public void SetPresetTareWeight(string presetTareWeight)
        {
            SetPresetTareWeight(presetTareWeight, 1);
        }
        public void SetPresetTareWeight(string presetTareWeight, int weighingPlatformNo)
        {
            try
            {
                CurrentWCB.PresetTareWeight = presetTareWeight;
            }
            catch (Exception ex)
            {
                throw new Exception("预值皮重失败：" + ex.ToString());
            }

        }

        /// <summary>
        /// 清零
        /// </summary>
        public void SetZero()
        {
            SetZero(1);
        }
        public void SetZero(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    switch (CommunicationMode.ToLower())
                    {
                        default:
                        case ("内部通讯"):
                        case ("串口"):
                        case ("serialport"):
                            switch (OutputType)
                            {
                                case ("continue"):
                                case ("print"):
                                    CurrentSerialPort.WriteLine("Z");//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    CurrentSerialPort.WriteLine("ZI");//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            break;
                        case ("TCP/IP"):
                            string sendData = string.Empty;
                            switch (OutputType)
                            {
                                case ("continue"):
                                case ("print"):
                                    sendData = "Z" + "\x0D\x0A"; ;//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    sendData = "ZI" + "\x0D\x0A";//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            //加结束符
                            byte[] buffer = Encoding.UTF8.GetBytes(sendData);  // length of the text "Hello world!"//FIXME
                            SocketHelper.Send(CurrentSocket, buffer, 0, buffer.Length, 10000);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("清零失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 去皮
        /// </summary>
        public void SetTare()
        {
            SetTare(1);
        }
        public void SetTare(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    switch (CommunicationMode.ToLower())
                    {
                        default:
                        case ("内部通讯"):
                        case ("串口"):
                        case ("serialport"):
                            switch (OutputType)
                            {
                                case ("continue"):
                                case ("print"):
                                    CurrentSerialPort.WriteLine("T");//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    CurrentSerialPort.WriteLine("TI");//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            break;
                        case ("TCP/IP"):
                            string sendData = string.Empty;
                            switch (OutputType)
                            {
                                case ("continu"):
                                case ("continue"):
                                case ("print"):
                                    sendData = "T" + "\x0D\x0A"; ;//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    sendData = "TI" + "\x0D\x0A";//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            //加结束符
                            byte[] buffer = Encoding.UTF8.GetBytes(sendData);  // length of the text "Hello world!"//FIXME
                            SocketHelper.Send(CurrentSocket, buffer, 0, buffer.Length, 10000);
                            break;
                    }
                    CurrentWCB.PresetTareWeight = "0";//内存的预制皮重
                }
            }
            catch (Exception ex)
            {
                throw new Exception("去皮失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 清皮
        /// </summary>
        public void ClearTare()
        {
            ClearTare(1);
        }
        public void ClearTare(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    switch (CommunicationMode.ToLower())
                    {
                        default:
                        case ("内部通讯"):
                        case ("串口"):
                        case ("serialport"):
                            switch (OutputType)
                            {
                                case ("continue"):
                                case ("print"):
                                    CurrentSerialPort.WriteLine("C");//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    CurrentSerialPort.WriteLine("TAC");//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            break;
                        case ("TCP/IP"):
                            string sendData = string.Empty;
                            switch (OutputType)
                            {
                                case ("continu"):
                                case ("continue"):
                                case ("print"):
                                    sendData = "C" + "\x0D\x0A"; ;//包含连续输出和按键输出
                                    break;
                                case ("sics"):
                                    sendData = "TAC" + "\x0D\x0A";//问答模式
                                    break;
                                default:
                                    throw new Exception("未指定称台输出模式");
                                    break;
                            }
                            //加结束符
                            byte[] buffer = Encoding.UTF8.GetBytes(sendData);  // length of the text "Hello world!"//FIXME
                            SocketHelper.Send(CurrentSocket, buffer, 0, buffer.Length, 10000);
                            break;
                    }
                    CurrentWCB.PresetTareWeight = "0";//内存的预制皮重
                }
            }
            catch (Exception ex)
            {
                throw new Exception("清皮失败：" + ex.ToString());
            }
        }



        #region BalanceInterface 成员


        public void GetDivisionAndRange(out decimal division, out decimal range)
        {
            throw new NotImplementedException();
        }

        public void GetDivisionAndRange(out decimal division, out decimal range, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight)
        {
            throw new NotImplementedException();
        }

        public void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public void CalibrateZero()
        {
            throw new NotImplementedException();
        }

        public void CalibrateZero(int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public void CalibrateWeight(decimal calibrateWeight)
        {
            throw new NotImplementedException();
        }

        public void CalibrateWeight(decimal calibrateWeight, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public void FactoryZero()
        {
            throw new NotImplementedException();
        }

        public void FactoryZero(int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public bool SetWarningLightStatus(string[] strArray)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BalanceInterface 成员


        public decimal GetDivision()
        {
            throw new NotImplementedException();
        }

        public decimal GetDivision(int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public decimal GetRange()
        {
            throw new NotImplementedException();
        }

        public decimal GetRange(int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BalanceInterface 成员


        public void SetZeroTracking(int costant)
        {
            throw new NotImplementedException();
        }

        public void SetZeroTracking(int costant, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        public void SetFiltering(int avg, int costant)
        {
            throw new NotImplementedException();
        }

        public void SetFiltering(int avg, int costant, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
