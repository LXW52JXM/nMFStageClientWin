using NTDCommLib;
using NTDCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmSetScaleNumber : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        private TextBox FocusTextBox = null;

        public FrmSetScaleNumber()
        {
            InitializeComponent();
        }

        private void FrmSetScaleNumber_Load(object sender, EventArgs e)
        {
            try
            {
                TxtDeviceCode.Text = SystemSet.DeviceCode;
                TxtCountdown.Text = SystemSet.NTDMsgTimeout.ToString();
                TxtDeviceCode.Text = SystemSet.DeviceCode;
                CmbOpenCount.Text = SystemSet.NTDMsgCanCountDown == true ? "是" : "否";

                CmbLocalhostIp.Items.AddRange(IpHelper.GetIPAddressArrayStr());
                CmbLocalhostIp.Text = SystemSet.LocalhostIp;

            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }


        private bool CheckData()
        {

            if (string.IsNullOrEmpty(TxtDeviceCode.Text.Trim()))
            {
                NTDMsg.TouchFlatMsgInfo("设备编号不能为空.");
                return false;
            }

            if (IntHelper.Conversion(TxtCountdown.Text.Trim()) <= 0)
            {
                NTDMsg.TouchFlatMsgInfo("倒计时间不能小于1s.");
                return false;
            }


            return true;
        }


      

        private void TxtServiceIp_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
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
                if (CheckData())
                {
                    SystemSet.DeviceCode = TxtDeviceCode.Text.Trim();
                    SystemSet.NTDMsgCanCountDown = CmbOpenCount.Text == "是" ? true : false;
                    SystemSet.NTDMsgTimeout = IntHelper.Conversion(TxtCountdown.Text.Trim());

                    SystemSet.LocalhostIp = CmbLocalhostIp.Text.Trim();
                    AppSet.SaveSystemSettingsConfig();

                    NTDMsg.CanCountDown = SystemSet.NTDMsgCanCountDown;
                    NTDMsg.Timeout = SystemSet.NTDMsgTimeout;

                    NTDMsg.TouchFlatMsgInfo("保存设置成功");
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
        #endregion
        private void BtnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != FocusTextBox)
                {
                    Button b = (Button)sender;
                    if (b.Text.Trim() == "全键盘")
                    {
                        StartKeyBoard.StartKeyBoardFun();
                    }
                    else
                    {
                        NTDKeyBoard.KeyboardClickFunc(b, FocusTextBox);
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

  
    }
}
