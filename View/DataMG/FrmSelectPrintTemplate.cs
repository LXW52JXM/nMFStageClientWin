using DBService;
using Model;
using NTDCommLib;
using NTDCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmSelectPrintTemplate : Form
    {
        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;

        private string LabelPartsPrinterPath = string.Empty;

        private string LabelFormulaPrinterPath = string.Empty;


        private bool LoadInit = false;

        public FrmSelectPrintTemplate()
        {
            InitializeComponent();
        }



        private void FrmSelectPrintTemplate_Load(object sender, EventArgs e)
        {
            try
            {

                CmbPartsLabelPrinter.Items.AddRange(PrinterHelper.GetAllPrinter());
                CmbFormulaLabelPrinter.Items.AddRange(PrinterHelper.GetAllPrinter());

                CmbPartsLabelPrinter.Text = SystemSet.PartsLabelPrinter;
                CmbFormulaLabelPrinter.Text = SystemSet.FormulaLabelPrinter;

                TxtPartsLabelPrintLable.Text = SystemSet.PartsLabelPrintLable;
                LabelPartsPrinterPath = SystemSet.PartsLabelPrintLablePath;

                TxtFormulaLabelPrintLable.Text = SystemSet.FormulaLabelPrintLable;
                LabelFormulaPrinterPath = SystemSet.FormulaLabelPrintLablePath;

            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            LoadInit = true;
        }


        private void PicSelectSimpleWeightTemplate_Click(object sender, EventArgs e)
        {
            try
            {

                Button p = (Button)sender;
                if (p.Tag == null || p.Tag == "") return;
                var frm = new FrmSelectPrintLable();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (p.Tag.ToString())
                    {
                        case ("物料标签模板"):
                            TxtPartsLabelPrintLable.Text = Path.GetFileNameWithoutExtension(frm.SelectData.Name);
                            LabelPartsPrinterPath = frm.SelectData.FullName;

                            break;
                        case ("配方标签模板"):
                            TxtFormulaLabelPrintLable.Text = Path.GetFileNameWithoutExtension(frm.SelectData.Name);
                            LabelFormulaPrinterPath = frm.SelectData.FullName;

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private bool CheckData()
        {
            if (string.IsNullOrEmpty(LabelPartsPrinterPath))
            {
                NTDMsg.TouchFlatMsgInfo("请选择物料标签的模板");
                return false;
            }

            if (string.IsNullOrEmpty(LabelFormulaPrinterPath))
            {
                NTDMsg.TouchFlatMsgInfo("请选择配方标签的模板");
                return false;
            }
            return true;
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
                        break;
                    case (Keys.F5):
                        if (!BtnTestPrint.Enabled) return;
                        BtnTestPrint_Click(BtnTestPrint, e);

                        break;
                    case (Keys.F6):

                        break;
                    case (Keys.F7):

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
        /// 测试打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTestPrint_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                string msg = string.Empty;


                if (!FastReportHelper.FastReportForParamters(new Dictionary<string, object>(), LabelPartsPrinterPath, out msg, SystemSet.PartsLabelPrinter))
                {
                    NTDMsg.TouchFlatMsgError(msg);
                    return;
                }

                var reportFormViewList = new List<ReportFormView>();
                for (int i = 0; i < 30; i++)
                {
                    var reportFormView = new ReportFormView();
                    reportFormView.ext1 = i.ToString();
                    reportFormView.ext2 = "2";
                    reportFormView.ext3 = "3";
                    reportFormViewList.Add(reportFormView);
                }


                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("date_time", "1");

                dic.Add("task_serial_number", "2");
                dic.Add("formula_id", "3");
                dic.Add("formula_name", "4");
                dic.Add("login_user_username", "5");
                dic.Add("total_weight", "6");
                NTDFunc.PrintFormulaFastReport(dic, reportFormViewList);

                //DataSet dataSet = new DataSet();
                //DataTable dt = new DataTable();
                //dt = DataTableHelper.ToDataTable(reportFormViewList);
                //dt.TableName = "ReportFormView"; // 一定要设置表名称
                //dataSet.Tables.Add(dt);



                //if (!FastReportHelper.FastReportForParamters(dic, dataSet, SystemSet.FormulaLabelPrintLablePath, out  msg, SystemSet.FormulaLabelPrinter))
                //{
                //    NTDMsg.TouchFlatMsgError(msg);
                //    return;
                //}
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
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                SystemSet.PartsLabelPrinter = CmbPartsLabelPrinter.Text.Trim();
                SystemSet.FormulaLabelPrinter = CmbFormulaLabelPrinter.Text.Trim();


                SystemSet.PartsLabelPrintLablePath = LabelPartsPrinterPath;


                SystemSet.FormulaLabelPrintLablePath = LabelFormulaPrinterPath;
                AppSet.SaveSystemSettingsConfig();
                NTDMsg.TouchFlatMsgInfo("保存成功");
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


    }
}
