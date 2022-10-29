using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTDCommon
{
    public partial class FrmEditReportTemplate : Form
    {
        public FrmEditReportTemplate()
        {
            InitializeComponent();
        }


        private void FrmEditReportTemplate_Load(object sender, EventArgs e)
        {
            //   //创建一个空的报表
            //   Report report = new Report();
            //   designerControl1.Report = report;
            //   //恢复设计布局
            //   designerControl1.RefreshLayout();
            ////   panel2.Controls.Add(designerControl1);
            //   designerControl1.Dock = DockStyle.Fill;
            //   designerControl1.UIStateChanged += designerControl1_UIStateChanged;
            //
            
            
            
            
            
            //加载时新建一个报表，把他附加到设计器上

            Report report = new Report();
            designerControl1.Report = report;

            //  这时打开窗口，可以清晰的看到FastReport的工作区 了，但同时还有个问题，就是在视图里面点击数据源、 属性等看不到相应的窗口，这时再加一句代码刷新
            designerControl1.RefreshLayout();
        }

        //// 设计器ui改变事件
        //private void designerControl1_UIStateChanged(object sender, EventArgs e)
        //{
        //    // btnSave.Enabled = designerControl1.cmdSave.Enabled;
        //    // btnUndo.Enabled = designerControl1.cmdUndo.Enabled;
        //    // btnRedo.Enabled = designerControl1.cmdRedo.Enabled;
        //}
    }
}
