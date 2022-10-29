
using DBService;
using Model;
using Newtonsoft.Json;
using nMFStageClientWin;
using NTDCommLib;
using NTDCommon; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTDCommon
{
    public class ServiceInterface
    {
       static AppSettings AppSet=>AppSettings.AppSet;
        static SystemSettings SystemSet =>  AppSet.SystemSet;
        private static string msg = string.Empty;
        private static string returnData = string.Empty;

        /// <summary>
        /// 获取终端
        /// </summary>
        /// <param name="tcpClientHelper"></param>
        /// <param name="CurrentDevice"></param>
        /// <returns></returns>
        public static bool GetHttpTerminal(out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
               // if (AjaxHelper.Get(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/terminal/select?code=" + SystemSet.DeviceCode, out result, null))
                 if (AjaxHelper.Get(SystemSet.UploadDataHttpIp+":"+ SystemSet.UploadDataHttpPort + "/app/v1/mfs/terminal/select?ip=" + SystemSet.LocalhostIp, out result, null))
                {
              
                    var res = JsonConvert.DeserializeObject<ResultMessage<nmfs_terminal>>(result);
                    if (res.code == 0)
                    {
                        NmfsTerminalService.DeleteAll();
                        NmfsTerminalService.Insert(res.data);

                        AppSet.CurrentTerminal = res.data;
                        NmfsTerminalDeviceService.DeleteAll();
                        NmfsTerminalDeviceService.InsertByList(res.data.terminal_device_List);

                        SystemSet.DeviceCode = res.data.code;
                        SystemSet.CurrentTerminalId = res.message;
                   
                        AppSet.SaveSystemSettingsConfig();
                        return true;
                    }
                    else
                    {
                        msg = res.message;

                        //未授权
                        AppSet.CurrentTerminal = new nmfs_terminal();
                    }
                }
                else
                {
                    msg = "访问服务器失败，请检查网络是否连接正常";
                    //用离线数据
                    var terminalData = NmfsTerminalService.GetData();
                    if (terminalData.Count > 0)
                    {
                        AppSet.CurrentTerminal = terminalData.First();
                    }
                    else
                    {
                        AppSet.CurrentTerminal = new nmfs_terminal();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }

        public static bool GetHttpParameters(out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                if (AjaxHelper.Get(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/parameters/select", out result,null))
                {
                   var  res = JsonConvert.DeserializeObject<ResultMessage<List<nmfs_parameters>>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        NmfsParametersService.DeleteAll();
                        NmfsParametersService.InsertByList(res.data);
                        return true;
                    }
                }
                else
                {
                    msg = result;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }

        public static bool GetHttpUser(out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                if (AjaxHelper.Get(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/user/select", out result,null))
                {

                   var  res = JsonConvert.DeserializeObject<ResultMessage<List<nmfs_user>>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        NmfsUserService.DeleteAll();
                        NmfsUserService.InsertByList(res.data); 
                        return true;
                    }
                }
                else
                {
                    msg = result;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }


        public static bool GetHttpContainer(out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                if (AjaxHelper.Get(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/container/select", out result,null))
                {
                    var  res = JsonConvert.DeserializeObject<ResultMessage<List<nmfs_container>>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        NmfsContainerService.DeleteAll();
                        NmfsContainerService.InsertByList(res.data); 
                        return true;
                    }
                }
                else
                {
                    msg = result;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="tcpClientHelper"></param>
        /// <returns></returns>
        public static bool GetHttpTask(out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                if (AjaxHelper.Get(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/task/select?terminalId=" + SystemSet.CurrentTerminalId, out result,null))
                {

                    var  res = JsonConvert.DeserializeObject<ResultMessage<List<nmfs_task>>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        //排除不是未下载的数据
                       var  taskList = res.data;//.Where(it => it.status_batching <= 2).ToList();
                       var  tasks = NmfsTaskService.GetData();
                        var task = new nmfs_task();
                        var entityDel = new nmfs_task_details();
                        var entityDel1 = new nmfs_current_open_task();

                        foreach (var item in tasks)
                        {
                            //for (int i = 0; i < taskList.Count; i++)
                            //{
                            //    //查询数据库是在下载任务里面是否存在
                            //    var e = taskList[i];
                            //    if (e.serial_number ==item.serial_number)
                            //    {
                            //        task = e;
                            //    }
                            //}
                            task = taskList.Find(delegate (nmfs_task e) { return e.serial_number == item.serial_number; });
                            if (task == null)
                            {
                                //删除任务表
                                NmfsTaskService.DeletePrimaryKey(item.id); 
                                var details = new nmfs_task_details();
                                details.task_serial_number = item.serial_number;
                                NmfsTaskDetailsService.DeleteByEntity(details);

                                //根据任务号删除临时数据表
                                var  opentask = new nmfs_current_open_task();
                                opentask.task_serial_number = item.serial_number;
                                NmfsCurrentOpenTaskService.DeleteByEntity(opentask);

                                //删除当前任务的称重记录
                                var  flowRecords = new nmfs_flow_records();
                                flowRecords.task_serial_number = item.serial_number;
                                NmfsFlowRecordsService.DeleteByEntity(flowRecords);
                     
                            }
                            else
                            {
                                //先更改数据库任务状态
                                switch (item.status_batching)
                                {
                                    case (0):
                                        item.status_batching = 0;
                                        break;
                                    case (1):
                                        item.status_batching = 1;
                                        break;
                                    case (5):
                                    case (2):
                                        item.status_batching = 2;
                                        break;
                                    case (3):
                                    case (4):
                                        item.status_batching = 4;
                                        break;
                                    default:
                                        break;
                                }

                                NmfsTaskService.Save(item);
                                //任务刷新和数据库同时存在不需要更改
                                taskList.Remove(task);
                            }
                        }
                        if (taskList.Count > 0)
                        {

                            foreach (var item in taskList)
                            {
                                if (item.status_batching == 0)
                                {
                                    item.status_batching = 1;
                                    NmfsTaskService.Save(item);

                                    var  taskTempDic = new Dictionary<string, string>();
                                    taskTempDic.Add("serial_number", item.serial_number);
                                    taskTempDic.Add("status_batching", item.status_batching.ToString());
                                    taskTempDic.Add("terminal_id", SystemSet.CurrentTerminalId);

                                    var sys_upload_data=new  sys_upload_data();
                                    sys_upload_data.cmd = "UploadTaskStatus";
                                    sys_upload_data.upload_data = JsonConvert.SerializeObject(taskTempDic, Formatting.Indented, AppSet.JsonSetting);
                                    SysUploadDataService.Save(sys_upload_data);
                                    AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);
                                }
                                else
                                {
                                    NmfsTaskService.Save(item);
                                } 
                                //按排序号升序保存
                                NmfsTaskDetailsService.InsertByList(item.task_details_List);
                            }
                        }
                        AppSet.CurrentServiceConnectStatus = true;
                        return true;
                    }
                }
                else
                {
                    msg = result;
                }
                return false;
            }
            catch (Exception ex)
            { 
                msg = "拉取http数据异常";
                return false;
            }
        }


        /// <summary>
        /// 上传操作日志
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool PostHttpUploadLog(string data, out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                if (AjaxHelper.Post(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/log/saveLog", data, out result,null))
                {
                    ResultMessage<string> res = JsonConvert.DeserializeObject<ResultMessage<string>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }
        /// <summary>
        /// 上传称重记录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool PostHttpUploadFlowRecord(string data, out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                if (AjaxHelper.Post(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/flowRecord/save", data, out result,null))
                {

                   var  res = JsonConvert.DeserializeObject<ResultMessage<List<nmfs_task>>>(result);
                    msg = res.message;
                    if (res.code == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }

        /// <summary>
        /// 上传任务状态记录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool PostHttpUploadTask(string data, out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
      
                return false;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }


        /// <summary>
        /// 上传任务(不管成功失败都要上传)
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool PostHttpUploadSuccessMessage(string data, out string msg)
        {
            msg = string.Empty;
            try
            {
                string result = string.Empty;
                //
                AjaxHelper.Post(SystemSet.UploadDataHttpIp + ":" + SystemSet.UploadDataHttpPort + "/app/v1/mfs/socketMessage/pushSocketMessageStatus", data, out result,null);
                return true;
            }
            catch (Exception ex)
            {
                msg = "拉取http数据异常";
                return false;
            }
        }


    }
}
