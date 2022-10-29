using HZH_Controls.Controls;
using Newtonsoft.Json;
using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NTDUserControlLib;

namespace nMFStageClientWin
{

    public partial class FrmSelectPrintLable : Form
    {
        public FileInfo SelectData = null;

        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;

       
        List<ucShowLable> ucShowDataList = new List<ucShowLable>();

        List<FileInfo> AllData = new List<FileInfo>();
        List<FileInfo> PageData = new List<FileInfo>();
      

        //分页参数
        int PageSize = 12;
        int CurrentPageIndex = 1;
        int TotalCount;
        int TotalPageCount = 1;


        public FrmSelectPrintLable()
        {
            InitializeComponent();
        }

        private void SetControlList()
        {
            ucShowDataList.Add(ucShowLable_0);
            ucShowDataList.Add(ucShowLable_1);
            ucShowDataList.Add(ucShowLable_2);
            ucShowDataList.Add(ucShowLable_3);
            ucShowDataList.Add(ucShowLable_4);
            ucShowDataList.Add(ucShowLable_5);
            ucShowDataList.Add(ucShowLable_6);
            ucShowDataList.Add(ucShowLable_7);
            ucShowDataList.Add(ucShowLable_8);
            ucShowDataList.Add(ucShowLable_9);  
            ucShowDataList.Add(ucShowLable_10);
            ucShowDataList.Add(ucShowLable_11);
        }



        private void FrmSelectContainer_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlList();

                //查询所有模板信息
                AllData = FileHelper.GetFile(".\\Resources\\template", ".frx", false);
                PageQuery(NTDPageEnum.None);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }


        private void PageQuery(NTDPageEnum p, int Page = 1)
        {
           
                switch (p)
                {
                    case NTDPageEnum.None:
                        {
                            CurrentPageIndex = 1;
                            break;
                        }
                    case NTDPageEnum.Previous:
                        {
                            if (CurrentPageIndex > 1)
                            {
                                CurrentPageIndex--; 
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是第一页.");
                                return;
                            }
                        }
                    case NTDPageEnum.Next:
                        {
                            if (CurrentPageIndex < TotalPageCount)
                            {
                                CurrentPageIndex++; 
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是最后一页.");
                                return;
                            }
                        }
                }

                PageData = PageHelper.GetPageList<FileInfo>(AllData, CurrentPageIndex, PageSize, out TotalPageCount);

                LblPageInfo.Text = $"{CurrentPageIndex} / {TotalPageCount}";

                if (AllData != null)
                {
                    ShowPageList(PageData);
                }
                else
                {
                    ClearPageList();
                }
        }

        private void ClearPageList()
        {
            for (int i = 0; i < ucShowDataList.Count; i++)
            {
                ucShowDataList[i].Tag = "";
                ucShowDataList[i].Visible = false;
            }
        }

        private void ShowPageList(List<FileInfo> pageData)
        {
            ClearPageList();
            int i = 0;
            foreach (var item in pageData)
            {
                // 更新块状显示数据
                ucShowDataList[i].Tag = item;
                if (ucShowDataList[i].Tag == null || string.IsNullOrWhiteSpace(ucShowDataList[i].Tag.ToString())) continue;

                ucShowDataList[i].Visible = true;
                ucShowDataList[i].Control_0 = Path.GetFileNameWithoutExtension(item.ToString());
                ucShowDataList[i].Control_1 = "创建时间: " + item.CreationTime;
                i++;
            }
        }
        

     

        private void ucShowData_0_Click(object sender, EventArgs e)
        {
            try
            {
                var p = (ucShowData_PnlContainLbl_Size15_2)sender;
                if (p.Tag == null) return;
                SelectData = (FileInfo)p.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void ucShowLable_11_Click(object sender, EventArgs e)
        {
            try
            {
                var p = (ucShowLable)sender;
                if (p.Tag == null) return;
                SelectData = (FileInfo)p.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
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
                      //  if (!BtnDel.Enabled) return;
                      //  BtnDel_Click(BtnDel, e);
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                var frm = new FrmPrintTemplateMG();
                frm.ShowDialog();

                //查询所有模板信息
                AllData = FileHelper.GetFile(".\\Resources\\", ".frx", false);
                PageQuery(NTDPageEnum.None);
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
                PageQuery(NTDPageEnum.Previous);
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
                PageQuery(NTDPageEnum.Next);
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


    }
}
