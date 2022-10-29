using HZH_Controls.Forms;
using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTDCommon
{
    public class ScaleTOLEDO231 : BalanceInterface
    {
        #region 属性

        /// <summary>
        /// 定义事件
        /// </summary>
        public event EventHandler EventHandler;

        /// <summary>
        /// 锁
        /// </summary>
        private static object Lock = new object();

        /// <summary>
        /// 连接状态
        /// </summary>
        private bool ConnectStatic = false;

        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        private string MessageInfo = string.Empty;

        /// <summary>
        /// 秤台数量
        /// </summary>
        private int PlatformCount = 1;

        /// <summary>
        /// 秤台号（内部秤台的地址）
        /// </summary>           
        public int WeighingPlatformNo = 1;

        /// <summary>
        /// 串口
        /// </summary>           
        public string SerialPort = "COM1";

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate = 9600;

        /// <summary>
        /// 秤台数据
        /// </summary>
        private NTDWeightCoreBean CurrentWCB = new NTDWeightCoreBean();


        /// <summary>
        /// 秤台实体类
        /// </summary>
        private balance_entity CurrentBalance = new balance_entity();
        private List<balance_entity> CurrentBalanceScaleList = new List<balance_entity>();

        //串口通讯实例
        private SerialPort CurrentSerialPort = null;
        private List<byte> ReceiveDatas = new List<byte>();

        #endregion


        public ScaleTOLEDO231()
        {

        }


        public void SetScaleDetails(List<balance_entity> entityList)
        {
            if (entityList != null && entityList.Count > 0)
            {
                CurrentBalanceScaleList = entityList;
                CurrentBalance = CurrentBalanceScaleList.First();
                SerialPort = CurrentBalance.serial_port ;
                BaudRate = IntHelper.Conversion(CurrentBalance.baud_rate);
            }
        }

        public List<balance_entity> GetScaleDetails()
        {
            return CurrentBalanceScaleList;
        }



        public bool InitAll()
        {
            return InitAll(PlatformCount);
        }

        public bool InitAll(int platformCount)
        {

            try
            {
                ConnectStatic = true;

                if (CurrentSerialPort != null) CurrentSerialPort.Close();
                CurrentSerialPort = new SerialPort();

                CurrentSerialPort.PortName = SerialPort;
                CurrentSerialPort.BaudRate = BaudRate;
                CurrentSerialPort.Open();

                Thread readSerialPortDataThread = new Thread(ReadSerialPortData);
                readSerialPortDataThread.IsBackground = true;
                readSerialPortDataThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                ConnectStatic = false;
                MessageInfo += "失败原因：" + ex.Message;
                return false;
            }
        }

        void ReadSerialPortData()
        {
            while (ConnectStatic)
            {
                try
                {
                    int len = CurrentSerialPort.BytesToRead;
                    if (len > 0)
                    {
                        byte[] buf = new byte[len];
                        CurrentSerialPort.Read(buf, 0, buf.Length);

                        DecryptContinuReceiveData(buf);
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
                    if (DoubleHelper.ObjectConversionDouble(n, out dNet))
                    {
                        dNet = dNet * PointValue;
                        if (!IsPositiveNumber) dNet = 0 - dNet;
                        CurrentWCB.NetWeight =  dNet.ToString(ToStr);
                    }
                    else
                    {
                        CurrentWCB.Stable = false;
                    }

                    // 计算皮重
                    if (DoubleHelper.ObjectConversionDouble(t, out dTare))
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
        /// <summary>
        /// 获取单个重量
        /// </summary>
        /// <returns></returns>
        public NTDWeightCoreBean GetSingleValue()
        {
            return GetSingleValue(WeighingPlatformNo);
        }

        public NTDWeightCoreBean GetSingleValue(int weighingPlatformNo)
        {
            return CurrentWCB;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            try
            {
                if (ConnectStatic) ConnectStatic = false;
                if (CurrentSerialPort != null) CurrentSerialPort.Close();
            }
            catch (Exception)
            {
                throw new Exception("关闭串口失败");
            }
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
            SetPresetTareWeight(presetTareWeight, WeighingPlatformNo);
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
            SetZero(WeighingPlatformNo);
        }
        public void SetZero(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    CurrentSerialPort.WriteLine("Z" + "\r\n");
                    // sp.WriteReadLine("ZI");
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
            SetTare(WeighingPlatformNo);
        }
        public void SetTare(int weighingPlatformNo)
        {
            try
            {
                CurrentWCB.PresetTareWeight = "0";
                lock (Lock)
                {
                    CurrentSerialPort.WriteLine("T" + "\r\n");
                    //  Com.WriteReadLine("TI");
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
            ClearTare(WeighingPlatformNo);
        }
        public void ClearTare(int weighingPlatformNo)
        {
            try
            {
                CurrentWCB.PresetTareWeight = "0";
                lock (Lock)
                {
                    CurrentSerialPort.WriteLine("C" + "\r\n");
                    //     Com.WriteReadLine("TAC");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("清皮失败：" + ex.ToString());
            }
        }

        public void SetNTDMassUnitEnumUnit(string unit)
        {
            throw new NotImplementedException();
        }

        public void SetNTDMassUnitEnumUnit(string unit, int weighingPlatformNo)
        {
            throw new NotImplementedException();
        }

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

        public void SetAllNTDMassUnitEnumUnit(string[] unitArray)
        {
            throw new NotImplementedException();
        }
    }
}
