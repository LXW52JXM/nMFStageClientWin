using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NTD910WeightLib
{
    public class NTD910Weight
    {
        public DigitalSensor.DigitalSensorManager SensorMgr { get; set; }
        public DigitalSensor.DigitalSensorGroup SensorGrp { get; set; }

        Timer GetValueTimer { get; set; }

        private int PlatformNumber = 1;
        private string Port = "COM1";

        public NTD910Weight(string port="COM1")
        {
            DigitalSensor.AppStatus.AppStat.InitFormSpecial();
            Port = port;
        }
        
        public void Init(int platformNumber = 1)
        {
            try
            {
                PlatformNumber = platformNumber;
                SensorMgr = DigitalSensor.AppStatus.AppStat.SensorMgr;
                SensorMgr.PowerUpZero = true;

                SensorGrp = SensorMgr.NewGroup();
                SensorGrp.OpenCom(Port);
                SensorGrp.ReadTimeout = 100;
                SensorGrp.BuildSensors(PlatformNumber);
                // 读取称台参数
                for(int i = 0; i < PlatformNumber; i++)
                {
                    SensorGrp.Sensors[i].UpdateParams();
                }
                
                SensorGrp.StartReading();

                //GetValueTimer = new Timer();
                //GetValueTimer.Interval = 50;
                //GetValueTimer.Tick += GetValueTimer_Tick;
                //GetValueTimer.Enabled = true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        
        private void GetValueTimer_Tick(object sender, EventArgs e)
        {
            //isOnline = SensorGrp.Sensors[0].IsOnline;
            //if(isOnline: false=>true){

            //}
            //IsStable = SensorGrp.Sensors[0].Values.IsStable;
            //Gross = SensorGrp.Sensors[0].Values.GrossWeight.ToString();
            //Tare = SensorGrp.Sensors[0].Values.TareWeight.ToString();
            //Net = SensorGrp.Sensors[0].Values.NetWeight.ToString();

        }

        /// <summary>
        /// 设置量程
        /// </summary>
        /// <param name="span"></param>
        /// <param name="key"></param>
        public void SetSpan(decimal span, int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].SetCapacity(span);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 设置稳态范围
        /// </summary>
        /// <param name="stableRange"></param>
        /// <param name="key"></param>
        public void SetStableRange(decimal stableRange, int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].SetStableRange(stableRange);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 设置自动清零范围
        /// </summary>
        /// <param name="ZeroCapture"></param>
        /// <param name="key"></param>
        public void SetZeroCapture(decimal ZeroCapture, int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].SetZeroCapture(ZeroCapture);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Increment"></param>
        /// <param name="key"></param>
        public void SetIncrement(decimal Increment, int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].SetIncrement(Increment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 读取称台基本参数
        /// </summary>
        /// <param name="platformNo"></param>
        public void ReadParams(int platformNo = 1)
        {
            try
            {
                SensorGrp.Sensors[platformNo - 1].UpdateParams();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        /// <summary>
        /// 获取一条完整数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public WeightBean GetSingleValue(int key = 1)
        {
            if (key > SensorGrp?.SensorCount || key <0) return null;

            try
            {
                WeightBean value = new WeightBean()
                {
                    PlatNo = key,
                    IsOnline = SensorGrp.Sensors[key - 1].IsOnline,
                    IsStable = SensorGrp.Sensors[key - 1].Values.IsStable,
                    Gross = SensorGrp.Sensors[key - 1].Values.GrossWeight.ToString(),
                    Tare = SensorGrp.Sensors[key - 1].Values.TareWeight.ToString(),
                    Net = SensorGrp.Sensors[key - 1].Values.NetWeight.ToString(),
                    IsOverLoad = SensorGrp.Sensors[key - 1].Values.IsOverLoad,
                    IsUnderLoad = SensorGrp.Sensors[key - 1].Values.IsUnderLoad,
                    HighGross = SensorGrp.Sensors[key - 1].Values.HighGross.ToString(),
                    Increment = SensorGrp.Sensors[key - 1].Params.Increment.ToString(),
                    HighNet = SensorGrp.Sensors[key - 1].Values.HighNet.ToString(),
                    Capacity = SensorGrp.Sensors[key - 1].Params.Capacity.ToString(),
                    ZeroCapture = SensorGrp.Sensors[key - 1].Params.ZeroCapture.ToString(),
                    StableRange = SensorGrp.Sensors[key - 1].Params.StableRange.ToString(),
                };
                
                return value;
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// 去皮并清零
        /// </summary>
        /// <param name="key"></param>
        public void ClearTareAndSetZero(int key = 1)
        {
            if (key > SensorGrp?.SensorCount) return;

            try
            {
                SensorGrp?.Sensors[key - 1].ClearTare();
                SensorGrp?.Sensors[key - 1].DoZero();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 清零
        /// </summary>
        /// <param name="key"></param>
        public void SetZero(int key = 1)
        {
            if (key > SensorGrp.SensorCount) return;

            try
            {
                SensorGrp.Sensors[key - 1].DoZero();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 去皮
        /// </summary>
        /// <param name="key"></param>
        public void SetTare(int key = 1)
        {
            if (key > SensorGrp?.SensorCount) return;

            try
            {
                SensorGrp?.Sensors[key - 1].DoTare();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 数字去皮
        /// </summary>
        /// <param name="tareValue"></param>
        /// <param name="key"></param>
        public void SetTare(decimal tareValue, int key = 1)
        {
            if (key > SensorGrp?.SensorCount) return;

            try
            {
                SensorGrp?.Sensors[key - 1].SetTare(tareValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
        /// <summary>
        /// 清皮
        /// </summary>
        /// <param name="Key"></param>
        public void ClearTare(int Key = 1)
        {
            if (Key > SensorGrp?.SensorCount) return;

            try
            {
                SensorGrp?.Sensors[Key - 1].ClearTare();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        public void ReleaseAll()
        {
            try
            {
                SensorGrp?.StopReading();
                SensorGrp?.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }            
        }

        /// <summary>
        /// 标定零点
        /// </summary>
        /// <param name="key"></param>
        public void CalibrationZero(int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].CalibrateZero();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 标定量程
        /// </summary>
        /// <param name="span"></param>
        /// <param name="key"></param>
        public void CalibrationSpan(decimal span, int key= 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].CalibrateSpan(span);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 保存零点
        /// </summary>
        /// <param name="key"></param>
        public void CalibrationSaveZero(int key = 1)
        {
            try
            {
                if (key > PlatformNumber) return;

                SensorGrp?.Sensors[key - 1].DoZero(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 标定
        /// </summary>
        public void Calibrate()
        {
            try
            {
                FrmCalibrate frm = new FrmCalibrate(SensorGrp.Sensors[0]);
                frm.ShowDialog();
                frm.Close();
            }
            catch 
            {
                
            }
        }

    }
}
