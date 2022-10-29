namespace NTDCommon
{
    partial class FrmEditReportTemplate
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditReportTemplate));
            this.PnlCenter = new System.Windows.Forms.Panel();
            this.designerControl1 = new FastReport.Design.StandardDesigner.DesignerControl();
            this.PnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlCenter
            // 
            this.PnlCenter.BackColor = System.Drawing.Color.Transparent;
            this.PnlCenter.Controls.Add(this.designerControl1);
            this.PnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlCenter.Location = new System.Drawing.Point(0, 0);
            this.PnlCenter.Name = "PnlCenter";
            this.PnlCenter.Size = new System.Drawing.Size(1024, 768);
            this.PnlCenter.TabIndex = 333;
            // 
            // designerControl1
            // 
            this.designerControl1.AskSave = true;
            this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl1.LayoutState = resources.GetString("designerControl1.LayoutState");
            this.designerControl1.Location = new System.Drawing.Point(0, 0);
            this.designerControl1.Name = "designerControl1";
            this.designerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.designerControl1.Size = new System.Drawing.Size(1024, 768);
            this.designerControl1.TabIndex = 0;
            // 
            // FrmEditReportTemplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.PnlCenter);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditReportTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FastReport编辑器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEditReportTemplate_Load);
            this.PnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlCenter;
        private FastReport.Design.StandardDesigner.DesignerControl designerControl1;
    }
}

