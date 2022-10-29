
using Model;
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
   public  class NTDFunc
    {
        static AppSettings  AppSet =>AppSettings. AppSet;
        static SystemSettings SystemSet =>AppSettings. AppSet.SystemSet;
        /// <summary>
        /// 用,分割的权限名字
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static bool AuthorityVerification(string userPermission, string permission, out string msg)
        {
            msg = string.Empty;
            try
            {

                if (userPermission == null)
                {
                    msg = "用户未登录！";
                    return false;
                }

                string[] strArray = userPermission.Split(',');
                string[] permissionArray = permission.Split(',');
                if (strArray == null || strArray.Length <= 0)
                {
                    msg = "用户权限为空！";
                    return false;
                }

                foreach (var item in strArray)
                {
                    if (item == "超级管理员")
                    {
                        return true;
                    }
                    foreach (var item1 in permissionArray)
                    {
                        if (item == item1)
                        {
                            return true;
                        }
                    }
                }
                msg = "您没有该权限,请联系管理员添加权限！";
                return false;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 切换秤台
        /// </summary>
        /// <param name="type"></param>
        public static void ChangScaleDetails(bool type,List<nmfs_terminal_device> currentScaleList)
        {

            try
            {
                //切换到第一个秤台
                if (type)
                {
                    if (currentScaleList.Count > 0)
                    {
                        //选择第一个秤台打开
                        AppSet.CurrentScale = currentScaleList.First();
                        if (AppSet.ExternalScaleConnectMap.ContainsKey(AppSet.CurrentScale.id))
                        {
                            AppSet.CurrentBalanceInterface = (BalanceInterface)AppSet.ExternalScaleConnectMap[AppSet.CurrentScale.id];
                            if (AppSet.CurrentBalanceInterface == null)
                            {
                                NTDMsg.TouchFlatMsgError("称台编号" + AppSet.CurrentScale.code + ",称台名称为" + AppSet.CurrentScale.name + "的称台解析错误.");
                            }
                            else if (!AppSet.CurrentBalanceInterface.GetStatus())
                            {
                                NTDMsg.TouchFlatMsgError("称台编号" + AppSet.CurrentScale.code + ",称台名称为" + AppSet.CurrentScale.name + "的错误信息：" + AppSet.CurrentBalanceInterface.GetMessageInfo());
                            }

                            //else
                            //{
                            //    //称台改变重量数据初始化
                            //    AppSet.CurrentWcb = new WeightCoreBean();
                            //    AppSet.CurrentInterfaceScale.SetScaleDetails(AppSet.CurrentScale);
                            //}
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(AppSet.CurrentScale.id)&& currentScaleList.Count > 1)
                {
                    int i = currentScaleList.FindIndex(delegate (nmfs_terminal_device it)
                    {
                        return it.id == AppSet.CurrentScale.id;
                    });
                    //根据下标为开始数据重新排序
                    currentScaleList = ListHelper.ReorderByIndex(currentScaleList, i);
                    AppSet.CurrentScale = currentScaleList[1];
                    //查询秤台是否存在
                    if (AppSet.ExternalScaleConnectMap.ContainsKey(AppSet.CurrentScale.id))
                    {
                        AppSet.CurrentBalanceInterface = (BalanceInterface)AppSet.ExternalScaleConnectMap[AppSet.CurrentScale.id];
                        if (AppSet.CurrentBalanceInterface == null)
                        {
                            NTDMsg.TouchFlatMsgError("称台编号" + AppSet.CurrentScale.code + ",称台名称为" + AppSet.CurrentScale.name + "的称台解析错误.");
                        }
                        else if (!AppSet.CurrentBalanceInterface.GetStatus())
                        {
                            NTDMsg.TouchFlatMsgError("称台编号" + AppSet.CurrentScale.code + ",称台名称为" + AppSet.CurrentScale.name + "的错误信息：" + AppSet.CurrentBalanceInterface.GetMessageInfo());
                        }
                        //else
                        //{  //称台改变重量数据初始化
                        //    AppSet.CurrentWcb = new WeightCoreBean();
                        //    AppSet.CurrentInterfaceScale.SetScaleDetails(AppSet.CurrentScale);
                        //}
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 选中秤台
        /// </summary>
        /// <param name="type"></param>
        public static BalanceInterface SelectBalanceInterface(object o)
        {
            try
            {
                if (o == null) return null;
                //查询秤台是否存在
                if (AppSet.ExternalScaleConnectMap.ContainsKey(o))
                {
                    return (BalanceInterface)AppSet.ExternalScaleConnectMap[o];
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 选中打印机
        /// </summary>
        /// <param name="type"></param>
        public static PrintInterface SelectPrintInterface(object o)
        {
            try
            {
                if (o == null) return null;
                //查询秤台是否存在
                if (AppSet.ExternalPrinterConnectMap.ContainsKey(o))
                {
                    return (PrintInterface)AppSet.ExternalPrinterConnectMap[o];
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 查询适合的秤台
        /// </summary>
        /// <param name="scaleList"></param>
        /// <param name="upper_limit"></param>
        /// <param name="lower_limit"></param>
        /// <param name="standard_weight"></param>
        /// <param name="weight_unit"></param>
        /// <param name="currentDeviceDetails"></param>
        /// <param name="msg"></param>
        /// <param name="isContentRange"></param>
        /// <returns></returns>
        public static bool SwitchBalanceInterface(List<nmfs_terminal_device> scaleList, decimal upper_limit, decimal lower_limit, decimal standard_weight, string weight_unit, ref nmfs_terminal_device currentDeviceDetails, out string msg, bool isContentRange)
        {
            msg = string.Empty;
            currentDeviceDetails = new nmfs_terminal_device();
            //临时
            var tempScaleList = new List<nmfs_terminal_device>();

            //判断单位
            scaleList = scaleList.Where(it => it.weight_unit == weight_unit).ToList();
            if (scaleList.Count() <= 0)
            {

                msg = "当前未有单位为" + weight_unit + "的合适秤台";
                return false;
            }
            //判断所称重的目标值是否大于最小称量值
            scaleList = scaleList.Where(it => it.min_weight_value <= standard_weight).ToList();
            if (scaleList.Count() <= 0)
            {
                msg = "未找到最小称量值大于目标重量的合适秤台";
                return false;
            }



            decimal tolPlus = upper_limit - standard_weight;
            decimal tolMinus = standard_weight - lower_limit;
            decimal minTol = (tolMinus <= tolPlus) ? tolMinus : tolPlus;//找最小的差值

            scaleList = scaleList.OrderBy(o => o.divison).OrderByDescending(o => o.range_no).ToList();//升序
            //误差为0， 切换为分度值最小的秤目标重量必须在量程之内(如果有分度值相同判断量程取小的)
            if (minTol == 0)
            {
                //查找最小分度值的数据
                tempScaleList = new List<nmfs_terminal_device>();
                tempScaleList = scaleList;
                //判断称重是否满足满量程
                if (isContentRange)
                {
                    tempScaleList = tempScaleList.Where(it => it.range_no > standard_weight).ToList();
                    if (tempScaleList.Count == 0)
                    {
                        msg = "没有合适量程的称台";
                        return false;
                    }
                }

                switch (tempScaleList.Count)
                {
                    case (0):

                        msg = "称台满量程小于当前目标重量";
                        return false;
                    default:
                        currentDeviceDetails = tempScaleList.First();
                        return true;
                }
            }
            else
            {
                //查找最接近分度值的数据(如果有分度值相同判断量程)
                tempScaleList = new List<nmfs_terminal_device>();
                tempScaleList = scaleList.Where(it => minTol >= it.divison).ToList();
                if (tempScaleList.Count == 0)
                {
                    msg = "没有合适分度值的称台";
                    return false;
                }

                //是否称重的重量小于满量程
                if (isContentRange)
                {
                    tempScaleList = tempScaleList.Where(it => it.range_no > standard_weight).ToList();
                    if (tempScaleList.Count == 0)
                    {
                        msg = "没有合适量程的称台";
                        return false;
                    }

                }

                switch (tempScaleList.Count)
                {
                    case (0):

                        msg = "称台满量程小于当前目标重量或者称台没有满足的分度值";
                        return false;
                    default:
                        currentDeviceDetails = tempScaleList.First();
                        return true;
                }
            }
        }

        /// <summary>
        /// 查询适合的多秤台
        /// </summary>
        /// <param name="scaleList"></param>
        /// <param name="upper_limit"></param>
        /// <param name="lower_limit"></param>
        /// <param name="standard_weight"></param>
        /// <param name="weight_unit"></param>
        /// <param name="currentDeviceDetails"></param>
        /// <param name="msg"></param>
        /// <param name="isContentRange"></param>
        /// <returns></returns>
        public static bool SwitchBalanceInterface(List<nmfs_terminal_device> scaleList, decimal upper_limit, decimal lower_limit, decimal standard_weight, string weight_unit, ref  List<nmfs_terminal_device> currentDeviceDetailsList, out string msg, bool isContentRange)
        {
            msg = string.Empty;
            currentDeviceDetailsList = new List<nmfs_terminal_device>();
            //临时
            var tempScaleList = new List<nmfs_terminal_device>();

            //判断单位
            scaleList = scaleList.Where(it => it.weight_unit == weight_unit).ToList();
            if (scaleList.Count() <= 0)
            {

                msg = "当前未有单位为" + weight_unit + "的合适秤台";
                return false;
            }
            //判断所称重的目标值是否大于最小称量值
            scaleList = scaleList.Where(it => it.min_weight_value <= standard_weight).ToList();
            if (scaleList.Count() <= 0)
            {
                msg = "未找到最小称量值大于目标重量的合适秤台";
                return false;
            }



            decimal tolPlus = upper_limit - standard_weight;
            decimal tolMinus = standard_weight - lower_limit;
            decimal minTol = (tolMinus <= tolPlus) ? tolMinus : tolPlus;//找最小的差值

            scaleList = scaleList.OrderBy(o => o.divison).OrderByDescending(o => o.range_no).ToList();//升序
            //误差为0， 切换为分度值最小的秤目标重量必须在量程之内(如果有分度值相同判断量程取小的)
            if (minTol == 0)
            {
                //查找最小分度值的数据
                tempScaleList = new List<nmfs_terminal_device>();
                tempScaleList = scaleList;
                //判断称重是否满足满量程
                if (isContentRange)
                {
                    tempScaleList = tempScaleList.Where(it => it.range_no > standard_weight).ToList();
                    if (tempScaleList.Count == 0)
                    {
                        msg = "没有合适量程的称台";
                        return false;
                    }
                }

                switch (tempScaleList.Count)
                {
                    case (0):

                        msg = "称台满量程小于当前目标重量";
                        return false;
                    default:
                        currentDeviceDetailsList = tempScaleList;
                        return true;
                }
            }
            else
            {
                //查找最接近分度值的数据(如果有分度值相同判断量程)
                tempScaleList = new List<nmfs_terminal_device>();
                tempScaleList = scaleList.Where(it => minTol >= it.divison).ToList();
                if (tempScaleList.Count == 0)
                {
                    msg = "没有合适分度值的称台";
                    return false;
                }

                //是否称重的重量小于满量程
                if (isContentRange)
                {
                    tempScaleList = tempScaleList.Where(it => it.range_no > standard_weight).ToList();
                    if (tempScaleList.Count == 0)
                    {
                        msg = "没有合适量程的称台";
                        return false;
                    }

                }

                switch (tempScaleList.Count)
                {
                    case (0):

                        msg = "称台满量程小于当前目标重量或者称台没有满足的分度值";
                        return false;
                    default:
                        currentDeviceDetailsList = tempScaleList;
                        return true;
                }
            }
        }



        /// <summary>
        /// 打印物料标签
        /// </summary>
        /// <param name="currentFlowRecord"></param>
        public static void PrintPartsFastReport(nmfs_flow_records currentFlowRecord)
        {
            try
            {
                //是否打印物料标签
                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic.Add("login_user_username", currentFlowRecord.login_user_username);
                dic.Add("formula_id", currentFlowRecord.formula_id + "_V" + currentFlowRecord.formula_version_name);//配方编号
                dic.Add("formula_name", currentFlowRecord.formula_name);
                dic.Add("task_serial_number", currentFlowRecord.task_serial_number + "_" + currentFlowRecord.task_current_count);
                dic.Add("parts_batch_numbers", currentFlowRecord.review_barcode);
                dic.Add("parts_id", currentFlowRecord.parts_id);
                dic.Add("parts_name", currentFlowRecord.parts_name);
                dic.Add("weight", (DecimalHelper.Conversion(currentFlowRecord.real_net_weight) + DecimalHelper.Conversion(currentFlowRecord.package_count_weight) + " " + currentFlowRecord.real_unit));
                dic.Add("real_time", DateTimeHelper.Conversion(currentFlowRecord.real_time).ToString("yyyy-MM-dd HH:mm:ss"));
                dic.Add("QR_code", dic["parts_batch_numbers"] + "," + dic["task_serial_number"] + "," + dic["parts_id"] + "," + dic["weight"]);

                string msg = string.Empty;
                //驱动打印
                if (!FastReportHelper.FastReportForParamters(dic, SystemSet.PartsLabelPrintLablePath, out msg, SystemSet.PartsLabelPrinter))
                {
                    NTDMsg.TouchFlatMsgError(msg);
                    return;
                }

            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("打印失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 打印配方
        /// </summary>
        /// <param name="currentFlowRecord"></param>
        public static void PrintFormulaFastReport(Dictionary<string, object> dic, List<ReportFormView> reportFormViewList)
        {
            try
            {
                string msg = string.Empty;
              
                if (reportFormViewList.Count <= 0)
                {
                    NTDMsg.TouchFlatMsgError("暂无称重记录");
                    return;
                }

                List<ReportFormView> currentReportFormViewList = new List<ReportFormView>();
                int i = 1;
                int j = 0;
                foreach (var item in reportFormViewList)
                {
                    j ++;
                    if (i <= 1)
                    {
                        currentReportFormViewList = new List<ReportFormView>();
                    }

                    currentReportFormViewList.Add(item);
                    if (i>=7)
                    {
                        //开始循环打印
                        DataSet dataSet = new DataSet();
                        DataTable dt = new DataTable();
                        dt = DataTableHelper.ToDataTable(currentReportFormViewList);
                        dt.TableName = "ReportFormView"; // 一定要设置表名称
                        dataSet.Tables.Add(dt);
                        //驱动打印
                        if (!FastReportHelper.FastReportForParamters(dic, dataSet, SystemSet.FormulaLabelPrintLablePath, out msg, SystemSet.FormulaLabelPrinter))
                        {
                            NTDMsg.TouchFlatMsgError(msg);
                        }
                        i = 1;
                        continue;
                    }

                    if (j>= reportFormViewList.Count)
                    {
                        //开始循环打印
                        DataSet dataSet = new DataSet();
                        DataTable dt = new DataTable();
                        dt = DataTableHelper.ToDataTable(currentReportFormViewList);
                        dt.TableName = "ReportFormView"; // 一定要设置表名称
                        dataSet.Tables.Add(dt);
                        //驱动打印
                        if (!FastReportHelper.FastReportForParamters(dic, dataSet, SystemSet.FormulaLabelPrintLablePath, out msg, SystemSet.FormulaLabelPrinter))
                        {
                            NTDMsg.TouchFlatMsgError(msg);
                        }
                        i = 1;
                    }

                    i++;
                }

            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError("打印失败：" + ex.Message);
            }
        }
    }
}
