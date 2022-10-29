using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public static class T81Api
    {
        //1，初始化所有资源并启动线程
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool InitAll();

        //2，退出程序前释放所有资源并结束线程
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool ReleaseAll();

        //3，读取数据（重量、皮重、重量状态）、以及按键信息
        //返回字符串格式：W1=%s,T1=%s,Z1=%d,U1=%d,O1=%d,N1=%d,S1=%d,W2=%s,T2=%s,Z2=%d,U2=%d,O2=%d,N2=%d,S2=%d,KEY=%d
        //W重量，T皮重,Z零位标志,U欠载标志,O过载标志，N净重标志,S稳定标志 ，后面的1或2表示秤台编号
        //KEY为仪表物理按键值
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetWeightAndKeyInfo();

        //4，清零
        //PlatformNo:秤台号，1 或 2
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool SetZero(int PlatformNo);

        //5，按键去皮
        //PlatformNo:秤台号，1 或 2
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool SetKeyTare(int PlatformNo);

        //6，去皮
        //PlatformNo:秤台号，1 或 2
        //tare,皮重值
        //Digit,皮重值的小数位数(0-4)
        //如希望去皮0.250kg，则tare=250,Digit=3
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool SetTare(int PlatformNo, uint tare, uint Digit);

        //7，清皮
        //PlatformNo:秤台号，1 或 2
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool ClearTare(int PlatformNo);

        //8，读取传感器参数
        //PlatformNo 秤台号：或2
        //FilterDepth滤波深度:0最轻,1轻度,2中度,3深度,4最深
        //DynamicRange  动态检测范围：禁止,1(0.1d),2(0.2d),....9(0.9d),10(1.0d),11(1.1d),.....99(9.9d)
        //ZeroTrackRange零点跟踪范围：禁止,1(0.1d),2(0.2d),....9(0.9d),10(1.0d),11(1.1d),.....99(9.9d)
        //PressKeyZeroRange按键清零范围：禁止，(±%),2(±%),.....98（±%）,99（±%）
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int GetScaleParameter(int PlatformNo, ref int FilterDepth, ref int DynamicRange, ref int ZeroTrackRange, ref int PressKeyZeroRange);

        //9，设置传感器参数
        //PlatformNo 秤台号：或2
        //FilterDepth滤波深度:0最轻,1轻度,2中度,3深度,4最深
        //DynamicRange  动态检测范围：禁止,1(0.1d),2(0.2d),....9(0.9d),10(1.0d),11(1.1d),.....99(9.9d)
        //ZeroTrackRange零点跟踪范围：禁止,1(0.1d),2(0.2d),....9(0.9d),10(1.0d),11(1.1d),.....99(9.9d)
        //PressKeyZeroRange按键清零范围：禁止，(±%),2(±%),.....98（±%）,99（±%）
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SetScaleParameter(int PlatformNo, int FilterDepth, int DynamicRange, int ZeroTrackRange, int PressKeyZeroRange);


        //10，读取秤台量程分度
        //MinDivision最小分度：(0.0001),1(0.0002),2(0.0005),3(0.001),4(0.002),5(0.005),6(0.01),7(0.02),8(0.05),
        //					9(0.1),10(0.2),11(0.5),12(1),13(2),14(5),15(10)
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int GetRangeDivision(ref int Range1, ref int Range2, ref int MinDivision1, ref int MinDivision2);//int*-->ref int

        //11，设置校准量程、分度、校准砝码重
        //PlatformNo:秤台号，或2
        //MinDivision最小分度：(0.0001),1(0.0002),2(0.0005),3(0.001),4(0.002),5(0.005),6(0.01),7(0.02),8(0.05),
        //					9(0.1),10(0.2),11(0.5),12(1),13(2),14(5),15(10)
        //FullRange满量程：(0-800000]
        //CalibrateWeight标定砝码重量：(0-800000]
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CalStep1_SetRange(int PlatformNo, int MinDivision, int FullRange, int CalibrateWeight);

        //12，校准空秤台
        //PlatformNo:秤台号，或2
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool CalStep2_CheckEmptyPlatform(int PlatformNo);

        //13，校准预设砝码重
        //PlatformNo:秤台号，或2
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool CalStep3_CheckCalWeight(int PlatformNo);

        //14, 读取IP
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int GetIP(byte[] IP, byte[] Mask, byte[] Gate);


        //15, 设置IP
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int SetIP(byte[] IP, byte[] Mask, byte[] Gate);

        //16, 校准触摸屏
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool CalibrateTouchScreen();

        //17，设置是否允许自动关闭背光
        //EnableFlag=true 允许自动关闭,
        //          =false禁止
        //DelayTime，自动关闭背光延时时间,单位是秒,范围-120s，仅EnableFlag=true时有效
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool SetAutoTurnOffBackLight(bool EnableFlag, int DelayTime);

        //18，关闭背光
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool TurnOffBackLight();

        //19，重启
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool RebootSystem();

        //20，显示桌面（explorer.exe）
        [DllImport("Scale.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern bool ShowDesktop();


    }
}