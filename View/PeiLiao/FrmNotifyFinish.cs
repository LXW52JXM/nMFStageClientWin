using Model;
using NTDCommLib;
using NTDCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmNotifyFinish : Form
    {

        AppSettings AppSet =>AppSettings.AppSet;
        SystemSettings SystemSet =>AppSettings.AppSet.SystemSet;

        nmfs_flow_records CurrentTempFlowRecord = new nmfs_flow_records();//补打标签的数据
        Form Form = null;
        public FrmNotifyFinish()
        {
            InitializeComponent();
            FormHelper.FormBottonCenter(this,  AppSet.FormWidth,  AppSet.FormHeight);
            TmrWeight.Enabled = true;
        }
        public FrmNotifyFinish(Form form, nmfs_flow_records currentTempFlowRecord)
        {
            InitializeComponent();
            Form = form;
            CurrentTempFlowRecord = currentTempFlowRecord;
            FormHelper.FormBotton(this);
            TmrWeight.Enabled = true;
            BtnUsePrint.Visible = true;
        }

        private void TmrWeight_Tick(object sender, EventArgs e)
        {
            try
            {
                if (AppSet.CurrentScale.divison * 5 > DecimalHelper.Conversion(AppSet.CurrentWCB.GetNetWeight()) && -AppSet.CurrentScale.divison * 5 < DecimalHelper.Conversion(AppSet.CurrentWCB.GetNetWeight()))
                {
                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
              
            }
        }

        private void FrmNotifyFinish_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrWeight.Enabled = false;
        }

      

        
        /// <summary>
        /// 去皮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetTare_Click(object sender, EventArgs e)
        {
            try
            {
                AppSet.CurrentBalanceInterface.SetTare();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "去皮失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnZero_Click(object sender, EventArgs e)
        {
            try
            {
                AppSet.CurrentBalanceInterface.SetZero();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "清零失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 清皮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearTare_Click(object sender, EventArgs e)
        {
            try
            {
                AppSet.CurrentBalanceInterface.ClearTare();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("称台" + AppSet.CurrentScale.name + "清皮失败:" + ex.Message);
            }
        }

        /// <summary>
        /// 补打
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUsePrint_Click(object sender, EventArgs e)
        {
            try
            {
                NTDFunc.PrintPartsFastReport(CurrentTempFlowRecord);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("打印称重记录失败：" + ex.Message);
            }
        }

        private void FrmNotifyFinish_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
    }
}
