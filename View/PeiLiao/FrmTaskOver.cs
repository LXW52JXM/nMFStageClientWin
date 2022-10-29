

using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBService;
using System.Drawing.Drawing2D;

namespace nMFStageClientWin
{

    public partial class FrmTaskOver : Form
    {
        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;

        nmfs_flow_records FlowRecordsQueryEntity = new nmfs_flow_records();

        nmfs_current_open_task CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
        public FrmTaskOver()
        {
            InitializeComponent();
        }

        private void BtnPrintTemplate_Click(object sender, EventArgs e)
        {
            try
            {


                Dictionary<string, object> dic = new Dictionary<string, object>();
                var flowRecordsList = new List<nmfs_flow_records>();
                decimal weight = 0;


                string deviceCode = "";
                string userName = "";
                List<ReportFormView> reportFormViewList = new List<ReportFormView>();
                ReportFormView reportFormView = new ReportFormView();

                switch (AppSet.CurrentTask.batching_way)
                {
                    case ("AAA-BBB-CCC"):

                        reportFormViewList = new List<ReportFormView>();

                        FlowRecordsQueryEntity = new nmfs_flow_records();
                        FlowRecordsQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;

                        flowRecordsList = NmfsFlowRecordsService.GetDataByEntity(FlowRecordsQueryEntity);
                        weight = 0;//总重
                        dic = new Dictionary<string, object>();
                        foreach (var item in flowRecordsList.OrderBy(o => o.real_time).ToList())
                        {
                            weight = weight + DecimalHelper.Conversion(item.real_net_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(item.real_unit), NTDMassUnitEnum.kg) + DecimalHelper.Conversion(item.package_count_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(item.real_unit), NTDMassUnitEnum.kg);
                            deviceCode = item.terminal_code;
                            userName = item.login_user_username;

                            reportFormView = new ReportFormView();
                            reportFormView.ext1 = item.parts_id;
                            reportFormView.ext2 = item.parts_name;
                            reportFormView.ext3 = DecimalHelper.Conversion(item.real_net_weight) + DecimalHelper.Conversion(item.package_count_weight) + " " + item.real_unit;
                            reportFormViewList.Add(reportFormView);
                            if (dic.ContainsKey("date_time"))
                            {
                                dic["date_time"] = DateTimeHelper.Conversion(item.real_time).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                dic.Add("date_time", DateTimeHelper.Conversion(item.real_time).ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        //是否配方标签
                        // dic = EntityHelper.ToMap(AppSet.CurrentFormula);

                        dic.Add("task_serial_number", AppSet.CurrentTask.serial_number + "_1");
                        dic.Add("formula_id", AppSet.CurrentTask.formula_id + " V" + AppSet.CurrentTask.formula_version_name);
                        dic.Add("formula_name", AppSet.CurrentTask.formula_name);
                        dic.Add("login_user_username", AppSet.CurrentLoginUser.username);

                        dic.Add("total_weight", weight + " kg");

                        break;
                    case ("ABC-ABC-ABC"):
                        reportFormViewList = new List<ReportFormView>();

                        CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
                        CurrentOpenTaskQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;

                        var currentOpenTaskList = NmfsCurrentOpenTaskService.GetDataByEntity(CurrentOpenTaskQueryEntity);
                        //取已做任务的最多次数
                        ArrayList list = new ArrayList();
                        foreach (var data in currentOpenTaskList)
                        {
                            list.Add(data.task_current_count);
                        }
                        list.Sort();


                        FlowRecordsQueryEntity = new nmfs_flow_records();
                        FlowRecordsQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;
                        FlowRecordsQueryEntity.task_current_count = IntHelper.Conversion(list[list.Count - 1]);
                        flowRecordsList = NmfsFlowRecordsService.GetDataByEntity(FlowRecordsQueryEntity);
                        dic = new Dictionary<string, object>();
                        weight = 0;
                        foreach (var item in flowRecordsList.OrderBy(o => o.real_time).ToList())
                        {
                            weight = weight + DecimalHelper.Conversion(item.real_net_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(item.real_unit), NTDMassUnitEnum.kg) + DecimalHelper.Conversion(item.package_count_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(item.real_unit), NTDMassUnitEnum.kg);
                            deviceCode = item.terminal_code;
                            userName = item.login_user_username;

                            reportFormView = new ReportFormView();
                            reportFormView.ext1 = item.parts_id;
                            reportFormView.ext2 = item.parts_name;
                            reportFormView.ext3 = DecimalHelper.Conversion(item.real_net_weight) + DecimalHelper.Conversion(item.package_count_weight) + " " + item.real_unit;
                            reportFormViewList.Add(reportFormView);

                            if (dic.ContainsKey("date_time"))
                            {
                                dic["date_time"] = DateTimeHelper.Conversion(item.real_time).ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                dic.Add("date_time", DateTimeHelper.Conversion(item.real_time).ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        //是否配方标签
                        //dic = EntityHelper.ToMap(AppSet.CurrentFormula);

                        dic.Add("task_serial_number", AppSet.CurrentTask.serial_number + "_" + list[list.Count - 1].ToString());
                        dic.Add("formula_id", AppSet.CurrentTask.formula_id + " V" + AppSet.CurrentTask.formula_version_name);
                        dic.Add("formula_name", AppSet.CurrentTask.formula_name);
                        dic.Add("login_user_username", AppSet.CurrentLoginUser.username);
                        dic.Add("total_weight", weight + " kg");
                        break;
                }

                NTDFunc.PrintFormulaFastReport(dic,reportFormViewList);

                //var terminalDevice = new nmfs_terminal_device();
                //terminalDevice.code = SystemSet.FormulaLabelPrinter;
                //if (NmfsTerminalDeviceService.IsExistSingleDataByEntity(terminalDevice, out terminalDevice))
                //{
                //    string msg = string.Empty;
                //    if (terminalDevice.communication_mode == "USB")
                //    {

                //        DataSet dataSet = new DataSet();
                //        DataTable dt = new DataTable();
                //        dt = DataTableHelper.ToDataTable(reportFormViewList);
                //        dt.TableName = "ReportFormView"; // 一定要设置表名称
                //        dataSet.Tables.Add(dt);

                //        if (!FastReportHelper.FastReportForParamters(dic, dataSet, SystemSet.FormulaLabelPrintLablePath, out msg, terminalDevice.drive_name))
                //        {
                //            NTDMsg.TouchFlatMsgError(msg);
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        AppSet.CurrentPrintInterface = NTDFunc.SelectPrintInterface(IntHelper.Conversion(SystemSet.FormulaLabelPrinter));
                //        if (AppSet.CurrentPrintInterface == null)
                //        {
                //            NTDMsg.TouchFlatMsgError("未找到该打印机的实例");
                //            return;
                //        }

                //        string fileData = string.Empty;

                //        if (!PrintHelper.FileToStringByDic(SystemSet.PartsLabelPrintLablePath, dic, out fileData, out msg, true))
                //        {
                //            NTDMsg.TouchFlatMsgError(msg);
                //            return;
                //        }
                //        else
                //        {
                //            if (!AppSet.CurrentPrintInterface.ShortConnectionSendDataToPrint(fileData, out msg))
                //            {
                //                NTDMsg.TouchFlatMsgError(msg);
                //                return;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    NTDMsg.TouchFlatMsgError("请选择打印机.");

                //}
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
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

        private void FrmTaskOver_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
    }
}
