using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NTDCommon;
using System.Threading;
using Model;
using DBService;
using NTDCommLib;

namespace NTDCommon
{
    public class HttpUploadServiceData 
    {
        //加载配置文件信息
        static AppSettings AppSet { get { return AppSettings.AppSet; } }
        static SystemSettings SystemSet { get { return AppSettings.AppSet.SystemSet; } }

        bool ThreadStatus = true;
        /// <summary>
        /// 上传日志的同步集合
        /// </summary>
        Queue<sys_upload_data> UploadsDataQueue = new Queue<sys_upload_data>();//同步集合

        /// <summary>
        /// 当前上传的线程
        /// </summary>
        Thread UpLoadDataThread = null;


        /// <summary>
        /// 消息队列保存的最大值
        /// </summary>
        int MaxUpDataCount = 500;

        /// <summary>
        /// 当前IP地址
        /// </summary>
        string IP = String.Empty;

        /// <summary>
        /// 当前端口
        /// </summary>
        int Port = 0;


        public HttpUploadServiceData()
        {

        }

        public bool Init(string ip, int port)
        {
            IP = ip;
            Port = port;

            Close();
            //初始化数据的线程
            UpLoadDataThread = new Thread(UpLoadDataThreadFunc);
            UpLoadDataThread.IsBackground = true;
            UpLoadDataThread.Start();


            //重新查询数据库的线程
            ReadDBDataThread = new Thread(ReadDBDataThreadFunc);
            ReadDBDataThread.IsBackground = true;
            ReadDBDataThread.Start();
            ThreadStatus = true;
            return true;
        }

        public void Close()
        {
            ThreadStatus = false;

            //if (UpLoadDataThread != null)
            //{
            //    UpLoadDataThread.Abort();
            //}

            //if (ReadDBDataThread != null)
            //{
            //    ReadDBDataThread.Abort();
            //}
        }

        public void AddUploadsDataQueue(sys_upload_data entity)
        {
            if (UploadsDataQueue.Count < MaxUpDataCount)
            {
                UploadsDataQueue.Enqueue(entity);
            }

        }

        #region 定义常用全局变量


        /// <summary>
        /// 查询数据库的线程
        /// </summary>
        Thread ReadDBDataThread = null;

        /// <summary>
        /// 线程睡眠的时间
        /// </summary>
        int ReadDBDataThreadSleepTime = 5000;

        /// <summary>
        /// 重新读数据库的时间(每半小时)
        /// </summary>
        int ReadDBDataThreadRunTime = 1800000;


        /// <summary>
        /// 消息队列为空时隔一段时间查询数据库上传数据
        /// </summary>
        void ReadDBDataThreadFunc()
        {
            int startTickCount = Environment.TickCount;
            int endTickCount = Environment.TickCount;
            while (ThreadStatus)
            {
                try
                {
                    endTickCount = Environment.TickCount;

                    //判断线程是否空执行1小时

                    if (endTickCount - startTickCount > ReadDBDataThreadRunTime)
                    {
                        startTickCount = Environment.TickCount;
                        //消息队列有数据，不需要读取数据库
                        if (UploadsDataQueue.Count > 0) continue;

                        startTickCount = Environment.TickCount;
                        //从数据库拿最大数据并保存到消息队列
                        foreach (var item in SysUploadDataService.GetDataByNumber(MaxUpDataCount))
                        {
                            UploadsDataQueue.Enqueue(item);
                        }
                    }

                }
                catch (Exception)
                {

                }
                finally
                {
                    Thread.Sleep(ReadDBDataThreadSleepTime);
                }
            }
        }
        #endregion

        /// <summary>
        /// 上传数据到服务器的线程
        /// </summary>
        void UpLoadDataThreadFunc()
        {
            try
            {

                //查询未上传的数据
                foreach (var item in SysUploadDataService.GetDataByNumber(MaxUpDataCount))
                {
                    UploadsDataQueue.Enqueue(item);
                }
                var entity = new sys_upload_data();
                string msg = string.Empty;
                string result = string.Empty;
                ResultMessage<string> res = new ResultMessage<string>();
                while (ThreadStatus)
                {
                    try
                    {
                        //

                        if (UploadsDataQueue.Count > 0)
                        {
                            entity = new sys_upload_data();
                            entity = UploadsDataQueue.Dequeue();
                            if (entity != null && !string.IsNullOrEmpty(entity.id))
                            {
                                try
                                {
                                    switch (entity.cmd)
                                    {
                                        case ("UploadTaskStatus"):
                                            if (AjaxHelper.Post(IP + ":" + Port + "/app/v1/mfs/task/saveTaskStatus", entity.upload_data, out result, null))
                                            {

                                                res = JsonConvert.DeserializeObject<ResultMessage<string>>(result);
                                            }
                                            break;
                                        case ("UploadsFlowRecords"):

                                            if (AjaxHelper.Post(IP + ":" + Port + "/app/v1/mfs/flowRecord/save", entity.upload_data, out result, null))
                                            {
                                                res = JsonConvert.DeserializeObject<ResultMessage<string>>(result);
                                            }
                                            break;
                                        case ("UploadsLog"):
                                            if (AjaxHelper.Post(IP + ":" + Port + "/app/v1/mfs/log/saveLog", entity.upload_data, out result, null))
                                            {
                                                res = JsonConvert.DeserializeObject<ResultMessage<string>>(result);
                                            }
                                            break;

                                        default:
                                            SysUploadDataService.DeletePrimaryKey(entity.id);
                                            continue;
                                    }
                                    if (res.code == 0)
                                    {
                                        SysUploadDataService.DeletePrimaryKey(entity.id);
                                    }
                                    else
                                    {
                                        UploadsDataQueue.Enqueue(entity);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    UploadsDataQueue.Enqueue(entity);
                                    LogFileHelper.AddLog("上次数据到服务器失败："+entity.cmd+"，"+ex.Message);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// 检查是否ping通
        /// </summary>
        /// <param name="_ip"></param>
        /// <param name="_port"></param>
        /// <returns></returns>
        bool Ping(string ip, int port)
        {
            bool status = false;
            try
            {   //将IP和端口替换成为你要检测的
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
                using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    sock.Connect(ipEndPoint);
                    //Console.WriteLine("连接{0}成功!", point);
                    sock.Close();

                    status = true;
                }
            }
            catch (SocketException sex)
            {
                //Console.WriteLine("连接{0}失败", point);
                status = false;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("连接{0}失败", point);
                status = false;
            }
            return status;
        }
    }
}
