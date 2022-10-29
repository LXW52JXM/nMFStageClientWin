using NTDCommLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class PrintHelper
    {
        /// <summary>
        /// 传文件路径或文件内容初始化串口进行输出
        /// </summary>
        /// <param name="file"></param>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="dicParams"></param>
        /// <param name="msg"></param>
        /// <param name="isUrl"></param>
        /// <returns></returns>
        public static bool SerialPortPrint(string file, string portName, int baudRate, Dictionary<string, object> dicParams, out string msg, bool isUrl)
        {
            string fileData = string.Empty;
            msg = string.Empty;
            if (isUrl)
            {
                // 判断文件是否存在
                if (!File.Exists(file))
                {
                    msg = "模板文件未找到.";
                    return false;
                }
                else
                { // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(file))
                    {
                        fileData = sr.ReadToEnd();
                    }
                }
            }
            else
            {
                // 判断文件内容是否为空
                if (string.IsNullOrEmpty(file))
                {
                    msg = "模板内容为空.";
                    return false;
                }
                else
                {
                    fileData = file;
                }

            }
            SerialPort sp = new SerialPort();
            try
            {
                foreach (var item in dicParams)
                {
                    fileData = fileData.Replace("[" + item.Key + "]", item.Value == null ? "" : item.Value.ToString());
                }
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                try
                {
                    sp.Open();
                    sp.Encoding = Encoding.Default;
                    sp.WriteLine(fileData);
                    msg = "打印成功";
                    return true;
                }
                catch (Exception ex)
                {
                    msg = "串口操作出错：" + ex.ToString();
                    return false;
                }
            }
            finally
            {

                if (sp.IsOpen) sp.Close();
            }
        }

        /// <summary>
        /// 传文件路径或文件内容初始化socket短连接发zpi命令
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="dicParams"></param>
        /// <param name="msg"></param>
        /// <param name="isUrl"></param>
        /// <returns></returns>
        public static bool SocketPrint(string file, string ip, int port, Dictionary<string, object> dicParams, out string msg, bool isUrl)
        {
            string fileData = string.Empty;
            msg = string.Empty;
            if (isUrl)
            {
                // 判断文件是否存在
                if (!File.Exists(file))
                {
                    msg = "模板文件未找到.";
                    return false;
                }
                else
                { // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(file))
                    {
                        fileData = sr.ReadToEnd();
                    }
                }
            }
            else
            {
                // 判断文件内容是否为空
                if (string.IsNullOrEmpty(file))
                {
                    msg = "模板内容为空.";
                    return false;
                }
                else
                {
                    fileData = file;
                }
            }
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse(ip), port);
                Socket socket = tcpClient.Client;
                foreach (var item in dicParams)
                {
                    fileData = fileData.Replace("[" + item.Key + "]", item.Value == null ? "" : item.Value.ToString());
                }
                //建立连接服务端的数据流  
                byte[] buffer = Encoding.Default.GetBytes(fileData);
                SocketHelper.Send(socket, buffer, 0, buffer.Length, 10000);
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            finally
            {

                if (tcpClient != null)
                    tcpClient.Close();
            }
        }


        public static bool FileToStringByDic(string file, Dictionary<string, object> dic, out string fileData, out string msg, bool isUrl)
        {
            fileData = string.Empty;
            msg = string.Empty;
            if (isUrl)
            {
                // 判断文件是否存在
                if (!File.Exists(file))
                {
                    msg = "模板文件未找到.";
                    return false;
                }
                else
                { // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader(file))
                    {
                        fileData = sr.ReadToEnd();
                    }
                }
            }
            else
            {
                // 判断文件内容是否为空
                if (string.IsNullOrEmpty(file))
                {
                    msg = "模板内容为空.";
                    return false;
                }
                else
                {
                    fileData = file;
                }
            }
            foreach (var item in dic)
            {
                fileData = fileData.Replace("[" + item.Key + "]", item.Value == null ? "" : item.Value.ToString());
            }


            return true;
        }
    }
}
