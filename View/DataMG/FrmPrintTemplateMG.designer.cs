namespace nMFStageClientWin
{
    partial class FrmPrintTemplateMG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrintTemplateMG));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TsrGoods = new System.Windows.Forms.ToolStrip();
            this.TsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.TsbDel = new System.Windows.Forms.ToolStripButton();
            this.TsbAdd = new System.Windows.Forms.ToolStripButton();
            this.TsbCheck = new System.Windows.Forms.ToolStripButton();
            this.TsbExit = new System.Windows.Forms.ToolStripButton();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.TsrGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1024, 70);
            this.panel1.TabIndex = 307;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(30, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(994, 70);
            this.label1.TabIndex = 85;
            this.label1.Tag = "";
            this.label1.Text = "模板管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TsrGoods
            // 
            this.TsrGoods.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TsrGoods.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TsrGoods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbRefresh,
            this.TsbDel,
            this.TsbAdd,
            this.TsbCheck,
            this.TsbExit});
            this.TsrGoods.Location = new System.Drawing.Point(0, 70);
            this.TsrGoods.Name = "TsrGoods";
            this.TsrGoods.Size = new System.Drawing.Size(1024, 70);
            this.TsrGoods.TabIndex = 372;
            this.TsrGoods.Text = "toolStrip1";
            // 
            // TsbRefresh
            // 
            this.TsbRefresh.AutoSize = false;
            this.TsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("TsbRefresh.Image")));
            this.TsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbRefresh.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TsbRefresh.Name = "TsbRefresh";
            this.TsbRefresh.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TsbRefresh.Size = new System.Drawing.Size(60, 60);
            this.TsbRefresh.Text = "刷新";
            this.TsbRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbRefresh.Click += new System.EventHandler(this.PicRefresh_Click);
            // 
            // TsbDel
            // 
            this.TsbDel.AutoSize = false;
            this.TsbDel.Image = ((System.Drawing.Image)(resources.GetObject("TsbDel.Image")));
            this.TsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbDel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TsbDel.Name = "TsbDel";
            this.TsbDel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TsbDel.Size = new System.Drawing.Size(60, 60);
            this.TsbDel.Text = "删除";
            this.TsbDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TsbDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbDel.Click += new System.EventHandler(this.TsbDel_Click);
            // 
            // TsbAdd
            // 
            this.TsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("TsbAdd.Image")));
            this.TsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAdd.Name = "TsbAdd";
            this.TsbAdd.Size = new System.Drawing.Size(46, 67);
            this.TsbAdd.Text = "添加";
            this.TsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbAdd.Click += new System.EventHandler(this.TsbAdd_Click);
            // 
            // TsbCheck
            // 
            this.TsbCheck.AutoSize = false;
            this.TsbCheck.Image = ((System.Drawing.Image)(resources.GetObject("TsbCheck.Image")));
            this.TsbCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbCheck.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TsbCheck.Name = "TsbCheck";
            this.TsbCheck.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TsbCheck.Size = new System.Drawing.Size(60, 60);
            this.TsbCheck.Text = "选择";
            this.TsbCheck.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TsbCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbCheck.Click += new System.EventHandler(this.TsbCheck_Click);
            // 
            // TsbExit
            // 
            this.TsbExit.AutoSize = false;
            this.TsbExit.Image = ((System.Drawing.Image)(resources.GetObject("TsbExit.Image")));
            this.TsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbExit.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.TsbExit.Name = "TsbExit";
            this.TsbExit.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TsbExit.Size = new System.Drawing.Size(60, 60);
            this.TsbExit.Text = "关闭";
            this.TsbExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TsbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsbExit.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // DgvData
            // 
            this.DgvData.AllowUserToAddRows = false;
            this.DgvData.BackgroundColor = System.Drawing.Color.White;
            this.DgvData.ColumnHeadersHeight = 40;
            this.DgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColCreationTime,
            this.ColFullName});
            this.DgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvData.Location = new System.Drawing.Point(0, 140);
            this.DgvData.Margin = new System.Windows.Forms.Padding(2);
            this.DgvData.MultiSelect = false;
            this.DgvData.Name = "DgvData";
            this.DgvData.ReadOnly = true;
            this.DgvData.RowHeadersWidth = 25;
            this.DgvData.RowTemplate.Height = 40;
            this.DgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvData.Size = new System.Drawing.Size(1024, 628);
            this.DgvData.TabIndex = 374;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColName.DataPropertyName = "Name";
            this.ColName.HeaderText = "文件名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 83;
            // 
            // ColCreationTime
            // 
            this.ColCreationTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColCreationTime.DataPropertyName = "CreationTime";
            this.ColCreationTime.HeaderText = "时间";
            this.ColCreationTime.Name = "ColCreationTime";
            this.ColCreationTime.ReadOnly = true;
            this.ColCreationTime.Width = 67;
            // 
            // ColFullName
            // 
            this.ColFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColFullName.DataPropertyName = "FullName";
            this.ColFullName.HeaderText = "路径";
            this.ColFullName.Name = "ColFullName";
            this.ColFullName.ReadOnly = true;
            this.ColFullName.Width = 67;
            // 
            // FrmPrintTemplateMG
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.TsrGoods);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPrintTemplateMG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmPrintTemplateMG_Load);
            this.panel1.ResumeLayout(false);
            this.TsrGoods.ResumeLayout(false);
            this.TsrGoods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip TsrGoods;
        private System.Windows.Forms.ToolStripButton TsbRefresh;
        private System.Windows.Forms.ToolStripButton TsbDel;
        private System.Windows.Forms.ToolStripButton TsbExit;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFullName;
        private System.Windows.Forms.ToolStripButton TsbAdd;
        private System.Windows.Forms.ToolStripButton TsbCheck;
    }
}

