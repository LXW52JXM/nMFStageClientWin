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
using System.Threading.Tasks;
using System.Windows.Forms;
using DBService;
using System.Threading;

namespace nMFStageClientWin
{
    public partial class FrmSelectContainer : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;
        List<nmfs_container> PageData = new List<nmfs_container>(); 
       
        List<ucShowContainer> ucShowContainerList = new List<ucShowContainer>();
        //分页参数
        int PageSize = 16;
        int CurrentPageIndex = 1;
        int TotalCount=0;
        int TotalPageCount = 1; 
      

        public nmfs_container SelectData = new nmfs_container();


        /// <summary>
        /// 物料属性
        /// </summary>
        string PartsContainerType = string.Empty;
        /// <summary>
        /// 是否验证容器
        /// </summary>
        int IsReviewContainer = 0;




        public FrmSelectContainer(string partsContainerType, int isReviewContainer)
        {
            InitializeComponent();
            PartsContainerType = partsContainerType;
            IsReviewContainer = isReviewContainer;
        }
        private void FrmSelectContainer_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlList();
                TmrTime.Enabled = true;
                PageQuery(NTDPageEnum.None);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
        }

        private void SetControlList()
        {
            ucShowContainerList.Add(ucShowContainer_0);
            ucShowContainerList.Add(ucShowContainer_1);
            ucShowContainerList.Add(ucShowContainer_2);
            ucShowContainerList.Add(ucShowContainer_3);
            ucShowContainerList.Add(ucShowContainer_4);
            ucShowContainerList.Add(ucShowContainer_5);
            ucShowContainerList.Add(ucShowContainer_6);
            ucShowContainerList.Add(ucShowContainer_7);
            ucShowContainerList.Add(ucShowContainer_8);
            ucShowContainerList.Add(ucShowContainer_9);
            ucShowContainerList.Add(ucShowContainer_10);
            ucShowContainerList.Add(ucShowContainer_11);
            ucShowContainerList.Add(ucShowContainer_12);
            ucShowContainerList.Add(ucShowContainer_13);
            ucShowContainerList.Add(ucShowContainer_14);
            ucShowContainerList.Add(ucShowContainer_15);
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
                        if (!BtnRefresh.Enabled) return;
                        BtnRefresh_Click(BtnRefresh, e);
                        break;
                    case (Keys.F5):

                        break;
                    case (Keys.F6):
                        if (!BtnPrevPage.Enabled) return;
                        BtnPrevPage_Click(BtnPrevPage, e);
                        break;
                    case (Keys.F7):

                        break;
                    case (Keys.F8):
                        if (!BtnNextPage.Enabled) return;
                        BtnNextPage_Click(BtnNextPage, e);
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
                if (IsRefreshTaskStatus()) return;

                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
        }

        /// <summary>
        /// 刷新任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                ThreadPool.QueueUserWorkItem(o => RefreshTask());
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
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
        /// 前一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                PageQuery(NTDPageEnum.Previous);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
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
        /// 下一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                if (IsRefreshTaskStatus()) return;

                PageQuery(NTDPageEnum.Next);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
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



        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Page"></param>
        private void PageQuery(NTDPageEnum p,  int Page = 1)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { PageQuery(p); })); return;
            }
            switch (p)
                {
                    case NTDPageEnum.None:
                        {
                            CurrentPageIndex = 1;
                            BtnPrevPage.Enabled = false;
                            BtnNextPage.Enabled = true;
                            break;
                        }
                    case NTDPageEnum.Previous:
                        {
                            if (CurrentPageIndex > 1)
                            {
                                CurrentPageIndex--;
                                BtnNextPage.Enabled = true;
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是第一页!");
                                return;
                            }
                        }
                    case NTDPageEnum.Next:
                        {
                            if (CurrentPageIndex < TotalPageCount)
                            {
                                CurrentPageIndex++;
                                BtnPrevPage.Enabled = true;
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是最后一页!");
                                return;
                            }
                        }
                }
                PageData = NmfsContainerService.GetPageDataByDic(CurrentPageIndex, PageSize,ref TotalCount,new Dictionary<string, object>());
                //DgvAllList.DataSource = PageData;

                if (TotalCount % PageSize == 0)
                {
                    TotalPageCount = TotalCount / PageSize;
                }
                else
                {
                    TotalPageCount = TotalCount / PageSize + 1;
                }
                LblPageInfo.Text = $"{CurrentPageIndex} / {TotalPageCount}";

                if (PageData != null)
                {
                    ShowPageList(PageData);
                    //ShowTaskStatus();
                }
                else
                {
                    ClearPageList();
                }
        }

        private void ClearPageList()
        {
            for (int i = 0; i < ucShowContainerList.Count; i++)
            {
                ucShowContainerList[i].Tag = "";
                ucShowContainerList[i].Visible = false;
            }
        }

        private void ShowPageList(List<nmfs_container> pageData)
        {
            ClearPageList();
            int i = 0;
            foreach (var data in pageData)
            {
                // 更新块状显示数据
                ucShowContainerList[i].Tag = data;
                ucShowContainerList[i].Visible = true;
                ucShowContainerList[i].Control_0 = "容器名称: " + data.name;
                ucShowContainerList[i].Control_1 = "容器编号: " + data.code;
                ucShowContainerList[i].Control_2 = "容器皮重: " + data.weight + " " + data.weight_unit;
                ucShowContainerList[i].Control_3 = "容器种类: " + data.type;
                i++;
            }
        }
        //private void ShowTaskStatus()
        //{
        //    //改变任务状态
        //    for (int i = 0; i < ucShowContainerList.Count; i++)
        //    {

        //        // 更新块状显示数据
        //        if (ucShowContainerList[i].Tag == null || string.IsNullOrWhiteSpace(ucShowContainerList[i].Tag.ToString())) continue;
        //        nmfs_container container = (nmfs_container)ucShowContainerList[i].Tag;
        //        ucShowContainerList[i].Ext1 = "容器编号：" + container.code;
        //        ucShowContainerList[i].Ext2 = "容器皮重：" + container.weight; 
        //        ucShowContainerList[i].Ext3 = "容器种类：" + container.type; 
        //    }
        //}

        private void Btn1_0_Click(object sender, EventArgs e)
        { 
            try
            {
                ucShowContainer b = (ucShowContainer)sender;
                if (b.Tag == null) return;

              
                SelectData = (nmfs_container)b.Tag;
                //验证容器
                if (IsReviewContainer == 1&&!string.IsNullOrEmpty(PartsContainerType))
                {
                    if (PartsContainerType != SelectData.type)
                    {
                        NTDMsg.TouchFlatMsgInfo("当前选择容器的物料属性不符合，请选择"+ PartsContainerType+"容器");
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
        }

      

        #region 同步服务器的数据
        private void RefreshTask()
        {
            RefreshTaskStatus = true;
            try
            {
                ShowControlText(LblTips, "开始获取服务器容器信息", Color.White, 100);
                ShowControlVisible(PnlLoading, true);
                string msg = string.Empty;
                //刷新任务和任务详情
                if (!ServiceInterface.GetHttpContainer(out msg))
                {
                    ShowControlText(LblTips, msg, Color.Red, 2000);
                }
                else
                {
                    ShowControlText(LblTips, msg, Color.White, 100);
                }
                PageQuery(NTDPageEnum.None);
                ShowControlVisible(PnlLoading, false);
            
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message); ;
            }
            finally
            { 
               RefreshTaskStatus = false;
            }
           }
           
         
         
        public void ShowControlText(Control control, string msg, Color textColor, int waitingTime)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => { ShowControlText(control, msg, textColor, waitingTime); })); Thread.Sleep(waitingTime < 0 ? 0 : waitingTime); return;
            }

            control.Text = msg;
            control.ForeColor = textColor;

        }
        public void ShowControlVisible(Control control, bool b)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { ShowControlVisible(control, b); })); return;
            }

            control.Visible = b;
        }

        bool RefreshTaskStatus = false;
        /// <summary>
        /// 判断是否正在刷新
        /// </summary>
        /// <returns></returns>
        private bool IsRefreshTaskStatus()
        {
            if (RefreshTaskStatus)
            {
                NTDMsg.TouchFlatMsgInfo("正在容器下载容器信息，不能点击！");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            try
            { 
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
            }
            catch (Exception ex)
            {

            }
        }

      
    }
}
