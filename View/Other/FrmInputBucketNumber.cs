using NTDCommLib;
using NTDCommon; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Drawing.Drawing2D;

namespace nMFStageClientWin
{
    public partial class FrmInputBucketNumber : Form
    {
        public bool IsSetTareAndSave = false;

        public nmfs_container SelectData = new nmfs_container();
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

    
        /// <summary>
        /// 物料属性
        /// </summary>
        string PartsContainerType = string.Empty;
        /// <summary>
        /// 是否验证容器
        /// </summary>
        int IsReviewContainer = 0;

    
        public FrmInputBucketNumber(string partsContainerType, int isReviewContainer)
        {
            InitializeComponent();
            FormHelper.FormBottonCenter(this,  AppSet.FormWidth,  AppSet.FormHeight);
            PartsContainerType = partsContainerType;
            IsReviewContainer = isReviewContainer;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IsSetTareAndSave = false;
                DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnSetTareAndSave_Click(object sender, EventArgs e)
        {
            try
            {
                IsSetTareAndSave = true;
                DialogResult = DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
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

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSelectContainer frm = new FrmSelectContainer(PartsContainerType, IsReviewContainer);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SelectData = frm.SelectData;
                    TxtContainerCode.Text = SelectData.code;
                    TxtContainerName.Text = SelectData.name;
                    TxtTareValue.Text = SelectData.weight + SelectData.weight_unit;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void FrmInputBucketNumber_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
    }
}
