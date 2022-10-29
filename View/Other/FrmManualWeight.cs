using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NTDCommon;
using Model;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using NTDCommLib;

namespace nMFStageClientWin
{
    public partial class FrmManualWeight : Form
    {
        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;

        private TextBox FocusTextBox = null;
        private nmfs_task_details CurrentTaskDetails = new nmfs_task_details();

        public decimal Net = 0;
        public decimal Tare = 0;

        public FrmManualWeight(nmfs_task_details currentTaskDetails)
        {
                InitializeComponent();
                FormHelper.FormBottonCenter(this, AppSet.FormWidth, AppSet.FormHeight);
                CurrentTaskDetails = currentTaskDetails;
        }


        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Net < DecimalHelper.Conversion(CurrentTaskDetails.lower_limit) || Net > DecimalHelper.Conversion(CurrentTaskDetails.upper_limit))
                {
                    NTDMsg.TouchFlatMsgError("当前输入的净重值不在合格范围内，当前合格范围为" + CurrentTaskDetails.lower_limit + "—" + CurrentTaskDetails.upper_limit);
                    return;
                }
                this.DialogResult = DialogResult.OK;
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

        private void FrmPresetTare_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }

        private void TxtNet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Net = DecimalHelper.Conversion(TxtNet.Text.Trim());
                TxtGross.Text = (Net + Tare).ToString();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void TxtTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Tare = DecimalHelper.Conversion(TxtTare.Text.Trim());
                TxtGross.Text = (Net + Tare).ToString();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        private void TxtNet_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
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