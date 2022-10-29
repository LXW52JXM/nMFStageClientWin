using HZH_Controls.Controls;
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
using static NTDCommon.LocalTimeHelper;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace nMFStageClientWin
{
    public partial class FrmSetScanningGun : Form
    {
        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSettings.AppSet.SystemSet;
        public FrmSetScanningGun()
        {
            InitializeComponent();
        }

        private TextBox FocusTextBox;
        


        private void TxtYear_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
        }

        private bool CheckData()
        {

            // 校验是否ip4
            //if (string.IsNullOrEmpty(TxtUploadDataHttpAddress.Text.Trim()))
            //{
            //    NTDMsg.TouchFlatMsgError("服务器ip不能为空.");
            //    return false;
            //}

            return true;
        }

        private void FrmServcieSet_Load(object sender, EventArgs e)
        {
            try
            {

                CmbIsUseScanningGun.Active = SystemSet.IsUseScanningGun;

                CmbScanningGunSerialPort.Items.AddRange(SerialPort.GetPortNames());
                CmbScanningGunBaudRate.Items.AddRange(ConstantHelper.BAUD_RATE);

                CmbScanningGunSerialPort.Text = SystemSet.ScanningGunSerialPort;
                CmbScanningGunBaudRate.Text = SystemSet.ScanningGunBaudRate.ToString();
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
                    SystemSet.IsUseScanningGun=CmbIsUseScanningGun.Active;
                    SystemSet.ScanningGunSerialPort= CmbScanningGunSerialPort.Text.Trim();
                    SystemSet.ScanningGunBaudRate=IntHelper.Conversion(CmbScanningGunBaudRate.Text.Trim());
                    AppSet.SaveSystemSettingsConfig();

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
 
