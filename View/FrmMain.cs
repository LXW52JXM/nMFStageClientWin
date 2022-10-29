using DBService;
using HZH_Controls.Controls;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NTDCommLib;
using NTDCommon;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace nMFStageClientWin
{

    public partial class FrmMain : Form
    {
        static AppSettings AppSet => AppSettings.AppSet;
        static SystemSettings SystemSet => AppSet.SystemSet;

        private TextBox FocusTextBox = null;
        /// <summary>
        /// 发送心跳线程
        /// </summary>
        public Thread SenderHeartbeatThread = null;


        /// <summary>
        /// socket 通道线程
        /// </summary>
        public Thread ReceiveThread;



        /// <summary>
        /// 是否正在从服务器拉取数据
        /// </summary>
        private bool RefreshTaskStatus = false;



        /// <summary>
        /// 初始化所有设备的线程
        /// </summary>
        public Thread InitAllTerminalDeviceThread;
        ~FrmMain()
        {
            try
            {
                //关闭心跳的线程
                if (SenderHeartbeatThread != null) SenderHeartbeatThread.Abort();
                //接收线程
                if (ReceiveThread != null) ReceiveThread.Abort();

                this.Dispose();
            }
            catch { }
        }
        public FrmMain()
        {
            InitializeComponent();
            try
            {
                //加载配置文件
                AppSet.LoadSystemSettingsConfig();//加载配置文件
                AppSet.SaveSystemSettingsConfig();//保存

                //删除log日志
                LogFileHelper.ClearLogFiles(DateTime.Now, SystemSet.LogFileDays);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("初始化配置文件出错：" + ex.Message);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                AppSet.FormWidth = this.Width;
                AppSet.FormHeight = this.Height;

                FormHelper.FormCenter(PnlLoading, this.Width, this.Height);
                NTDMsg.CanCountDown = SystemSet.NTDMsgCanCountDown;
                NTDMsg.Timeout = SystemSet.NTDMsgTimeout;

                //校验mac地址
                if (MacAddressCheck.CheckMacAddress(SystemInfoHelper.GetAllMacAddress(), out string macStr))
                {
                    SystemSet.DeviceCode = macStr.Replace("-", ""); ;
                    AppSet.SaveSystemSettingsConfig();//保存
                }
                else
                {
                    NTDMsg.TouchFlatMsgError("该设备未授权", false);
                    Environment.Exit(0);
                }
                //socket心跳的线程
                if (SenderHeartbeatThread != null) SenderHeartbeatThread.Abort();
                SenderHeartbeatThread = new Thread(SenderHeartbeatThreadFunc);
                SenderHeartbeatThread.IsBackground = true;
                SenderHeartbeatThread.Start();

                //启动socket接收的线程
                if (ReceiveThread != null) ReceiveThread.Abort();
                ReceiveThread = new Thread(ReceiveThreadFunc);
                ReceiveThread.IsBackground = true;
                ReceiveThread.Start();

                //初始化数据线程
                ThreadPool.QueueUserWorkItem(o => Init());

                TxtAccount.Focus();
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
                        if (!BtnScaleNo.Enabled) return;
                        BtnScaleNo_Click(BtnScaleNo, e);
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
                        if (!BtnSynchronous.Enabled) return;
                        BtnSynchronous_Click(BtnSynchronous, e);
                        break;
                    case (Keys.F8):
                        if (!BtnSetting.Enabled) return;
                        BtnSetting_Click(BtnSetting, e);
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
        /// 秤台切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnScaleNo_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;
                //判断当前是否有秤台集合
                if (AppSet.CurrentScaleList == null || AppSet.CurrentScaleList.Count <= 0)
                {
                    NTDMsg.TouchFlatMsgError("未有可切换的秤台");
                    return;
                }
                NTDFunc.ChangScaleDetails(false, AppSet.CurrentScaleList);
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


                if (IsRefreshTaskStatus()) return;
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
                this.Focus();
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
                if (IsRefreshTaskStatus()) return;
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
                if (IsRefreshTaskStatus()) return;
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
                if (IsRefreshTaskStatus()) return;
                var frm = new FrmPresetTare();
                var rst = frm.ShowDialog();
                if (rst == DialogResult.OK)
                {
                    AppSet.CurrentBalanceInterface.SetPresetTareWeight(frm.CurrentPresetTareValue);
                    //AppSet.CurrentWcb.PresetTareWeight = frm.CurrentPresetTareValue;
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
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSynchronous_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;
                ThreadPool.QueueUserWorkItem(o => Init());
                //Thread thred = new Thread(() => Init());
                //thred.IsBackground = true;
                //thred.Start();
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
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                TmrWeight.Enabled = false;
                if (new FrmLogin().ShowDialog() == DialogResult.OK)
                {
                    var nmfsLog = new nmfs_log();
                    nmfsLog.operation_time = DateTime.Now;
                    nmfsLog.type = "登录日志";
                    nmfsLog.operation_type = "登录";
                    nmfsLog.content = "登录终端设置界面";
                    //保存操作日志
                    nmfsLog.content = "[" + AppSet.CurrentLoginUser.username + "]登录[" + AppSet.CurrentTerminal.name + "]终端设置界面";
                    nmfsLog.user_account = AppSet.CurrentLoginUser.account;
                    nmfsLog.user_username = AppSet.CurrentLoginUser.username;
                    var sys_upload_data = new sys_upload_data();
                    sys_upload_data.cmd = "UploadsLog";
                    sys_upload_data.upload_data = JsonConvert.SerializeObject(nmfsLog, Formatting.Indented, AppSet.JsonSetting);
                    SysUploadDataService.Save(sys_upload_data);
                    AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);

                    var frm = new FrmMenu();
                    frm.ShowDialog();
                }




                //if (AppSet.CurrentLoginUser == null || AppSet.CurrentLoginUser.id <= 0)
                //{
                //    
                //}
                //else
                //{
                //    var frm = new FrmConfiguration();
                //    frm.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                TmrWeight.Enabled = true;
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }

        #endregion



        public void Init()
        {
            try
            {
                string msg = string.Empty;

                ShowControlVisible(PnlLoading, true);
                RefreshTaskStatus = true;

                //启动上传服务器信息线程
                if (AppSet.CurrentUploadServiceDataInterface != null) AppSet.CurrentUploadServiceDataInterface.Close();
                AppSet.CurrentUploadServiceDataInterface = new HttpUploadServiceData();
                AppSet.CurrentUploadServiceDataInterface.Init(SystemSet.UploadDataHttpIp, SystemSet.UploadDataHttpPort);

                ShowControlText(LblTips, "连接服务器", Color.White, 100);
                bool serverStatus = false;


                //http下拉终端的数据
                if (!ServiceInterface.GetHttpTerminal(out msg))
                {
                    ShowControlText(LblTips, msg, Color.Red, 1000);
                }
                else
                {

                    ShowControlText(LblTips, "获取服务器终端授权成功", Color.White, 100);
                    if (!ServiceInterface.GetHttpParameters(out msg))
                    {
                        ShowControlText(LblTips, msg, Color.Red, 1000);
                    }
                    else
                    {
                        ShowControlText(LblTips, msg, Color.White, 100);
                    }
                    if (!ServiceInterface.GetHttpUser(out msg))
                    {
                        ShowControlText(LblTips, msg, Color.Red, 1000);
                    }
                    else
                    {
                        ShowControlText(LblTips, msg, Color.White, 100);
                    }
                }

                //初始化所有秤台和打印机
                ThreadPool.QueueUserWorkItem(new WaitCallback(InitScaleDetailsListThread), NmfsTerminalDeviceService.GetData());

                //初始化所有秤台和打印机
                //if (InitAllTerminalDeviceThread != null) InitAllTerminalDeviceThread.Abort();
                //InitAllTerminalDeviceThread = new Thread(() => InitScaleDetailsListThread(NmfsTerminalDeviceService.GetData()));
                //InitAllTerminalDeviceThread.IsBackground = true;
                //InitAllTerminalDeviceThread.Start();
            }
            catch (Exception ex)
            {
                //      this.Close();
            }
            finally
            {
                ShowControlVisible(PnlLoading, false);
                RefreshTaskStatus = false;
            }
        }

        /// <summary>
        /// 用线程开启所有秤台实例
        /// </summary>
        /// <param name="currentScaleDetailsList"></param>
        public void InitScaleDetailsListThread(object ob)
        {

            try
            {
                #region 先关闭已经起来的秤和打印机
                BalanceInterface balanceInterfaceTemp = null;
                foreach (var item in AppSet.ExternalScaleConnectMap)
                {
                    balanceInterfaceTemp = (BalanceInterface)item.Value;
                    if (balanceInterfaceTemp != null) balanceInterfaceTemp.Close();
                }
                AppSet.ExternalScaleConnectMap = new Dictionary<object, object>();

                //设备打印机初始化
                PrintInterface printInterfaceTemp = null;
                foreach (var item in AppSet.ExternalPrinterConnectMap)
                {
                    printInterfaceTemp = (PrintInterface)item.Value;
                    if (printInterfaceTemp != null) printInterfaceTemp.Close();
                }
                AppSet.ExternalPrinterConnectMap = new Dictionary<object, object>();

                //初始化所有秤台标定的数据
                AppSet.CalbrationMap = new Dictionary<string, string[]>();
                #endregion

                List<nmfs_terminal_device> currentScaleList = ob as List<nmfs_terminal_device>;

                if (currentScaleList == null || currentScaleList.Count <= 0) return;

                //保存秤台信息到全局变量
                AppSet.CurrentScaleList = currentScaleList.Where(o => o.hardware_type == "秤").ToList();


                //初始化内部称的实例
                try
                {
                    // 判断是否有内部秤
                    if (AppSet.CurrentScaleList.Where(it => it.impl_type == "BalanceNTD910").Count() > 0)
                    {
                        if (AppSet.CurrentNTD910 != null) AppSet.CurrentNTD910.ReleaseAll();
                        AppSet.CurrentNTD910 = new NTD910WeightLib.NTD910Weight(SystemSet.CurrentNTD910SerialPort);
                        Thread.Sleep(100);
                        AppSet.CurrentNTD910.Init(SystemSet.CurrentNTD910BalanceNumber);
                    }
                }
                catch (Exception ex)
                {
                    LogFileHelper.AddLog("初始化内部称出错：" + ex.Message);
                }

                //临时数据
                var deviceDetails = new nmfs_terminal_device();
                var scaleDetailsList = new List<nmfs_terminal_device>();
                string msg = string.Empty;
                balance_entity balanceEntity = new balance_entity();
                foreach (var item in currentScaleList)
                {
                    //判断设备是否为秤台
                    switch (item.hardware_type)
                    {
                        case ("秤"):
                            //所有称台巡检的数据
                            AppSet.CalbrationMap.Add(item.id.ToString(), new string[9]);

                            BalanceInterface interfaceScale = null;
                            if (ReflectionHelper.CreateInstance<BalanceInterface>(Assembly.GetExecutingAssembly().GetName().Name, "NTDCommon." + item.impl_type, out interfaceScale, out msg))
                            {
                                balanceEntity = new balance_entity();

                                balanceEntity.communication_mode = item.communication_mode;
                                balanceEntity.output_type = item.output_type;
                                balanceEntity.serial_port = item.serial_port;
                                balanceEntity.baud_rate = item.baud_rate;
                                balanceEntity.ip = item.ip;
                                balanceEntity.port = item.port;
                                balanceEntity.device_number = item.device_no;
                                balanceEntity.unit = item.weight_unit;
                                interfaceScale.SetSingleScaleDetails(balanceEntity);
                                interfaceScale.InitAll();
                            }
                            else
                            {
                                interfaceScale = null;
                            }
                            AppSet.ExternalScaleConnectMap.Add(item.id, interfaceScale);
                            break;
                        /*  case ("打印机"):
                              PrintInterface printInterface = new PrintZPLCommand();
                              printInterface.InitAll(item.communication_mode, item.serial_port, IntHelper.Conversion(item.baud_rate), item.ip, IntHelper.Conversion(item.port));
                              AppSet.ExternalPrinterConnectMap.Add(item.code, printInterface);
                              break;*/
                        default:
                            break;
                    }
                }
                NTDFunc.ChangScaleDetails(true, AppSet.CurrentScaleList);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //如果不关闭会一直运行
                //  if (interfaceScale != null) interfaceScale.Close();
            }
        }

        #region 通过socekt

        private byte[] CurrentReceiveThreadFuncBuffer = new byte[0];

        /// <summary>
        /// 接收socket数据的方法
        /// </summary>
        void ReceiveThreadFunc()
        {
            string msg = string.Empty;
            while (true)
            {
                try
                {
                    CurrentReceiveThreadFuncBuffer = SocketHelper.ReadLine(AppSet.CurrentTcpClient?.CurrentTcpClient?.Client);
                    Dictionary<string, string> res = JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(CurrentReceiveThreadFuncBuffer, 0, CurrentReceiveThreadFuncBuffer.Length));
                    res.Add("terminalId", SystemSet.CurrentTerminalId);


                    if (res.ContainsKey("taskSerialNumber") && res.ContainsKey("statusBatching"))
                    {
                        if (AppSet.CurrentTask != null && !string.IsNullOrEmpty(AppSet.CurrentTask.id) && AppSet.CurrentTask.serial_number == res["taskSerialNumber"])
                        {
                            AppSet.CurrentTask.status_batching = IntHelper.Conversion(res["statusBatching"]);
                        }

                        var entity = new nmfs_task();
                        entity.serial_number = res["taskSerialNumber"];
                        if (NmfsTaskService.IsExistSingleDataByEntity(entity, out entity))
                        {
                            entity.status_batching = IntHelper.Conversion(res["statusBatching"]);
                            NmfsTaskService.Save(entity);
                        }
                    }
                    ServiceInterface.PostHttpUploadSuccessMessage(JsonConvert.SerializeObject(res, Formatting.None), out msg);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Thread.Sleep(5000);
                }
            }
        }


        private static byte[] CurrentSenderHeartbeatThreadFuncBuffer = new byte[0];

        //判断失败次数的临时变量
        private static int SenderHeartbeatThreadFuncI = 0;

        /// <summary>
        /// 心跳发送
        /// </summary>
        public static void SenderHeartbeatThreadFunc()
        {
            string ip = SystemSet.UploadDataSocketIp;
            int port = SystemSet.UploadDataSocketPort;
            // 打开socket服务器连接
            if (AppSet.CurrentTcpClient != null) AppSet.CurrentTcpClient.Close();
            AppSet.CurrentTcpClient.Init(SystemSet.UploadDataSocketIp, SystemSet.UploadDataSocketPort);
            if (AppSet.CurrentTcpClient.GetConnectStatic())
            {
                AppSet.CurrentServiceConnectStatus = true;
            }
            else
            {
                AppSet.CurrentServiceConnectStatus = false;
            }
            while (true)
            {
                try
                {
                    if (AppSet.CurrentTcpClient.GetConnectStatic() == false && SenderHeartbeatThreadFuncI <= 20)
                    {
                        SenderHeartbeatThreadFuncI++;
                        Thread.Sleep(5000);
                        continue;
                    }

                    if (SenderHeartbeatThreadFuncI > 20 || ip != SystemSet.UploadDataSocketIp || port != SystemSet.UploadDataSocketPort)
                    {
                        ip = SystemSet.UploadDataSocketIp;
                        port = SystemSet.UploadDataSocketPort;
                        AppSet.CurrentTcpClient.Init(SystemSet.UploadDataSocketIp, SystemSet.UploadDataSocketPort);
                    }

                    SenderHeartbeatThreadFuncI = 0;
                    CurrentSenderHeartbeatThreadFuncBuffer = Encoding.UTF8.GetBytes("[PING][" + SystemSet.CurrentTerminalId + "][" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "]" + "\x0D\x0A"); //加结束符 // length of the text "Hello world!"//FIXME
                    SocketHelper.Send(AppSet.CurrentTcpClient.CurrentTcpClient.Client, CurrentSenderHeartbeatThreadFuncBuffer, 0, CurrentSenderHeartbeatThreadFuncBuffer.Length, 10000);
                    AppSet.CurrentServiceConnectStatus = true;
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    AppSet.CurrentServiceConnectStatus = false;
                    Thread.Sleep(5000);
                    AppSet.CurrentTcpClient.Init(SystemSet.UploadDataSocketIp, SystemSet.UploadDataSocketPort);
                }
            }
        }
        #endregion



        public void ShowControlVisible(Control control, bool b)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ShowControlVisible(control, b); })); return;
            }

            control.Visible = b;
        }

        /// <summary>
        /// 显示启动信息
        /// </summary>
        /// <param name="info">启动信息</param>
        public void ShowControlText(Control control, string msg, Color textColor, int waitingTime)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => { ShowControlText(control, msg, textColor, waitingTime); })); Thread.Sleep(waitingTime < 0 ? 0 : waitingTime); return;
            }
            control.Text = msg;
            control.ForeColor = textColor;

        }


        private void TmrWeight_Tick(object sender, EventArgs e)
        {
            try
            {
                LblSysTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                switch (AppSet.CurrentServiceConnectStatus)
                {
                    case (true):
                        PicWifi0.Visible = false;
                        PicWifi.Visible = true;
                        break;
                    case (false):
                        PicWifi.Visible = false;
                        PicWifi0.Visible = true;
                        break;
                    default:
                        PicWifi.Visible = false;
                        PicWifi0.Visible = false;
                        break;
                }
                if (AppSet.CurrentBalanceInterface == null) return;
                //if (!isOk)
                //{
                //    try
                //    {  
                //        if (AppSet.CurrentNTD910 != null) AppSet.CurrentNTD910.ReleaseAll();
                //        AppSet.CurrentNTD910 = new NTD910Weight(AppSet.CurrentScale.serial_port);
                //        AppSet.CurrentNTD910.Init(IntHelper.Conversion(AppSet.CurrentScale.device_no));
                //        isOk = true;
                //    }
                //    catch (Exception ex)
                //    {
                //        isOk = true;
                //        NTDMsg.TouchFlatMsgError("错误："+ex.Message);
                //    }
                //}
                LblSystemName.Text = AppSet.CurrentScale.name + " Max:" + AppSet.CurrentScale.range_no + AppSet.CurrentScale.weight_unit + " e:" + AppSet.CurrentScale.divison + AppSet.CurrentScale.weight_unit + " Min:" + AppSet.CurrentScale.min_weight_value + AppSet.CurrentScale.weight_unit;
                LblSystemName.Font = new Font("微软雅黑", 20f, FontStyle.Bold);
                LblSystemName.TextAlign = ContentAlignment.MiddleLeft;
                AppSet.CurrentWCB = AppSet.CurrentBalanceInterface.GetSingleValue();

                LblStable.Visible = !AppSet.CurrentWCB.Stable;
                LblZero.Visible = AppSet.CurrentWCB.ZeroFlag;
                LblUnitNet.Text = LblUnitTare.Text = LblUnitGross.Text = AppSet.CurrentWCB.Unit.ToString();
                if (AppSet.CurrentWCB.UnderOrOverLoadFlag)
                {
                    LblNet.Text = AppSet.CurrentWCB.UnderOrOverLoadFlagStr;
                    LblGross.Text = "------";
                    LblTare.Text = "------";
                    return;
                }
                LblNet.Text = AppSet.CurrentWCB.GetNetWeight().ToString();
                LblGross.Text = AppSet.CurrentWCB.GetGrossWeight().ToString();
                LblTare.Text = AppSet.CurrentWCB.GetTareWeight().ToString();
                LblIsNet.Visible = AppSet.CurrentWCB.IsSetTareFlag;
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("错误：" + ex.ToString());
            }
        }

        //private void button22_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (null != FocusTextBox)
        //        {
        //            Button b = (Button)sender;
        //            if (b.Text.Trim() == "全键盘")
        //            {
        //                var frm = new FrmChineseKeyboard("", "", AppSet.DBconn);
        //                if (frm.ShowDialog() == DialogResult.OK)
        //                {
        //                    FocusTextBox.Text = frm.FocusTextBox.Text.Trim();
        //                }
        //            }
        //            else
        //            {
        //                NTDKeyBoardHelper.KeyboardClickFunc((Button)sender, FocusTextBox);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        NTDMsg.TouchFlatMsgError(ex.Message);
        //    }

        //}

        private void ucTxtAccount_Enter(object sender, EventArgs e)
        {
            try
            {
                FocusTextBox = (TextBox)sender;
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }


        private bool IsRefreshTaskStatus()
        {
            if (RefreshTaskStatus)
            {
                NTDMsg.TouchFlatMsgInfo("正在初始化系统...！");
                return true;
            }
            else
            {
                return false;
            }

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = new nmfs_user();
            var nmfsLog = new nmfs_log();
            nmfsLog.operation_time = DateTime.Now;
            nmfsLog.type = "登录日志";
            nmfsLog.operation_type = "登录";
            try
            {

                TmrWeight.Enabled = false;
                if (IsRefreshTaskStatus()) return;
                string account = TxtAccount.Text.Trim();
                string password = TxtPwd.Text.Trim();

                if (string.IsNullOrEmpty(account))
                {
                    NTDMsg.TouchFlatMsgInfo("用户名不能为空！");
                    TxtAccount.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    NTDMsg.TouchFlatMsgInfo("密码不能为空！");
                    TxtPwd.Focus();
                    return;
                }
                //超级管理员登录
                if (account == "0000" && password == "9999")
                {
                    user = new nmfs_user();
                    {
                        user.id = "9999";
                        user.account = "0000";
                        user.username = "管理员";
                        user.password = "9999";
                        user.role_name = "超级管理员";
                    }
                    //保存登录人信息到全局
                    AppSet.CurrentLoginUser = user;
                }
                else
                {
                    //密码MD5加密
                    password = MD5Helper.MD5Return(password);
                    user = NmfsUserService.UserLoginAccount
                        (account);
                    if (user == null)
                    {
                        NTDMsg.TouchFlatMsgError("用户名不存在，请重新输入！");
                        return;
                    }

                    //查询密码是否出错
                    user = NmfsUserService.UserLogin(account, password);
                    if (user == null)
                    {
                        NTDMsg.TouchFlatMsgError("密码输入错误，请重新输入！");
                        return;
                    }
                    //保存登录人信息到全局
                    AppSet.CurrentLoginUser = user;
                }


                //保存操作日志
                nmfsLog.content = "[" + user.username + "]登录[" + AppSet.CurrentTerminal.name + "]终端";
                nmfsLog.user_account = user.account;
                nmfsLog.user_username = user.username;
                var sys_upload_data = new sys_upload_data();
                sys_upload_data.cmd = "UploadsLog";
                sys_upload_data.upload_data = JsonConvert.SerializeObject(nmfsLog, Formatting.Indented, AppSet.JsonSetting);
                SysUploadDataService.Save(sys_upload_data);
                AppSet.CurrentUploadServiceDataInterface.AddUploadsDataQueue(sys_upload_data);

                switch (AppSet.CurrentTerminal.type)
                {
                    case ("领料"):

                        NTDMsg.TouchFlatMsgError("暂无领料功能");
                        break;
                    case ("配料"):

                        //筛选出秤台需要强制校准的
                        if (AppSet.CurrentScaleList != null && AppSet.CurrentScaleList.Count > 0)
                        {
                            var scaleList = AppSet.CurrentScaleList.Where(it => it.force_calibration == 1).OrderBy(it => it.device_no).ToList();
                            if (scaleList.Count > 0)
                            {
                                if (new FrmVerifyCalibration(scaleList).ShowDialog() != DialogResult.OK) return;
                            }
                        }
                        new FrmSelectTask().ShowDialog();
                        break;
                    case ("投料"):
                        NTDMsg.TouchFlatMsgError("暂无投料功能");
                        break;
                    default:
                        NTDMsg.TouchFlatMsgError("当前终端未授权");
                        break;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("登录窗口加载出错" + ex.ToString());
            }
            finally
            {
                AppSet.CurrentLoginUser = new nmfs_user();
                TxtAccount.Text = "";
                TxtPwd.Text = "";
                TxtAccount.Focus();
                TmrWeight.Enabled = true;
            }
        }




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
