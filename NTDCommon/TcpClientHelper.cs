using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NTDCommLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class StCmdObj<T>
    {
        public string cmd { get; set; }
        public string ip { get; set; }
        public T data { get; set; }
    }

    public class TcpClientHelper
    {
        //当我们创建tcpclient对象的时候，就会跟server去建立连接
        public TcpClient CurrentTcpClient = null;

        private Socket CurrentSocket = null;

        private string Ip = string.Empty;

        private int Port = -1;

        //是否连接
        private bool ConnectStatic = false;

        //当前操作数据
        private byte[] CurrentBuffer = new byte[0];

        //socket连接服务器次数
        private int Reconnections = 0;
        //连接次数阀值
        private int ReconnectionsCount = 1;

        public bool Init(string ip, int port)
        {
            Ip = ip;
            Port = port;
            try
            {
                if (CurrentTcpClient != null) CurrentTcpClient.Close();
                CurrentTcpClient = new TcpClient();
                CurrentTcpClient.NoDelay = true;
                CurrentTcpClient.SendTimeout = 1000;
                CurrentTcpClient.ReceiveTimeout = 1000;
                CurrentTcpClient.Connect(IPAddress.Parse(Ip), Port);
                ConnectStatic = true;
                return true;
            }
            catch (Exception ex)
            {
                CurrentTcpClient.Close();
                ConnectStatic = false;
                return false;
            }
        }

        //获取socket是否连接的状态
        public bool GetConnectStatic()
        {
            return ConnectStatic;
        }


        //关闭socket连接（不关闭会一直占着）
        public void Close()
        {
            if (CurrentTcpClient != null) CurrentTcpClient.Close();

            if (CurrentSocket != null) CurrentSocket.Close();


        }
        /// <summary>
        /// 直接发string到socket(重新启用socket)
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool StartClient(string ip, int port, string Data, out string msg, out string returnData)
        {
            returnData = string.Empty;
            msg = string.Empty;
            try
            {
                if (!Init(ip, port))
                {
                    msg = "Socket初始化失败";
                    return false;
                }
                CurrentSocket = CurrentTcpClient.Client;
                if (CurrentSocket == null)
                {
                    throw new Exception("Socket为null");
                }
                //发送数据和结收数据处理
                try
                {
                    CurrentBuffer = Encoding.UTF8.GetBytes(Data + "\x0D\x0A"); //加结束符 // length of the text "Hello world!"//FIXME
                    SocketHelper.Send(CurrentSocket, CurrentBuffer, 0, CurrentBuffer.Length, 10000);
                    Reconnections = 0;//socket通讯正常连接次数清零


                    CurrentBuffer = SocketHelper.Receive(CurrentSocket, "<EOF>");
                    returnData = Encoding.UTF8.GetString(CurrentBuffer, 0, CurrentBuffer.Length).Replace("\0", "").Replace("<EOF>", "");//获取body 去掉头尾;
                    return true;
                }
                catch (Exception ex) //接收返回信息超时
                {
                    msg = "接收Socket返回数据超时";
                    return false;
                    /* ... */
                }
            }
            catch//socket连接超时
            {
                msg = "socket连接超时";
                return false;
            }
        }

        /// <summary>
        /// 直接发string到socket
        /// </summary>
        /// <typeparam name="?"></typeparam>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool StartClient(string Data, out string msg, out string returnData)
        {
            returnData = string.Empty;
            msg = string.Empty;
            try
            {
                CurrentSocket = CurrentTcpClient.Client;
                if (CurrentSocket == null)
                {
                    throw new Exception("Socket为null");
                }
                //发送数据和结收数据处理
                try
                {
                    CurrentBuffer = Encoding.UTF8.GetBytes(Data + "\x0D\x0A"); //加结束符 // length of the text "Hello world!"//FIXME
                    SocketHelper.Send(CurrentSocket, CurrentBuffer, 0, CurrentBuffer.Length, 10000);
                    Reconnections = 0;//socket通讯正常连接次数清零

                    CurrentBuffer = SocketHelper.Receive(CurrentSocket, "<EOF>");
                    returnData = Encoding.UTF8.GetString(CurrentBuffer, 0, CurrentBuffer.Length).Replace("\0", "").Replace("<EOF>", "");//获取body 去掉头尾;
                    return true;
                }
                catch (Exception ex) //接收返回信息超时
                {
                    throw new Exception("连接socket超时");
                    /* ... */
                }
            }
            catch (Exception ex) //socket连接超时
            {

                Reconnections++;
                if (Reconnections > ReconnectionsCount)
                {
                    msg = "第" + Reconnections + "次连接socket超时";
                    Reconnections = 0;
                    return false;
                }
                Init(Ip, Port);
                return StartClient(Data, out msg, out returnData);
            }
        }
    }
}
