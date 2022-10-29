using Model;
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
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmVerifyCalibration : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        //当前秤台的实例
        BalanceInterface CurrentBalanceInterface = null;
        //重量数据
        NTDWeightCoreBean CurrentWcb = new NTDWeightCoreBean();
        //当前选择的秤台索引

        int CurrentDeviceDetailsIndex =0;
        //需要校准的称台
        List<nmfs_terminal_device> CurrentDeviceDetailsList = new List<nmfs_terminal_device>();
        //需要校验的的设备详情
        nmfs_terminal_device CurrentVerifyDeviceDetails = new nmfs_terminal_device();

        //传参的设备详情
        nmfs_terminal_device CurrentDeviceDetails = new nmfs_terminal_device();

        #region 巡检的参数
        bool IsVerifyCalibration = false;//是否标定
        bool IsCheckStatus = true;//是否标定成功
        int CalibrationTimes;//标定次数
        int CalibrationThreshold;//标定阀值
        decimal ShowWeight;//显示重量
        decimal ResetWeight;   //9d 清零标
        decimal MinLoadWeight;  //100d //最小标定值
        decimal StandWeight;//标定重量
        decimal Tolerance;//上下限 
        #endregion

        public FrmVerifyCalibration(List<nmfs_terminal_device> terminalDeviceList)
        {
            InitializeComponent(); 
        

            CurrentDeviceDetailsList = terminalDeviceList;
        }

        public FrmVerifyCalibration(nmfs_terminal_device nmfs_terminal_device)
        {
            InitializeComponent(); 
          
            CurrentDeviceDetails = nmfs_terminal_device;
        }

        private void FrmVerifyCalibration_Load(object sender, EventArgs e)
        {
            try
            {

                PicP1.Image = nMFStageClientWin.Properties.Resources.BtnP0_BackgroundImage1;
                PicP2.Image = nMFStageClientWin.Properties.Resources.BtnP1_BackgroundImage1;
                PicP3.Image = nMFStageClientWin.Properties.Resources.BtnP2_BackgroundImage1;
                PicP4.Image = nMFStageClientWin.Properties.Resources.BtnP3_BackgroundImage1;
                PicP5.Image = nMFStageClientWin.Properties.Resources.BtnP4_BackgroundImage1;
                PicP1.Image = GraphicsImageHelper.UpdatePreview(PicP1.Image, "未校验", new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);
                PicP2.Image = GraphicsImageHelper.UpdatePreview(PicP2.Image, "未校验", new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);
                PicP3.Image = GraphicsImageHelper.UpdatePreview(PicP3.Image, "未校验", new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);
                PicP4.Image = GraphicsImageHelper.UpdatePreview(PicP4.Image, "未校验", new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);
                PicP5.Image = GraphicsImageHelper.UpdatePreview(PicP5.Image, "未校验", new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);

                // CurrentWcb = new NTDWeightCoreBean();//称台重量清除
                if (CurrentDeviceDetails != null && !string.IsNullOrEmpty(CurrentDeviceDetails.id))
                {
                    CurrentVerifyDeviceDetails = CurrentDeviceDetails;
                    //保存校称信息
                    if (AppSet.CalbrationMap.ContainsKey(CurrentVerifyDeviceDetails.id.ToString()))
                    {

                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][5] = AppSet.CurrentLoginUser.account;
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][6] = AppSet.CurrentLoginUser.username;
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][7] = CurrentVerifyDeviceDetails.counter_weight.ToString();
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    //AppSet.CurrentScaleList = AppSet.CurrentScaleList.FindAll(delegate(nmfs_terminal_device o)
                    //{ if (o.id == CurrentDeviceDetails.id) { o.check_time = DateTime.Now; o.check_user_account = AppSet.CurrentLoginUser.account; o.check_user_name = AppSet.CurrentLoginUser.name; } return o.id > 0; });
                }
                else
                {
                    //判断是否有需要检验的称台
                    if (CurrentDeviceDetailsList == null || CurrentDeviceDetailsList.Count <= 0)
                    {
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    //获取第一个秤台
                    CurrentVerifyDeviceDetails = CurrentDeviceDetailsList[CurrentDeviceDetailsIndex];
                    //保存校称信息
                    if (AppSet.CalbrationMap.ContainsKey(CurrentVerifyDeviceDetails.id.ToString()))
                    {
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][5] = AppSet.CurrentLoginUser.account;
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][6] = AppSet.CurrentLoginUser.username;
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][7] = CurrentVerifyDeviceDetails.counter_weight.ToString();
                        AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    }
                    //AppSet.CurrentScaleList = AppSet.CurrentScaleList.FindAll(delegate(nmfs_terminal_device o)
                    //{ if (o.id == CurrentDeviceDetails.id) { o.check_time = DateTime.Now; o.check_user_account = AppSet.CurrentLoginUser.account; o.check_user_name = AppSet.CurrentLoginUser.name; } return o.id > 0; });
                }
                CurrentBalanceInterface = NTDFunc.SelectBalanceInterface(CurrentVerifyDeviceDetails.id);
                if (CurrentBalanceInterface == null)
                {
                    NTDMsg.TouchFlatMsgInfo("未找到该秤台的实例");
                    return;
                }
                else
                {
                    TmrWeight.Enabled = true;
                } 
                CalibrationTimes = 0;
                IsVerifyCalibration = false;
                IsCheckStatus = true;
                ResetWeight = DecimalHelper.Conversion(CurrentVerifyDeviceDetails.divison) * 9;
                MinLoadWeight = DecimalHelper.Conversion(CurrentVerifyDeviceDetails.divison) * 10;
                StandWeight = DecimalHelper.Conversion(CurrentVerifyDeviceDetails.counter_weight);
                Tolerance = DecimalHelper.Conversion(CurrentVerifyDeviceDetails.counter_weight_bound);

                BtnScaleName.Text = CurrentVerifyDeviceDetails.name;
                BtnStandardWeight.Text = StandWeight + CurrentVerifyDeviceDetails.weight_unit;
                switch (AppSet.CurrentLoginUser.role_name)
                {
                    default:
                    case ("仪表操作员"):
                        CalibrationThreshold = 1;
                        PicP1.Enabled = true;
                        PicP1.Visible = true;
                        PicP2.Visible = PicP3.Visible = PicP4.Visible = PicP5.Visible = false;
                        break;
                    case ("仪表管理员"):
                    case ("超级管理员"):
                        
                        CalibrationThreshold = 5;

                        PicP1.Enabled = PicP2.Enabled = PicP3.Enabled = PicP4.Enabled = PicP5.Enabled = true;
                        PicP1.Visible = PicP2.Visible = PicP3.Visible = PicP4.Visible = PicP5.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
        }
       


   

        private void WeightUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentBalanceInterface == null) return;
                CurrentWcb = CurrentBalanceInterface.GetSingleValue();

                ShowWeight = DecimalHelper.Conversion(CurrentWcb.GetNetWeight());
                BtnWeight.Text = ShowWeight + " " + CurrentWcb.Unit;

                if (ShowWeight < ResetWeight)
                {
                    IsVerifyCalibration = false;
                }
                //判断称台单位是否一致
                if (CurrentWcb.Stable)
                {
                    if (!CurrentWcb.Unit.ToString().Equals(CurrentVerifyDeviceDetails.weight_unit))
                    {
                        TmrWeight.Enabled = false;
                        NTDMsg.TouchFlatMsgError(CurrentVerifyDeviceDetails.name + "在管理端的单位为" + CurrentVerifyDeviceDetails.weight_unit + "，称台实际读取的单位为" + CurrentWcb.Unit + "，请重新标定称台或者在管理端设置秤台");
                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // PopMessage.Show(PopStyle.Normal, "提示", ex.Message, 0);
            }
        }



        private void BtnP_Click(object sender, EventArgs e)
        {
            try
            {
                Button p = (Button)sender;

                Image image;
                switch (IntHelper.Conversion(p.Tag))
                {
                    default:
                    case (0):
                        image = nMFStageClientWin.Properties.Resources.BtnP0_BackgroundImage1;
                        break;
                    case (1):
                        image = nMFStageClientWin.Properties.Resources.BtnP1_BackgroundImage1;
                        break;
                    case (2):
                        image = nMFStageClientWin.Properties.Resources.BtnP2_BackgroundImage1;
                        break;
                    case (3):
                        image = nMFStageClientWin.Properties.Resources.BtnP3_BackgroundImage1;
                        break;
                    case (4):
                        image = nMFStageClientWin.Properties.Resources.BtnP4_BackgroundImage1;
                        break;
                }
                if (ShowWeight < ResetWeight)
                {
                    NTDMsg.TouchFlatMsgInfo("请先加入砝码！");
                    return;
                }
                if (IsVerifyCalibration == true && ShowWeight > MinLoadWeight)
                {
                    NTDMsg.TouchFlatMsgInfo(" 请先从秤上拿下砝码！");
                    return;
                }
                p.Enabled = false;
                p.Image = GraphicsImageHelper.UpdatePreview(image, ShowWeight.ToString(), new Font("宋体", 14F, FontStyle.Bold), new SolidBrush(Color.DodgerBlue), 40, 120);

                //保存标定的值
                if (AppSet.CalbrationMap.ContainsKey(CurrentVerifyDeviceDetails.id.ToString()))
                {
                    AppSet.CalbrationMap[CurrentVerifyDeviceDetails.id.ToString()][IntHelper.Conversion(p.Tag)] = ShowWeight.ToString();
                }


                if (ShowWeight < StandWeight - Tolerance || ShowWeight > StandWeight + Tolerance)
                {
                    IsCheckStatus = false;
                    // b.BackColor = Color.Red;
                }
                else
                {
                    // b.BackColor = Color.DarkRed;
                }
                CalibrationTimes++;
                IsVerifyCalibration = true;
                if (CalibrationTimes >= CalibrationThreshold)
                {
                    //是否强行通过
                    if (CurrentVerifyDeviceDetails.force_pass == 1)
                    {
                        BtnSkip_Click(BtnSkip, e);
                    }
                    else
                    {

                        if (!IsCheckStatus)
                        {
                            NTDMsg.TouchFlatMsgInfo("秤台检定未通过，请重新检定!");
                            FrmVerifyCalibration_Load(this, e);
                        }
                        else
                        {
                            if (CurrentDeviceDetails != null && !string.IsNullOrEmpty(CurrentDeviceDetails.id))
                            {
                                DialogResult = DialogResult.OK;
                                this.Dispose();
                                return;
                            }
                            CurrentDeviceDetailsIndex++;
                            if (CurrentDeviceDetailsList.Count <= CurrentDeviceDetailsIndex)
                            {
                                DialogResult = DialogResult.OK;
                                this.Dispose();
                                return;
                            }

                             FrmVerifyCalibration_Load(sender, e);
                       
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
        }
        private void FrmVerifyCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrWeight.Enabled = false;
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
                      
                        break;
                    case (Keys.F8):
                        if (!BtnSkip.Enabled) return;
                        BtnSkip_Click(BtnSkip, e);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
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
                NTDMsg.TouchFlatMsgError(ex.Message); ;
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
        /// 强制通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSkip_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否强行通过
                if (CurrentVerifyDeviceDetails.force_pass == 1)
                {
                    if (CurrentDeviceDetails != null && !string.IsNullOrEmpty(CurrentDeviceDetails.id))
                    {
                        DialogResult = DialogResult.OK;
                        this.Dispose();
                        return;
                    }
                    CurrentDeviceDetailsIndex++;
                    if (CurrentDeviceDetailsList.Count <= CurrentDeviceDetailsIndex)
                    {
                        DialogResult = DialogResult.OK;
                        this.Dispose();
                        return;
                    }

                    FrmVerifyCalibration_Load(this, e);
                }
                else
                {
                    NTDMsg.TouchFlatMsgInfo("该称台不能校准强行通过");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        #endregion
    }
}
