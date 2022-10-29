using FastReport;
using NTDCommLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDCommon
{
    public class ReportFormView
    {
        public string ext1 { get; set; }
        public string ext2 { get; set; }
        public string ext3 { get; set; }
    }
    
    public class FastReportHelper
    {
        /// <summary>
        /// 传参打印
        /// </summary>
        /// <param name="dic">键值对</param>
        /// <param name="file">文件路径</param>
        /// <param name="printerName">打印机名称（没有使用默认打印机）</param>
        /// <param name="printCount">打印次数</param>
        /// <param name="msg">返回信息</param>
        /// <returns></returns>
        public static bool FastReportForParamters(Dictionary<string, object> dic, string file, out string msg, string printerName = "", int printCount = 1)
        {
            msg = string.Empty;
            if (File.Exists(file))
            {
                try
                {
                    Report report = new Report();
                    report.Load(file);
                    foreach (var d in dic)
                    {
                        report.SetParameterValue(d.Key, d.Value);
                    }
                    //指定打印机
                    report.PrintSettings.Printer = string.IsNullOrWhiteSpace(printerName) ? PrinterHelper.GetDefaultPrinter() : printerName; //设置打印机名称
                    //设置打印页码
                    report.PrintSettings.PageNumbers = "1";
                    //打印次数
                    report.PrintSettings.Copies = printCount <= 1 ? 1 : printCount;
                    //打印对话框
                    report.PrintSettings.ShowDialog = false;
                    //打印
                    report.Print();
                    //释放
                    report.Dispose();
                    msg = "打印完成.";
                }
                catch (Exception ex)
                {
                    msg = $"打印出错：{ex.ToString()}";
                    return false;
                }
            }
            else
            {
                msg = "模板文件不存在，请联系管理员.";
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="dataSet"></param>
        /// <param name="file"></param>
        /// <param name="msg"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        public static bool FastReportForParamters(Dictionary<string, object> dic, DataSet dataSet, string file, out string msg, string printerName = "", int printCount = 1)
        {
            msg = string.Empty;
            if (File.Exists(file))
            {
                try
                {
                    Report report = new Report();
                    report.Load(file);

                    foreach (var d in dic)
                    {
                        report.SetParameterValue(d.Key, d.Value);
                    }
                    report.RegisterData(dataSet);// 将DataSet对象注册到FastReport控件中
                    //指定打印机
                    report.PrintSettings.Printer = string.IsNullOrWhiteSpace(printerName) ? PrinterHelper.GetDefaultPrinter() : printerName; //设置打印机名称
                    //设置打印页码
                    report.PrintSettings.PageNumbers = "1";
                    //打印次数
                    report.PrintSettings.Copies = printCount <= 1 ? 1 : printCount;
                    //打印对话框
                    report.PrintSettings.ShowDialog = false;
                    //打印
                    report.Print();
                    //释放
                    report.Dispose();
                    msg = "打印完成.";
                }
                catch (Exception ex)
                {
                    msg = $"打印出错：{ex.ToString()}";
                    return false;
                }
            }
            else
            {
                msg = "模板文件不存在，请联系管理员.";
                return false;
            }
            return true;
        }
    }
}
