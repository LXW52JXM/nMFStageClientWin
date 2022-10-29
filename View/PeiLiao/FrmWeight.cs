using DBService;
using Model;
using Newtonsoft.Json;
using NTDCommLib;
using NTDCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmWeight : Form
    {
        static AppSettings AppSet => AppSettings.AppSet;
        static SystemSettings SystemSet => AppSet.SystemSet;

        //是否读取秤台的重量（手工称重。点袋全部重量时不用读取秤台重量）
        bool IsReadScaleWeight = true;

        WeightProgressBar wpb = new WeightProgressBar();//进度条

        Dictionary<string, string> QueryDic = new Dictionary<string, string>();

        nmfs_current_open_task CurrentOpenTask = new nmfs_current_open_task();//当前临时表选中的数据
        nmfs_current_open_task NetCurrentOpenTask = new nmfs_current_open_task();//当前临时表选中的数据的下一条数据

        nmfs_container CurrentContainer = new nmfs_container();//当前容器

        nmfs_task_details CurrentTaskDetails = new nmfs_task_details();//当前任务详情 

        nmfs_flow_records CurrentFlowRecord = new nmfs_flow_records();//当前称重的记录信息

        List<string> CurrentPartsBatchNumber = new List<string>();//当前物料所扫描的批号

        nmfs_flow_records CurrentPrintFlowRecords = new nmfs_flow_records();//补打标签的数据

        //查询
        nmfs_flow_records FlowRecordsQueryEntity = new nmfs_flow_records();
        nmfs_current_open_task CurrentOpenTaskQueryEntity = new nmfs_current_open_task();


        //当前物料合适的秤
        List<nmfs_terminal_device> CurrentScaleList = new List<nmfs_terminal_device>();

        //固定配方顺序
        public FrmWeight() : this(NmfsCurrentOpenTaskService.GetFirstNotCompleteEntityByTask(AppSet.CurrentTask, AppSet.CurrentTask.batching_way))
        {

        }
        //非固定配方顺序
        public FrmWeight(nmfs_current_open_task entity)
        {
            InitializeComponent();
            DgvData.AutoGenerateColumns = false;
            CurrentOpenTask = entity;
            TmrWeight.Enabled = true;
        }

        private void FrmWeight_Load(object sender, EventArgs e)
        {
            try
            {
                FormHelper.FormTableLayoutPanelFlickeringProblem(TlpNetInfo);
                FormHelper.FormTableLayoutPanelFlickeringProblem(TlpGrossInfo);
                FormHelper.FormTableLayoutPanelFlickeringProblem(TlpTareInfo);
                if (CurrentOpenTask == null || string.IsNullOrEmpty(CurrentOpenTask.id))
                {
                    NTDMsg.TouchFlatMsgInfo("选择物料为空");
                    this.Close();
                    return;
                }
                //LblUser.Text = $"操作员：{AppSet.CurrentLoginUser.name}";
                //当前任务
                LblTaskListsName.Text = "任务名称：" + AppSet.CurrentTask.name;
                LblTaskListsNo.Text = "任务号：" + AppSet.CurrentTask.serial_number;
                //配方
                LblPeiFangName.Text = "配方名称：" + AppSet.CurrentTask.formula_name;//配方名称：
                LblPeiLiaoType.Text = "配料方式：" + AppSet.CurrentTask.batching_way;
                //刷新任务完成的称重记录和进度条
                ShowFlowRecordsInfo();
                //初始化进度条
                wpb.Init(PicProgressBar.Width, PicProgressBar.Height);
                PicProgressBar.Image = wpb.PreviewImage;
                ShowAllCurrentDataByCurrentOpenPeiFangs();
                ShowWeightProgressBar();
                //数据信息
                ShowFrmData(false);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void ShowFlowRecordsInfo()
        {
            FlowRecordsQueryEntity = new nmfs_flow_records();
            FlowRecordsQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;
            List<nmfs_flow_records> flowRecordsList = NmfsFlowRecordsService.GetDataByEntity(FlowRecordsQueryEntity);
            if (DgvData.DataSource != null)
            {
                this.BindingContext[DgvData.DataSource].SuspendBinding();
            }
            DgvData.DataSource = new List<object>();
            DgvData.DataSource = flowRecordsList;
            this.BindingContext[DgvData.DataSource].ResumeBinding();
            //PrgTask.Visible = true;// 显示进度条控件.
            CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
            CurrentOpenTaskQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;
            List<nmfs_current_open_task> currentOpenTask = NmfsCurrentOpenTaskService.GetDataByEntity(CurrentOpenTaskQueryEntity);

            int maximum = 0;
            int value = 0;
            foreach (var data in currentOpenTask)
            {
                maximum += IntHelper.ObjectConversionInt(data.task_all_count);
                value += IntHelper.ObjectConversionInt(data.task_current_count);
            }
            PrgTask.Minimum = 0;// 设置进度条最小值.
            PrgTask.Maximum = maximum;// 设置进度条最大值.
            PrgTask.Value = value;      // 设置进度条当前值
            PrgTask.Step = 1;// 设置每次增加的步长
        }
        //根据当前临时表数据显示当前物料和任务详情数据
        //private void ShowAllCurrentDataByCurrentOpenPeiFangs()
        //{
        //    //防止单个物料造成切换下一物料问题（根据当前任务的物料重新去数据库获取）
        //    nmfs_current_open_task currentOpenTask = new nmfs_current_open_task();
        //    currentOpenTask.id = CurrentOpenTask.id;
        //    CurrentOpenTaskService.IsExistByEntity(currentOpenTask, out CurrentOpenTask);


        //    CurrentTaskDetails = new nmfs_task_details();
        //    CurrentTaskDetails.id = IntHelper.Conversion(CurrentOpenTask.task_details_id);
        //    TaskDetailsService.IsExistByEntity(CurrentTaskDetails, out CurrentTaskDetails);

        //    CurrentParts = new tb_parts();
        //    CurrentParts.id = IntHelper.Conversion(CurrentOpenTask.parts_id);
        //    PartsService.IsExistByEntity(CurrentParts, out CurrentParts);
        //}
        private void FrmWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrInit.Enabled = TmrWeight.Enabled = false;
        }


        //根据当前临时表数据显示当前物料和任务详情数据
        private void ShowAllCurrentDataByCurrentOpenPeiFangs()
        {
            try
            {
                //防止单个物料造成切换下一物料问题（根据当前任务的物料重新去数据库获取）
                CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
                CurrentOpenTaskQueryEntity.id = CurrentOpenTask.id;
                NmfsCurrentOpenTaskService.IsExistSingleDataByEntity(CurrentOpenTaskQueryEntity, out CurrentOpenTask);

                //CurrentTaskDetails = new nmfs_task_details();
                //CurrentTaskDetails.task_serial_number = CurrentOpenTask.task_serial_number;
                //CurrentTaskDetails.parts_id = CurrentOpenTask.parts_id;
                //NmfsTaskDetailsService.IsExistSingleDataByEntity(CurrentTaskDetails, out CurrentTaskDetails);

                //根据主键查询任务详情
                CurrentTaskDetails = NmfsTaskDetailsService.GetOneDataByPrimaryKey(CurrentOpenTask.task_details_id);
                if (CurrentTaskDetails == null)
                {
                    CurrentTaskDetails = new nmfs_task_details();
                    NTDMsg.TouchFlatMsgError("查询任务详情失败");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        //刷新称重达标进度条
        private void ShowWeightProgressBar()
        {
            wpb.LowerWeight = DoubleHelper.ObjectConversionDouble(CurrentTaskDetails.lower_limit);
            wpb.TargetWeight = DoubleHelper.ObjectConversionDouble(CurrentTaskDetails.standard_weight);
            wpb.UpperWeight = DoubleHelper.ObjectConversionDouble(CurrentTaskDetails.upper_limit);
            wpb.ControlLocation(LblLowerWeight, LblTargetWeight, LblUpperWeight);
            wpb.IsEnable = true;
        }
        private void ShowFrmData(bool IsCompleteWeighing = false)
        {
            //刷新物料信息
           // BtnBatchNumber.Text = CurrentTaskDetails.parts_barcode;//换批数据重置
            BtnGoodsNo.Text = CurrentTaskDetails.parts_id;//"物料编号：" +
            BtnGoodsName.Text = CurrentTaskDetails.parts_name; //"物料名称：" +
            BtnNotes.Text = CurrentTaskDetails.parts_remark;//"物料描述：" +
            switch (CurrentTaskDetails.parts_type)
            {
                case ("放射性"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.放射性;
                    break;
                case ("生物危害"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.生物危害;
                    break;
                case ("易燃易爆"):
                case ("易爆炸"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.易爆炸;
                    break;
                case ("易腐蚀"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.易腐蚀;
                    break;
                case ("易燃烧"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.易燃烧;
                    break;
                case ("易氧化"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.易氧化;
                    break;
                case ("有毒"):
                    PicBlast.BackgroundImage = nMFStageClientWin.Properties.Resources.有毒;
                    break;
                default:
                    break;
            }
            if (IsCompleteWeighing)
            {
                //根据数据库判断当前任务是否完成
                if (NmfsCurrentOpenTaskService.IsCompleteTaskByTask(AppSet.CurrentTask))
                {

                    var frm = new FrmTaskOver();
                    frm.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    return;
                }
                switch (AppSet.CurrentTask.batching_way)
                {
                    case ("ABC-ABC-ABC"):
                        //判断是否完成一轮但是任务没完成
                        if (NmfsCurrentOpenTaskService.IsCompleteRoundTasks(CurrentOpenTask))
                        {
                            var frm = new FrmTaskOver();
                            frm.ShowDialog();
                        }
                        break;
                }
                //当前选中的任务配方物料临时数据
                CurrentOpenTask = NetCurrentOpenTask;
                ShowAllCurrentDataByCurrentOpenPeiFangs();
                ShowWeightProgressBar();
                ShowFrmData(false);
                return;
            }
            //刷新任务
            switch (AppSet.CurrentTask.batching_way)
            {
                case ("AAA-BBB-CCC"):
                    LblTaskSpeedProgress.Text = CurrentOpenTask.parts_name + "完成进度：" + CurrentOpenTask.task_current_count + "/" + CurrentOpenTask.task_all_count;
                    break;
                case ("ABC-ABC-ABC"):
                    LblTaskSpeedProgress.Text = AppSet.CurrentTask.formula_name + "完成进度:" + CurrentOpenTask.task_current_count + "/" + CurrentOpenTask.task_all_count + "," + CurrentOpenTask.parts_name + "完成进度:" + CurrentOpenTask.task_current_count + "/" + CurrentOpenTask.task_all_count;
                    break;
            }
            NetCurrentOpenTask = NmfsCurrentOpenTaskService.GetNetEntityByEntity(CurrentOpenTask, AppSet.CurrentTask.batching_way);
            if (NetCurrentOpenTask != null && !string.IsNullOrEmpty(NetCurrentOpenTask.id))
            {
                BtnNextGoodsNo.Text = NetCurrentOpenTask.parts_name;
            }
            else
            {
                BtnNextGoodsNo.Text = "暂无下个物料";
            }
            //开启物料的点袋去皮符合条码
            if (!IsCompleteWeighing)
            {
                TmrInit.Enabled = true;
            }
        }
        private void TmrInit_Tick(object sender, EventArgs e)
        {
            TmrInit.Enabled = false;
            try
            {
                string msg = string.Empty;
                IsReadScaleWeight = true;

                //判断当前任务是否挂起和取消
                switch (AppSet.CurrentTask.status_batching)
                {
                    case (4):
                        NTDMsg.TouchFlatMsgError("当前任务已挂起");
                        this.Close();
                        return;
                    case (7):
                        NTDMsg.TouchFlatMsgError("当前任务已取消");
                        //删除任务和任务详情
                        this.Close();
                        return;
                }

                //根据物料信息选择称台(可以不满足满量程)
                if (!NTDFunc.SwitchBalanceInterface(AppSet.CurrentScaleList, DecimalHelper.Conversion(CurrentTaskDetails.upper_limit), DecimalHelper.Conversion(CurrentTaskDetails.lower_limit), DecimalHelper.Conversion(CurrentTaskDetails.standard_weight), CurrentTaskDetails.weight_unit, ref CurrentScaleList, out msg, true))
                {
                    NTDMsg.TouchFlatMsgInfo(msg);
                    this.Close();
                    this.Dispose();
                    return;
                }
                NTDFunc.ChangScaleDetails(true, CurrentScaleList);

                //根据物料信息选择称台(可以不满足满量程)
                //if (!NTDFunc.SwitchBalanceInterface(AppSet.CurrentScaleList, DecimalHelper.Conversion(CurrentTaskDetails.upper_limit), DecimalHelper.Conversion(CurrentTaskDetails.lower_limit), DecimalHelper.Conversion(CurrentTaskDetails.standard_weight), CurrentTaskDetails.weight_unit, ref AppSet.CurrentScale, out msg, true))
                //{
                //    NTDMsg.TouchFlatMsgInfo(msg);
                //    this.Close();
                //    return;
                //}
                //AppSet.CurrentBalanceInterface = NTDFunc.SelectBalanceInterface(AppSet.CurrentScale.id);
                //if (AppSet.CurrentBalanceInterface == null)
                //{
                //    NTDMsg.TouchFlatMsgInfo("未找到该秤台的实例");
                //    this.Close();
                //    return;
                //}

                //是否复核
                if (CurrentTaskDetails.is_review_barcode == "1")
                {
                    var frm = new FrmReviewBarcode(CurrentTaskDetails);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CurrentPartsBatchNumber.Add(frm.BatchNumber);
                        BtnBatchNumber.Text = frm.BatchNumber;
                    }
                    else
                    {
                        this.Close();
                        return;
                    }
                }

                //是否手工称重
                if (CurrentTaskDetails.is_manual_weight == "1")
                {
                    var frm = new FrmManualWeight(CurrentTaskDetails);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CurrentFlowRecord.real_tare_weight = frm.Tare;
                        CurrentFlowRecord.real_net_weight = frm.Net;
                        CurrentFlowRecord.real_gross_weight = (frm.Tare + frm.Net);
                        IsReadScaleWeight = false;
                        BtnSave_Click(BtnSave, e);
                        return;
                    }
                }

                switch (CurrentTaskDetails.dot_bag_type)
                {
                    default:
                    case "无需点袋":
                        break;
                    case "手工点袋":
                        var frmManualDotBag = new FrmManualDotBag(CurrentTaskDetails);
                        frmManualDotBag.ShowDialog();
                        CurrentFlowRecord.package_count = frmManualDotBag.InputBags;//点袋数
                        CurrentFlowRecord.package_count_weight = frmManualDotBag.ZapWeightValue;//点袋重量
                                                                                                //改变进度条显示值
                        wpb.LowerWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.lower_limit) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));
                        wpb.TargetWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));
                        wpb.UpperWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.upper_limit) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));

                        if (wpb.TargetWeight <= 0)
                        {
                            CurrentFlowRecord.real_tare_weight = 0;
                            CurrentFlowRecord.real_net_weight = 0;
                            CurrentFlowRecord.real_gross_weight = 0;
                            IsReadScaleWeight = false;
                            BtnSave_Click(BtnSave, e);
                            return;
                        }
                        //刷新点袋之后的重量 
                        wpb.ControlLocation(LblLowerWeight, LblTargetWeight, LblUpperWeight);
                        break;
                    case "扫码点袋":
                        // 条码点袋
                        var frmBarcodeDotBag = new FrmBarcodeDotBag(CurrentTaskDetails);
                        frmBarcodeDotBag.ShowDialog();
                        CurrentFlowRecord.package_count = frmBarcodeDotBag.InputBags;//点袋数
                        CurrentFlowRecord.package_count_weight = frmBarcodeDotBag.ZapWeightValue;//点袋重量
                                                                                                 //改变进度条显示值
                        wpb.LowerWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.lower_limit) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));
                        wpb.TargetWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));
                        wpb.UpperWeight = DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.upper_limit) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight));

                        if (wpb.TargetWeight <= 0)
                        {
                            CurrentFlowRecord.real_tare_weight = 0;
                            CurrentFlowRecord.real_net_weight = 0;
                            CurrentFlowRecord.real_gross_weight = 0;
                            IsReadScaleWeight = false;
                            BtnSave_Click(BtnSave, e);
                            return;
                        }
                        //刷新点袋之后的重量 
                        wpb.ControlLocation(LblLowerWeight, LblTargetWeight, LblUpperWeight);
                        break;
                }


                //判断是否累计称重
                //if ((DecimalHelper.Conversion(CurrentTaskDetails.lower_limit) - DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight)) > AppSet.CurrentScale.range)
                //{

                //    var frm = new FrmCumulativeWeighing(CurrentOpenTask, CurrentPartsBatchNumber,CurrentFlowRecord.package_count_weight);
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        //保存称重信息
                //        CurrentPartsBatchNumber = new List<string>();
                //        CurrentPartsBatchNumber = frm.CurrentPartsBatchNumber;
                //        for (int i = 0; i < frm.CumulativeWeighingFlowRecordsList.Count; i++)
                //        {
                //            CurrentFlowRecord.real_tare_weight = DecimalHelper.Conversion(CurrentFlowRecord.real_tare_weight)+ DecimalHelper.Conversion(frm.CumulativeWeighingFlowRecordsList[i].real_tare_weight);
                //            CurrentFlowRecord.real_net_weight = DecimalHelper.Conversion(CurrentFlowRecord.real_net_weight) + DecimalHelper.Conversion(frm.CumulativeWeighingFlowRecordsList[i].real_net_weight);
                //            CurrentFlowRecord.real_gross_weight = DecimalHelper.Conversion(CurrentFlowRecord.real_gross_weight) + DecimalHelper.Conversion(frm.CumulativeWeighingFlowRecordsList[i].real_gross_weight);
                //            if (i == 0)
                //            {
                //                CurrentFlowRecord.unpack_weight_des += frm.CumulativeWeighingFlowRecordsList[i].real_net_weight;
                //            }
                //            else
                //            {
                //                CurrentFlowRecord.unpack_weight_des += "+" + frm.CumulativeWeighingFlowRecordsList[i].real_net_weight;
                //            }
                //        }

                //        CurrentFlowRecord.real_unit = AppSet.CurrentWcb.Unit.ToString(); 
                //        CurrentFlowRecord.real_time = DateTimeHelper.Conversion(DateTime.Now.ToString("yyyy-MM -dd HH:mm:ss"));
                //        CurrentFlowRecord.unpack_count = frm.CumulativeWeighingFlowRecordsList.Count();

                //        //改变任务数量
                //        CurrentOpenTask.task_current_count = CurrentOpenTask.task_current_count + 1;
                //        //物料完成数加一 
                //        CurrentOpenTaskService.Save(CurrentOpenTask);

                //        //根据数据库判断当前任务是否完成
                //        if (!CurrentOpenTaskService.IsCompleteTaskByTask(AppSet.CurrentTask))
                //        {
                //            //是否点袋未完成和没有点袋
                //            if (CurrentTaskDetails.is_dot_bag != 1 || (CurrentTaskDetails.is_dot_bag == 1 && wpb.TargetWeight > 0))
                //            {
                //                var frmNotifyFinish = new FrmNotifyFinish();
                //                frmNotifyFinish.ShowDialog();
                //            }
                //        }
                //        //保存称重记录并上传称重记录和打印
                //        SavePrintFoowRecords(); 
                //        ShowFlowRecordsInfo(); 
                //        ShowFrmData(true);
                //        return; 
                //    }
                //    else {
                //        tmrInit.Enabled = true;
                //        return;
                //    }
                //}

                //是否选择容器去皮和数字去皮
                if (CurrentTaskDetails.is_use_container == "1" && CurrentTaskDetails.is_need_tare == "1")
                {
                    //选择容器按钮
                    BtnSelectContainer_Click(BtnSelectContainer, e);
                }
                //数字去皮
                else if (CurrentTaskDetails.is_use_container != "1" && CurrentTaskDetails.is_need_tare == "1")
                {
                    if (DecimalHelper.Conversion(CurrentTaskDetails.preset_tare) > 0)
                    {

                        try
                        {
                            //数字去皮
                            AppSet.CurrentBalanceInterface.SetPresetTareWeight(CurrentTaskDetails.preset_tare.ToString());
                            // AppSet.CurrentWcb.PresetTareWeight = CurrentTaskDetails.preset_tare.ToString();

                        }
                        catch (Exception ex)
                        {
                            NTDMsg.TouchFlatMsgError("错误：" + ex.Message);
                        }
                    }
                    else
                    {

                        var frm = new FrmPresetTare();
                        var rst = frm.ShowDialog();
                        if (rst == DialogResult.OK)
                        {
                            //数字去皮
                            AppSet.CurrentBalanceInterface.SetPresetTareWeight(frm.CurrentPresetTareValue);
                            // AppSet.CurrentWcb.PresetTareWeight = frm.CurrentPresetTareValue;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        private void TmrWeight_Tick(object sender, EventArgs e)
        {
            try
            {
                LblSysTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

                if (AppSet.CurrentBalanceInterface == null) return;

                lblScaleInfo.Text = AppSet.CurrentScale.name + "  Max=" + AppSet.CurrentScale.range_no + AppSet.CurrentScale.weight_unit + " e=" + AppSet.CurrentScale.divison + AppSet.CurrentScale.weight_unit + " Min=" + AppSet.CurrentScale.min_weight_value + AppSet.CurrentScale.weight_unit;
                AppSet.CurrentWCB = AppSet.CurrentBalanceInterface.GetSingleValue();
                LblStable.Visible = !AppSet.CurrentWCB.Stable;
                LblIsZero.Visible = AppSet.CurrentWCB.ZeroFlag;
                LblUnitNet.Text = LblUnitTare.Text = LblUnitGross.Text = AppSet.CurrentWCB.Unit.ToString();

                if (AppSet.CurrentWCB.UnderOrOverLoadFlag)
                {
                    LblNet.Text = AppSet.CurrentWCB.UnderOrOverLoadFlagStr;
                    LblGross.Text = "------";
                    LblTare.Text = "------";
                    return;
                }
                LblStable.Visible = AppSet.CurrentWCB.IsSetTareFlag;
                LblNet.Text = AppSet.CurrentWCB.GetNetWeight().ToString();
                LblGross.Text = AppSet.CurrentWCB.GetGrossWeight().ToString();
                LblTare.Text = AppSet.CurrentWCB.GetTareWeight().ToString();
                if (wpb.IsEnable)
                {
                    // 更新进度条
                    wpb.ActualWeight = DoubleHelper.ObjectConversionDouble(LblNet.Text.Trim());
                    wpb.UpdatePreview();
                    PicProgressBar.Image = wpb.PreviewImage;
                }

                //判断称台是否稳定并在合格范围内
                if (AppSet.CurrentWCB.Stable && wpb.IsQualified)
                {
                    BtnSave.Enabled = true;
                }
                else
                {
                    BtnSave.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }




        #region 保存上传数据和补打打印

        private void SavePrintFlowRecords()
        {
            try
            {
                //标定信息
                CurrentFlowRecord.check_weight_p0 = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][0];
                CurrentFlowRecord.check_weight_p1 = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][1];
                CurrentFlowRecord.check_weight_p2 = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][2];
                CurrentFlowRecord.check_weight_p3 = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][3];
                CurrentFlowRecord.check_weight_p4 = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][4];
                CurrentFlowRecord.check_user_account = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][5];
                CurrentFlowRecord.check_user_username = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][6];
                CurrentFlowRecord.check_counter_weight = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][7];
                CurrentFlowRecord.check_time = AppSet.CalbrationMap[AppSet.CurrentScale.id.ToString()][8];


                //终端秤台信息
                CurrentFlowRecord.terminal_code = AppSet.CurrentTerminal.code;
                CurrentFlowRecord.terminal_name = AppSet.CurrentTerminal.name;
                CurrentFlowRecord.terminal_ip = AppSet.CurrentTerminal.ip;
                CurrentFlowRecord.terminal_device_code = AppSet.CurrentScale.code;
                CurrentFlowRecord.terminal_device_name = AppSet.CurrentScale.name;


                //当前登录人
                CurrentFlowRecord.login_user_account = AppSet.CurrentLoginUser.account;
                CurrentFlowRecord.login_user_username = AppSet.CurrentLoginUser.username;


                //任务信息
                CurrentFlowRecord.task_serial_number = AppSet.CurrentTask.serial_number;
                CurrentFlowRecord.task_name = AppSet.CurrentTask.name;
                CurrentFlowRecord.task_plan_time = AppSet.CurrentTask.plan_time;
                CurrentFlowRecord.task_is_fixed_batching = AppSet.CurrentTask.is_fixed_batching;
                CurrentFlowRecord.task_batching_way = AppSet.CurrentTask.batching_way;
                CurrentFlowRecord.task_all_count = CurrentOpenTask.task_all_count;
                CurrentFlowRecord.task_current_count = CurrentOpenTask.task_current_count;
                //任务详情

                CurrentFlowRecord.task_details_lower_limit = CurrentTaskDetails.lower_limit;
                CurrentFlowRecord.task_details_standard_weight = CurrentTaskDetails.standard_weight;
                CurrentFlowRecord.task_details_upper_limit = CurrentTaskDetails.upper_limit;
                CurrentFlowRecord.task_details_weight_unit = CurrentTaskDetails.weight_unit;

                //配方信息
                CurrentFlowRecord.formula_id = AppSet.CurrentTask.formula_id;
                CurrentFlowRecord.formula_name = AppSet.CurrentTask.formula_name;
                CurrentFlowRecord.formula_version_id = AppSet.CurrentTask.formula_version_id;
                CurrentFlowRecord.formula_version_name = AppSet.CurrentTask.formula_version_name;

                //容器信息
                CurrentFlowRecord.container_code = CurrentContainer.code;
                CurrentFlowRecord.container_name = CurrentContainer.name;
                CurrentFlowRecord.container_type = CurrentContainer.type;
                CurrentFlowRecord.container_barcode = CurrentContainer.barcode;

                //物料信息
                CurrentFlowRecord.parts_id = CurrentTaskDetails.parts_id;
                CurrentFlowRecord.parts_name = CurrentTaskDetails.parts_name;
                CurrentFlowRecord.parts_type = CurrentTaskDetails.parts_type;
                CurrentFlowRecord.parts_every_package_weight = CurrentTaskDetails.parts_every_package_weight;
                CurrentFlowRecord.parts_weight_unit = CurrentTaskDetails.parts_weight_unit;
                CurrentFlowRecord.parts_remark = CurrentTaskDetails.parts_remark;


                //复核条码的信息(通过，分割)
                for (int i = 0; i < CurrentPartsBatchNumber.Count; i++)
                {
                    if (i == 0)
                    {
                        CurrentFlowRecord.review_barcode += CurrentPartsBatchNumber[i];
                    }
                    else
                    {
                        CurrentFlowRecord.review_barcode += "," + CurrentPartsBatchNumber[i];
                    }
                }

                //描述
                CurrentFlowRecord.data_des = "配料数据-" + AppSet.CurrentTask.batching_way + "-" + CurrentOpenTask.task_current_count + "/" + CurrentOpenTask.task_all_count + "-" + CurrentOpenTask.task_details_sort;


                //保存点袋数据（解决点袋值为null的情况）
                CurrentFlowRecord.package_count = IntHelper.Conversion(CurrentFlowRecord.package_count);
                CurrentFlowRecord.package_count_weight = DecimalHelper.Conversion(CurrentFlowRecord.package_count_weight);

                //报存记录的唯一编号
                CurrentFlowRecord.record_serial_number = CurrentFlowRecord.task_serial_number + CurrentFlowRecord.task_current_count + CurrentFlowRecord.parts_id;


                //保存称重记录
                NmfsFlowRecordsService.Save(CurrentFlowRecord);

                CurrentPrintFlowRecords = new nmfs_flow_records();
                CurrentPrintFlowRecords = EntityHelper.Mapper<nmfs_flow_records, nmfs_flow_records>(CurrentFlowRecord);

                //上传称重记录
                var sys_upload_data = new sys_upload_data();
                sys_upload_data.cmd = "UploadsFlowRecords";
                sys_upload_data.upload_data = JsonConvert.SerializeObject(CurrentFlowRecord, Formatting.Indented, AppSet.JsonSetting);
                SysUploadDataService.Save(sys_upload_data);
                AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);

                if (CurrentTaskDetails.is_print_label == "1")
                {
                    //打印当前称重记录
                   NTDFunc.PrintPartsFastReport(CurrentPrintFlowRecords);
                }
                //清除当前称重的记录
                CurrentFlowRecord = new nmfs_flow_records();

                //清除容器号
                CurrentContainer = new nmfs_container();
                BtnlVesselNo.Text ="";
                //清除批号
                CurrentPartsBatchNumber = new List<string>();
                BtnBatchNumber.Text = "";
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("保存称重记录失败：" + ex.Message);
            }

        }

     
        #endregion




      
        /// <summary>
        /// 切换下一物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextPart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(NetCurrentOpenTask.id))
                {
                    CurrentOpenTask = NetCurrentOpenTask;
                    FrmWeight_Load(this, e);
                }
                else
                {
                    NTDMsg.TouchFlatMsgInfo("暂无下一物料.");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        /// <summary>
        /// 选择容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCurrentContainer_BtnClick(object sender, EventArgs e)
        {
            try
            {
                if (!BtnSelectContainer.Enabled) return;
                BtnSelectContainer_Click(BtnSelectContainer, e);
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
                        if (!BtnScaleNo.Enabled) return;
                        BtnScaleNo_Click(BtnScaleNo, e);
                        break;
                    case (Keys.F3):
                        if (!BtnSetZero.Enabled) return;
                        BtnSetZero_Click(BtnSetZero, e);
                        break;
                    case (Keys.F4):
                        if (!BtnSetTare.Enabled) return;
                        BtnSetTare_Click(BtnSetTare, e);
                        break;
                    case (Keys.F5):
                        if (!BtnClearTare.Enabled) return;
                        BtnClearTare_Click(BtnClearTare, e);
                        break;
                    case (Keys.F6):
                        if (!BtnSetTareNumber.Enabled) return;
                        BtnSetTareNumber_Click(BtnSetTareNumber, e);
                        break;
                    case (Keys.F7):
                        if (!BtnSelectContainer.Enabled) return;
                        BtnSelectContainer_Click(BtnSelectContainer, e);

                        break;
                    case (Keys.F8):
                        if (!BtnSave.Enabled) return;
                        BtnSave_Click(BtnSave, e);
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
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        /// <summary>
        /// 秤台切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScaleNo_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                //判断当前是否有秤台集合
                if (AppSet.CurrentScaleList == null || AppSet.CurrentScaleList.Count <= 0)
                {
                    NTDMsg.TouchFlatMsgError("未有可切换的秤台");
                    return;
                }
                NTDFunc.ChangScaleDetails(false, AppSet.CurrentScaleList);
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
        /// 清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetZero_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                AppSet.CurrentBalanceInterface.SetZero();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "清零失败:" + ex.Message);
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
        /// 去皮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetTare_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                AppSet.CurrentBalanceInterface.SetTare();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "去皮失败:" + ex.Message);
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
        /// 清皮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearTare_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                AppSet.CurrentBalanceInterface.ClearTare();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "清皮失败:" + ex.Message);
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
        /// 设皮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetTareNumber_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                var frm = new FrmPresetTare();
                var rst = frm.ShowDialog();
                if (rst == DialogResult.OK)
                {
                    AppSet.CurrentBalanceInterface.SetPresetTareWeight(frm.CurrentPresetTareValue);
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "设皮失败:" + ex.Message);
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
        /// 选择容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectContainer_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
               
                var frm = new FrmInputBucketNumber(CurrentTaskDetails.parts_container_type,IntHelper.Conversion(CurrentTaskDetails.is_review_container));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.IsSetTareAndSave)
                    {
                        //去皮并保存
                        BtnSetTare_Click(BtnSetTare, e);
                        CurrentContainer = frm.SelectData;
                        CurrentContainer.weight = DecimalHelper.Conversion(AppSet.CurrentWCB.GetTareWeight());
                        CurrentOpenTask.container_name = CurrentContainer.name;
                        CurrentOpenTask.container_tare_value = CurrentContainer.weight;
                    }
                    else
                    {
                        CurrentContainer = frm.SelectData;
                        CurrentOpenTask.container_name = CurrentContainer.name;
                        CurrentOpenTask.container_tare_value = CurrentContainer.weight * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentContainer.weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(AppSet.CurrentScale.weight_unit));
                        //数字去皮
                        AppSet.CurrentWCB.PresetTareWeight = CurrentOpenTask.container_tare_value.ToString();
                    }
                    BtnlVesselNo.Text = CurrentContainer.name;
                }
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //称重记录
            CurrentFlowRecord.real_unit = AppSet.CurrentWCB.Unit.ToString();
            CurrentFlowRecord.real_time = DateTimeHelper.Conversion(DateTime.Now.ToString("yyyy-MM -dd HH:mm:ss"));

            //是否手工称重(手工称重毛皮净的重量已经保存过了)
            if (IsReadScaleWeight)
            {
                CurrentFlowRecord.real_tare_weight = DecimalHelper.Conversion(AppSet.CurrentWCB.GetTareWeight());
                CurrentFlowRecord.real_net_weight = DecimalHelper.Conversion(AppSet.CurrentWCB.GetNetWeight());
                CurrentFlowRecord.real_gross_weight = DecimalHelper.Conversion(AppSet.CurrentWCB.GetGrossWeight());
            }

            //如果点袋完成就不保存毛皮净
            //if (WeightProgressBar.TargetWeight <= 0)
            //{
            //    CurrentFlowRecord.real_tare_weight = 0;
            //    CurrentFlowRecord.real_net_weight = 0;
            //    CurrentFlowRecord.real_gross_weight = 0;
            //}

            //改变任务数量
            CurrentOpenTask.task_current_count = CurrentOpenTask.task_current_count + 1;
            //物料完成数加一 
            NmfsCurrentOpenTaskService.Save(CurrentOpenTask);



            //保存称重记录并上传称重记录和打印
            SavePrintFlowRecords();
            //根据数据库判断当前任务是否完成
            //if (!CurrentOpenTaskService.IsCompleteTaskByTask(AppSet.CurrentTask))
            //{
            //    //是否点袋未完成和没有点袋
            //    if (CurrentTaskDetails.dot_bag_type == "无需点袋" || (CurrentTaskDetails.dot_bag_type != "无需点袋" && WeightProgressBar.TargetWeight > 0))
            //    {

            //        var frm = new FrmNotifyFinish(this, CurrentTempFlowRecord);
            //        frm.ShowDialog();
            //    }
            //}
            //根据数据库判断当前任务是否完成
            if (!NmfsCurrentOpenTaskService.IsCompleteTaskByTask(AppSet.CurrentTask))
            {
                if (IsReadScaleWeight)
                {
                    var frm = new FrmNotifyFinish(this, CurrentPrintFlowRecords);
                    frm.ShowDialog();
                }
            }


            //刷新数据表格
            // ShowFlowRecordsInfo(); 
            ShowFrmData(true);
            ShowFlowRecordsInfo();
        }

        #endregion

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && DgvData.Columns[e.ColumnIndex].Name == "ColPrint")
            {
                var  flowRecords = new nmfs_flow_records();
                flowRecords.id = DgvData.Rows[e.RowIndex].Cells["ColId"].Value?.ToString();

                if (NmfsFlowRecordsService.IsExistSingleDataByEntity(flowRecords, out flowRecords))
                {
                    //打印当前称重记录
                    NTDFunc.PrintPartsFastReport(flowRecords);
                }
                else
                {
                    NTDMsg.TouchFlatMsgInfo("未找到该数据");
                }
            }
        }

 
    }
}
