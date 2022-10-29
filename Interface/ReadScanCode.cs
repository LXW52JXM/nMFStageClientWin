using NTDCommLib;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class ReadScanCode
    {


        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        string MessageInfo = string.Empty;
        /// <summary>
        /// 委托事件
        /// </summary>
        public event EventHandler EventHandler;

        SerialPort CurrentSerialPort =null;   //串口

        public bool Init(string Port, int Baudrate)
        {
            
            try
                {

                Close();
                CurrentSerialPort = new SerialPort();
                CurrentSerialPort.NewLine = "\r";
                CurrentSerialPort.PortName = Port;
                CurrentSerialPort.BaudRate = Baudrate;
                CurrentSerialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);//串口数据接收事件，必须手动添加事件处理程序
                CurrentSerialPort.ReceivedBytesThreshold = 1;  //必须一定要加上这句话，意思是接收缓冲区当中如果有一个字节的话就出发接收函数，如果不加上这句话，那就有时候触发接收有时候都发了好多次了也没有触发接收，有时候延时现象等等，
           
                
                CurrentSerialPort.Open();
                return true;

            }
            catch (Exception ex)
            {
                MessageInfo = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取串口错误信息
        /// </summary>
        public string GetMessageInfo()
        {
            return MessageInfo;

        }
        private  void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //获取带有换行的一行数据
                string result = CurrentSerialPort.ReadLine().Replace("\r", "");
                this.EventHandler(this, new BaseEvent<string>(result));
                return;
                //解决多次触发问题
                /*     Thread.Sleep(1000);
                     //开辟接收缓冲区
                     byte[] ReDatas = new byte[10240];
                     ReDatas = new byte[10240];
                     string result1 = sp.ReadLine();*/
                //从串口读取数据




                //协议解析
                //   string result = Encoding.UTF8.GetString(ReDatas, 0, ReDatas.Length).Replace(System.Environment.NewLine, string.Empty).Replace("\0", "");
                //if (startTime == 0) { 
                //    startTime = DateTimeHelper.GetTimeStamp(); 
                //}
                //else {
                //    if (endTime == 0) {
                //        endTime = DateTimeHelper.GetTimeStamp();
                //        if (endTime - startTime >= 5)
                //        {
                //            startTime = endTime;
                //            endTime = 0;
                //        }
                //        else {
                //            endTime = 0;
                //            return;
                //        }
                //    }
                //}

                //OnPrintEventHandler(new SendDataEventArgs<string>(result));//触发事件
              

            }
            catch (Exception ex)
            {
            }
        }
        public void Close()
        {
            MessageInfo = string.Empty;
            if (CurrentSerialPort != null)
            {
                CurrentSerialPort.DataReceived -= new SerialDataReceivedEventHandler(sp_DataReceived);//串口数据接收事件，必须手动添加事件处理程序
                Thread.Sleep(50);
                CurrentSerialPort.Close();
            }
        }
    }
}
