using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTD910WeightLib;

namespace NTDCommon
{
    public class BalanceNTD910 : BalanceInterface
    {
        static AppSettings AppSet => AppSettings.AppSet;
        static SystemSettings SystemSet => AppSet.SystemSet;
        public BalanceNTD910()
        {
        }

        #region 属性

        /// <summary>
        /// 定义事件
        /// </summary>
        public event EventHandler EventHandler;

        /// <summary>
        /// 锁
        /// </summary>
        private static object Lock = new object();

        /// <summary>
        /// 秤台名称
        /// </summary>
        private string BalanceName = "";

        /// <summary>
        /// 连接状态
        /// </summary>
        private bool ConnectStatic;

        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        private string MessageInfo = string.Empty;



        /// <summary>
        /// 秤台号（内部秤台的地址）
        /// </summary>           
        public int WeighingPlatformNo = 1;


        /// <summary>
        /// 计算单位转换值的临时数据
        /// </summary>
        private int TempIndex = 0;
        private decimal TempUnitProportionalValue = 0;
        private int TempDivisionDecimalPlace = 0;

        /// <summary>
        /// 秤台数据
        /// </summary>
        private NTDWeightCoreBean CurrentWCB = new NTDWeightCoreBean();
        /// <summary>
        /// 多秤台的单位
        /// </summary>
        private NTDMassUnitEnum CurrentUnit = new NTDMassUnitEnum();
        /// <summary>
        /// 秤台实体类
        /// </summary>
        private balance_entity CurrentBalance = new balance_entity();



        #endregion



        /// <summary>
        /// 设置单个秤台的显示的单位
        /// </summary>
        /// <param name="unit"></param>
        public void SetNTDMassUnitEnumUnit(string unit)
        {
            try
            {
                CurrentUnit = EnumHelper.Conversion<NTDMassUnitEnum>(unit);
                TempUnitProportionalValue = UnitHelper.MassUnitConversion(NTDMassUnitEnum.kg, CurrentUnit);//缩放比例
            }
            catch (Exception ex)
            {


            }

        }

        public void SetSingleScaleDetails(balance_entity entity)
        {
            try
            {
                CurrentBalance = entity;
                if (entity.device_number != null && entity.device_number > 0)
                {
                    WeighingPlatformNo = IntHelper.Conversion(entity.device_number);
                }

                if (!string.IsNullOrEmpty(entity.unit))
                {
                    SetNTDMassUnitEnumUnit(entity.unit);
                }
                else
                {
                    SetNTDMassUnitEnumUnit("kg");
                }
            }
            catch (Exception)
            {

            }
        }


        public balance_entity GetSingleScaleDetails()
        {
            return CurrentBalance;
        }




        public bool InitAll()
        {
            return InitAll(WeighingPlatformNo);
        }

