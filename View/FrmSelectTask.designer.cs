namespace nMFStageClientWin
{
    partial class FrmSelectTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectTask));
            this.PnlLoading = new System.Windows.Forms.Panel();
            this.LblTips = new System.Windows.Forms.Label();
            this.TmrTime = new System.Windows.Forms.Timer(this.components);
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.PicWifi = new System.Windows.Forms.PictureBox();
            this.PicWifi0 = new System.Windows.Forms.PictureBox();
            this.TlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.PnlBottomMenu_7 = new System.Windows.Forms.Panel();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_6 = new System.Windows.Forms.Panel();
            this.LblPageInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_0 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBottomMenu_5 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.BtnPrevPage = new System.Windows.Forms.Button();
            this.PnlBottomMenu_3 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.PnlBottomMenu_4 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.ucShowTask_11 = new NTDCommon.ucShowTask();
            this.ucShowTask_0 = new NTDCommon.ucShowTask();
            this.ucShowTask_10 = new NTDCommon.ucShowTask();
            this.ucShowTask_1 = new NTDCommon.ucShowTask();
            this.ucShowTask_9 = new NTDCommon.ucShowTask();
            this.ucShowTask_2 = new NTDCommon.ucShowTask();
            this.ucShowTask_8 = new NTDCommon.ucShowTask();
            this.ucShowTask_3 = new NTDCommon.ucShowTask();
            this.ucShowTask_7 = new NTDCommon.ucShowTask();
            this.ucShowTask_4 = new NTDCommon.ucShowTask();
            this.ucShowTask_6 = new NTDCommon.ucShowTask();
            this.ucShowTask_5 = new NTDCommon.ucShowTask();
            this.PnlLoading.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicWifi0)).BeginInit();
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
            // PnlLoading
            // 
            this.PnlLoading.BackColor = System.Drawing.Color.DimGray;
            this.PnlLoading.Controls.Add(this.LblTips);
            this.PnlLoading.Location = new System.Drawing.Point(226, 282);
            this.PnlLoading.Name = "PnlLoading";
            this.PnlLoading.Size = new System.Drawing.Size(600, 250);
            this.PnlLoading.TabIndex = 370;
            this.PnlLoading.Visible = false;
            // 
            // LblTips
            // 
            this.LblTips.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblTips.Font = new System.Drawing.Font("微软雅黑", 25F);
            this.LblTips.ForeColor = System.Drawing.Color.White;
            this.LblTips.Location = new System.Drawing.Point(0, 46);
            this.LblTips.Name = "LblTips";
            this.LblTips.Size = new System.Drawing.Size(600, 204);
            this.LblTips.TabIndex = 0;
            this.LblTips.Text = "系统正在初始化...";
            this.LblTips.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TmrTime
            // 
            this.TmrTime.Tick += new System.EventHandler(this.TmrTime_Tick);
            // 
            // PnlTop
            // 
            this.PnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlTop.BackgroundImage")));
            this.PnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Controls.Add(this.LblTime);
            this.PnlTop.Controls.Add(this.panel15);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1024, 70);
            this.PnlTop.TabIndex = 308;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(580, 70);
            this.LblTitle.TabIndex = 81;
            this.LblTitle.Text = "   选择任务";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.Transparent;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblTime.Font = new System.Drawing.Font("微软雅黑", 24.25F);
            this.LblTime.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblTime.Location = new System.Drawing.Point(580, 0);
            this.LblTime.Margin = new System.Windows.Forms.Padding(0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Padding = new System.Windows.Forms.Padding(0, 0, 20, 10);
            this.LblTime.Size = new System.Drawing.Size(374, 70);
            this.LblTime.TabIndex = 371;
            this.LblTime.Text = "2020-10-22 12:00:00";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(20)))), ((int)(((byte)(51)))));
            this.panel15.Controls.Add(this.PicWifi);
            this.panel15.Controls.Add(this.PicWifi0);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(954, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(70, 70);
            this.panel15.TabIndex = 373;
            // 
            // PicWifi
            // 
            this.PicWifi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(20)))), ((int)(((byte)(51)))));
            this.PicWifi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicWifi.Image = ((System.Drawing.Image)(resources.GetObject("PicWifi.Image")));
            this.PicWifi.Location = new System.Drawing.Point(0, 0);
            this.PicWifi.Name = "PicWifi";
            this.PicWifi.Size = new System.Drawing.Size(70, 70);
            this.PicWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicWifi.TabIndex = 372;
            this.PicWifi.TabStop = false;
            this.PicWifi.Visible = false;
            // 
            // PicWifi0
            // 
            this.PicWifi0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(20)))), ((int)(((byte)(51)))));
            this.PicWifi0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicWifi0.Image = ((System.Drawing.Image)(resources.GetObject("PicWifi0.Image")));
            this.PicWifi0.Location = new System.Drawing.Point(0, 0);
            this.PicWifi0.Name = "PicWifi0";
            this.PicWifi0.Size = new System.Drawing.Size(70, 70);
            this.PicWifi0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicWifi0.TabIndex = 371;
            this.PicWifi0.TabStop = false;
            this.PicWifi0.Visible = false;
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
            this.TlpBottom.TabIndex = 466;
            // 
            // PnlBottomMenu_7
            // 
            this.PnlBottomMenu_7.Controls.Add(this.BtnNextPage);
            this.PnlBottomMenu_7.Controls.Add(this.panel1);
            this.PnlBottomMenu_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_7.Location = new System.Drawing.Point(892, 3);
            this.PnlBottomMenu_7.Name = "PnlBottomMenu_7";
            this.PnlBottomMenu_7.Size = new System.Drawing.Size(129, 79);
            this.PnlBottomMenu_7.TabIndex = 465;
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnNextPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNextPage.FlatAppearance.BorderSize = 0;
            this.BtnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNextPage.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnNextPage.ForeColor = System.Drawing.Color.White;
            this.BtnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("BtnNextPage.Image")));
            this.BtnNextPage.Location = new System.Drawing.Point(0, 0);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(128, 79);
            this.BtnNextPage.TabIndex = 314;
            this.BtnNextPage.TabStop = false;
            this.BtnNextPage.Text = "下页";
            this.BtnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNextPage.UseVisualStyleBackColor = true;
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(128, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 79);
            this.panel1.TabIndex = 314;
            // 
            // PnlBottomMenu_6
            // 
            this.PnlBottomMenu_6.Controls.Add(this.LblPageInfo);
            this.PnlBottomMenu_6.Controls.Add(this.panel2);
            this.PnlBottomMenu_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_6.Location = new System.Drawing.Point(765, 3);
            this.PnlBottomMenu_6.Name = "PnlBottomMenu_6";
            this.PnlBottomMenu_6.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_6.TabIndex = 465;
            // 
            // LblPageInfo
            // 
            this.LblPageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPageInfo.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.LblPageInfo.ForeColor = System.Drawing.Color.White;
            this.LblPageInfo.Location = new System.Drawing.Point(0, 0);
            this.LblPageInfo.Name = "LblPageInfo";
            this.LblPageInfo.Size = new System.Drawing.Size(120, 79);
            this.LblPageInfo.TabIndex = 315;
            this.LblPageInfo.Text = "1/1";
            this.LblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(120, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 79);
            this.panel2.TabIndex = 314;
            // 
            // PnlBottomMenu_2
            // 
            this.PnlBottomMenu_2.Controls.Add(this.panel3);
            this.PnlBottomMenu_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_2.Location = new System.Drawing.Point(257, 3);
            this.PnlBottomMenu_2.Name = "PnlBottomMenu_2";
            this.PnlBottomMenu_2.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_2.TabIndex = 465;
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
            // PnlBottomMenu_1
            // 
            this.PnlBottomMenu_1.Controls.Add(this.panel4);
            this.PnlBottomMenu_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_1.Location = new System.Drawing.Point(130, 3);
            this.PnlBottomMenu_1.Name = "PnlBottomMenu_1";
            this.PnlBottomMenu_1.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_1.TabIndex = 465;
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
            // PnlBottomMenu_0
            // 
            this.PnlBottomMenu_0.Controls.Add(this.panel5);
            this.PnlBottomMenu_0.Controls.Add(this.BtnClose);
            this.PnlBottomMenu_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_0.Location = new System.Drawing.Point(3, 3);
            this.PnlBottomMenu_0.Name = "PnlBottomMenu_0";
            this.PnlBottomMenu_0.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_0.TabIndex = 465;
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
            this.PnlBottomMenu_5.Controls.Add(this.panel14);
            this.PnlBottomMenu_5.Controls.Add(this.BtnPrevPage);
            this.PnlBottomMenu_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_5.Location = new System.Drawing.Point(638, 3);
            this.PnlBottomMenu_5.Name = "PnlBottomMenu_5";
            this.PnlBottomMenu_5.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_5.TabIndex = 464;
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
            // BtnPrevPage
            // 
            this.BtnPrevPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrevPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPrevPage.FlatAppearance.BorderSize = 0;
            this.BtnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevPage.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnPrevPage.ForeColor = System.Drawing.Color.White;
            this.BtnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevPage.Image")));
            this.BtnPrevPage.Location = new System.Drawing.Point(0, 0);
            this.BtnPrevPage.Name = "BtnPrevPage";
            this.BtnPrevPage.Size = new System.Drawing.Size(121, 79);
            this.BtnPrevPage.TabIndex = 320;
            this.BtnPrevPage.TabStop = false;
            this.BtnPrevPage.Text = "上页";
            this.BtnPrevPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrevPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnPrevPage.UseVisualStyleBackColor = true;
            this.BtnPrevPage.Click += new System.EventHandler(this.BtnPrevPage_Click);
            // 
            // PnlBottomMenu_3
            // 
            this.PnlBottomMenu_3.Controls.Add(this.panel16);
            this.PnlBottomMenu_3.Controls.Add(this.BtnRefresh);
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
            // BtnRefresh
            // 
            this.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRefresh.FlatAppearance.BorderSize = 0;
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("BtnRefresh.Image")));
            this.BtnRefresh.Location = new System.Drawing.Point(0, 0);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(121, 79);
            this.BtnRefresh.TabIndex = 428;
            this.BtnRefresh.TabStop = false;
            this.BtnRefresh.Text = "刷新";
            this.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // PnlBottomMenu_4
            // 
            this.PnlBottomMenu_4.Controls.Add(this.panel17);
            this.PnlBottomMenu_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_4.Location = new System.Drawing.Point(511, 3);
            this.PnlBottomMenu_4.Name = "PnlBottomMenu_4";
            this.PnlBottomMenu_4.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_4.TabIndex = 319;
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
            // ucShowTask_11
            // 
            this.ucShowTask_11.BackColor = System.Drawing.Color.White;
            this.ucShowTask_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_11.Control_0 = "-";
            this.ucShowTask_11.Control_1 = "-";
            this.ucShowTask_11.Control_2 = "-";
            this.ucShowTask_11.Control_3 = "-";
            this.ucShowTask_11.Control_4 = "-";
            this.ucShowTask_11.Control_5 = "-";
            this.ucShowTask_11.Control_6 = "";
            this.ucShowTask_11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_11.Location = new System.Drawing.Point(770, 482);
            this.ucShowTask_11.Name = "ucShowTask_11";
            this.ucShowTask_11.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_11.TabIndex = 11;
            this.ucShowTask_11.Task = null;
            this.ucShowTask_11.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_0
            // 
            this.ucShowTask_0.BackColor = System.Drawing.Color.White;
            this.ucShowTask_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_0.Control_0 = "-";
            this.ucShowTask_0.Control_1 = "-";
            this.ucShowTask_0.Control_2 = "-";
            this.ucShowTask_0.Control_3 = "-";
            this.ucShowTask_0.Control_4 = "-";
            this.ucShowTask_0.Control_5 = "-";
            this.ucShowTask_0.Control_6 = "";
            this.ucShowTask_0.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_0.Location = new System.Drawing.Point(11, 82);
            this.ucShowTask_0.Name = "ucShowTask_0";
            this.ucShowTask_0.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_0.TabIndex = 0;
            this.ucShowTask_0.Task = null;
            this.ucShowTask_0.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_10
            // 
            this.ucShowTask_10.BackColor = System.Drawing.Color.White;
            this.ucShowTask_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_10.Control_0 = "-";
            this.ucShowTask_10.Control_1 = "-";
            this.ucShowTask_10.Control_2 = "-";
            this.ucShowTask_10.Control_3 = "-";
            this.ucShowTask_10.Control_4 = "-";
            this.ucShowTask_10.Control_5 = "-";
            this.ucShowTask_10.Control_6 = "";
            this.ucShowTask_10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_10.Location = new System.Drawing.Point(517, 482);
            this.ucShowTask_10.Name = "ucShowTask_10";
            this.ucShowTask_10.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_10.TabIndex = 10;
            this.ucShowTask_10.Task = null;
            this.ucShowTask_10.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_1
            // 
            this.ucShowTask_1.BackColor = System.Drawing.Color.White;
            this.ucShowTask_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_1.Control_0 = "-";
            this.ucShowTask_1.Control_1 = "-";
            this.ucShowTask_1.Control_2 = "-";
            this.ucShowTask_1.Control_3 = "-";
            this.ucShowTask_1.Control_4 = "-";
            this.ucShowTask_1.Control_5 = "-";
            this.ucShowTask_1.Control_6 = "";
            this.ucShowTask_1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_1.Location = new System.Drawing.Point(264, 82);
            this.ucShowTask_1.Name = "ucShowTask_1";
            this.ucShowTask_1.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_1.TabIndex = 1;
            this.ucShowTask_1.Task = null;
            this.ucShowTask_1.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_9
            // 
            this.ucShowTask_9.BackColor = System.Drawing.Color.White;
            this.ucShowTask_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_9.Control_0 = "-";
            this.ucShowTask_9.Control_1 = "-";
            this.ucShowTask_9.Control_2 = "-";
            this.ucShowTask_9.Control_3 = "-";
            this.ucShowTask_9.Control_4 = "-";
            this.ucShowTask_9.Control_5 = "-";
            this.ucShowTask_9.Control_6 = "";
            this.ucShowTask_9.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_9.Location = new System.Drawing.Point(264, 482);
            this.ucShowTask_9.Name = "ucShowTask_9";
            this.ucShowTask_9.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_9.TabIndex = 9;
            this.ucShowTask_9.Task = null;
            this.ucShowTask_9.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_2
            // 
            this.ucShowTask_2.BackColor = System.Drawing.Color.White;
            this.ucShowTask_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_2.Control_0 = "-";
            this.ucShowTask_2.Control_1 = "-";
            this.ucShowTask_2.Control_2 = "-";
            this.ucShowTask_2.Control_3 = "-";
            this.ucShowTask_2.Control_4 = "-";
            this.ucShowTask_2.Control_5 = "-";
            this.ucShowTask_2.Control_6 = "";
            this.ucShowTask_2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_2.Location = new System.Drawing.Point(517, 82);
            this.ucShowTask_2.Name = "ucShowTask_2";
            this.ucShowTask_2.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_2.TabIndex = 2;
            this.ucShowTask_2.Task = null;
            this.ucShowTask_2.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_8
            // 
            this.ucShowTask_8.BackColor = System.Drawing.Color.White;
            this.ucShowTask_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_8.Control_0 = "-";
            this.ucShowTask_8.Control_1 = "-";
            this.ucShowTask_8.Control_2 = "-";
            this.ucShowTask_8.Control_3 = "-";
            this.ucShowTask_8.Control_4 = "-";
            this.ucShowTask_8.Control_5 = "-";
            this.ucShowTask_8.Control_6 = "";
            this.ucShowTask_8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_8.Location = new System.Drawing.Point(11, 482);
            this.ucShowTask_8.Name = "ucShowTask_8";
            this.ucShowTask_8.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_8.TabIndex = 8;
            this.ucShowTask_8.Task = null;
            this.ucShowTask_8.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_3
            // 
            this.ucShowTask_3.BackColor = System.Drawing.Color.White;
            this.ucShowTask_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_3.Control_0 = "-";
            this.ucShowTask_3.Control_1 = "-";
            this.ucShowTask_3.Control_2 = "-";
            this.ucShowTask_3.Control_3 = "-";
            this.ucShowTask_3.Control_4 = "-";
            this.ucShowTask_3.Control_5 = "-";
            this.ucShowTask_3.Control_6 = "";
            this.ucShowTask_3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_3.Location = new System.Drawing.Point(770, 82);
            this.ucShowTask_3.Name = "ucShowTask_3";
            this.ucShowTask_3.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_3.TabIndex = 3;
            this.ucShowTask_3.Task = null;
            this.ucShowTask_3.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_7
            // 
            this.ucShowTask_7.BackColor = System.Drawing.Color.White;
            this.ucShowTask_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_7.Control_0 = "-";
            this.ucShowTask_7.Control_1 = "-";
            this.ucShowTask_7.Control_2 = "-";
            this.ucShowTask_7.Control_3 = "-";
            this.ucShowTask_7.Control_4 = "-";
            this.ucShowTask_7.Control_5 = "-";
            this.ucShowTask_7.Control_6 = "";
            this.ucShowTask_7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_7.Location = new System.Drawing.Point(770, 282);
            this.ucShowTask_7.Name = "ucShowTask_7";
            this.ucShowTask_7.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_7.TabIndex = 7;
            this.ucShowTask_7.Task = null;
            this.ucShowTask_7.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_4
            // 
            this.ucShowTask_4.BackColor = System.Drawing.Color.White;
            this.ucShowTask_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_4.Control_0 = "-";
            this.ucShowTask_4.Control_1 = "-";
            this.ucShowTask_4.Control_2 = "-";
            this.ucShowTask_4.Control_3 = "-";
            this.ucShowTask_4.Control_4 = "-";
            this.ucShowTask_4.Control_5 = "-";
            this.ucShowTask_4.Control_6 = "";
            this.ucShowTask_4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_4.Location = new System.Drawing.Point(11, 282);
            this.ucShowTask_4.Name = "ucShowTask_4";
            this.ucShowTask_4.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_4.TabIndex = 4;
            this.ucShowTask_4.Task = null;
            this.ucShowTask_4.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_6
            // 
            this.ucShowTask_6.BackColor = System.Drawing.Color.White;
            this.ucShowTask_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_6.Control_0 = "-";
            this.ucShowTask_6.Control_1 = "-";
            this.ucShowTask_6.Control_2 = "-";
            this.ucShowTask_6.Control_3 = "-";
            this.ucShowTask_6.Control_4 = "-";
            this.ucShowTask_6.Control_5 = "-";
            this.ucShowTask_6.Control_6 = "";
            this.ucShowTask_6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_6.Location = new System.Drawing.Point(517, 282);
            this.ucShowTask_6.Name = "ucShowTask_6";
            this.ucShowTask_6.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_6.TabIndex = 6;
            this.ucShowTask_6.Task = null;
            this.ucShowTask_6.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // ucShowTask_5
            // 
            this.ucShowTask_5.BackColor = System.Drawing.Color.White;
            this.ucShowTask_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucShowTask_5.Control_0 = "-";
            this.ucShowTask_5.Control_1 = "-";
            this.ucShowTask_5.Control_2 = "-";
            this.ucShowTask_5.Control_3 = "-";
            this.ucShowTask_5.Control_4 = "-";
            this.ucShowTask_5.Control_5 = "-";
            this.ucShowTask_5.Control_6 = "";
            this.ucShowTask_5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucShowTask_5.Location = new System.Drawing.Point(264, 282);
            this.ucShowTask_5.Name = "ucShowTask_5";
            this.ucShowTask_5.Size = new System.Drawing.Size(240, 187);
            this.ucShowTask_5.TabIndex = 5;
            this.ucShowTask_5.Task = null;
            this.ucShowTask_5.Click += new System.EventHandler(this.ucShowTask_0_Click);
            // 
            // FrmSelectTask
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.TlpBottom);
            this.Controls.Add(this.PnlLoading);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.ucShowTask_11);
            this.Controls.Add(this.ucShowTask_0);
            this.Controls.Add(this.ucShowTask_10);
            this.Controls.Add(this.ucShowTask_1);
            this.Controls.Add(this.ucShowTask_9);
            this.Controls.Add(this.ucShowTask_2);
            this.Controls.Add(this.ucShowTask_8);
            this.Controls.Add(this.ucShowTask_3);
            this.Controls.Add(this.ucShowTask_7);
            this.Controls.Add(this.ucShowTask_4);
            this.Controls.Add(this.ucShowTask_6);
            this.Controls.Add(this.ucShowTask_5);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSelectTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSelectTask_FormClosing);
            this.Load += new System.EventHandler(this.FrmSelectTask_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.PnlLoading.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicWifi0)).EndInit();
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

        }

        #endregion
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblTitle;
        private NTDCommon.ucShowTask ucShowTask_11;
        private NTDCommon.ucShowTask ucShowTask_10;
        private NTDCommon.ucShowTask ucShowTask_9;
        private NTDCommon.ucShowTask ucShowTask_8;
        private NTDCommon.ucShowTask ucShowTask_7;
        private NTDCommon.ucShowTask ucShowTask_6;
        private NTDCommon.ucShowTask ucShowTask_5;
        private NTDCommon.ucShowTask ucShowTask_4;
        private NTDCommon.ucShowTask ucShowTask_3;
        private NTDCommon.ucShowTask ucShowTask_2;
        private NTDCommon.ucShowTask ucShowTask_1;
        private NTDCommon.ucShowTask ucShowTask_0;
        private System.Windows.Forms.Timer TmrTime;
        private System.Windows.Forms.Panel PnlLoading;
        private System.Windows.Forms.Label LblTips;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.PictureBox PicWifi;
        private System.Windows.Forms.PictureBox PicWifi0;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TableLayoutPanel TlpBottom;
        private System.Windows.Forms.Panel PnlBottomMenu_7;
        private System.Windows.Forms.Button BtnNextPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PnlBottomMenu_6;
        private System.Windows.Forms.Label LblPageInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnlBottomMenu_2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PnlBottomMenu_1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel PnlBottomMenu_0;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PnlBottomMenu_5;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button BtnPrevPage;
        private System.Windows.Forms.Panel PnlBottomMenu_3;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Panel PnlBottomMenu_4;
        private System.Windows.Forms.Panel panel17;
    }
}

