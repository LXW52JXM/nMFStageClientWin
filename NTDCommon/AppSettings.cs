using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using NTDCommon;
using System.Reflection;
using System.Threading;
using Newtonsoft.Json;
using NTDCommLib;
using Newtonsoft.Json.Converters;
using Model;
using System.Xml;
using System.Xml.Serialization;
using NTD910WeightLib;

namespace NTDCommon
{
    public class AppSettings
    {
        public static AppSettings AppSet { get; } = new AppSettings();
        /// <summary>
        /// 配置文件的class类
        /// </summary>
        private SystemSettings SystemSetDefaultValue = new SystemSettings();
        public SystemSettings SystemSet
        {
            get => SystemSetDefaultValue;
            set
            {
                if (SystemSetDefaultValue != value)
                {
                    SystemSetDefaultValue = value;
                }
            }
        }
        /// <summary>
        /// 数据库配置文件的class类
        /// </summary>
        private DBSettings DBSetDefaultValue = new DBSettings();
        public DBSettings DBSet
        {
            get => DBSetDefaultValue;
            set
            {
                if (DBSetDefaultValue != value)
                {
                    DBSetDefaultValue = value;
                }
            }
        }

        #region 定义全局变量

        /// <summary>
        /// 项目运行路径
        /// </summary>
        public string AppPath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)).Replace("file:\\", "");

        /// <summary>
        /// 系统配置文件路径
        /// </summary>
        public string SystemSetPathName => ".\\SystemSettings.config";

        /// <summary>
        /// 数据库配置文件
        /// </summary>
        public string DBSetPathName => ".\\DBSettings.config";


        /// <summary>
        /// 主界面尺寸大小
        /// </summary>
        public int FormWidth = 0;
        public int FormHeight = 0;


        //序列化格式
        public JsonSerializerSettings JsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss"};
        //public  JsonSerializerSettings JsonSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        #endregion


        #region 常用变量

        /// <summary>
        /// 重量实体类
        /// </summary>
        public NTDWeightCoreBean CurrentWCB = new NTDWeightCoreBean();

        /// <summary>
        ///  当前选中的秤台的称重接口实例
        /// </summary>
        public balance_entity CurrentBalanceInfo = new balance_entity();

        /// <summary>
        ///  当前选中的秤台的称重接口实例
        /// </summary>
        public BalanceInterface CurrentBalanceInterface = null;


        /// <summary>
        ///  当前打印机接口实例
        /// </summary>
        public PrintInterface CurrentPrintInterface = null;

        /// <summary>
        /// 当前socket连接类
        /// </summary>
        public TcpClientHelper CurrentTcpClient = new TcpClientHelper();

        /// <summary>
        /// 内部秤
        /// </summary>
        public NTD910Weight CurrentNTD910 = null;
        #endregion


        #region 业务逻辑置信息


        public HttpUploadServiceData CurrentUploadServiceDataInterface = new HttpUploadServiceData();

        public bool? CurrentServiceConnectStatus = null;


        /// <summary>
        /// 当前选中的任务
        /// </summary>
        public nmfs_task CurrentTask = new nmfs_task();

        /// <summary>
        /// 当前登录人
        /// </summary>
        public nmfs_user CurrentLoginUser = new nmfs_user();


        /// <summary>
        /// 当前终端
        /// </summary>
        public nmfs_terminal CurrentTerminal = new nmfs_terminal();

        /// <summary>
        /// 数据库所有的秤的数据
        /// </summary>
        public List<nmfs_terminal_device> CurrentScaleList = new List<nmfs_terminal_device>();

        /// <summary>
        /// 正在使用秤
        /// </summary>
        public nmfs_terminal_device CurrentScale = new nmfs_terminal_device();
        /// <summary>
        /// 保存秤台编号和socket或串口连接实例
        /// </summary>
        public Dictionary<object, object> ExternalScaleConnectMap = new Dictionary<object, object>();


        public Dictionary<object, object> ExternalPrinterConnectMap = new Dictionary<object, object>();



        /// <summary>
        ///  记录称台标定的键值
        /// </summary>
        public Dictionary<string, string[]> CalbrationMap = new Dictionary<string, string[]>();

    

        #endregion


        #region 读取、保存系统配置信息
        public void LoadSystemSettingsConfig()
        {
            try
            {
                SystemSet = ReadXml<SystemSettings>(SystemSetPathName);
            }
            catch (Exception ex) { }
        }
        public void SaveSystemSettingsConfig()
        {
            try
            {
                SaveXml<SystemSettings>(SystemSetPathName, ref SystemSetDefaultValue);
            }
            catch (Exception ex) { }
        }
        public void LoadDBSettingsConfig()
        {
            try
            {
                DBSet = ReadXml<DBSettings>(DBSetPathName);
            }
            catch { }
        }
        public void SaveDBSettingsConfig()
        {
            try
            {
                SaveXml<DBSettings>(DBSetPathName, ref DBSetDefaultValue);
            }
            catch (Exception ex) { }
        }
        #endregion

        #region 系统配置信息方法
        /// <summary>
        ///保存配置文件的类到指定路径[文件类不能包含其他类]
        /// </summary>
        /// <param name="pathname">配置文件路径及文件名</param>
        public static void SaveXml<T>(string pathName, ref T settings) where T : class, new()
        {
            //save profile
            //  settings = new T();
            try
            {
                // 判断配置文件是否存在，不存在则创建
                if (!File.Exists(pathName))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(pathName)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(pathName));
                    }
                    //File.WriteAllText(pathname, null);
                    File.Create(pathName).Dispose();//创建完文件关闭，防止文件被占用;
                }

                // 保存配置数据
                using (FileStream fs = new FileStream(pathName, FileMode.Create, FileAccess.Write))
                {
                    XmlWriterSettings xws = new XmlWriterSettings()
                    {
                        Indent = true,
                        NamespaceHandling = NamespaceHandling.OmitDuplicates,
                        OmitXmlDeclaration = false,
                        Encoding = Encoding.UTF8,
                        NewLineChars = "\r\n"
                    };
                    XmlWriter writer = XmlWriter.Create(fs, xws);
                    XmlSerializer xs = new XmlSerializer(settings.GetType());
                    xs.Serialize(writer, settings);
                    writer.Flush();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 读取配置文件的内容返回到配置文件的类的属性上
        /// </summary>
        /// <param name="pathname">配置文件路径及文件名</param>
        /// <returns>配置文件类</returns>
        public static T ReadXml<T>(string pathName) where T : class, new()
        {
            T settings = new T();
            try
            {
                using (FileStream fs = new FileStream(pathName, FileMode.Open, FileAccess.Read))
                {
                    XmlReader reader = XmlReader.Create(fs);
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    settings = xs.Deserialize(reader) as T;
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return settings;
        }
        #endregion
    }

    [Serializable]
    public class SystemSettings
    {

        #region 系统参数的参数

        /// <summary>
        /// 日志保存时间
        /// </summary>
        public int LogFileDays = 7;

        /// <summary>
        /// 是否强制登录
        /// </summary>
        public bool ForceLogin;

        /// <summary>
        /// 选择进入的界面
        /// </summary>
        public string DevicePrintModel = "";

        /// <summary>
        /// 当前设备的本地IP
        /// </summary>
        public string LocalhostServiceIp = "";

        /// <summary>
        /// 登录限制
        /// </summary>
        public bool LoginRestriction = false;

        /// <summary>
        /// 登录次数阈值
        /// </summary>
        public int FailLoginThreshold = 3;

        /// <summary>
        /// 密码更改时间周期(天)
        /// </summary>
        public int PasswordUpdateCycle = 30;

        /// <summary>
        /// 当前产品的版本号
        /// </summary>
        public string AppVersion = "1.1.1.1";

        /// <summary>
        /// 本机Ip
        /// </summary>
        public string LocalhostIp = "192.168.0.114";
        #endregion

        #region 设备参数的参数

        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceCode = "102";

        /// <summary>
        /// 窗体是否倒计时
        /// </summary>
        public bool NTDMsgCanCountDown = true;

        /// <summary>
        /// 窗体倒计时时间
        /// </summary>
        public int NTDMsgTimeout = 60;


        /// <summary>
        /// 设备启动时间
        /// </summary>
        public string SystemStartTime;

        /// <summary>
        /// 设备关闭时间
        /// </summary>
        public string SystemEndTime;

        #endregion

        #region 秤台的参数

        /// <summary>
        /// 秤台型号
        /// </summary>
        public string BalanceImpl = "BalanceNTD910";

        /// <summary>
        /// 秤台输出模式
        /// </summary>
        public string BalanceOutputType = "";

        /// <summary>
        /// 秤台通讯方式
        /// </summary>
        public string BalanceCommunicationMode = "";

        /// <summary>
        /// 秤台串口
        /// </summary>
        public string BalanceSerialPort = "COM1";


        /// <summary>
        /// 秤台波特率
        /// </summary>
        public int BalanceBaudRate = 9600;


        /// <summary>
        /// 秤台IP
        /// </summary>
        public string BalanceIp = "";

        /// <summary>
        /// 秤台端口
        /// </summary>
        public int BalancePort = 1500;

        #endregion

        #region 打印机的参数

        /// <summary>
        /// 是否使用打印机
        /// </summary>
        public bool UsePrinter = false;

        /// <summary>
        /// 打印机通讯方式
        /// </summary>
        public string PrintCommunicationMode = "";


        /// <summary>
        /// 打印机串口
        /// </summary>
        public string PrintSerialPort = "COM2";


        /// <summary>
        /// 打印机波特率
        /// </summary>
        public int PrintBaudRate = 9600;


        /// <summary>
        /// 打印机IP
        /// </summary>
        public string PrintIp = "";


        /// <summary>
        ///  打印机端口
        /// </summary>
        public int PrintPort = 9100;

        #endregion

        #region 内部称的参数

        /// <summary>
        /// 内部称的数量
        /// </summary>
        public int CurrentNTD910BalanceNumber = 2;


        /// <summary>
        /// 内部称的串口(NTD910内部称串口为COM3)
        /// </summary>
        public string CurrentNTD910SerialPort = "COM3";

        /// <summary>
        /// 内部称的波特率
        /// </summary>
        ///public int CurrentNTD910BaudRate = 115200;

        #endregion

        #region 上传服务器的参数

        /// <summary>
        /// http通讯的ip带http
        /// </summary>
        public string UploadDataHttpIp = "200.200.200.100";

        /// <summary>
        /// http通讯的端口
        /// </summary>
        public int UploadDataHttpPort = 58764;

        /// <summary>
        /// 上传的称重记录的IP
        /// </summary>
        public string UploadDataSocketIp = "200.200.200.100";

        /// <summary>
        /// socket端口
        /// </summary>
        public int UploadDataSocketPort = 58765;


        /// <summary>
        /// 是否上传称重记录
        /// </summary>
        public bool UseUploadService = false;

        /// <summary>
        /// 是否上传称重记录
        /// </summary>
        public bool UploadFlowRecord = false;


        /// <summary>
        /// 是否上传仪表的重量数据
        /// </summary>
        public bool UploadWeightCoreBean = false;

        #endregion


        #region 串口扫码枪参数


        public bool IsUseScanningGun; 
        /// <summary>
        /// 扫码枪串口
        /// </summary>
        public string ScanningGunSerialPort;
        /// <summary>
        /// 扫码枪波特率
        /// </summary>
        public int ScanningGunBaudRate=-1;
        #endregion

        #region 配料web版下位机参数
        /// <summary>
        /// 设备号
        /// </summary>
        public int TerminalUnitNo = 0;

        /// <summary>
        /// 升级程序的路径
        /// </summary>
        public string CalibrationProgramPath = string.Empty;
        /// <summary>
        /// 是否打印报表
        /// </summary>
        public bool IsPrintTaskFlowRecordReport = false;

        /// <summary>
        /// 服务器终端ID
        /// </summary>
        public string CurrentTerminalId = string.Empty;

        /// <summary>
        /// 物料标签打印机Id
        /// </summary>
        public string PartsLabelPrinter = string.Empty; 


        /// <summary>
        /// 物料标签打印机的模板路径
        /// </summary>
        public string PartsLabelPrintLablePath = string.Empty;

        /// <summary>
        /// 物料标签打印机的模板名称
        /// </summary>
        public string PartsLabelPrintLable
        {
            get
            {
                return Path.GetFileNameWithoutExtension(PartsLabelPrintLablePath);
            }
        }

        /// <summary>
        /// 配方标签打印机的Id
        /// </summary>
        public string FormulaLabelPrinter = string.Empty;

        /// <summary>
        /// 配方标签打印机的模板路径
        /// </summary>
        public string FormulaLabelPrintLablePath = string.Empty;

        /// <summary>
        ///配方标签打印机的模板名称
        /// </summary>
        public string FormulaLabelPrintLable
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FormulaLabelPrintLablePath);
            }
        }
        #endregion

    }
    [Serializable]
    public class DBSettings
    {
        //sqlserver

    }

}