        public bool InitAll(int platformCount)
        {
            try
            {
                //先关掉在开启
                Close();
                WeighingPlatformNo = platformCount;
                ConnectStatic = true;
                return true;
            }
            catch (Exception ex)
            {
                MessageInfo += "失败原因：" + ex.Message;

                Close();
                return false;
            }
        }
        private WeightBean CurrentWeightBean = new WeightBean();
        /// <summary>
        /// 获取单个重量
        /// </summary>
        /// <returns></returns>
        public NTDWeightCoreBean GetSingleValue()
        {//判断内部称当前使用的称台



            var data = AppSet.CurrentNTD910.GetSingleValue(WeighingPlatformNo);
            if (data != null)
            {
                CurrentWCB.Stable = data.IsStable;//状态
                CurrentWCB.Range = data.Capacity.ToString();//量程
                CurrentWCB.Division = data.Increment.ToString();//分度值
                CurrentWCB.OverLoadFlag = data.IsOverLoad;//超载
                CurrentWCB.UnderLoadFlag = data.IsUnderLoad;//欠载
                CurrentWCB.ZeroFlag = data.IsZero;
                CurrentWCB.PlatformNo = WeighingPlatformNo;//称号
                CurrentWCB.GrossWeight = data.Gross.ToString();//毛重
                CurrentWCB.TareWeight = data.Tare.ToString();//皮重
                CurrentWCB.NetWeight = data.Net.ToString();//净重
                CurrentWCB.UnitValue = CurrentUnit;//单位

                
                if (TempUnitProportionalValue != 1)
                {
                    TempDivisionDecimalPlace = StringHelper.GetSpecifyDecimalPlaces(DoubleHelper.Conversion(TempUnitProportionalValue * DecimalHelper.Conversion(StringHelper.GetValueByDecimalPlaces(StringHelper.GetSpecifyDecimalPlaces(CurrentWCB.NetWeight)))).ToString());//分度值小数位
                                                                                                                                                                                                                                                                                                //保留指定位数
                    CurrentWCB.GrossWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCB.GrossWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace,true);//毛重
                    CurrentWCB.TareWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCB.TareWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace, true);//皮重
                    CurrentWCB.NetWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCB.NetWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace, true);//净重
                }
            }
            else
            {
                CurrentWCB.GrossWeight = "-999";//毛重
                CurrentWCB.TareWeight = "0";//皮重
                CurrentWCB.NetWeight = "-999";//净重
            }
            return CurrentWCB;
        }


        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            try
            {
                MessageInfo = string.Empty;
                if (ConnectStatic) ConnectStatic = false;
            }
            catch (Exception ex)
            {
                throw new Exception("关闭秤台失败" + ex.Message);
            }
        }

        /// <summary>
        /// 获取实例名称
        /// </summary>
        public string GetBalanceName()
        {
            return BalanceName;

        }

        /// <summary>
        /// 获取串口状态
        /// </summary>
        public bool GetStatus()
        {
            return ConnectStatic;

        }
        /// <summary>
        /// 获取串口错误信息
        /// </summary>
        public string GetMessageInfo()
        {
            return MessageInfo;

        }



        /// <summary>
        /// 预值皮重
        /// </summary>
        /// <param name="presetTareWeight"></param>
        public void SetPresetTareWeight(string presetTareWeight)
        {
            SetPresetTareWeight(presetTareWeight, WeighingPlatformNo);
        }
        public void SetPresetTareWeight(string presetTareWeight, int weighingPlatformNo)
        {
            try
            {

                CurrentWCB.PresetTareWeight = presetTareWeight;
                //判断要去的皮重是否整除分度值
                //获取分度值
                //decimal i = DecimalHelper.Conversion(presetTareWeight) % AppSet.CurrentNTD910.GetIncrement(weighingPlatformNo);
                //if (i == 0)
                //{
                //    CurrentWCB.PresetTareWeight = presetTareWeight;
                //}
                //else
                //{
                //    throw new Exception("去皮重量不能整除分度值");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("预值皮重失败：" + ex.Message.Trim());
            }

        }

        /// <summary>
        /// 清零
        /// </summary>
        public void SetZero()
        {
            SetZero(WeighingPlatformNo);
        }
        public void SetZero(int weighingPlatformNo)
        {
            try
            {
                AppSet.CurrentNTD910.SetZero(weighingPlatformNo);
            }
            catch (Exception ex)
            {
                throw new Exception("清零失败：" + ex.ToString());
            }
        }
        /// <summary>
        /// 去皮
        /// </summary>
        public void SetTare()
        {
            SetTare(WeighingPlatformNo);
        }
        public void SetTare(int weighingPlatformNo)
        {
            try
            {
                CurrentWCB.PresetTareWeight = "0";
                AppSet.CurrentNTD910.SetTare(weighingPlatformNo);
            }
            catch (Exception ex)
            {
                throw new Exception("去皮失败：" + ex.ToString());
            }
        }
        /// <summary>
        /// 清皮
        /// </summary>
        public void ClearTare()
        {
            ClearTare(WeighingPlatformNo);
        }
        public void ClearTare(int weighingPlatformNo)
        {
            try
            {
                CurrentWCB.PresetTareWeight = "0";
                AppSet.CurrentNTD910.ClearTare(weighingPlatformNo);
            }
            catch (Exception ex)
            {
                throw new Exception("清皮失败：" + ex.ToString());
            }
        }


        #region BalanceInterface 成员

        /// <summary>
        /// 获取分度值和满量程
        /// </summary>
        /// <param name="division"></param>
        /// <param name="range"></param>
        public void GetDivisionAndRange(out decimal division, out decimal range)
        {
            division = -1;
            range = -1;
            GetDivisionAndRange(out  division, out  range, WeighingPlatformNo);
        }
        public void GetDivisionAndRange(out decimal division, out decimal range, int weighingPlatformNo)
        {
            try
            {
                division = -1;
                range = -1;
                lock (Lock)
                {
                    division =DecimalHelper.Conversion(CurrentWCB.Division);
                    range = DecimalHelper.Conversion(CurrentWCB.Range);

                    //division = ntd910.GetIncrement(weighingPlatformNo);
                    //range = ntd910.GetCapacity(weighingPlatformNo);
                }
                if (division < 0) throw new Exception("获取分度值失败");
                if (range < 0) throw new Exception("获取满量程失败");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 设置分度值、满量程和标定重量
        /// </summary>
        /// <param name="division"></param>
        /// <param name="range"></param>
        /// <param name="calibrateWeight"></param>
        public void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight)
        {
            SetDivisionAndRangeAndCalibrateWeight(division,range,calibrateWeight, WeighingPlatformNo);
        }
        public void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight, int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    //if (!ntd910.SetIncrement(weighingPlatformNo, division)) throw new Exception("设置分度值失败");
                    //if (!ntd910.SetCapacity(weighingPlatformNo, range)) throw new Exception("设置满量程失败");

                  AppSet.CurrentNTD910.SetIncrement(division, weighingPlatformNo);
                    AppSet.CurrentNTD910.SetSpan(range, weighingPlatformNo);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 标定零点
        /// </summary>
        /// <param name="PlatformNo"></param>
        /// <returns></returns>
        public void CalibrateZero()
        {
            CalibrateZero(WeighingPlatformNo);
        }
        public void CalibrateZero(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    //if (!ntd910.CalibrateZero(weighingPlatformNo)) throw new Exception("");
                    AppSet.CurrentNTD910.CalibrationZero(weighingPlatformNo);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("标定零点失败：" + ex.ToString());
            }
        }
        /// <summary>
        /// 砝码标定
        /// </summary>
        /// <param name="PlatformNo"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public void CalibrateWeight(decimal calibrateWeight)
        {
            CalibrateWeight(calibrateWeight, WeighingPlatformNo);
        }
        public void CalibrateWeight(decimal calibrateWeight, int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    //if (!ntd910.CalibrateSpan(weighingPlatformNo, calibrateWeight)) throw new Exception("");
                    AppSet.CurrentNTD910.CalibrationSpan(calibrateWeight,weighingPlatformNo);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("标定零点失败：" + ex.ToString());
            }
        }
        /// <summary>
        /// 工厂置零
        /// </summary>
        /// <param name="PlatformNo"></param>
        /// <returns></returns>
        public void FactoryZero()
        {
            FactoryZero(WeighingPlatformNo);
        }
        public void FactoryZero(int weighingPlatformNo)
        {
            try
            {
                lock (Lock)
                {
                    //   if (!ntd910.SetFactoryZero(weighingPlatformNo)) throw new Exception("");
                    AppSet.CurrentNTD910.CalibrationSaveZero(weighingPlatformNo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("工厂置零失败：" + ex.ToString());
            }
        }
        #endregion


    }
}
