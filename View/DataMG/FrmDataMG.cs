using DBService;
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
    public partial class FrmDataMG : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;
        public FrmDataMG()
        {
            InitializeComponent();
            TmrSysTime.Enabled = true;
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmDataMG_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrSysTime.Enabled = false;
        }

        private void Restart()

        {

            Thread thtmp = new Thread(new ParameterizedThreadStart(run));

            object appName = Application.ExecutablePath;

            Thread.Sleep(2000);
            thtmp.Start(appName);

        }

        private void run(Object obj)

        {

            Process ps = new Process();

            ps.StartInfo.FileName = obj.ToString();
            ps.Start();

        }
        private void TmrSysTime_Tick(object sender, EventArgs e)
        {
            LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void BtnReStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (NTDMsg.TouchFlatMsgQuestion("确定要删除所有数据吗？") == DialogResult.OK)
                {
                    NmfsContainerService.DeleteAll();
                    NmfsCurrentOpenTaskService.DeleteAll();
                    NmfsFlowRecordsService.DeleteAll();
                    NmfsParametersService.DeleteAll();
                    NmfsTaskService.DeleteAll();
                    NmfsTaskDetailsService.DeleteAll();
                    NmfsTerminalService.DeleteAll();
                    NmfsTerminalDeviceService.DeleteAll();
                    NmfsUserService.DeleteAll();
                    SysUploadDataService.DeleteAll();
                   
                    NTDMsg.TouchFlatMsgInfo("删除成功！");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnDataMG_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmPrintTemplateMG();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

    
    }
}
