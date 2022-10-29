using NTDCommLib;
using NTDCommon;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBService;
using System.Threading;

namespace nMFStageClientWin
{
    public partial class FrmSelectParts : Form
    {
        AppSettings AppSet =>AppSettings.AppSet;
        SystemSettings SystemSet => AppSet.SystemSet;


        //当前临时表的本任务的所有物料信息
        List<nmfs_current_open_task> CurrentAllData = new List<nmfs_current_open_task>();
        //符合条件的物料信息
        List<nmfs_current_open_task> AllData = new List<nmfs_current_open_task>();
        //要分页的物料信息
        List<nmfs_current_open_task> PageData = new List<nmfs_current_open_task>();

        //控件集合
        List<ucShowParts> ucShowPartsList = new List<ucShowParts>();

        //查询参数
        nmfs_current_open_task CurrentOpenTaskQueryEntity = new nmfs_current_open_task();


        //分页参数(内存级分页)
        int PageSize = 16;
        int CurrentPageIndex = 1;
        int TotalPageCount = 0;
        public FrmSelectParts()
        {
            InitializeComponent();
            SetControlList();
            //查询配方名称
            //tb_formula formula = new tb_formula();
            //formula.id =IntHelper.Conversion( AppSet.CurrentTask.formula_id);

            //if (FormulaService.IsExistByEntity(formula,out formula))
            //{
            //        LblTitle.Text = $"选择物料   任务名称：{ AppSet.CurrentTask.name}  配方名称：{formula.name}";
            //}
        }
        private void SetControlList()
        {
            ucShowPartsList.Add(ucShowParts_0);
            ucShowPartsList.Add(ucShowParts_1);
            ucShowPartsList.Add(ucShowParts_2);
            ucShowPartsList.Add(ucShowParts_3);
            ucShowPartsList.Add(ucShowParts_4);
            ucShowPartsList.Add(ucShowParts_5);
            ucShowPartsList.Add(ucShowParts_6);
            ucShowPartsList.Add(ucShowParts_7);
            ucShowPartsList.Add(ucShowParts_8);
            ucShowPartsList.Add(ucShowParts_9);
            ucShowPartsList.Add(ucShowParts_10);
            ucShowPartsList.Add(ucShowParts_11);
            ucShowPartsList.Add(ucShowParts_12);
            ucShowPartsList.Add(ucShowParts_13);
            ucShowPartsList.Add(ucShowParts_14);
            ucShowPartsList.Add(ucShowParts_15);
        }

