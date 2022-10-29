namespace nMFStageClientWin
{
    partial class FrmScaleSettingNTD910
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScaleSettingNTD910));
            this.TmrWeight = new System.Windows.Forms.Timer(this.components);
            this.LblTip = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtWeightValue = new System.Windows.Forms.TextBox();
            this.CmbIncrement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSpan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.roundPanel5 = new NTDCommLib.UI.RoundPanel();
            this.LblWeight = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.PnlKeyboard = new System.Windows.Forms.Panel();
            this.BtnKeyboard_12 = new System.Windows.Forms.Button();
            this.BtnKeyboard_0 = new System.Windows.Forms.Button();
            this.BtnKeyboard_4 = new System.Windows.Forms.Button();
            this.BtnKeyboard_8 = new System.Windows.Forms.Button();
            this.BtnKeyboard_1 = new System.Windows.Forms.Button();
            this.BtnKeyboard_2 = new System.Windows.Forms.Button();
            this.BtnKeyboard_3 = new System.Windows.Forms.Button();
            this.BtnKeyboard_5 = new System.Windows.Forms.Button();
            this.BtnKeyboard_6 = new System.Windows.Forms.Button();
            this.BtnKeyboard_7 = new System.Windows.Forms.Button();
            this.BtnKeyboard_9 = new System.Windows.Forms.Button();
            this.BtnKeyboard_10 = new System.Windows.Forms.Button();
            this.BtnKeyboard_11 = new System.Windows.Forms.Button();
            this.TlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.PnlBottomMenu_7 = new System.Windows.Forms.Panel();
            this.BtnSetFactroyZero = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_6 = new System.Windows.Forms.Panel();
            this.BtnCalibrateWeight = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_0 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBottomMenu_5 = new System.Windows.Forms.Panel();
            this.BtnlSetZero = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_3 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_4 = new System.Windows.Forms.Panel();
            this.BtnSaveParmas = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.roundPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlKeyboard.SuspendLayout();
            this.TlpBottom.SuspendLayout();
            this.PnlBottomMenu_7.SuspendLayout();
            this.PnlBottomMenu_6.SuspendLayout();
            this.PnlBottomMenu_2.SuspendLayout();
            this.PnlBottomMenu_1.SuspendLayout();
            this.PnlBottomMenu_0.SuspendLayout();
            this.PnlBottomMenu_5.SuspendLayout();
            this.PnlBottomMenu_3.SuspendLayout();
            this.PnlBottomMenu_4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrWeight
            // 
            this.TmrWeight.Interval = 200;
            this.TmrWeight.Tick += new System.EventHandler(this.WeightUpdateTimer_Tick);
            // 
            // LblTip
            // 
            this.LblTip.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.LblTip.ForeColor = System.Drawing.Color.Red;
            this.LblTip.Location = new System.Drawing.Point(47, 113);
            this.LblTip.Name = "LblTip";
            this.LblTip.Size = new System.Drawing.Size(937, 39);
            this.LblTip.TabIndex = 340;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label10.Location = new System.Drawing.Point(434, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 35);
            this.label10.TabIndex = 336;
            this.label10.Text = "kg";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label11.Location = new System.Drawing.Point(92, 590);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 35);
            this.label11.TabIndex = 335;
            this.label11.Text = "砝码重量";
            // 
            // TxtWeightValue
            // 
            this.TxtWeightValue.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.TxtWeightValue.Location = new System.Drawing.Point(230, 584);
            this.TxtWeightValue.Name = "TxtWeightValue";
            this.TxtWeightValue.Size = new System.Drawing.Size(198, 43);
            this.TxtWeightValue.TabIndex = 334;
            this.TxtWeightValue.Enter += new System.EventHandler(this.TxtSpan_Enter);
            // 
            // CmbIncrement
            // 
            this.CmbIncrement.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.CmbIncrement.FormattingEnabled = true;
            this.CmbIncrement.IntegralHeight = false;
            this.CmbIncrement.Location = new System.Drawing.Point(230, 483);
            this.CmbIncrement.MaxLength = 8;
            this.CmbIncrement.Name = "CmbIncrement";
            this.CmbIncrement.Size = new System.Drawing.Size(198, 43);
            this.CmbIncrement.TabIndex = 320;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label1.Location = new System.Drawing.Point(434, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 35);
            this.label1.TabIndex = 312;
            this.label1.Text = "kg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label4.Location = new System.Drawing.Point(92, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 35);
            this.label4.TabIndex = 311;
            this.label4.Text = "称台分度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label2.Location = new System.Drawing.Point(434, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 35);
            this.label2.TabIndex = 309;
            this.label2.Text = "kg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label9.Location = new System.Drawing.Point(92, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 35);
            this.label9.TabIndex = 308;
            this.label9.Text = "称台量程";
            // 
            // TxtSpan
            // 
            this.TxtSpan.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.TxtSpan.Location = new System.Drawing.Point(230, 382);
            this.TxtSpan.Name = "TxtSpan";
            this.TxtSpan.Size = new System.Drawing.Size(198, 43);
            this.TxtSpan.TabIndex = 307;
            this.TxtSpan.Enter += new System.EventHandler(this.TxtSpan_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label12.Location = new System.Drawing.Point(92, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 35);
            this.label12.TabIndex = 310;
            this.label12.Text = "称台编号";
            // 
            // roundPanel5
            // 
            this.roundPanel5.Back = System.Drawing.Color.DimGray;
            this.roundPanel5.Controls.Add(this.LblWeight);
            this.roundPanel5.Location = new System.Drawing.Point(98, 180);
            this.roundPanel5.MatrixRound = 8;
            this.roundPanel5.mMatrixRound = 8;
            this.roundPanel5.Name = "roundPanel5";
            this.roundPanel5.Size = new System.Drawing.Size(383, 62);
            this.roundPanel5.TabIndex = 356;
            // 
            // LblWeight
            // 
            this.LblWeight.BackColor = System.Drawing.Color.Transparent;
            this.LblWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblWeight.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblWeight.ForeColor = System.Drawing.Color.White;
            this.LblWeight.Location = new System.Drawing.Point(0, 0);
            this.LblWeight.Name = "LblWeight";
            this.LblWeight.Size = new System.Drawing.Size(383, 62);
            this.LblWeight.TabIndex = 0;
            this.LblWeight.Text = "----";
            this.LblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1024, 70);
            this.panel1.TabIndex = 354;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(30, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(994, 70);
            this.label14.TabIndex = 85;
            this.label14.Tag = "";
            this.label14.Text = "称台标定";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.radioButton1.Location = new System.Drawing.Point(230, 281);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 39);
            this.radioButton1.TabIndex = 400;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.radioButton2.Location = new System.Drawing.Point(316, 281);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 39);
            this.radioButton2.TabIndex = 401;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "2";
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // PnlKeyboard
            // 
            this.PnlKeyboard.BackColor = System.Drawing.Color.Navy;
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_12);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_0);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_4);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_8);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_1);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_2);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_3);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_5);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_6);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_7);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_9);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_10);
            this.PnlKeyboard.Controls.Add(this.BtnKeyboard_11);
            this.PnlKeyboard.Location = new System.Drawing.Point(597, 223);
            this.PnlKeyboard.Margin = new System.Windows.Forms.Padding(0);
            this.PnlKeyboard.Name = "PnlKeyboard";
            this.PnlKeyboard.Size = new System.Drawing.Size(365, 325);
            this.PnlKeyboard.TabIndex = 477;
            // 
            // BtnKeyboard_12
            // 
            this.BtnKeyboard_12.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_12.BackgroundImage")));
            this.BtnKeyboard_12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_12.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_12.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_12.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_12.ForeColor = System.Drawing.Color.Black;
            this.BtnKeyboard_12.Location = new System.Drawing.Point(5, 245);
            this.BtnKeyboard_12.Name = "BtnKeyboard_12";
            this.BtnKeyboard_12.Size = new System.Drawing.Size(355, 75);
            this.BtnKeyboard_12.TabIndex = 366;
            this.BtnKeyboard_12.TabStop = false;
            this.BtnKeyboard_12.Tag = "key";
            this.BtnKeyboard_12.Text = "全键盘";
            this.BtnKeyboard_12.UseVisualStyleBackColor = false;
            this.BtnKeyboard_12.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_0
            // 
            this.BtnKeyboard_0.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_0.BackgroundImage")));
            this.BtnKeyboard_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_0.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_0.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_0.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_0.Location = new System.Drawing.Point(5, 5);
            this.BtnKeyboard_0.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_0.Name = "BtnKeyboard_0";
            this.BtnKeyboard_0.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_0.TabIndex = 354;
            this.BtnKeyboard_0.TabStop = false;
            this.BtnKeyboard_0.Tag = "key";
            this.BtnKeyboard_0.Text = "1";
            this.BtnKeyboard_0.UseVisualStyleBackColor = false;
            this.BtnKeyboard_0.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_4
            // 
            this.BtnKeyboard_4.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_4.BackgroundImage")));
            this.BtnKeyboard_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_4.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_4.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_4.Location = new System.Drawing.Point(5, 85);
            this.BtnKeyboard_4.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_4.Name = "BtnKeyboard_4";
            this.BtnKeyboard_4.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_4.TabIndex = 358;
            this.BtnKeyboard_4.TabStop = false;
            this.BtnKeyboard_4.Tag = "key";
            this.BtnKeyboard_4.Text = "5";
            this.BtnKeyboard_4.UseVisualStyleBackColor = false;
            this.BtnKeyboard_4.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_8
            // 
            this.BtnKeyboard_8.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_8.BackgroundImage")));
            this.BtnKeyboard_8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_8.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_8.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_8.Location = new System.Drawing.Point(5, 165);
            this.BtnKeyboard_8.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_8.Name = "BtnKeyboard_8";
            this.BtnKeyboard_8.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_8.TabIndex = 362;
            this.BtnKeyboard_8.TabStop = false;
            this.BtnKeyboard_8.Tag = "key";
            this.BtnKeyboard_8.Text = "9";
            this.BtnKeyboard_8.UseVisualStyleBackColor = false;
            this.BtnKeyboard_8.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_1
            // 
            this.BtnKeyboard_1.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_1.BackgroundImage")));
            this.BtnKeyboard_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_1.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_1.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_1.Location = new System.Drawing.Point(95, 5);
            this.BtnKeyboard_1.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_1.Name = "BtnKeyboard_1";
            this.BtnKeyboard_1.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_1.TabIndex = 355;
            this.BtnKeyboard_1.TabStop = false;
            this.BtnKeyboard_1.Tag = "key";
            this.BtnKeyboard_1.Text = "2";
            this.BtnKeyboard_1.UseVisualStyleBackColor = false;
            this.BtnKeyboard_1.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_2
            // 
            this.BtnKeyboard_2.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_2.BackgroundImage")));
            this.BtnKeyboard_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_2.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_2.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_2.Location = new System.Drawing.Point(185, 5);
            this.BtnKeyboard_2.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_2.Name = "BtnKeyboard_2";
            this.BtnKeyboard_2.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_2.TabIndex = 356;
            this.BtnKeyboard_2.TabStop = false;
            this.BtnKeyboard_2.Tag = "key";
            this.BtnKeyboard_2.Text = "3";
            this.BtnKeyboard_2.UseVisualStyleBackColor = false;
            this.BtnKeyboard_2.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_3
            // 
            this.BtnKeyboard_3.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_3.BackgroundImage")));
            this.BtnKeyboard_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_3.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_3.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_3.Location = new System.Drawing.Point(275, 5);
            this.BtnKeyboard_3.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_3.Name = "BtnKeyboard_3";
            this.BtnKeyboard_3.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_3.TabIndex = 357;
            this.BtnKeyboard_3.TabStop = false;
            this.BtnKeyboard_3.Tag = "key";
            this.BtnKeyboard_3.Text = "4";
            this.BtnKeyboard_3.UseVisualStyleBackColor = false;
            this.BtnKeyboard_3.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_5
            // 
            this.BtnKeyboard_5.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_5.BackgroundImage")));
            this.BtnKeyboard_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_5.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_5.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_5.Location = new System.Drawing.Point(95, 85);
            this.BtnKeyboard_5.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_5.Name = "BtnKeyboard_5";
            this.BtnKeyboard_5.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_5.TabIndex = 359;
            this.BtnKeyboard_5.TabStop = false;
            this.BtnKeyboard_5.Tag = "key";
            this.BtnKeyboard_5.Text = "6";
            this.BtnKeyboard_5.UseVisualStyleBackColor = false;
            this.BtnKeyboard_5.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_6
            // 
            this.BtnKeyboard_6.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_6.BackgroundImage")));
            this.BtnKeyboard_6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_6.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_6.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_6.Location = new System.Drawing.Point(185, 85);
            this.BtnKeyboard_6.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_6.Name = "BtnKeyboard_6";
            this.BtnKeyboard_6.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_6.TabIndex = 360;
            this.BtnKeyboard_6.TabStop = false;
            this.BtnKeyboard_6.Tag = "key";
            this.BtnKeyboard_6.Text = "7";
            this.BtnKeyboard_6.UseVisualStyleBackColor = false;
            this.BtnKeyboard_6.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_7
            // 
            this.BtnKeyboard_7.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_7.BackgroundImage")));
            this.BtnKeyboard_7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_7.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_7.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_7.Location = new System.Drawing.Point(275, 85);
            this.BtnKeyboard_7.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_7.Name = "BtnKeyboard_7";
            this.BtnKeyboard_7.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_7.TabIndex = 361;
            this.BtnKeyboard_7.TabStop = false;
            this.BtnKeyboard_7.Tag = "key";
            this.BtnKeyboard_7.Text = "8";
            this.BtnKeyboard_7.UseVisualStyleBackColor = false;
            this.BtnKeyboard_7.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_9
            // 
            this.BtnKeyboard_9.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_9.BackgroundImage")));
            this.BtnKeyboard_9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_9.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_9.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_9.Location = new System.Drawing.Point(95, 165);
            this.BtnKeyboard_9.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_9.Name = "BtnKeyboard_9";
            this.BtnKeyboard_9.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_9.TabIndex = 363;
            this.BtnKeyboard_9.TabStop = false;
            this.BtnKeyboard_9.Tag = "key";
            this.BtnKeyboard_9.Text = "0";
            this.BtnKeyboard_9.UseVisualStyleBackColor = false;
            this.BtnKeyboard_9.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_10
            // 
            this.BtnKeyboard_10.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_10.BackgroundImage")));
            this.BtnKeyboard_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_10.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_10.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_10.Location = new System.Drawing.Point(185, 165);
            this.BtnKeyboard_10.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_10.Name = "BtnKeyboard_10";
            this.BtnKeyboard_10.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_10.TabIndex = 364;
            this.BtnKeyboard_10.TabStop = false;
            this.BtnKeyboard_10.Tag = "key";
            this.BtnKeyboard_10.Text = ".";
            this.BtnKeyboard_10.UseVisualStyleBackColor = false;
            this.BtnKeyboard_10.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // BtnKeyboard_11
            // 
            this.BtnKeyboard_11.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeyboard_11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnKeyboard_11.BackgroundImage")));
            this.BtnKeyboard_11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnKeyboard_11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnKeyboard_11.FlatAppearance.BorderSize = 0;
            this.BtnKeyboard_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnKeyboard_11.Font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Bold);
            this.BtnKeyboard_11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnKeyboard_11.Location = new System.Drawing.Point(275, 165);
            this.BtnKeyboard_11.Margin = new System.Windows.Forms.Padding(0);
            this.BtnKeyboard_11.Name = "BtnKeyboard_11";
            this.BtnKeyboard_11.Size = new System.Drawing.Size(85, 75);
            this.BtnKeyboard_11.TabIndex = 365;
            this.BtnKeyboard_11.TabStop = false;
            this.BtnKeyboard_11.Tag = "key";
            this.BtnKeyboard_11.Text = "删除";
            this.BtnKeyboard_11.UseVisualStyleBackColor = false;
            this.BtnKeyboard_11.Click += new System.EventHandler(this.BtnKeyboard_Click);
            // 
            // TlpBottom
            // 
            this.TlpBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.TlpBottom.ColumnCount = 8;
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.TlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_7, 7, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_6, 6, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_2, 2, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_1, 1, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_0, 0, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_5, 5, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_3, 3, 0);
            this.TlpBottom.Controls.Add(this.PnlBottomMenu_4, 4, 0);
            this.TlpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TlpBottom.Location = new System.Drawing.Point(0, 683);
            this.TlpBottom.Name = "TlpBottom";
            this.TlpBottom.RowCount = 1;
            this.TlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpBottom.Size = new System.Drawing.Size(1024, 85);
            this.TlpBottom.TabIndex = 478;
            // 
            // PnlBottomMenu_7
            // 
            this.PnlBottomMenu_7.Controls.Add(this.BtnSetFactroyZero);
            this.PnlBottomMenu_7.Controls.Add(this.panel2);
            this.PnlBottomMenu_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_7.Location = new System.Drawing.Point(892, 3);
            this.PnlBottomMenu_7.Name = "PnlBottomMenu_7";
            this.PnlBottomMenu_7.Size = new System.Drawing.Size(129, 79);
            this.PnlBottomMenu_7.TabIndex = 465;
            // 
            // BtnSetFactroyZero
            // 
            this.BtnSetFactroyZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetFactroyZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetFactroyZero.FlatAppearance.BorderSize = 0;
            this.BtnSetFactroyZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetFactroyZero.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSetFactroyZero.ForeColor = System.Drawing.Color.White;
            this.BtnSetFactroyZero.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetFactroyZero.Image")));
            this.BtnSetFactroyZero.Location = new System.Drawing.Point(0, 0);
            this.BtnSetFactroyZero.Name = "BtnSetFactroyZero";
            this.BtnSetFactroyZero.Size = new System.Drawing.Size(128, 79);
            this.BtnSetFactroyZero.TabIndex = 314;
            this.BtnSetFactroyZero.TabStop = false;
            this.BtnSetFactroyZero.Text = "工厂置零";
            this.BtnSetFactroyZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetFactroyZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetFactroyZero.UseVisualStyleBackColor = true;
            this.BtnSetFactroyZero.Click += new System.EventHandler(this.BtnSetFactroyZero_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(128, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 79);
            this.panel2.TabIndex = 314;
            // 
            // PnlBottomMenu_6
            // 
            this.PnlBottomMenu_6.Controls.Add(this.BtnCalibrateWeight);
            this.PnlBottomMenu_6.Controls.Add(this.panel3);
            this.PnlBottomMenu_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_6.Location = new System.Drawing.Point(765, 3);
            this.PnlBottomMenu_6.Name = "PnlBottomMenu_6";
            this.PnlBottomMenu_6.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_6.TabIndex = 465;
            // 
            // BtnCalibrateWeight
            // 
            this.BtnCalibrateWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalibrateWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCalibrateWeight.FlatAppearance.BorderSize = 0;
            this.BtnCalibrateWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCalibrateWeight.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnCalibrateWeight.ForeColor = System.Drawing.Color.White;
            this.BtnCalibrateWeight.Image = ((System.Drawing.Image)(resources.GetObject("BtnCalibrateWeight.Image")));
            this.BtnCalibrateWeight.Location = new System.Drawing.Point(0, 0);
            this.BtnCalibrateWeight.Name = "BtnCalibrateWeight";
            this.BtnCalibrateWeight.Size = new System.Drawing.Size(120, 79);
            this.BtnCalibrateWeight.TabIndex = 479;
            this.BtnCalibrateWeight.TabStop = false;
            this.BtnCalibrateWeight.Text = "砝码标定";
            this.BtnCalibrateWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCalibrateWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCalibrateWeight.UseVisualStyleBackColor = true;
            this.BtnCalibrateWeight.Click += new System.EventHandler(this.BtnCalibrateWeight_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(120, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 79);
            this.panel3.TabIndex = 314;
            // 
            // PnlBottomMenu_2
            // 
            this.PnlBottomMenu_2.Controls.Add(this.panel4);
            this.PnlBottomMenu_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_2.Location = new System.Drawing.Point(257, 3);
            this.PnlBottomMenu_2.Name = "PnlBottomMenu_2";
            this.PnlBottomMenu_2.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_2.TabIndex = 465;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Navy;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(120, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 79);
            this.panel4.TabIndex = 314;
            // 
            // PnlBottomMenu_1
            // 
            this.PnlBottomMenu_1.Controls.Add(this.panel5);
            this.PnlBottomMenu_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_1.Location = new System.Drawing.Point(130, 3);
            this.PnlBottomMenu_1.Name = "PnlBottomMenu_1";
            this.PnlBottomMenu_1.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_1.TabIndex = 465;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Navy;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(120, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 79);
            this.panel5.TabIndex = 314;
            // 
            // PnlBottomMenu_0
            // 
            this.PnlBottomMenu_0.Controls.Add(this.panel6);
            this.PnlBottomMenu_0.Controls.Add(this.BtnClose);
            this.PnlBottomMenu_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_0.Location = new System.Drawing.Point(3, 3);
            this.PnlBottomMenu_0.Name = "PnlBottomMenu_0";
            this.PnlBottomMenu_0.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_0.TabIndex = 465;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Navy;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(120, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 79);
            this.panel6.TabIndex = 314;
            // 
            // BtnClose
            // 
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnClose.Image")));
            this.BtnClose.Location = new System.Drawing.Point(0, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(121, 79);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TabStop = false;
            this.BtnClose.Text = "返回";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlBottomMenu_5
            // 
            this.PnlBottomMenu_5.Controls.Add(this.BtnlSetZero);
            this.PnlBottomMenu_5.Controls.Add(this.panel14);
            this.PnlBottomMenu_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_5.Location = new System.Drawing.Point(638, 3);
            this.PnlBottomMenu_5.Name = "PnlBottomMenu_5";
            this.PnlBottomMenu_5.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_5.TabIndex = 464;
            // 
            // BtnlSetZero
            // 
            this.BtnlSetZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnlSetZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnlSetZero.FlatAppearance.BorderSize = 0;
            this.BtnlSetZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnlSetZero.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnlSetZero.ForeColor = System.Drawing.Color.White;
            this.BtnlSetZero.Image = ((System.Drawing.Image)(resources.GetObject("BtnlSetZero.Image")));
            this.BtnlSetZero.Location = new System.Drawing.Point(0, 0);
            this.BtnlSetZero.Name = "BtnlSetZero";
            this.BtnlSetZero.Size = new System.Drawing.Size(120, 79);
            this.BtnlSetZero.TabIndex = 479;
            this.BtnlSetZero.TabStop = false;
            this.BtnlSetZero.Text = "零点标定";
            this.BtnlSetZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnlSetZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnlSetZero.UseVisualStyleBackColor = true;
            this.BtnlSetZero.Click += new System.EventHandler(this.BtnlSetZero_Click);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Navy;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(120, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1, 79);
            this.panel14.TabIndex = 314;
            // 
            // PnlBottomMenu_3
            // 
            this.PnlBottomMenu_3.Controls.Add(this.panel16);
            this.PnlBottomMenu_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_3.Location = new System.Drawing.Point(384, 3);
            this.PnlBottomMenu_3.Name = "PnlBottomMenu_3";
            this.PnlBottomMenu_3.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_3.TabIndex = 316;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Navy;
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.Location = new System.Drawing.Point(120, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1, 79);
            this.panel16.TabIndex = 313;
            // 
            // PnlBottomMenu_4
            // 
            this.PnlBottomMenu_4.Controls.Add(this.BtnSaveParmas);
            this.PnlBottomMenu_4.Controls.Add(this.panel17);
            this.PnlBottomMenu_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_4.Location = new System.Drawing.Point(511, 3);
            this.PnlBottomMenu_4.Name = "PnlBottomMenu_4";
            this.PnlBottomMenu_4.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_4.TabIndex = 319;
            // 
            // BtnSaveParmas
            // 
            this.BtnSaveParmas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSaveParmas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSaveParmas.FlatAppearance.BorderSize = 0;
            this.BtnSaveParmas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveParmas.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSaveParmas.ForeColor = System.Drawing.Color.White;
            this.BtnSaveParmas.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveParmas.Image")));
            this.BtnSaveParmas.Location = new System.Drawing.Point(0, 0);
            this.BtnSaveParmas.Name = "BtnSaveParmas";
            this.BtnSaveParmas.Size = new System.Drawing.Size(120, 79);
            this.BtnSaveParmas.TabIndex = 479;
            this.BtnSaveParmas.TabStop = false;
            this.BtnSaveParmas.Text = "保存参数";
            this.BtnSaveParmas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSaveParmas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSaveParmas.UseVisualStyleBackColor = true;
            this.BtnSaveParmas.Click += new System.EventHandler(this.BtnSaveParmas_Click);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Navy;
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(120, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1, 79);
            this.panel17.TabIndex = 314;
            // 
            // FrmScaleSettingNTD910
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.TlpBottom);
            this.Controls.Add(this.PnlKeyboard);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.roundPanel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblTip);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtWeightValue);
            this.Controls.Add(this.CmbIncrement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtSpan);
            this.Controls.Add(this.label12);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmScaleSettingNTD910";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScaleSetting_FormClosed);
            this.Load += new System.EventHandler(this.FrmScaleSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.roundPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PnlKeyboard.ResumeLayout(false);
            this.TlpBottom.ResumeLayout(false);
            this.PnlBottomMenu_7.ResumeLayout(false);
            this.PnlBottomMenu_6.ResumeLayout(false);
            this.PnlBottomMenu_2.ResumeLayout(false);
            this.PnlBottomMenu_1.ResumeLayout(false);
            this.PnlBottomMenu_0.ResumeLayout(false);
            this.PnlBottomMenu_5.ResumeLayout(false);
            this.PnlBottomMenu_3.ResumeLayout(false);
            this.PnlBottomMenu_4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer TmrWeight;
        private System.Windows.Forms.Label LblTip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtWeightValue;
        private System.Windows.Forms.ComboBox CmbIncrement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSpan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private NTDCommLib.UI.RoundPanel roundPanel5;
        private System.Windows.Forms.Label LblWeight;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel PnlKeyboard;
        private System.Windows.Forms.Button BtnKeyboard_12;
        private System.Windows.Forms.Button BtnKeyboard_0;
        private System.Windows.Forms.Button BtnKeyboard_4;
        private System.Windows.Forms.Button BtnKeyboard_8;
        private System.Windows.Forms.Button BtnKeyboard_1;
        private System.Windows.Forms.Button BtnKeyboard_2;
        private System.Windows.Forms.Button BtnKeyboard_3;
        private System.Windows.Forms.Button BtnKeyboard_5;
        private System.Windows.Forms.Button BtnKeyboard_6;
        private System.Windows.Forms.Button BtnKeyboard_7;
        private System.Windows.Forms.Button BtnKeyboard_9;
        private System.Windows.Forms.Button BtnKeyboard_10;
        private System.Windows.Forms.Button BtnKeyboard_11;
        private System.Windows.Forms.TableLayoutPanel TlpBottom;
        private System.Windows.Forms.Panel PnlBottomMenu_7;
        private System.Windows.Forms.Button BtnSetFactroyZero;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnlBottomMenu_6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PnlBottomMenu_2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PnlBottomMenu_1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel PnlBottomMenu_0;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PnlBottomMenu_5;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel PnlBottomMenu_3;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel PnlBottomMenu_4;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button BtnCalibrateWeight;
        private System.Windows.Forms.Button BtnlSetZero;
        private System.Windows.Forms.Button BtnSaveParmas;
    }
}

