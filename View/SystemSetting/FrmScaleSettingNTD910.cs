using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace nMFStageClientWin
{
    public partial class FrmScaleSettingNTD910 : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;
         TextBox FocusTextBox = null;
         bool LoadInit = false;
         NTDWeightCoreBean CurrentWcb = new NTDWeightCoreBean();


         int WeighingPlatformNo = 0;



        public FrmScaleSettingNTD910()
        {
            InitializeComponent(); 
        }

        private void FrmScaleSetting_Load(object sender, EventArgs e)
        {
            try
            {
                CmbIncrement.Items.AddRange(ConstantHelper.SCALE_DIVISION_KG_ARRAY);
            }
            catch (Exception ex)
            {
            }
            LoadInit = true;
        }
        

        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            // 校验量程值
            if (DecimalHelper.Conversion(TxtSpan.Text.Trim()) <= 0)
            {
                NTDMsg.TouchFlatMsgWarning("请正确输入量程值.");
                return false;
            }

            // 校验分度值
            if (DecimalHelper.Conversion(CmbIncrement.Text.Trim()) <= 0)
            {
                NTDMsg.TouchFlatMsgWarning("请正确输入分度值.");
                return false;
            }

            if (DecimalHelper.Conversion(TxtWeightValue.Text.Trim()) <= 0)
            {
                NTDMsg.TouchFlatMsgWarning("请正确输入标定砝码重量.");
                return false;
            }
            return true;
        }
      

        private void TxtSpan_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
        }

      
        private void FrmScaleSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            TmrWeight.Enabled = false;
        }

        private void WeightUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {

                if (AppSet.CurrentNTD910 == null) return;
                if (IntHelper.Conversion(WeighingPlatformNo) <= 0)
                {
                    LblWeight.Text = "-999";
                    return;
                }

                var data = AppSet.CurrentNTD910.GetSingleValue(IntHelper.Conversion(WeighingPlatformNo));
                if (data != null)
                {
                    LblWeight.Text = data.Net;
                }
                else
                {
                    LblWeight.Text = "-999";
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }



        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoadInit)
                {
                    RadioButton r = (RadioButton)sender;
                    if (r.Checked && r.Tag != null)
                    {
                        WeighingPlatformNo = IntHelper.Conversion(r.Tag);
                        //获取秤台分度值满量程
                        try
                        { 
                            var DATA = AppSet.CurrentNTD910.GetSingleValue(WeighingPlatformNo);
                            if (DATA != null)
                            {
                                CmbIncrement.Text = DATA.Increment.ToString();
                                TxtSpan.Text = DATA.Capacity.ToString();
                            }
                          
                        }
                        catch (Exception ex)
                        {
                            NTDMsg.TouchFlatMsgError(ex.Message);
                        }
                        TmrWeight.Enabled = true;
                        LblTip.Text = "请先设置秤体参数,然后点击【1.保存参数】按钮.";
                    }
                }
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
                        if (!BtnSaveParmas.Enabled) return;
                        BtnSaveParmas_Click(BtnSaveParmas, e);
                        break;
                    case (Keys.F6):
                        if (!BtnlSetZero.Enabled) return;
                        BtnlSetZero_Click(BtnlSetZero, e);
                        break;
                    case (Keys.F7):
                        if (!BtnCalibrateWeight.Enabled) return;
                        BtnCalibrateWeight_Click(BtnCalibrateWeight, e);
                        break;
                    case (Keys.F8):
                        if (!BtnSetFactroyZero.Enabled) return;
                        BtnSetFactroyZero_Click(BtnSetFactroyZero, e);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {


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
        /// 设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveParmas_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (CheckData())
                {

                    AppSet.CurrentNTD910.SetIncrement(DecimalHelper.ObjectConversionDecimal(CmbIncrement.Text.Trim()));
                    AppSet.CurrentNTD910.SetSpan(DecimalHelper.ObjectConversionDecimal(TxtSpan.Text.Trim()));
                    AppSet.SaveSystemSettingsConfig();
                    NTDMsg.TouchFlatMsgInfo("参数保存成功！");
                    LblTip.Text = "请先清空称台，然后点击【2.标定零点】按钮标定零点.";
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
        /// 零点标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnlSetZero_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (CheckData())
                {
                    AppSet.CurrentNTD910.CalibrationZero(WeighingPlatformNo);
                    NTDMsg.TouchFlatMsgInfo("零点标定成功.");
                    LblTip.Text = "请先将标定砝码放置到称台上，然后点击【3.砝码标定】按钮进行标定.";
                }
            }
            catch (Exception)
            {
                NTDMsg.TouchFlatMsgError("零点标定失败.");
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
        /// 砝码标定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalibrateWeight_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                decimal weightValue = DecimalHelper.Conversion(TxtWeightValue.Text.Trim());
                if (weightValue <= 0)
                {
                    NTDMsg.TouchFlatMsgInfo("请正确输入标定砝码重量.");
                    return;
                }
                if (CheckData())
                {
                    AppSet.CurrentNTD910.CalibrationSpan(weightValue, WeighingPlatformNo);
                    NTDMsg.TouchFlatMsgInfo("砝码标定保存成功.");
                    LblTip.Text = "请先清空称台，然后点击【4.保存标定零点】按钮保存标定零点.";
                }
            }
            catch (Exception)
            {
                NTDMsg.TouchFlatMsgError("砝码标定失败，请放入砝码.");
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
        /// 工厂置零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetFactroyZero_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (CheckData())
                {
                    AppSet.CurrentNTD910.CalibrationSaveZero(WeighingPlatformNo);
                    NTDMsg.TouchFlatMsgInfo("工厂置零成功.");
                    LblTip.Text = "";
                }
            }
            catch (Exception)
            {
                NTDMsg.TouchFlatMsgError("标定零点失败.");
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
                NTDMsg.TouchMsgError(ex.Message);
            }
        }

  
    }
}
