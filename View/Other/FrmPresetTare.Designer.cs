namespace nMFStageClientWin
{
    partial class FrmPresetTare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPresetTare));
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTareValue = new System.Windows.Forms.TextBox();
            this.BtnExit = new Sunny.UI.UIButton();
            this.BtnSave = new Sunny.UI.UIButton();
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
            this.PnlTop.SuspendLayout();
            this.PnlKeyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(159)))));
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(590, 50);
            this.PnlTop.TabIndex = 349;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(590, 50);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "数字去皮";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.Location = new System.Drawing.Point(52, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 39);
            this.label2.TabIndex = 131;
            this.label2.Text = "输入皮重";
            // 
            // TxtTareValue
            // 
            this.TxtTareValue.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtTareValue.Location = new System.Drawing.Point(178, 73);
            this.TxtTareValue.Name = "TxtTareValue";
            this.TxtTareValue.Size = new System.Drawing.Size(328, 39);
            this.TxtTareValue.TabIndex = 0;
            this.TxtTareValue.Enter += new System.EventHandler(this.TxtTareValue_Enter);
            this.TxtTareValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTareValue_KeyPress);
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnExit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.Location = new System.Drawing.Point(438, 291);
            this.BtnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Radius = 15;
            this.BtnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.ShowFocusLine = true;
            this.BtnExit.Size = new System.Drawing.Size(120, 60);
            this.BtnExit.Style = Sunny.UI.UIStyle.Custom;
            this.BtnExit.StyleCustomMode = true;
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "退 出";
            this.BtnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSave.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnSave.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnSave.Location = new System.Drawing.Point(438, 161);
            this.BtnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Radius = 15;
            this.BtnSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSave.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnSave.ShowFocusLine = true;
            this.BtnSave.Size = new System.Drawing.Size(120, 60);
            this.BtnSave.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSave.StyleCustomMode = true;
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "确 定";
            this.BtnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.PnlKeyboard.Location = new System.Drawing.Point(31, 127);
            this.PnlKeyboard.Margin = new System.Windows.Forms.Padding(0);
            this.PnlKeyboard.Name = "PnlKeyboard";
            this.PnlKeyboard.Size = new System.Drawing.Size(365, 325);
            this.PnlKeyboard.TabIndex = 471;
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
            // FrmPresetTare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 461);
            this.Controls.Add(this.PnlKeyboard);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTareValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPresetTare";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmPresetTare_Paint);
            this.PnlTop.ResumeLayout(false);
            this.PnlKeyboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTareValue;
        private Sunny.UI.UIButton BtnExit;
        private Sunny.UI.UIButton BtnSave;
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
    }
}

