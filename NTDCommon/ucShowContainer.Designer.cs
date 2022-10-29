namespace NTDCommon
{
    partial class ucShowContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucShowContainer));
            this.Lbl1 = new System.Windows.Forms.Label();
            this.Lbl2 = new System.Windows.Forms.Label();
            this.Lbl3 = new System.Windows.Forms.Label();
            this.Lbl4 = new System.Windows.Forms.Label();
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
            this.Lbl1.Text = "容器名称";
            this.Lbl1.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // Lbl2
            // 
            this.Lbl2.AutoSize = true;
            this.Lbl2.BackColor = System.Drawing.Color.Transparent;
            this.Lbl2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Lbl2.ForeColor = System.Drawing.Color.White;
            this.Lbl2.Location = new System.Drawing.Point(2, 35);
            this.Lbl2.Name = "Lbl2";
            this.Lbl2.Size = new System.Drawing.Size(69, 20);
            this.Lbl2.TabIndex = 7;
            this.Lbl2.Text = "容器编号";
            this.Lbl2.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // Lbl3
            // 
            this.Lbl3.AutoSize = true;
            this.Lbl3.BackColor = System.Drawing.Color.Transparent;
            this.Lbl3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Lbl3.ForeColor = System.Drawing.Color.White;
            this.Lbl3.Location = new System.Drawing.Point(2, 60);
            this.Lbl3.Name = "Lbl3";
            this.Lbl3.Size = new System.Drawing.Size(69, 20);
            this.Lbl3.TabIndex = 8;
            this.Lbl3.Text = "容器皮重";
            this.Lbl3.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // Lbl4
            // 
            this.Lbl4.AutoSize = true;
            this.Lbl4.BackColor = System.Drawing.Color.Transparent;
            this.Lbl4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Lbl4.ForeColor = System.Drawing.Color.White;
            this.Lbl4.Location = new System.Drawing.Point(2, 85);
            this.Lbl4.Name = "Lbl4";
            this.Lbl4.Size = new System.Drawing.Size(69, 20);
            this.Lbl4.TabIndex = 9;
            this.Lbl4.Text = "容器状态";
            this.Lbl4.Click += new System.EventHandler(this.Lbl_Click);
            // 
            // ucMFSContainer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Lbl4);
            this.Controls.Add(this.Lbl3);
            this.Controls.Add(this.Lbl2);
            this.Controls.Add(this.Lbl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucMFSContainer";
            this.Size = new System.Drawing.Size(210, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl1;
        private System.Windows.Forms.Label Lbl2;
        private System.Windows.Forms.Label Lbl3;
        private System.Windows.Forms.Label Lbl4;
    }
}
