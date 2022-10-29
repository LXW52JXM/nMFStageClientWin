using NTDCommLib;
using NTDCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nMFStageClientWin
{
    public partial class FrmPresetTare : Form
    {
        AppSettings AppSet =>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        TextBox FocusTextBox = null;

        //当前皮重值
        public string CurrentPresetTareValue;
        public FrmPresetTare()
        {

            InitializeComponent();
            FormHelper.FormBottonCenter(this,  AppSet.FormWidth,  AppSet.FormHeight);
        }


        private void TxtTareValue_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
        }


        private void TxtTareValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormHelper.TextBoxIsIntOrDouble((TextBox)sender, e);
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentPresetTareValue = TxtTareValue.Text.Trim();
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

        private void FrmPresetTare_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
    }
}