        private void FrmSelectParts_Load(object sender, EventArgs e)
        {
            try
            {
                LblSystemName.Text = "选择物料   任务名称:" + AppSet.CurrentTask.name + "  配方名称:" + AppSet.CurrentTask.formula_name;


                CurrentOpenTaskQueryEntity = new nmfs_current_open_task();
                CurrentOpenTaskQueryEntity.task_serial_number = AppSet.CurrentTask.serial_number;
                CurrentAllData = NmfsCurrentOpenTaskService.GetDataByEntity(CurrentOpenTaskQueryEntity).OrderBy(it=>it.task_details_sort).ToList();
                switch (AppSet.CurrentTask.batching_way)
                {
                    default:
                    case ("AAA-BBB-CCC"):
                        AllData = CurrentAllData.Where(it => it.task_current_count < it.task_all_count).ToList();
                        if (AllData.Count == 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Dispose();
                            return;
                        }
                        break;
                    case ("ABC-ABC-ABC"):
                        //取已做任务的最少次数
                        ArrayList list = new ArrayList();
                        foreach (var data in CurrentAllData)
                        {
                            list.Add(data.task_current_count);
                        }
                        list.Sort();
                        if (DecimalHelper.Conversion(list[0]) >= AppSet.CurrentTask.num)
                        {
                            //if (string.IsNullOrWhiteSpace(CurrentOpenPeiFangs.id))
                            //{
                            //    NTDMsg.TouchFlatMsgInfo($"{AppStat.CurrentTaskLists.taskName}任务已完成");
                            //}
                            this.DialogResult = DialogResult.OK;
                            this.Dispose();
                            return;
                        }
                        AllData = CurrentAllData.Where(it => it.task_current_count == IntHelper.Conversion(list[0])).ToList();
                        break;
                }

                PageQuery(NTDPageEnum.None);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }

        #region 按键事件
        /// <summary>
        /// 监听按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case (Keys.F1):
                        if (!BtnClose.Enabled) return;
                        BtnClose_Click(BtnClose, e);
                        break;
                    case (Keys.F2):

                        break;
                    case (Keys.F3):

                        break;
                    case (Keys.F4):
                        break;
                    case (Keys.F5):

                        break;
                    case (Keys.F6):
                        if (!BtnPrevPage.Enabled) return;
                        BtnPrevPage_Click(BtnPrevPage, e);
                        break;
                    case (Keys.F7):

                        break;
                    case (Keys.F8):
                        if (!BtnNextPage.Enabled) return;
                        BtnNextPage_Click(BtnNextPage, e);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
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

      


        /// <summary>
        /// 前一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                PageQuery(NTDPageEnum.Previous);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }

        /// <summary>
        /// 下一页数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Enabled = false;
            try
            {
                PageQuery(NTDPageEnum.Next);
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
                //防止重复点击
                Thread.Sleep(1000);
                Application.DoEvents();
                b.Enabled = true;
            }
        }
        #endregion

     
        private void PageQuery(NTDPageEnum p, int Page = 1)
        {
                switch (p)
                {
                    case NTDPageEnum.None:
                        {
                            CurrentPageIndex = 1;  
                            break;
                        }
                    case NTDPageEnum.Previous:
                        {
                            if (CurrentPageIndex > 1)
                            {
                                CurrentPageIndex--;
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是第一页!"); 
                                return;
                            }
                        }
                    case NTDPageEnum.Next:
                        {
                            if (CurrentPageIndex < TotalPageCount)
                            {
                                CurrentPageIndex++;
                                break;
                            }
                            else
                            {
                                NTDMsg.TouchFlatMsgInfo("当前已是最后一页!");
                                return;
                            }
                        }
                }
              
                PageData = PageHelper.GetPageList<nmfs_current_open_task>(AllData, CurrentPageIndex, PageSize, out TotalPageCount);

                LblPageInfo.Text = $"{CurrentPageIndex} / {TotalPageCount}";

                if (AllData != null)
                {
                    ShowPageList(PageData);
                }
                else
                {
                    ClearPageList();
                }

        }

        private void ClearPageList()
        {
            for (int i = 0; i < ucShowPartsList.Count; i++)
            {
                ucShowPartsList[i].Tag = "";
                ucShowPartsList[i].Visible = false;
            }
        }

        private void ShowPageList(List<nmfs_current_open_task> pageData)
        {
            ClearPageList();
            int i = 0;
            foreach (var data in pageData)
            {
                // 更新块状显示数据
                ucShowPartsList[i].Tag = data;
                if (ucShowPartsList[i].Tag == null || string.IsNullOrWhiteSpace(ucShowPartsList[i].Tag.ToString())) continue;

                ucShowPartsList[i].Visible = true; 
                ucShowPartsList[i].GoodName = data.parts_name;
                ucShowPartsList[i].GoodsNo = "物料编号: " + data.parts_id; 
                ucShowPartsList[i].Weight = "目标重量: " + data.standard_weight + data.weight_unit;
                ucShowPartsList[i].Order = "配料顺序: " + data.task_details_sort; 
                i++;
            }

        }

        private void ucShowParts_0_Click(object sender, EventArgs e)
        {
            ucShowParts p = (ucShowParts)sender;
            if (p.Tag == null) return;
            nmfs_current_open_task currentOpenTask = (nmfs_current_open_task)p.Tag;
      
                var frm = new FrmWeight(currentOpenTask);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                this.Dispose();
                    return;
                }
            
            FrmSelectParts_Load(this, e);
        }
    }
}
