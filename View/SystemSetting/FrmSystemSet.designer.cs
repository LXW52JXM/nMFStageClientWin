namespace nMFStageClientWin
{
    partial class FrmSystemSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemSet));
            this.TmrSysTime = new System.Windows.Forms.Timer(this.components);
            this.BtnSetService = new System.Windows.Forms.Button();
            this.BtnScaleSetting = new System.Windows.Forms.Button();
            this.BtnSetscanningGun = new System.Windows.Forms.Button();
            this.BtnSetScaleNum = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrSysTime
            // 
            this.TmrSysTime.Enabled = true;
            this.TmrSysTime.Interval = 1000;
            this.TmrSysTime.Tick += new System.EventHandler(this.TmrSysTime_Tick);
            // 
            // BtnSetService
            // 
            this.BtnSetService.BackColor = System.Drawing.Color.Transparent;
            this.BtnSetService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetService.FlatAppearance.BorderSize = 0;
            this.BtnSetService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetService.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnSetService.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnSetService.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetService.Image")));
            this.BtnSetService.Location = new System.Drawing.Point(713, 165);
            this.BtnSetService.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnSetService.Name = "BtnSetService";
            this.BtnSetService.Size = new System.Drawing.Size(220, 220);
            this.BtnSetService.TabIndex = 310;
            this.BtnSetService.TabStop = false;
            this.BtnSetService.Text = "服务设置";
            this.BtnSetService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSetService.UseVisualStyleBackColor = false;
            this.BtnSetService.Click += new System.EventHandler(this.BtnSetService_Click);
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
            this.BtnScaleSetting.Location = new System.Drawing.Point(405, 165);
            this.BtnScaleSetting.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnScaleSetting.Name = "BtnScaleSetting";
            this.BtnScaleSetting.Size = new System.Drawing.Size(220, 220);
            this.BtnScaleSetting.TabIndex = 309;
            this.BtnScaleSetting.TabStop = false;
            this.BtnScaleSetting.Text = "计量设置";
            this.BtnScaleSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnScaleSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnScaleSetting.UseVisualStyleBackColor = false;
            this.BtnScaleSetting.Click += new System.EventHandler(this.BtnScaleSetting_Click);
            // 
            // BtnSetscanningGun
            // 
            this.BtnSetscanningGun.BackColor = System.Drawing.Color.Transparent;
            this.BtnSetscanningGun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetscanningGun.FlatAppearance.BorderSize = 0;
            this.BtnSetscanningGun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetscanningGun.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnSetscanningGun.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnSetscanningGun.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetscanningGun.Image")));
            this.BtnSetscanningGun.Location = new System.Drawing.Point(97, 426);
            this.BtnSetscanningGun.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnSetscanningGun.Name = "BtnSetscanningGun";
            this.BtnSetscanningGun.Size = new System.Drawing.Size(220, 220);
            this.BtnSetscanningGun.TabIndex = 308;
            this.BtnSetscanningGun.TabStop = false;
            this.BtnSetscanningGun.Text = "扫码设置";
            this.BtnSetscanningGun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetscanningGun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSetscanningGun.UseVisualStyleBackColor = false;
            this.BtnSetscanningGun.Click += new System.EventHandler(this.BtnSetNet_Click);
            // 
            // BtnSetScaleNum
            // 
            this.BtnSetScaleNum.BackColor = System.Drawing.Color.Transparent;
            this.BtnSetScaleNum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetScaleNum.FlatAppearance.BorderSize = 0;
            this.BtnSetScaleNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetScaleNum.Font = new System.Drawing.Font("微软雅黑", 26F);
            this.BtnSetScaleNum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.BtnSetScaleNum.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetScaleNum.Image")));
            this.BtnSetScaleNum.Location = new System.Drawing.Point(97, 165);
            this.BtnSetScaleNum.Margin = new System.Windows.Forms.Padding(15, 40, 15, 40);
            this.BtnSetScaleNum.Name = "BtnSetScaleNum";
            this.BtnSetScaleNum.Size = new System.Drawing.Size(220, 220);
            this.BtnSetScaleNum.TabIndex = 34;
            this.BtnSetScaleNum.TabStop = false;
            this.BtnSetScaleNum.Text = "设备设置";
            this.BtnSetScaleNum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSetScaleNum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSetScaleNum.UseVisualStyleBackColor = false;
            this.BtnSetScaleNum.Click += new System.EventHandler(this.BtnSetScaleNum_Click);
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
            this.label1.Size = new System.Drawing.Size(600, 70);
            this.label1.TabIndex = 85;
            this.label1.Tag = "系统名称";
            this.label1.Text = "系统设置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.Transparent;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblTime.Font = new System.Drawing.Font("微软雅黑", 24.25F);
            this.LblTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblTime.Location = new System.Drawing.Point(630, 0);
            this.LblTime.Margin = new System.Windows.Forms.Padding(0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.LblTime.Size = new System.Drawing.Size(394, 70);
            this.LblTime.TabIndex = 82;
            this.LblTime.Text = "2020-10-22 12:00:00";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.BtnBack.Location = new System.Drawing.Point(713, 426);
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
            // FrmSystemSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.BtnSetService);
            this.Controls.Add(this.BtnScaleSetting);
            this.Controls.Add(this.BtnSetscanningGun);
            this.Controls.Add(this.BtnSetScaleNum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnBack);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSystemSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnSetScaleNum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer TmrSysTime;
        private System.Windows.Forms.Button BtnSetscanningGun;
        private System.Windows.Forms.Button BtnScaleSetting;
        private System.Windows.Forms.Button BtnSetService;
    }
}

