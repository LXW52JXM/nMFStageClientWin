using NTDCommLib;
using NTDCommon; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public interface BalanceInterface
    {
        //委托事件
        event EventHandler EventHandler;

        /// <summary>
        /// 初始化秤台
        /// </summary>
        /// <param name="balanceCount">秤台总数</param>
        /// <returns></returns>
        bool InitAll();
        bool InitAll(int platformCount);

        /// <summary>
        /// 设置显示的单位(内部称使用)
        /// </summary>
        /// <param name="unit"></param>
        void SetNTDMassUnitEnumUnit(string unit);



        /// <summary>
        /// 设置单秤台初始化的参数
        /// </summary>
        /// <param name="balanceScaleList"></param>
        void SetSingleScaleDetails(balance_entity balanceScale);


        /// <summary>
        /// 获取单秤台初始化的参数
        /// </summary>
        /// <returns></returns>
        balance_entity GetSingleScaleDetails();


        /// <summary>
        /// 获取默认秤台的基本数据
        /// </summary>
        /// <returns></returns>
        NTDWeightCoreBean GetSingleValue();


        /// <summary>
        /// 获取状态
        /// </summary>
        string GetBalanceName();

        /// <summary>
        /// 获取状态
        /// </summary>
        bool GetStatus();

        /// <summary>
        /// 获取错误信息
        /// </summary>
        string GetMessageInfo();

        /// <summary>
        /// 关闭
        /// </summary>
        void Close();

        /// <summary>
        /// 设置预值皮重值
        /// </summary>
        /// <param name="presetTareWeight"></param>
        void SetPresetTareWeight(string presetTareWeight);
        void SetPresetTareWeight(string presetTareWeight, int weighingPlatformNo);
        /// <summary>
        /// 清零
        /// </summary>
        void SetZero();
        void SetZero(int weighingPlatformNo);


        /// <summary>
        /// 去皮
        /// </summary>
        void SetTare();
        void SetTare(int weighingPlatformNo);
        /// <summary>
        /// 清皮
        /// </summary>
        void ClearTare();
        void ClearTare(int weighingPlatformNo);

        #region 内部秤台标定的方法

        /// <summary>
        /// 获取分度值和满量程
        /// </summary>
        /// <param name="division"></param>
        /// <param name="range"></param>
        void GetDivisionAndRange(out decimal division, out decimal range);
        void GetDivisionAndRange(out decimal division, out decimal range, int weighingPlatformNo);



        /// <summary>
        /// 设置分度值满量程和标定的重量
        /// </summary>
        /// <param name="division"></param>
        /// <param name="range"></param>
        /// <param name="calibrateWeight"></param>
        void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight);
        void SetDivisionAndRangeAndCalibrateWeight(decimal division, decimal range, decimal calibrateWeight, int weighingPlatformNo);
        /// <summary>
        /// 标定零点
        /// </summary>
        void CalibrateZero();
        void CalibrateZero(int weighingPlatformNo);
        /// <summary>
        /// 砝码标定
        /// </summary>
        /// <param name="span"></param>
        void CalibrateWeight(decimal calibrateWeight);
        void CalibrateWeight(decimal calibrateWeight, int weighingPlatformNo);
        /// <summary>
        /// 工厂置零
        /// </summary>
        /// <param name="PlatformNo"></param>
        /// <returns></returns>
        void FactoryZero();
        void FactoryZero(int weighingPlatformNo);
        #endregion




        ////委托事件
        //event EventHandler EventHandler;

        //bool InitAll(string PortName, int Baudrate = 9600);

        //void SetScaleDetails(tb_device_details scaleDetails);

        //tb_device_details GetScaleDetails();

        ////获取指定秤台的基本重量数据
        //bool GetSingleValue(ref WeightCoreBean wcb);
        ///// <summary>
        ///// 关闭数据读取
        ///// </summary>
        //void Close();

        ///// <summary>
        ///// 获取串口状态
        ///// </summary>
        // bool GetStatus();

        ///// <summary>
        ///// 获取串口错误信息
        ///// </summary>
        // string GetMessageInfo();

        ///// <summary>
        ///// 清零
        ///// </summary>
        //void SetZero();
        ///// <summary>
        ///// 去皮
        ///// </summary>
        //void SetTare();
        ///// <summary>
        ///// 清皮
        ///// </summary>
        //void ClearTare();

        ///// <summary>
        ///// 设置量程
        ///// </summary>
        ///// <param name="span"></param>
        ///// <param name="key"></param>
        //void SetSpan(decimal tareValue);
        ///// <summary>
        ///// 设置分度值
        ///// </summary>
        ///// <param name="Increment"></param>
        ///// <param name="key"></param>
        //void SetIncrement(decimal Increment);
        ///// <summary>
        ///// 设置零点跟踪
        ///// </summary>
        ///// <param name="ZeroCapture"></param>
        ///// <param name="key"></param>
        //void SetZeroCapture(decimal ZeroCapture);
        ///// <summary>
        ///// 稳态范围
        ///// </summary>
        ///// <param name="stableRange"></param>
        ///// <param name="key"></param>
        //void SetStableRange(decimal stableRange);
        ///// <summary>
        ///// 标定零点
        ///// </summary>
        ///// <param name="key"></param>
        //void CalibrationZero();
        ///// <summary>
        ///// 标定砝码量程
        ///// </summary>
        ///// <param name="span"></param>
        ///// <param name="key"></param>
        //void CalibrationSpan(decimal tareValue);
        ///// <summary>
        ///// 保存零点并标定
        ///// </summary>
        ///// <param name="key"></param>
        //void CalibrationSaveZero();



    }
}

