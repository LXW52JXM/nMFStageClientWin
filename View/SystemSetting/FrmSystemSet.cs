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
    public partial class FrmSystemSet : Form
    {
        AppSettings AppSet =>AppSettings.AppSet;
        SystemSettings SystemSet =>AppSettings.AppSet.SystemSet;
        public FrmSystemSet()
        {
            InitializeComponent();

            LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
         

        private void BtnBack_Click(object sender, EventArgs e)
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


        
        private void TmrSysTime_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
         

        private void BtnSetScaleNum_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmSetScaleNumber();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnScaleSetting_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmScaleSettingNTD910();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

       

        private void BtnSetNet_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmSetScanningGun();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnSetService_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmServiceSet();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
    }
}
