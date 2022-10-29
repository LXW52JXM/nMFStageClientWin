using NTDCommLib;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class PrintZPLCommand : PrintInterface
    {
        #region 属性

        /// <summary>
        /// 通讯连接状态
        /// </summary>
        private bool ConnectStatic = false;

        /// <summary>
        /// 连接次数
        /// </summary>
        private int ConnectCount = 0;

        /// <summary>
        /// 连接次数阀值
        /// </summary>
        private int ConnectCountThreshold = 1;

        /// <summary>
        /// socket通讯实例
        /// </summary>
        private TcpClient CurrentTcpClient = null;

        private Socket CurrentSocket = null;

        /// <summary>
        /// 串口通讯实例
        /// </summary>
        private SerialPort CurrentSerialPort = null;

        /// <summary>
        /// byte数据
        /// </summary>
        private byte[] CurrentBuffer = new byte[0];

        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        private string MessageInfo = string.Empty;

        /// <summary>
        /// 通讯方式（串口，TCP/IP）
        /// </summary>
        public string CommunicationMode = string.Empty;

        /// <summary>
        /// 串口
        /// </summary>
        public string SerialPort = "COM1";

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate = 9600;

        /// <summary>
        /// 停止位
        /// </summary>
        public int StopBit = 8;

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip = string.Empty;

        /// <summary>
        /// 端口
        /// </summary>
        public int Port = 1500;


        #endregion

        public PrintZPLCommand()
        {

        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            try
            {
                if (CurrentSerialPort != null) CurrentSerialPort.Close();
                if (CurrentTcpClient != null) CurrentTcpClient.Close();
                if (CurrentSocket != null) CurrentSocket.Close();

                ConnectStatic = false;

            }
            catch (Exception)
            {

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

        public bool InitAll(string communicationMode, string serialPort, int baudRate, string ip, int port)
        {

            try
            {


                CommunicationMode = communicationMode;
                SerialPort = serialPort;
                BaudRate = baudRate;
                Ip = ip;
                Port = port;

                //先关掉在打开
                Close();

                switch (CommunicationMode)
                {
                    default:
                    case ("串口"):
                        CurrentSerialPort = new SerialPort();
                        CurrentSerialPort.PortName = SerialPort;
                        CurrentSerialPort.BaudRate = BaudRate;
                        CurrentSerialPort.Encoding = Encoding.Default;
                        CurrentSerialPort.Open();

                        ConnectStatic = true;
                        break;
                    case ("TCP/IP"):
                        CurrentTcpClient = new TcpClient();
                        CurrentTcpClient.Connect(IPAddress.Parse(Ip), Port);
                        ConnectStatic = true;
                        break;
                }
                ConnectStatic = true;
                return true;

            }
            catch (Exception ex)
            {
                MessageInfo += "失败原因：" + ex.Message;
                Close();
                return false;
            }
        }

        /// <summary>
        /// 发送ZPL数据到打印机(文件格式必须是GBK,否则乱码)
        /// </summary>
        public bool SendDataToPrint(string Data, out string msg)
        {

            msg = string.Empty;


            switch (CommunicationMode)
            {
                default:
                case ("串口"):
                    if (!ConnectStatic)
                    {
                        msg = MessageInfo;
                        return false;
                    }
                    try
                    {
                        CurrentSerialPort.WriteLine(Data);
                        msg = "打印成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg = "打印失败：" + ex.Message;
                        return false;
                    }
                case ("TCP/IP"):
                    try
                    {
                        CurrentSocket = CurrentTcpClient.Client;
                        CurrentBuffer = Encoding.Default.GetBytes(Data + "\x0D\x0A");
                        SocketHelper.Send(CurrentSocket, CurrentBuffer, 0, CurrentBuffer.Length, 10000);
                        ConnectCount = 0;//socket通讯正常连接次数清零
                        msg = "打印成功";
                    }
                    catch (Exception ex) //socket连接超时
                    {
                        ConnectCount++;
                        if (ConnectCount > ConnectCountThreshold)
                        {
                            msg = "第" + ConnectCount + "次连接超时";
                            ConnectCount = 0;
                            return false;
                        }
                        InitAll(CommunicationMode, SerialPort, BaudRate, Ip, Port);
                        return SendDataToPrint(Data, out msg);
                    }
                    return true;
            }
        }

        public bool SendDataToPrint(Byte[] bytes, out string msg)
        {

            msg = string.Empty;


            switch (CommunicationMode)
            {
                default:
                case ("串口"):
                    if (!ConnectStatic)
                    {
                        msg = MessageInfo;
                        return false;
                    }
                    try
                    {
                        CurrentSerialPort.Write(bytes, 0, bytes.Length);
                        msg = "打印成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg = "打印失败：" + ex.Message;
                        return false;
                    }
                case ("TCP/IP"):
                    try
                    {
                        CurrentSocket = CurrentTcpClient.Client;
                        // CurrentSerialPort.Write(bytes, 0, bytes.Count());

                        //   CurrentBuffer = Encoding.Default.GetBytes(Data + "\x0D\x0A");
                        SocketHelper.Send(CurrentSocket, bytes, 0, bytes.Length, 10000);
                        ConnectCount = 0;//socket通讯正常连接次数清零
                        msg = "打印成功";
                    }
                    catch (Exception ex) //socket连接超时
                    {
                        ConnectCount++;
                        if (ConnectCount > ConnectCountThreshold)
                        {
                            msg = "第" + ConnectCount + "次连接超时";
                            ConnectCount = 0;
                            return false;
                        }
                        InitAll(CommunicationMode, SerialPort, BaudRate, Ip, Port);
                        return SendDataToPrint(bytes, out msg);
                    }
                    return true;
            }
        }

        private TcpClient ShortConnectionCurrentTcpClient = null;
        private Socket ShortConnectionCurrentSocket = null;
        private byte[] ShortConnectionCurrentBuffer = new byte[0];
        /// <summary>
        /// 短连接
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool ShortConnectionSendDataToPrint(string Data, out string msg)
        {

            msg = string.Empty;
            switch (CommunicationMode)
            {
                default:
                case ("串口"):

                    if (!ConnectStatic)
                    {
                        msg = MessageInfo;
                        return false;
                    }
                    try
                    {
                        CurrentSerialPort.WriteLine(Data);
                        msg = "打印成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg = "打印失败：" + ex.Message;
                        return false;
                    }
                case ("TCP/IP"):
                    try
                    {
                        ShortConnectionCurrentTcpClient = new TcpClient();
                        ShortConnectionCurrentTcpClient.Connect(IPAddress.Parse(Ip), Port);

                        ShortConnectionCurrentSocket = ShortConnectionCurrentTcpClient.Client;

                        ShortConnectionCurrentBuffer = Encoding.Default.GetBytes(Data + "\x0D\x0A"); //加结束符(打印机要用Default)
                        SocketHelper.Send(ShortConnectionCurrentSocket, ShortConnectionCurrentBuffer, 0, ShortConnectionCurrentBuffer.Length, 10000);

                        msg = "打印成功";
                    }
                    catch (Exception ex) //socket连接超时
                    {
                        msg += "失败原因：" + ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (ShortConnectionCurrentTcpClient != null) ShortConnectionCurrentTcpClient.Close();
                        if (ShortConnectionCurrentSocket != null) ShortConnectionCurrentSocket.Close();
                    }
                    return true;
            }
        }

        public bool ShortConnectionSendDataToPrint(byte[] bytes, out string msg)
        {

            msg = string.Empty;
            switch (CommunicationMode)
            {
                default:
                case ("串口"):

                    if (!ConnectStatic)
                    {
                        msg = MessageInfo;
                        return false;
                    }
                    try
                    {
                        CurrentSerialPort.Write(bytes, 0, bytes.Length);
                        msg = "打印成功";
                        return true;
                    }
                    catch (Exception ex)
                    {
                        msg = "打印失败：" + ex.Message;
                        return false;
                    }
                case ("TCP/IP"):
                    try
                    {
                        ShortConnectionCurrentTcpClient = new TcpClient();
                        ShortConnectionCurrentTcpClient.Connect(IPAddress.Parse(Ip), Port);

                        ShortConnectionCurrentSocket = ShortConnectionCurrentTcpClient.Client;

                        //ShortConnectionCurrentBuffer = Encoding.Default.GetBytes(Data + "\x0D\x0A"); //加结束符(打印机要用Default)
                        SocketHelper.Send(ShortConnectionCurrentSocket, bytes, 0, bytes.Length, 10000);

                        msg = "打印成功";
                    }
                    catch (Exception ex) //socket连接超时
                    {
                        msg += "失败原因：" + ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (ShortConnectionCurrentTcpClient != null) ShortConnectionCurrentTcpClient.Close();
                        if (ShortConnectionCurrentSocket != null) ShortConnectionCurrentSocket.Close();
                    }
                    return true;
            }
        }
    }
}

