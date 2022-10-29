namespace nMFStageClientWin
{
    partial class FrmVerifyCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerifyCalibration));
            this.TmrWeight = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.PnlBottomMenu_7 = new System.Windows.Forms.Panel();
            this.BtnSkip = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_6 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BtnSetZero = new System.Windows.Forms.Button();
            this.PnlBottomMenu_1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_0 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBottomMenu_5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnSetTareNumber = new System.Windows.Forms.Button();
            this.PnlBottomMenu_3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BtnSetTare = new System.Windows.Forms.Button();
            this.PnlBottomMenu_4 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.BtnClearTare = new System.Windows.Forms.Button();
            this.BtnWeight = new System.Windows.Forms.Button();
            this.BtnScaleName = new System.Windows.Forms.Button();
            this.BtnStandardWeight = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.TblTopInfo = new System.Windows.Forms.TableLayoutPanel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PicP1 = new System.Windows.Forms.Button();
            this.PicP4 = new System.Windows.Forms.Button();
            this.PicP5 = new System.Windows.Forms.Button();
            this.PicP3 = new System.Windows.Forms.Button();
            this.PicP2 = new System.Windows.Forms.Button();
            this.TlpBottom.SuspendLayout();
            this.PnlBottomMenu_7.SuspendLayout();
            this.PnlBottomMenu_6.SuspendLayout();
            this.PnlBottomMenu_2.SuspendLayout();
            this.PnlBottomMenu_1.SuspendLayout();
            this.PnlBottomMenu_0.SuspendLayout();
            this.PnlBottomMenu_5.SuspendLayout();
            this.PnlBottomMenu_3.SuspendLayout();
            this.PnlBottomMenu_4.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.TblTopInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmrWeight
            // 
            this.TmrWeight.Interval = 200;
            this.TmrWeight.Tick += new System.EventHandler(this.WeightUpdateTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 647);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(867, 25);
            this.label1.TabIndex = 322;
            this.label1.Text = "说明：请将要求重量的标准砝码放置到称台指定位置，然后点击屏幕上相应位置砝码图标进行称台校验";
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
            this.TlpBottom.TabIndex = 464;
            // 
            // PnlBottomMenu_7
            // 
            this.PnlBottomMenu_7.Controls.Add(this.BtnSkip);
            this.PnlBottomMenu_7.Controls.Add(this.panel13);
            this.PnlBottomMenu_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_7.Location = new System.Drawing.Point(892, 3);
            this.PnlBottomMenu_7.Name = "PnlBottomMenu_7";
            this.PnlBottomMenu_7.Size = new System.Drawing.Size(129, 79);
            this.PnlBottomMenu_7.TabIndex = 465;
            // 
            // BtnSkip
            // 
            this.BtnSkip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSkip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSkip.FlatAppearance.BorderSize = 0;
            this.BtnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSkip.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSkip.ForeColor = System.Drawing.Color.White;
            this.BtnSkip.Image = ((System.Drawing.Image)(resources.GetObject("BtnSkip.Image")));
            this.BtnSkip.Location = new System.Drawing.Point(0, 0);
            this.BtnSkip.Name = "BtnSkip";
            this.BtnSkip.Size = new System.Drawing.Size(128, 79);
            this.BtnSkip.TabIndex = 314;
            this.BtnSkip.TabStop = false;
            this.BtnSkip.Text = "跳过";
            this.BtnSkip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSkip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSkip.UseVisualStyleBackColor = true;
            this.BtnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Navy;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(128, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1, 79);
            this.panel13.TabIndex = 314;
            // 
            // PnlBottomMenu_6
            // 
            this.PnlBottomMenu_6.Controls.Add(this.panel12);
            this.PnlBottomMenu_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_6.Location = new System.Drawing.Point(765, 3);
            this.PnlBottomMenu_6.Name = "PnlBottomMenu_6";
            this.PnlBottomMenu_6.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_6.TabIndex = 465;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Navy;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(120, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1, 79);
            this.panel12.TabIndex = 314;
            // 
            // PnlBottomMenu_2
            // 
            this.PnlBottomMenu_2.Controls.Add(this.panel8);
            this.PnlBottomMenu_2.Controls.Add(this.BtnSetZero);
            this.PnlBottomMenu_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_2.Location = new System.Drawing.Point(257, 3);
            this.PnlBottomMenu_2.Name = "PnlBottomMenu_2";
            this.PnlBottomMenu_2.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_2.TabIndex = 465;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Navy;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(120, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1, 79);
            this.panel8.TabIndex = 314;
            // 
            // BtnSetZero
            // 
            this.BtnSetZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetZero.FlatAppearance.BorderSize = 0;
            this.BtnSetZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetZero.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSetZero.ForeColor = System.Drawing.Color.White;
            this.BtnSetZero.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetZero.Image")));
            this.BtnSetZero.Location = new System.Drawing.Point(0, 0);
            this.BtnSetZero.Name = "BtnSetZero";
            this.BtnSetZero.Size = new System.Drawing.Size(121, 79);
            this.BtnSetZero.TabIndex = 315;
            this.BtnSetZero.TabStop = false;
            this.BtnSetZero.Text = "清零";
            this.BtnSetZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetZero.UseVisualStyleBackColor = true;
            this.BtnSetZero.Click += new System.EventHandler(this.BtnSetZero_Click);
            // 
            // PnlBottomMenu_1
            // 
            this.PnlBottomMenu_1.Controls.Add(this.panel6);
            this.PnlBottomMenu_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_1.Location = new System.Drawing.Point(130, 3);
            this.PnlBottomMenu_1.Name = "PnlBottomMenu_1";
            this.PnlBottomMenu_1.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_1.TabIndex = 465;
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
            // PnlBottomMenu_0
            // 
            this.PnlBottomMenu_0.Controls.Add(this.panel3);
            this.PnlBottomMenu_0.Controls.Add(this.BtnClose);
            this.PnlBottomMenu_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_0.Location = new System.Drawing.Point(3, 3);
            this.PnlBottomMenu_0.Name = "PnlBottomMenu_0";
            this.PnlBottomMenu_0.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_0.TabIndex = 465;
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
            this.PnlBottomMenu_5.Controls.Add(this.panel4);
            this.PnlBottomMenu_5.Controls.Add(this.BtnSetTareNumber);
            this.PnlBottomMenu_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_5.Location = new System.Drawing.Point(638, 3);
            this.PnlBottomMenu_5.Name = "PnlBottomMenu_5";
            this.PnlBottomMenu_5.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_5.TabIndex = 464;
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
            // BtnSetTareNumber
            // 
            this.BtnSetTareNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetTareNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetTareNumber.FlatAppearance.BorderSize = 0;
            this.BtnSetTareNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetTareNumber.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSetTareNumber.ForeColor = System.Drawing.Color.White;
            this.BtnSetTareNumber.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetTareNumber.Image")));
            this.BtnSetTareNumber.Location = new System.Drawing.Point(0, 0);
            this.BtnSetTareNumber.Name = "BtnSetTareNumber";
            this.BtnSetTareNumber.Size = new System.Drawing.Size(121, 79);
            this.BtnSetTareNumber.TabIndex = 320;
            this.BtnSetTareNumber.TabStop = false;
            this.BtnSetTareNumber.Text = "设皮";
            this.BtnSetTareNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetTareNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetTareNumber.UseVisualStyleBackColor = true;
            this.BtnSetTareNumber.Click += new System.EventHandler(this.BtnSetTareNumber_Click);
            // 
            // PnlBottomMenu_3
            // 
            this.PnlBottomMenu_3.Controls.Add(this.panel9);
            this.PnlBottomMenu_3.Controls.Add(this.BtnSetTare);
            this.PnlBottomMenu_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_3.Location = new System.Drawing.Point(384, 3);
            this.PnlBottomMenu_3.Name = "PnlBottomMenu_3";
            this.PnlBottomMenu_3.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_3.TabIndex = 316;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Navy;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(120, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1, 79);
            this.panel9.TabIndex = 313;
            // 
            // BtnSetTare
            // 
            this.BtnSetTare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSetTare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSetTare.FlatAppearance.BorderSize = 0;
            this.BtnSetTare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSetTare.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSetTare.ForeColor = System.Drawing.Color.White;
            this.BtnSetTare.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetTare.Image")));
            this.BtnSetTare.Location = new System.Drawing.Point(0, 0);
            this.BtnSetTare.Name = "BtnSetTare";
            this.BtnSetTare.Size = new System.Drawing.Size(121, 79);
            this.BtnSetTare.TabIndex = 428;
            this.BtnSetTare.TabStop = false;
            this.BtnSetTare.Text = "去皮";
            this.BtnSetTare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSetTare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSetTare.UseVisualStyleBackColor = true;
            this.BtnSetTare.Click += new System.EventHandler(this.BtnSetTare_Click);
            // 
            // PnlBottomMenu_4
            // 
            this.PnlBottomMenu_4.Controls.Add(this.panel15);
            this.PnlBottomMenu_4.Controls.Add(this.BtnClearTare);
            this.PnlBottomMenu_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_4.Location = new System.Drawing.Point(511, 3);
            this.PnlBottomMenu_4.Name = "PnlBottomMenu_4";
            this.PnlBottomMenu_4.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_4.TabIndex = 319;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Navy;
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(120, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1, 79);
            this.panel15.TabIndex = 314;
            // 
            // BtnClearTare
            // 
            this.BtnClearTare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnClearTare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClearTare.FlatAppearance.BorderSize = 0;
            this.BtnClearTare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearTare.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnClearTare.ForeColor = System.Drawing.Color.White;
            this.BtnClearTare.Image = ((System.Drawing.Image)(resources.GetObject("BtnClearTare.Image")));
            this.BtnClearTare.Location = new System.Drawing.Point(0, 0);
            this.BtnClearTare.Name = "BtnClearTare";
            this.BtnClearTare.Size = new System.Drawing.Size(121, 79);
            this.BtnClearTare.TabIndex = 314;
            this.BtnClearTare.TabStop = false;
            this.BtnClearTare.Text = "清皮";
            this.BtnClearTare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClearTare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClearTare.UseVisualStyleBackColor = true;
            this.BtnClearTare.Click += new System.EventHandler(this.BtnClearTare_Click);
            // 
            // BtnWeight
            // 
            this.BtnWeight.BackColor = System.Drawing.Color.Transparent;
            this.BtnWeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnWeight.BackgroundImage")));
            this.BtnWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnWeight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnWeight.FlatAppearance.BorderSize = 0;
            this.BtnWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnWeight.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.BtnWeight.ForeColor = System.Drawing.Color.Red;
            this.BtnWeight.Location = new System.Drawing.Point(714, 486);
            this.BtnWeight.Name = "BtnWeight";
            this.BtnWeight.Size = new System.Drawing.Size(240, 53);
            this.BtnWeight.TabIndex = 320;
            this.BtnWeight.TabStop = false;
            this.BtnWeight.Tag = "key";
            this.BtnWeight.UseVisualStyleBackColor = false;
            // 
            // BtnScaleName
            // 
            this.BtnScaleName.BackColor = System.Drawing.Color.Transparent;
            this.BtnScaleName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnScaleName.BackgroundImage")));
            this.BtnScaleName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnScaleName.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnScaleName.FlatAppearance.BorderSize = 0;
            this.BtnScaleName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnScaleName.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.BtnScaleName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnScaleName.Location = new System.Drawing.Point(714, 198);
            this.BtnScaleName.Name = "BtnScaleName";
            this.BtnScaleName.Size = new System.Drawing.Size(240, 53);
            this.BtnScaleName.TabIndex = 319;
            this.BtnScaleName.TabStop = false;
            this.BtnScaleName.Tag = "key";
            this.BtnScaleName.UseVisualStyleBackColor = false;
            // 
            // BtnStandardWeight
            // 
            this.BtnStandardWeight.BackColor = System.Drawing.Color.Transparent;
            this.BtnStandardWeight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnStandardWeight.BackgroundImage")));
            this.BtnStandardWeight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStandardWeight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnStandardWeight.FlatAppearance.BorderSize = 0;
            this.BtnStandardWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStandardWeight.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.BtnStandardWeight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.BtnStandardWeight.Location = new System.Drawing.Point(714, 342);
            this.BtnStandardWeight.Name = "BtnStandardWeight";
            this.BtnStandardWeight.Size = new System.Drawing.Size(240, 53);
            this.BtnStandardWeight.TabIndex = 318;
            this.BtnStandardWeight.TabStop = false;
            this.BtnStandardWeight.Tag = "key";
            this.BtnStandardWeight.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(714, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 53);
            this.button2.TabIndex = 317;
            this.button2.TabStop = false;
            this.button2.Tag = "key";
            this.button2.Text = "当前重量";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(714, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 53);
            this.button1.TabIndex = 316;
            this.button1.TabStop = false;
            this.button1.Tag = "key";
            this.button1.Text = "称台信息";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Transparent;
            this.btn1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn1.BackgroundImage")));
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(714, 270);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(240, 53);
            this.btn1.TabIndex = 315;
            this.btn1.TabStop = false;
            this.btn1.Tag = "key";
            this.btn1.Text = "砝码重量";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // PnlTop
            // 
            this.PnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlTop.BackgroundImage")));
            this.PnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlTop.Controls.Add(this.TblTopInfo);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1024, 70);
            this.PnlTop.TabIndex = 307;
            // 
            // TblTopInfo
            // 
            this.TblTopInfo.BackColor = System.Drawing.Color.Transparent;
            this.TblTopInfo.ColumnCount = 5;
            this.TblTopInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TblTopInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTopInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TblTopInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TblTopInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TblTopInfo.Controls.Add(this.LblTitle, 1, 0);
            this.TblTopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TblTopInfo.Location = new System.Drawing.Point(0, 0);
            this.TblTopInfo.Margin = new System.Windows.Forms.Padding(0);
            this.TblTopInfo.Name = "TblTopInfo";
            this.TblTopInfo.RowCount = 1;
            this.TblTopInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblTopInfo.Size = new System.Drawing.Size(1024, 70);
            this.TblTopInfo.TabIndex = 1;
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(23, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(396, 70);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "秤台校验";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicP1
            // 
            this.PicP1.BackColor = System.Drawing.Color.Transparent;
            this.PicP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicP1.FlatAppearance.BorderSize = 0;
            this.PicP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PicP1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PicP1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PicP1.Image = global::nMFStageClientWin.Properties.Resources.BtnP0_BackgroundImage1;
            this.PicP1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP1.Location = new System.Drawing.Point(268, 257);
            this.PicP1.Margin = new System.Windows.Forms.Padding(0);
            this.PicP1.Name = "PicP1";
            this.PicP1.Size = new System.Drawing.Size(185, 193);
            this.PicP1.TabIndex = 0;
            this.PicP1.Tag = "0";
            this.PicP1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP1.UseVisualStyleBackColor = false;
            this.PicP1.Click += new System.EventHandler(this.BtnP_Click);
            // 
            // PicP4
            // 
            this.PicP4.BackColor = System.Drawing.Color.Transparent;
            this.PicP4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicP4.FlatAppearance.BorderSize = 0;
            this.PicP4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PicP4.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PicP4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PicP4.Image = global::nMFStageClientWin.Properties.Resources.BtnP3_BackgroundImage1;
            this.PicP4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP4.Location = new System.Drawing.Point(471, 405);
            this.PicP4.Margin = new System.Windows.Forms.Padding(0);
            this.PicP4.Name = "PicP4";
            this.PicP4.Size = new System.Drawing.Size(185, 193);
            this.PicP4.TabIndex = 3;
            this.PicP4.Tag = "3";
            this.PicP4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP4.UseVisualStyleBackColor = false;
            this.PicP4.Click += new System.EventHandler(this.BtnP_Click);
            // 
            // PicP5
            // 
            this.PicP5.BackColor = System.Drawing.Color.Transparent;
            this.PicP5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicP5.FlatAppearance.BorderSize = 0;
            this.PicP5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PicP5.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PicP5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PicP5.Image = global::nMFStageClientWin.Properties.Resources.BtnP4_BackgroundImage1;
            this.PicP5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP5.Location = new System.Drawing.Point(41, 405);
            this.PicP5.Margin = new System.Windows.Forms.Padding(0);
            this.PicP5.Name = "PicP5";
            this.PicP5.Size = new System.Drawing.Size(185, 193);
            this.PicP5.TabIndex = 4;
            this.PicP5.Tag = "4";
            this.PicP5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP5.UseVisualStyleBackColor = false;
            this.PicP5.Click += new System.EventHandler(this.BtnP_Click);
            // 
            // PicP3
            // 
            this.PicP3.BackColor = System.Drawing.Color.Transparent;
            this.PicP3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicP3.FlatAppearance.BorderSize = 0;
            this.PicP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PicP3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PicP3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PicP3.Image = global::nMFStageClientWin.Properties.Resources.BtnP2_BackgroundImage1;
            this.PicP3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP3.Location = new System.Drawing.Point(471, 142);
            this.PicP3.Margin = new System.Windows.Forms.Padding(0);
            this.PicP3.Name = "PicP3";
            this.PicP3.Size = new System.Drawing.Size(185, 193);
            this.PicP3.TabIndex = 2;
            this.PicP3.Tag = "2";
            this.PicP3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP3.UseVisualStyleBackColor = false;
            this.PicP3.Click += new System.EventHandler(this.BtnP_Click);
            // 
            // PicP2
            // 
            this.PicP2.BackColor = System.Drawing.Color.Transparent;
            this.PicP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicP2.FlatAppearance.BorderSize = 0;
            this.PicP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PicP2.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.PicP2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PicP2.Image = global::nMFStageClientWin.Properties.Resources.BtnP1_BackgroundImage1;
            this.PicP2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP2.Location = new System.Drawing.Point(58, 142);
            this.PicP2.Margin = new System.Windows.Forms.Padding(0);
            this.PicP2.Name = "PicP2";
            this.PicP2.Size = new System.Drawing.Size(185, 193);
            this.PicP2.TabIndex = 1;
            this.PicP2.Tag = "1";
            this.PicP2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PicP2.UseVisualStyleBackColor = false;
            this.PicP2.Click += new System.EventHandler(this.BtnP_Click);
            // 
            // FrmVerifyCalibration
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.TlpBottom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnWeight);
            this.Controls.Add(this.BtnScaleName);
            this.Controls.Add(this.BtnStandardWeight);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.PicP1);
            this.Controls.Add(this.PicP4);
            this.Controls.Add(this.PicP5);
            this.Controls.Add(this.PicP3);
            this.Controls.Add(this.PicP2);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVerifyCalibration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVerifyCalibration_FormClosing);
            this.Load += new System.EventHandler(this.FrmVerifyCalibration_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.TlpBottom.ResumeLayout(false);
            this.PnlBottomMenu_7.ResumeLayout(false);
            this.PnlBottomMenu_6.ResumeLayout(false);
            this.PnlBottomMenu_2.ResumeLayout(false);
            this.PnlBottomMenu_1.ResumeLayout(false);
            this.PnlBottomMenu_0.ResumeLayout(false);
            this.PnlBottomMenu_5.ResumeLayout(false);
            this.PnlBottomMenu_3.ResumeLayout(false);
            this.PnlBottomMenu_4.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.TblTopInfo.ResumeLayout(false);
            this.TblTopInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PicP2;
        private System.Windows.Forms.Button PicP3;
        private System.Windows.Forms.Button PicP5;
        private System.Windows.Forms.Button PicP4;
        private System.Windows.Forms.Button PicP1;
        private System.Windows.Forms.Timer TmrWeight;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnWeight;
        private System.Windows.Forms.Button BtnScaleName;
        private System.Windows.Forms.Button BtnStandardWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TblTopInfo;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TableLayoutPanel TlpBottom;
        private System.Windows.Forms.Panel PnlBottomMenu_7;
        private System.Windows.Forms.Button BtnSkip;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel PnlBottomMenu_6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel PnlBottomMenu_2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BtnSetZero;
        private System.Windows.Forms.Panel PnlBottomMenu_1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel PnlBottomMenu_0;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PnlBottomMenu_5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnSetTareNumber;
        private System.Windows.Forms.Panel PnlBottomMenu_3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BtnSetTare;
        private System.Windows.Forms.Panel PnlBottomMenu_4;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button BtnClearTare;
    }
}

