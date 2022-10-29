namespace NTDCommon
{
    partial class ucShowLable
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucShowLable));
            this.Lbl1 = new System.Windows.Forms.Label();
            this.Lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl1
            // 
            this.Lbl1.AutoSize = true;
            this.Lbl1.BackColor = System.Drawing.Color.Transparent;
            this.Lbl1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.Lbl1.ForeColor = System.Drawing.Color.White;
            this.Lbl1.Location = new System.Drawing.Point(2, 3);
            this.Lbl1.Name = "Lbl1";
            this.Lbl1.Size = new System.Drawing.Size(84, 25);
            this.Lbl1.TabIndex = 5;
            this.Lbl1.Text = "模板名称";
            this.Lbl1.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // Lbl2
            // 
            this.Lbl2.BackColor = System.Drawing.Color.Transparent;
            this.Lbl2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Lbl2.ForeColor = System.Drawing.Color.White;
            this.Lbl2.Location = new System.Drawing.Point(2, 40);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(221, 27);
            this.Lbl2.TabIndex = 8;
            this.Lbl2.Text = "创建时间";
            this.Lbl2.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // ucShowLable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Lbl2);
            this.Controls.Add(this.Lbl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucShowLable";
            this.Size = new System.Drawing.Size(314, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.Label Lbl2;
    }
}
