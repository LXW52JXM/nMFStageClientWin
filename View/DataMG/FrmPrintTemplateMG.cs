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
    public partial class FrmPrintTemplateMG : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        private List<FileInfo> AllData = new List<FileInfo>();  

        public FrmPrintTemplateMG()
        {
            InitializeComponent();
            DgvData.AutoGenerateColumns = false;
        } 
        private void FrmPrintTemplateMG_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshOrFilter();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
           
        }

        private void RefreshOrFilter()
        {
          
                AllData = FileHelper.GetFile(".\\Resources\\template", ".frx", false);
                if (DgvData.DataSource != null)
                {
                    this.BindingContext[DgvData.DataSource].SuspendBinding();
                }
                DgvData.DataSource = new List<object>();
                DgvData.DataSource = AllData;
                this.BindingContext[DgvData.DataSource].ResumeBinding();
        }

        private void PicRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshOrFilter();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void PicDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvData.SelectedRows.Count > 0)
                {
                    if (NTDMsg.TouchFlatMsgQuestion("确定要删除选中的数据吗？") == DialogResult.OK)
                    {
                        bool rst = true;
                        for (int i = 0; i < DgvData.SelectedRows.Count; i++)
                        {

                            int selRowIndex = DgvData.SelectedRows[i].Index;
                            FileHelper.DeleteFile(AllData[selRowIndex].FullName);
                        }
                        RefreshOrFilter();
                    }
                }
                else
                {
                    NTDMsg.TouchFlatMsgInfo("请选择要删除的数据.");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void PicClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (NTDMsg.TouchFlatMsgQuestion("确定要删除所有的数据吗？") == DialogResult.OK)
                { 
                     for (int i = 0; i < AllData.Count; i++)
                     { 
                         FileHelper.DeleteFile(AllData[i].FullName);
                     }
                     RefreshOrFilter();
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        } 


        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message) ;
            }
        }

        private void TsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvData.SelectedRows.Count > 0)
                {
                    if (NTDMsg.TouchFlatMsgComfirm("确定要删除选中的模板吗？") == DialogResult.OK)
                    {
                        bool rst = true;
                        for (int i = 0; i < DgvData.SelectedRows.Count; i++)
                        {

                            int selRowIndex = DgvData.SelectedRows[i].Index;
                            FileHelper.DeleteFile(AllData[selRowIndex].FullName);
                        }
                        RefreshOrFilter();
                    }
                }
                else
                {
                    NTDMsg.TouchFlatMsgInfo("请选择要删除的模板.");
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void TsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!NTDFunc.AuthorityVerification(AppSet.CurrentLoginUser.role_name, "管理员", out string msg))
                {
                    NTDMsg.TouchFlatMsgError(msg);
                    return;
                }
                var frm = new FrmEditReportTemplate();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void TsbCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmSelectPrintTemplate();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
    }
}
