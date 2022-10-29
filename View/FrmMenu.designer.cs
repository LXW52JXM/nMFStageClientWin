namespace nMFStageClientWin
{
    partial class FrmMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.TmrSysTime = new System.Windows.Forms.Timer(this.components);
            this.BtnReStart = new System.Windows.Forms.Button();
            this.BtnScaleSetting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.BtnDataMG = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrSysTime
            // 
            this.TmrSysTime.Enabled = true;
            this.TmrSysTime.Interval = 200;
            this.TmrSysTime.Tick += new System.EventHandler(this.TmrSysTime_Tick);
            // 
            // BtnReStart
            // 
            this.BtnReStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnReStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReStart.FlatAppearance.BorderSize = 0;
            this.BtnReStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReStart.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnReStart.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnReStart.Image = ((System.Drawing.Image)(resources.GetObject("BtnReStart.Image")));
            this.BtnReStart.Location = new System.Drawing.Point(625, 153);
            this.BtnReStart.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnReStart.Name = "BtnReStart";
            this.BtnReStart.Size = new System.Drawing.Size(220, 220);
            this.BtnReStart.TabIndex = 33;
            this.BtnReStart.TabStop = false;
            this.BtnReStart.Text = "退出程序";
            this.BtnReStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnReStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnReStart.UseVisualStyleBackColor = false;
            this.BtnReStart.Click += new System.EventHandler(this.BtnReStart_Click);
            // 
            // BtnScaleSetting
            // 
            this.BtnScaleSetting.BackColor = System.Drawing.Color.Transparent;
            this.BtnScaleSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnScaleSetting.FlatAppearance.BorderSize = 0;
            this.BtnScaleSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnScaleSetting.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnScaleSetting.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnScaleSetting.Image = ((System.Drawing.Image)(resources.GetObject("BtnScaleSetting.Image")));
            this.BtnScaleSetting.Location = new System.Drawing.Point(183, 420);
            this.BtnScaleSetting.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnScaleSetting.Name = "BtnScaleSetting";
            this.BtnScaleSetting.Size = new System.Drawing.Size(220, 220);
            this.BtnScaleSetting.TabIndex = 34;
            this.BtnScaleSetting.TabStop = false;
            this.BtnScaleSetting.Text = "系统设置";
            this.BtnScaleSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnScaleSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnScaleSetting.UseVisualStyleBackColor = false;
            this.BtnScaleSetting.Click += new System.EventHandler(this.BtnScaleSetting_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblTime);
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
            this.label1.Size = new System.Drawing.Size(590, 70);
            this.label1.TabIndex = 85;
            this.label1.Tag = "系统名称";
            this.label1.Text = "菜单设置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.Transparent;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblTime.Font = new System.Drawing.Font("微软雅黑", 24.25F);
            this.LblTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblTime.Location = new System.Drawing.Point(620, 0);
            this.LblTime.Margin = new System.Windows.Forms.Padding(0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.LblTime.Size = new System.Drawing.Size(404, 70);
            this.LblTime.TabIndex = 82;
            this.LblTime.Text = "2020-10-22 12:00:00";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // BtnDataMG
            // 
            this.BtnDataMG.BackColor = System.Drawing.Color.Transparent;
            this.BtnDataMG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDataMG.FlatAppearance.BorderSize = 0;
            this.BtnDataMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDataMG.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnDataMG.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnDataMG.Image = ((System.Drawing.Image)(resources.GetObject("BtnDataMG.Image")));
            this.BtnDataMG.Location = new System.Drawing.Point(183, 153);
            this.BtnDataMG.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnDataMG.Name = "BtnDataMG";
            this.BtnDataMG.Size = new System.Drawing.Size(220, 220);
            this.BtnDataMG.TabIndex = 35;
            this.BtnDataMG.TabStop = false;
            this.BtnDataMG.Text = "数据管理";
            this.BtnDataMG.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDataMG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnDataMG.UseVisualStyleBackColor = false;
            this.BtnDataMG.Click += new System.EventHandler(this.BtnDataMG_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.Transparent;
            this.BtnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnBack.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnBack.Image = ((System.Drawing.Image)(resources.GetObject("BtnBack.Image")));
            this.BtnBack.Location = new System.Drawing.Point(625, 420);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(220, 220);
            this.BtnBack.TabIndex = 30;
            this.BtnBack.TabStop = false;
            this.BtnBack.Text = "返  回";
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // FrmConfiguration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.BtnReStart);
            this.Controls.Add(this.BtnScaleSetting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnDataMG);
            this.Controls.Add(this.BtnBack);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConfiguration_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnReStart;
        private System.Windows.Forms.Button BtnScaleSetting;
        private System.Windows.Forms.Button BtnDataMG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer TmrSysTime;
    }
}

