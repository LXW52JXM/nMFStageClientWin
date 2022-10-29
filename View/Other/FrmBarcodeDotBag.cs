using DBService;
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
    public partial class FrmBarcodeDotBag : Form
    {

        AppSettings AppSet => AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;

        Dictionary<string, string> QueryDic = new Dictionary<string, string>();

        Dictionary<string, object> ParamtersDic = new Dictionary<string, object>();//一条解析规则的map
        List<Dictionary<string, object>> ParamtersDicList = new List<Dictionary<string, object>>();//全部的解析规则的集合

        nmfs_task_details CurrentTaskDetails = new nmfs_task_details();
        List<nmfs_parameters> CurrentParamtersList = new List<nmfs_parameters>();

        List<string> stringList = new List<string>();

        //自定义表的类型
        string ParamtersType = "扫码点袋";

        //解析字段
        string Context = string.Empty;
        string FieldName = string.Empty;
        int StartPosition = 0;
        int Length = 0;

        //串口扫码枪的类
        ReadScanCode CurrentReadScanCode = new ReadScanCode();

        public decimal MaxBags = 0;//最大袋数
        public decimal ZapWeightValue = 0;//去掉的称重重量
        public decimal SurplusWeightValue = 0;//剩余称重重量
        public int? InputBags = 0;//输入袋数


        public FrmBarcodeDotBag(nmfs_task_details currentTaskDetails)
        {
            InitializeComponent();
            FormHelper.FormBottonCenter(this, AppSet.FormWidth, AppSet.FormHeight);
            CurrentTaskDetails = currentTaskDetails;
        }


        private void ShowPageList(List<string> pageData)
        {
            ucShowData_PnlContainLbl_Size15_2.RefreshPnl(pageData);
        }




        private void FrmBarcodeDotBag_Load(object sender, EventArgs e)
        {
            try
            {
                TmrInit.Enabled = true;
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
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
                nmfs_parameters paramters = new nmfs_parameters();

                paramters = new nmfs_parameters();
                paramters.type = ParamtersType;
                paramters.status = 1;
                CurrentParamtersList = NmfsParametersService.GetDataByEntity(paramters);

                if (CurrentParamtersList.Count > 0)
                {
                    foreach (var item in CurrentParamtersList)
                    {
                        ParamtersDic = new Dictionary<string, object>();
                        var array = item.key_value.Split(',');
                        foreach (string data in array)
                        {
                            if (string.IsNullOrEmpty(data)) continue;
                            var str = data.Split('=');

                            if (ParamtersDic.ContainsKey(str[0].Trim())) continue;
                            ParamtersDic.Add(str[0].Trim(), str[1].Trim());
                        }
                        ParamtersDicList.Add(ParamtersDic);
                    }

                }
                else
                {
                    NTDMsg.TouchFlatMsgError("暂无：条码复核解析规则");
                    this.Close();
                    this.Dispose();
                    return;
                }
                TxtPartsCode.Text = CurrentTaskDetails.parts_id;
                TxtGoodName.Text = CurrentTaskDetails.parts_name;
                TxtEveryPackageWeight.Text = CurrentTaskDetails.parts_every_package_weight + CurrentTaskDetails.parts_weight_unit;//每袋重量
                TxtPeiFanStdW11eight.Text = CurrentTaskDetails.standard_weight + CurrentTaskDetails.weight_unit;//目标重量
                MaxBags = DecimalHelper.Conversion(Math.Floor(DoubleHelper.Conversion(DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) / (DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit))))));
                TxtMaxBags.Text = MaxBags.ToString();
                TmrTimer.Enabled = true;

                //开启扫码枪
                if (SystemSet.IsUseScanningGun)
                {
                    CurrentReadScanCode.EventHandler += new EventHandler(ReadScanCode_scanning);

                    if (!CurrentReadScanCode.Init(SystemSet.ScanningGunSerialPort, SystemSet.ScanningGunBaudRate))
                    {
                        NTDMsg.TouchFlatMsgError(CurrentReadScanCode.GetMessageInfo());
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        private void ReadScanCode_scanning(object sender, EventArgs e)
        {
            string content = (e as BaseEvent<string>)._Data;
            ThreadOperationControlHelper.ShowControlText(TxtInputVale, content);
           
            if (IsToReview(content))
            {
                InputBags++;
                if (InputBags > MaxBags)
                {
                    InputBags--;
                    NTDMsg.TouchFlatMsgInfo("已达到最大袋数");
                }
                else
                {
                    stringList.Add(content);
                    ShowPageList(stringList);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LblInfo.Text = "扫描" + InputBags + "袋，剩余" + (DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - IntHelper.Conversion(InputBags) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit))) + "" + CurrentTaskDetails.weight_unit;
        }

        private void FrmBarcodeDotBag_FormClosing(object sender, FormClosingEventArgs e)
        {
          TmrInit.Enabled=  TmrTimer.Enabled = false;
            try
            {
                if (SystemSet.IsUseScanningGun)
                {
                    CurrentReadScanCode.EventHandler -= new EventHandler(ReadScanCode_scanning);
                    CurrentReadScanCode.Close();
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        //是否已经扫码录入
        private int IsScanCodeEntryCount = 0;
        private void TxtInputVale_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                IsScanCodeEntryCount++;
                TextBox t = (TextBox)sender;
                //扫码完毕触发事件
                if (IsScanCodeEntryCount == 1 && t.Text.Trim().Length > 0) t.Text = "";
                if (!string.Equals(e.KeyCode, Keys.Enter)) return;
                IsScanCodeEntryCount = 0;

                if (IsToReview(t.Text.Trim()))
                {
                    InputBags++;
                    if (InputBags > MaxBags)
                    {
                        InputBags--;
                        NTDMsg.TouchFlatMsgError("已达到最大袋数");
                    }
                    else
                    {
                        stringList.Add(t.Text.Trim());
                        ShowPageList(stringList);
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        private bool IsToReview(string content)
        {
            try
            {
                foreach (var item in ParamtersDicList)
                {
                    Context = item.ContainsKey("Context") ? item["Context"].ToString() : string.Empty;
                    FieldName = item.ContainsKey("FieldName") ? item["FieldName"].ToString() : string.Empty;
                    StartPosition = item.ContainsKey("StartPosition") ? IntHelper.Conversion(item["StartPosition"]) : 0;
                    Length = item.ContainsKey("Length") ? IntHelper.Conversion(item["Length"]) : 0;

                    //同时为0的话校验整个条码长度
                    if (StartPosition == 0 && Length == 0)
                    {
                        Context = content;
                    }
                    else
                    {
                        if (content.Length < StartPosition || content.Length < StartPosition + Length)
                        {
                            NTDMsg.TouchFlatMsgError("解析规则长度失败，请检查解析规则是否规范");
                            return false;
                        }

                        Context = content.Substring(StartPosition, Length);
                    }

                    switch (FieldName)
                    {
                        case ("expire_time"):
                            if (DateTimeHelper.CompanyDate(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTimeHelper.Conversion(Context, "yyyyMMdd").ToString("yyyy-MM-dd") + " 23:59:59") >= 0)
                            {
                                NTDMsg.TouchFlatMsgError("当前物料已过期，请检查");
                                return false;
                            }
                            break;
                        default:
                            Dictionary<string, object> dic = ClassToDic(CurrentTaskDetails);
                            if (dic.ContainsKey(FieldName))
                            {
                                if ((dic[FieldName]).ToString() == Context)
                                {
                                    break;
                                }
                            }
                            NTDMsg.TouchFlatMsgError("不是当前物料的条码，请检查");
                            return false;
                    }
                }
                return true;

            }
            catch (Exception)
            {
                NTDMsg.TouchFlatMsgError("未配置物料条码，或解析规则不正确");
                return false;
            }
        }

        public Dictionary<string, object> ClassToDic(nmfs_task_details details)
        {
            var d = details.GetType().GetProperties()//这一步获取匿名类的公共属性，返回一个数组
                .OrderBy(q => q.Name)//这一步排序，需要引入System.Linq，当然可以省略 
                .ToDictionary(q => q.Name, q => q.GetValue(details));//这一步将数组转换为字典
            return d;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ZapWeightValue = DecimalHelper.Conversion(DecimalHelper.Conversion(InputBags) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit)));
                SurplusWeightValue = DecimalHelper.Conversion(CurrentTaskDetails.standard_weight) - DecimalHelper.Conversion(InputBags) * DecimalHelper.Conversion(CurrentTaskDetails.parts_every_package_weight) * UnitHelper.MassUnitConversion(EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.parts_weight_unit), EnumHelper.Conversion<NTDMassUnitEnum>(CurrentTaskDetails.weight_unit));
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

        private void FrmBarcodeDotBag_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
    }
}
