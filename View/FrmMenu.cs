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
    public partial class FrmMenu : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;
        public FrmMenu()
        {
            InitializeComponent();
            TmrSysTime.Enabled = true;
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

        private void BtnScaleSetting_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmSystemSet();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
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
                if (NTDMsg.TouchFlatMsgQuestion("确定退出程序吗？") == DialogResult.OK)
                {
                    Application.ExitThread(); 
                    Application.Exit();
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
                var frm = new FrmDataMG();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void FrmConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrSysTime.Enabled = false;
        }
    }
}
