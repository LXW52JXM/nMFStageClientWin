
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
    public class ScaleNTD910 : BalanceInterface
    {

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
        /// 连接状态
        /// </summary>
        private bool ConnectStatic = false;

        /// <summary>
        /// 当前实例的错误信息
        /// </summary>
        private string MessageInfo = string.Empty;

        /// <summary>
        /// 秤台数量
        /// </summary>
        private int PlatformCount = 1;

        /// <summary>
        /// 秤台号（内部秤台的地址）
        /// </summary>           
        public int WeighingPlatformNo = 1;

        /// <summary>
        /// 串口
        /// </summary>           
        public string SerialPort = "COM1";

        /// <summary>
        /// 计算单位转换值的临时数据
        /// </summary>
        private int TempIndex = 0;
        private decimal TempUnitProportionalValue = 0;
        private int TempDivisionDecimalPlace = 0;

        /// <summary>
        /// 秤台数据
        /// </summary>
        private NTDWeightCoreBean[] CurrentWCBArray = new NTDWeightCoreBean[1];

        /// <summary>
        /// 多秤台的单位
        /// </summary>
        private NTDMassUnitEnum[] CurrentUnitArray = new NTDMassUnitEnum[1];
        /// <summary>
        /// 秤台实体类
        /// </summary>
        private List<balance_entity> CurrentBalanceScaleList = new List<balance_entity>();

        private NTD910Weight ntd910 = new NTD910Weight();
        //private Scale ntd910 =null;

        #endregion

        public ScaleNTD910()
        {
        }

        /// <summary>
        /// 设置单个秤台的显示的单位
        /// </summary>
        /// <param name="unit"></param>
        public void SetNTDMassUnitEnumUnit(string unit)
        {
            SetNTDMassUnitEnumUnit(unit, WeighingPlatformNo);
        }
        public void SetNTDMassUnitEnumUnit(string unit,int weighingPlatformNo)
        {
            try
            {
                if (!string.IsNullOrEmpty(unit)&& weighingPlatformNo<= CurrentUnitArray.Length)
                {
                    CurrentUnitArray[weighingPlatformNo - 1] = EnumHelper.Conversion<NTDMassUnitEnum>(unit);
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                throw new Exception("设置显示的单位失败");
            }
        }
        public void SetAllNTDMassUnitEnumUnit(string[] unitArray)
        {
            try
            {
                for (int i = 0; i < unitArray.Length; i++)
                {
                    if (i >= CurrentUnitArray.Length) continue;
                    CurrentUnitArray[i] = EnumHelper.Conversion<NTDMassUnitEnum>(unitArray[i]);
                }
            }
            catch (Exception)
            {

                throw new Exception("设置显示的单位失败");
            }
        }

        public void SetScaleDetails(List<balance_entity> entityList)
        {
            try
            {
                if (entityList != null && entityList.Count > 0)
                {
                    CurrentBalanceScaleList = entityList;
                    var entity = CurrentBalanceScaleList.First();
                    SerialPort = entity.serial_port;
                }
            }
            catch (Exception)
            {

            }
        }
        public List<balance_entity> GetScaleDetails()
        {
            return CurrentBalanceScaleList;
        }

        public bool InitAll() 
        {
           return  InitAll(PlatformCount);
        }

        public bool InitAll(int platformCount)
        {
            try
            {
                ConnectStatic = true;
                //初始化内部多秤台数据
                PlatformCount = platformCount;
                CurrentWCBArray = new NTDWeightCoreBean[PlatformCount];
                for (int i = 0; i < CurrentWCBArray.Length; i++)
                {
                    CurrentWCBArray[i] = new NTDWeightCoreBean(); 
                }

                CurrentUnitArray = new NTDMassUnitEnum[PlatformCount];
                for (int i = 0; i < CurrentUnitArray.Length; i++)
                {
                    CurrentUnitArray[i] = NTDMassUnitEnum.kg; 
                }


                ntd910 = new NTD910Weight(SerialPort);
                Thread.Sleep(100);
                ntd910.Init(platformCount);


                //if (ntd910 != null) ntd910.Release();
                //ntd910 = new Scale();
                //Thread.Sleep(100);
                //if (!ntd910.Init(SerialPort)) throw new Exception("秤台初始化失败");
              

                Thread readSerialPortDataThread = new Thread(ReadSerialPortData);
                readSerialPortDataThread.IsBackground = true;
                readSerialPortDataThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                ConnectStatic = false;
                MessageInfo += "失败原因：" + ex.Message;
                return false;
            }
        }

        void ReadSerialPortData()
        {
            while (ConnectStatic)
            {
                try
                {
                    for (int i = 0; i < CurrentWCBArray.Length; i++)
                    {
                        CurrentWCBArray[i] = GetNTD910Data(i+1);
                        Thread.Sleep(10);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Thread.Sleep(10);
                }
            }
        }


        private NTDWeightCoreBean GetNTD910Data(int weighingPlatformNo)
        {
            try
            {
                if (weighingPlatformNo <= 0) return new NTDWeightCoreBean();
                TempIndex = weighingPlatformNo - 1;
                //判断内部称当前使用的称台
                // var data = ntd910.GetWeightBean(weighingPlatformNo);
                var data = ntd910.GetSingleValue(weighingPlatformNo);
                if (data != null)
                {
                    CurrentWCBArray[TempIndex].Stable = data.IsStable;//状态
                    CurrentWCBArray[TempIndex].Range = data.Capacity.ToString();//量程
                    CurrentWCBArray[TempIndex].Division = data.Increment.ToString();//分度值
                    CurrentWCBArray[TempIndex].OverLoadFlag = data.IsOverLoad;//超载
                    CurrentWCBArray[TempIndex].UnderLoadFlag = data.IsUnderLoad;//欠载

                    //CurrentWCBArray[TempIndex].OverLoadFlag = data.IsOver;//超载
                    //CurrentWCBArray[TempIndex].UnderLoadFlag = data.IsUnder;//欠载

                    CurrentWCBArray[TempIndex].ZeroFlag = data.IsZero;
                    CurrentWCBArray[TempIndex].PlatformNo = weighingPlatformNo;//称号
                    CurrentWCBArray[TempIndex].GrossWeight = data.Gross.ToString();//毛重
                    CurrentWCBArray[TempIndex].TareWeight = data.Tare.ToString();//皮重
                    CurrentWCBArray[TempIndex].NetWeight = data.Net.ToString();//净重
                    CurrentWCBArray[TempIndex].Unit = CurrentUnitArray[TempIndex].ToString();//单位

                    TempUnitProportionalValue = UnitHelper.MassUnitConversion(NTDMassUnitEnum.kg, CurrentUnitArray[TempIndex]);//缩放比例
                    if (TempUnitProportionalValue != 1)
                    {
                        TempDivisionDecimalPlace = StringHelper.GetSpecifyDecimalPlaces(DoubleHelper.Conversion(TempUnitProportionalValue * DecimalHelper.Conversion(StringHelper.GetValueByDecimalPlaces(StringHelper.GetSpecifyDecimalPlaces(CurrentWCBArray[TempIndex].NetWeight)))).ToString());//分度值小数位
                                                                                                                                                                                                                                                                                                    //保留指定位数
                        CurrentWCBArray[TempIndex].GrossWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCBArray[TempIndex].GrossWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace);//毛重
                        CurrentWCBArray[TempIndex].TareWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCBArray[TempIndex].TareWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace);//皮重
                        CurrentWCBArray[TempIndex].NetWeight = StringHelper.KeepSpecifyDecimalPlaces(DecimalHelper.Conversion(CurrentWCBArray[TempIndex].NetWeight) * TempUnitProportionalValue, TempDivisionDecimalPlace);//净重
                    }
                }
                else
                {
                    CurrentWCBArray[TempIndex].GrossWeight = "-999";//毛重
                    CurrentWCBArray[TempIndex].TareWeight = "0";//皮重
                    CurrentWCBArray[TempIndex].NetWeight = "-999";//净重
                }
                return CurrentWCBArray[TempIndex];
            }
            catch (Exception)
            {
                return new NTDWeightCoreBean();
            }
          
        }



        /// <summary>
        /// 获取单个重量
        /// </summary>
        /// <returns></returns>
        public NTDWeightCoreBean GetSingleValue()
        {
            return GetSingleValue(WeighingPlatformNo);
        }


        public NTDWeightCoreBean GetSingleValue(int weighingPlatformNo)
        {
            //if (WeighingPlatformNo > CurrentWCBArray.Length) return new NTDWeightCoreBean();

            //return CurrentWCBArray[WeighingPlatformNo];
            return GetNTD910Data(weighingPlatformNo);
        }


        

        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            try
            {
                if (ConnectStatic)   ConnectStatic = false;
                //  if (ntd910 != null) ntd910.Release();
                if (ntd910 != null) ntd910.ReleaseAll();
            }
            catch (Exception)
            {
                throw new Exception("关闭串口失败");
            }
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
        public void SetPresetTareWeight(string presetTareWeight,int weighingPlatformNo)
        {
            try
            {
                if (weighingPlatformNo > CurrentWCBArray.Length) throw new Exception("");
                CurrentWCBArray[weighingPlatformNo-1].PresetTareWeight = presetTareWeight;
            }
            catch (Exception ex)
            {
                throw new Exception("预值皮重失败：" + ex.ToString());
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
                ntd910.SetZero(weighingPlatformNo);
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
                if (weighingPlatformNo > CurrentWCBArray.Length) throw new Exception("");
                CurrentWCBArray[weighingPlatformNo-1].PresetTareWeight = "0";
                //ntd910.SetKeyTare(weighingPlatformNo);
                ntd910.SetTare(weighingPlatformNo);
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
                if (weighingPlatformNo > CurrentWCBArray.Length) throw new Exception("");
                CurrentWCBArray[weighingPlatformNo-1].PresetTareWeight = "0";
                ntd910.ClearTare(weighingPlatformNo);
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
                    division =DecimalHelper.Conversion(CurrentWCBArray[weighingPlatformNo - 1].Division);
                    range = DecimalHelper.Conversion(CurrentWCBArray[weighingPlatformNo - 1].Range);

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

                    ntd910.SetIncrement(division, weighingPlatformNo);
                    ntd910.SetSpan(range, weighingPlatformNo);
                    
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
                    ntd910.CalibrationZero(weighingPlatformNo);
                    
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
                    ntd910.CalibrationSpan(calibrateWeight,weighingPlatformNo);
                    
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
                    ntd910.CalibrationSaveZero(weighingPlatformNo);
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
