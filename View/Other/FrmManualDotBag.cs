using Model;
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
    public partial class FrmManualDotBag : Form
    {
        public decimal ZapWeightValue = 0;//去掉的称重重量
        public decimal SurplusWeightValue = 0;//剩余称重重量
        public int? InputBags = 0;//输入袋数

        public decimal Net = 0;
        public decimal Tare = 0;

        AppSettings AppSet =>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        TextBox FocusTextBox = null;

        nmfs_task_details CurrentTaskDetails;

        decimal MaxBags = 0;//最大袋数

       

        public FrmManualDotBag(nmfs_task_details currentTaskDetails)
        {
            InitializeComponent();
            FormHelper.FormBottonCenter(this,  AppSet.FormWidth,  AppSet.FormHeight);
            CurrentTaskDetails = currentTaskDetails;
        }


        private void FrmManualDotBag_Load(object sender, EventArgs e)
        {
            TmrInit.Enabled = true;
        }

        private void TmrInit_Tick(object sender, EventArgs e)
        {
            TmrInit.Enabled = false;
            try
            {
                if (DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) <= 0)
                {
                    NTDMsg.TouchFlatMsgError("物料单重小于零，不允许点袋");
                    this.Close();
                    return;
                }

                TxtPartsCode.Text = CurrentTaskDetails.parts_id;
                TxtGoodName.Text = CurrentTaskDetails.parts_name;
                TxtEveryPackageWeight.Text = CurrentTaskDetails.parts_every_package_weight + CurrentTaskDetails.parts_weight_unit;//每袋重量
                TxtPeiFanStdW11eight.Text = CurrentTaskDetails.standard_weight + CurrentTaskDetails.weight_unit;//目标重量
                MaxBags = DecimalHelper.Conversion(Math.Floor(DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) / (DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit))))));
                TxtMaxBags.Text = MaxBags.ToString();
                TmrTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            LblInfo.Text = "输入" + TxtInputBags.Text.Trim() + "袋，剩余" + (DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - IntHelper.Conversion(TxtInputBags.Text.Trim()) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit))) + "" + CurrentTaskDetails.weight_unit;
        }

        private void FrmManualDotBag_FormClosing(object sender, FormClosingEventArgs e)
        {
            TmrInit.Enabled =  TmrTimer.Enabled = false;
        }

        private void TxtInputBags_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
        }

        private void TxtInputBags_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormHelper.TextBoxIsNumber((TextBox)sender, e);
        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DecimalHelper.Conversion(TxtInputBags.Text.Trim()) > MaxBags)
                {
                    NTDMsg.TouchFlatMsgError("已达到最大袋数");
                }
                else
                {
                    InputBags = IntHelper.Conversion(TxtInputBags.Text.Trim());
                    ZapWeightValue = DecimalHelper.Conversion(DecimalHelper.Conversion(InputBags) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit)));
                    SurplusWeightValue = DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - DecimalHelper.Conversion(InputBags) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit));
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
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

        private void FrmManualDotBag_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }

  
    }
}
