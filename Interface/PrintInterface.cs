using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    /// <summary>
    /// 打印机的接口
    /// </summary>
    public interface PrintInterface
    {
        /// <summary>
        /// 初始化打印机(只有ZPI命令,包含串口和网络打印机)
        /// </summary>
        /// <param name="communicationMode"></param>
        /// <param name="serialPort"></param>
        /// <param name="baudRate"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        bool InitAll(string communicationMode, string serialPort, int baudRate, string ip, int port);


        /// <summary>
        /// 关闭数据读取
        /// </summary>
        void Close();

        /// <summary>
        /// 获取状态
        /// </summary>
        bool GetStatus();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        string GetMessageInfo();

        /// <summary>
        /// 直接发送文件内容到打印机
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool SendDataToPrint(string Data, out string msg);

        /// <summary>
        /// 短连接直接发送文件内容到打印机
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool ShortConnectionSendDataToPrint(string Data, out string msg);

    }
}
