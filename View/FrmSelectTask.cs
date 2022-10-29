using FastReport;
using Newtonsoft.Json;
using NTDCommLib;
using NTDCommLib.UI;
using NTDCommon;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DBService;

namespace nMFStageClientWin
{
    public partial class FrmSelectTask :Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        //分页数据
        List<nmfs_task> PageData = new List<nmfs_task>();

        //控件集合
        List<ucShowTask> ucShowDataList = new List<ucShowTask>();

        //查询类
        nmfs_task TaskQueryEntity = new nmfs_task();
        nmfs_task_details TaskDetailsQueryEntity = new nmfs_task_details();
        nmfs_current_open_task CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
        nmfs_flow_records FlowRecordsQueryEntity = new nmfs_flow_records();
        //分页参数
        //分页参数
        int PageSize = 12;
        int CurrentPageIndex = 1;
        int TotalCount = 0;
        int TotalPageCount = 0;

        public FrmSelectTask()
        {
            InitializeComponent();
            SetControlList();
        }

        private void FrmSelectTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrTime.Enabled = false;
        }
        private void TmrTime_Tick(object sender, EventArgs e)
        {
                LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                switch (AppSet.CurrentServiceConnectStatus)
                {
                    case (true):
                        PicWifi0.Visible = false;
                        PicWifi.Visible = true;
                        break;
                    case (false):
                        PicWifi.Visible = false;
                        PicWifi0.Visible = true;
                        break;
                    default:
                        PicWifi.Visible = false;
                        PicWifi0.Visible = false;
                        break;
                }
        }
        private void SetControlList()
        {
            
            ucShowDataList.Add(ucShowTask_0);
            ucShowDataList.Add(ucShowTask_1);
            ucShowDataList.Add(ucShowTask_2);
            ucShowDataList.Add(ucShowTask_3);
            ucShowDataList.Add(ucShowTask_4);
            ucShowDataList.Add(ucShowTask_5);
            ucShowDataList.Add(ucShowTask_6);
            ucShowDataList.Add(ucShowTask_7);
            ucShowDataList.Add(ucShowTask_8);
            ucShowDataList.Add(ucShowTask_9);
            ucShowDataList.Add(ucShowTask_10);
            ucShowDataList.Add(ucShowTask_11);
        }



        private void FrmSelectTask_Load(object sender, EventArgs e)
        { 
            try
            {
               // FormHelper.FormCenter(PnlLoading);
                TmrTime.Enabled = true;
                //查询所有任务已经取消的并删除掉
                TaskQueryEntity = new nmfs_task();
                TaskQueryEntity.status_batching = 7;
                var taskList = NmfsTaskService.GetDataByEntity(TaskQueryEntity);
                foreach (var item in taskList)
                {
                    DelTaskRelationInfoFunc(item);
                }

                PageQuery(NTDPageEnum.None);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        #region 按键事件
        /// <summary>
        /// 监听按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case (Keys.F1):
                        if (!BtnClose.Enabled) return;
                        BtnClose_Click(BtnClose, e);
                        break;
                    case (Keys.F2):

                        break;
                    case (Keys.F3):
                      
                        break;
                    case (Keys.F4):
                        if (!BtnRefresh.Enabled) return;
                        BtnRefresh_Click(BtnRefresh, e);
                        break;
                    case (Keys.F5):
                      
                        break;
                    case (Keys.F6):
                        if (!BtnPrevPage.Enabled) return;
                        BtnPrevPage_Click(BtnPrevPage, e);
                        break;
                    case (Keys.F7):

                        break;
                    case (Keys.F8):
                        if (!BtnNextPage.Enabled) return;
                        BtnNextPage_Click(BtnNextPage, e);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsRefreshTaskStatus()) return;

                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        /// <summary>
        /// 刷新任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                ThreadPool.QueueUserWorkItem(o => RefreshTask());
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }


        /// <summary>
        /// 前一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                PageQuery(NTDPageEnum.Previous);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }

        /// <summary>
        /// 下一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                PageQuery(NTDPageEnum.Next);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }
        #endregion

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Page"></param>
        private void PageQuery(NTDPageEnum pot)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { PageQuery(pot); })); return;
            }
            
                switch (pot)
                {

                    case NTDPageEnum.None:
                        {
                            CurrentPageIndex = 1;
                            //NTDMsg.TouchFlatMsgInfo("当前已是第一页!");
                            // PicPrevPage.Enabled = false;
                            BtnNextPage.Enabled = true;
                            break;
                        }
                    case NTDPageEnum.Previous:
                        {
                            if (CurrentPageIndex > 1)
                            {
                                CurrentPageIndex--;
                                BtnNextPage.Enabled = true;
                                break;
                            }
                            else
                            {
                                //PicPrevPage.Enabled = false;
                                NTDMsg.TouchFlatMsgInfo("当前已是第一页!");
                                return;
                            }
                        }
                    case NTDPageEnum.Next:
                        {
                            if (CurrentPageIndex<TotalPageCount)
                            {
                                CurrentPageIndex++;
                                BtnPrevPage.Enabled = true;
                                break;
                            }
                            else
                            {
                                // PicNextPage.Enabled = false;
                                NTDMsg.TouchFlatMsgInfo("当前已是最后一页!");
                                return;
                            }
                        }
                }
                PageData = NmfsTaskService.GetPageDataByDic(CurrentPageIndex, PageSize,ref TotalPageCount,new Dictionary<string, object>());
            if (TotalCount % PageSize == 0)
            {
                TotalPageCount = TotalCount / PageSize;
            }
            else
            {
                TotalPageCount = TotalCount / PageSize + 1;
            }
            //数据分页
            //PageData = NmfsTaskService.GetPageDataByDic(CurrentPageIndex, PageSize,ref TotalPageCount,new Dictionary<string, object>());
            LblPageInfo.Text = $"{CurrentPageIndex} / {TotalPageCount}";

            if (PageData != null)
                {
                    ShowPageList(PageData);

                }
                else
                {
                    ClearPageList();
                }
        }

        private void ClearPageList()
        {
            for (int i = 0; i < ucShowDataList.Count; i++)
            {
                ucShowDataList[i].Tag = "";
                ucShowDataList[i].Visible = false;
            }
        }

        private void ShowPageList(List<nmfs_task> pageData)
        {
            ClearPageList();

            int i = 0;

            foreach (var item in pageData)
            {
                // 更新块状显示数据
                ucShowDataList[i].Tag = item;
                ucShowDataList[i].Visible = true;
                ucShowDataList[i].Control_0 = "流水号：" + item.serial_number;
                ucShowDataList[i].Control_1 = "任务名称：" + item.name;
                ucShowDataList[i].Control_2 = "配料名称：" + item.formula_name + "  V" + item.formula_version_name;
                ucShowDataList[i].Control_3 = "配料方式：" + item.batching_way;

                switch (item.status_batching)
                {
                    default:
                    case (0):
                        ucShowDataList[i].Control_4 = "任务状态：新建";
                        break;
                    case (1):
                        ucShowDataList[i].Control_4 = "任务状态：已下载";
                        break;
                    case (2):
                        ucShowDataList[i].Control_4 = "任务状态：进行中";
                        break;
                    case (3):
                    case (4):
                        ucShowDataList[i].Control_4 = "任务状态：已挂起";
                        break;
                    case (6):
                    case (7):
                        ucShowDataList[i].Control_4 = "任务状态：已取消";
                        break;
                    case (8):
                        ucShowDataList[i].Control_4 = "任务状态：已完成";
                        break;
                }
                switch (item.task_level)
                {
                    default:
                    case (0):
                        ucShowDataList[i].Control_4 = ucShowDataList[i].Control_4 + "(普通任务)";
                        ucShowDataList[i].SetDefaultControlBackColor();
                        break;
                    case (1):
                        ucShowDataList[i].Control_4 = ucShowDataList[i].Control_4 + "(紧急任务)";
                        ucShowDataList[i].SetControlBackColor(Color.Red, "");
                        break;

                }

                ShowUcShowDataListControl_5(ucShowDataList[i], item);


                i++;
            }
        }




        //计算当前任务完成份数
        List<nmfs_current_open_task> CurrentOpenTaskList = new List<nmfs_current_open_task>();
        decimal TaskAllCount = 0;
        decimal TaskCompletedCount = 0;
        /// <summary>
        /// 刷新完成任务份数
        /// </summary>
        /// <param name="ucShowData_NTD_Size10_6"></param>
        /// <param name="item"></param>
        private void ShowUcShowDataListControl_5(ucShowTask ucShowData, nmfs_task task)
        {
            TaskAllCount = 0;
            TaskCompletedCount = 0;
            if (ucShowData == null || task == null) return;
            //去操作的临时记录表查询当前已完成第几份
            CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
            CurrentOpenTaskQueryEntity.task_serial_number = task.serial_number;
            CurrentOpenTaskList = NmfsCurrentOpenTaskService.GetDataByEntity(CurrentOpenTaskQueryEntity);


            //if (CurrentOpenTaskList != null && CurrentOpenTaskList.Count > 0)
            //{
            //    TaskAllCount = IntHelper.Conversion(CurrentOpenTaskList.OrderBy(o => o.task_current_count).First().task_current_count);

            //}
            //else
            //{
            //    TaskAllCount = 0;
            //}


            foreach (var item in CurrentOpenTaskList)
            {
                TaskAllCount += DecimalHelper.Conversion(item.task_all_count);
                TaskCompletedCount += DecimalHelper.Conversion(item.task_current_count);
            }

            if (TaskAllCount != 0)
            {
                ucShowData.Control_5 = "任务完成进度：" + (Math.Ceiling(TaskCompletedCount/ TaskAllCount * 10000)/100).ToString("0.##") + "%";
            } else
            {
                ucShowData.Control_5 = "任务完成进度：0.00%";
            }
        }




        /// <summary>
        /// 选择任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucShowTask_0_Click(object sender, EventArgs e)
        {
            try
            {
                TmrTime.Enabled = false;
                ucShowTask uc = (ucShowTask)sender;
                if (IsRefreshTaskStatus()) return;

                var b = (ucShowTask)sender;
                if (b.Tag == null) return;
                //获取选中的任务数据
                AppSet.CurrentTask = (nmfs_task)b.Tag;

                //重新查数据库的数据（因为有挂起和取消的任务状态过来）

                nmfs_task task = new nmfs_task();
                task.id = AppSet.CurrentTask.id;
                if (NmfsTaskService.IsExistSingleDataByEntity(task, out task))
                {
                    AppSet.CurrentTask = task;
                }

                switch (AppSet.CurrentTask.status_batching)
                {
                    case (4):
                        NTDMsg.TouchFlatMsgError("当前任务已挂起");
                        return;
                    case (7):
                        NTDMsg.TouchFlatMsgError("当前任务已取消");
                        //删除任务和任务详情
                        DelTaskRelationInfoFunc(AppSet.CurrentTask);
                        FrmSelectTask_Load(sender, e);
                        return;
                    default:
                        break;
                }

                //获取任务详情是否存在
                TaskDetailsQueryEntity = new nmfs_task_details();
                TaskDetailsQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;

                var  taskDetailsList = NmfsTaskDetailsService.GetDataByEntity(TaskDetailsQueryEntity);

                if (taskDetailsList.Count <= 0)
                {
                    NTDMsg.TouchFlatMsgError("任务详情无数据");
                    return;
                }

                //判断任务是否已进行
                if (AppSet.CurrentTask.status_batching == 1)
                {
                    uc.Control_4 = "任务状态：进行中";
                    switch (AppSet.CurrentTask.task_level)
                    {
                        default:
                        case (0):
                            uc.Control_4 = uc.Control_4 + "(普通任务)";
                            break;
                        case (1):
                            uc.Control_4 = uc.Control_4 + "(紧急任务)";
                            break;

                    }

                    //上传任务状态
                    AppSet.CurrentTask.status_batching = 2;
                    NmfsTaskService.Update(AppSet.CurrentTask);

                    var taskTempDic = new Dictionary<string, string>();
                    taskTempDic.Add("serial_number", AppSet.CurrentTask.serial_number);
                    taskTempDic.Add("status_batching", AppSet.CurrentTask.status_batching.ToString());
                    taskTempDic.Add("terminal_id", SystemSet.CurrentTerminalId);

                    var sys_upload_data = new sys_upload_data();
                    sys_upload_data.cmd = "UploadTaskStatus";
                    sys_upload_data.upload_data = JsonConvert.SerializeObject(taskTempDic, Formatting.Indented, AppSet.JsonSetting);
                    SysUploadDataService.Save(sys_upload_data);
                    AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);
                }

                CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
                CurrentOpenTaskQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;
                //根据任务流水判断是否有临时表数据存在
                if (NmfsCurrentOpenTaskService.GetDataByEntity(CurrentOpenTaskQueryEntity).Count <= 0)
                {
                    //添加临时数据
                    var  currentOpenTask = new nmfs_current_open_task();//临时表
                    //遍历配方详情保存到临时表里面
                    foreach (var item in taskDetailsList)
                    {
                        currentOpenTask = new nmfs_current_open_task();
                        currentOpenTask.task_serial_number = AppSet.CurrentTask.serial_number;
                        currentOpenTask.task_all_count = AppSet.CurrentTask.num;
                        currentOpenTask.task_current_count = 0;
                        currentOpenTask.task_details_id = item.id;
                        currentOpenTask.task_details_sort = item.sort;
                        currentOpenTask.standard_weight = item.standard_weight;
                        currentOpenTask.weight_unit = item.weight_unit;
                        currentOpenTask.parts_id = item.parts_id;
                        currentOpenTask.parts_name = item.parts_name;

                        NmfsCurrentOpenTaskService.Save(currentOpenTask);
                    }
                }


                DialogResult rst = DialogResult.None;
                //判断是固定顺序还是选择
                if (AppSet.CurrentTask.is_fixed_batching == "1")
                {
                    var frm = new FrmWeight();
                    rst = frm.ShowDialog();
                }
                else
                {
                    var frm = new FrmSelectParts();
                    rst = frm.ShowDialog();
                }

                if (rst == DialogResult.OK)
                {
                    //判断任务是否被取消
                    if (AppSet.CurrentTask.status_batching != 7)
                    {
                        //当前任务完成
                        CurrentTaskCompletedFunc(AppSet.CurrentTask);
                        FrmSelectTask_Load(sender, e);
                        return;
                    }
                }
                //判断任务是否取消
                if (AppSet.CurrentTask.status_batching == 7)
                {
                    //删除任务和任务详情
                    DelTaskRelationInfoFunc(AppSet.CurrentTask);
                    FrmSelectTask_Load(sender, e);
                    return;
                }
                ShowUcShowDataListControl_5(b, AppSet.CurrentTask);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchMsgError(ex.Message);
            }
            finally
            {
                TmrTime.Enabled = true;
            }
        }

        //当前任务完成
        private void CurrentTaskCompletedFunc(nmfs_task currentTask)
        {
            //上传任务完成状态
            currentTask.status_batching = 8;
           

            var taskTempDic = new Dictionary<string, string>();
            taskTempDic.Add("serial_number", currentTask.serial_number);
            taskTempDic.Add("status_batching", currentTask.status_batching.ToString());
            taskTempDic.Add("terminal_id", SystemSet.CurrentTerminalId);

            var sys_upload_data = new sys_upload_data();
            sys_upload_data.cmd = "UploadTaskStatus";
            sys_upload_data.upload_data = JsonConvert.SerializeObject(taskTempDic, Formatting.Indented, AppSet.JsonSetting);
            SysUploadDataService.Save(sys_upload_data);
            AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);

            DelTaskRelationInfoFunc(currentTask);

        }



        /// <summary>
        /// 根据任务删除任务任务详情和当前所做的任务
        /// </summary>
        /// <param name="currentTask"></param>
        private void DelTaskRelationInfoFunc(nmfs_task currentTask)
        {
            //删除任务
            NmfsTaskService.DeletePrimaryKey(currentTask.id);

            //删除任务详情
            TaskDetailsQueryEntity = new nmfs_task_details();
            TaskDetailsQueryEntity.task_serial_number = currentTask.serial_number; 
            NmfsTaskDetailsService.DeleteByEntity(TaskDetailsQueryEntity);

            //删除正在打开的任务详情
            CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
            CurrentOpenTaskQueryEntity.task_serial_number = currentTask.serial_number; 
            NmfsCurrentOpenTaskService.DeleteByEntity(CurrentOpenTaskQueryEntity);

            //删除当前任务的称重记录
            FlowRecordsQueryEntity = new nmfs_flow_records();
            FlowRecordsQueryEntity.task_serial_number = currentTask.serial_number;
            NmfsFlowRecordsService.DeleteByEntity(FlowRecordsQueryEntity);
        }

        #region 同步服务器的数据

        private bool RefreshTaskStatus = false;

        /// <summary>
        /// 判断是否正在刷新
        /// </summary>
        /// <returns></returns>
        private bool IsRefreshTaskStatus()
        {
            if (RefreshTaskStatus)
            {
                NTDMsg.TouchFlatMsgError("正在下载任务信息，不能点击！");
                return true;
            }
            else
            {
                return false;
            }

        }
        private void RefreshTask()
        {
            RefreshTaskStatus = true;
            try
            {
                
                ShowControlText(LblTips, "开始获取服务器任务信息", Color.White, 100);
                ShowControlVisible(PnlLoading, true);
                string msg = string.Empty;
                //刷新任务和任务详情
                if (!ServiceInterface.GetHttpTask(out msg))
                {
                    ShowControlText(LblTips, msg, Color.Red, 1000);
                }
                else
                {
                    ShowControlText(LblTips, msg, Color.White, 100);
                }

                PageQuery(NTDPageEnum.None);
                ShowControlVisible(PnlLoading, false);
           
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                RefreshTaskStatus = false;
            }
           
        }
        public void ShowControlText(Control control, string msg, Color textColor, int waitingTime)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => { ShowControlText(control, msg, textColor, waitingTime); })); Thread.Sleep(waitingTime < 0 ? 0 : waitingTime); return;
            }

            control.Text = msg;
            control.ForeColor = textColor;

        }
        public void ShowControlVisible(Control control, bool b)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ShowControlVisible(control,b); })); return;
            }

            control.Visible = b;
        }


        #endregion

      
    }
}
