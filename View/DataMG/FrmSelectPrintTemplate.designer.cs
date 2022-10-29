namespace nMFStageClientWin
{
    partial class FrmSelectPrintTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectPrintTemplate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSelectTemplate1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFormulaLabelPrintLable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSelectTemplate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPartsLabelPrintLable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.PnlBottomMenu_7 = new System.Windows.Forms.Panel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_0 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBottomMenu_5 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_3 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.PnlBottomMenu_4 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.CmbFormulaLabelPrinter = new Sunny.UI.UIComboBox();
            this.CmbPartsLabelPrinter = new Sunny.UI.UIComboBox();
            this.BtnTestPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.label1.Text = "选择模板";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnSelectTemplate1
            // 
            this.BtnSelectTemplate1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.BtnSelectTemplate1.Location = new System.Drawing.Point(691, 483);
            this.BtnSelectTemplate1.Name = "BtnSelectTemplate1";
            this.BtnSelectTemplate1.Size = new System.Drawing.Size(90, 36);
            this.BtnSelectTemplate1.TabIndex = 336;
            this.BtnSelectTemplate1.Tag = "配方标签模板";
            this.BtnSelectTemplate1.Text = "选择";
            this.BtnSelectTemplate1.Click += new System.EventHandler(this.PicSelectSimpleWeightTemplate_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label2.Location = new System.Drawing.Point(63, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 50);
            this.label2.TabIndex = 337;
            this.label2.Text = "配方标签打印机";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtFormulaLabelPrintLable
            // 
            this.TxtFormulaLabelPrintLable.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.TxtFormulaLabelPrintLable.Location = new System.Drawing.Point(372, 483);
            this.TxtFormulaLabelPrintLable.Name = "TxtFormulaLabelPrintLable";
            this.TxtFormulaLabelPrintLable.Size = new System.Drawing.Size(313, 36);
            this.TxtFormulaLabelPrintLable.TabIndex = 334;
            this.TxtFormulaLabelPrintLable.Tag = "标签模板";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label3.Location = new System.Drawing.Point(63, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 50);
            this.label3.TabIndex = 338;
            this.label3.Text = "配方标签打印机模板";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnSelectTemplate
            // 
            this.BtnSelectTemplate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.BtnSelectTemplate.Location = new System.Drawing.Point(691, 291);
            this.BtnSelectTemplate.Name = "BtnSelectTemplate";
            this.BtnSelectTemplate.Size = new System.Drawing.Size(90, 36);
            this.BtnSelectTemplate.TabIndex = 333;
            this.BtnSelectTemplate.Tag = "物料标签模板";
            this.BtnSelectTemplate.Text = "选择";
            this.BtnSelectTemplate.Click += new System.EventHandler(this.PicSelectSimpleWeightTemplate_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label4.Location = new System.Drawing.Point(63, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 50);
            this.label4.TabIndex = 339;
            this.label4.Text = "物料标签打印机";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtPartsLabelPrintLable
            // 
            this.TxtPartsLabelPrintLable.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.TxtPartsLabelPrintLable.Location = new System.Drawing.Point(372, 291);
            this.TxtPartsLabelPrintLable.Name = "TxtPartsLabelPrintLable";
            this.TxtPartsLabelPrintLable.Size = new System.Drawing.Size(313, 36);
            this.TxtPartsLabelPrintLable.TabIndex = 331;
            this.TxtPartsLabelPrintLable.Tag = "标签模板";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label5.Location = new System.Drawing.Point(63, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 50);
            this.label5.TabIndex = 340;
            this.label5.Text = "物料标签打印机模板";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.TlpBottom.TabIndex = 476;
            // 
            // PnlBottomMenu_7
            // 
            this.PnlBottomMenu_7.Controls.Add(this.BtnSave);
            this.PnlBottomMenu_7.Controls.Add(this.panel2);
            this.PnlBottomMenu_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_7.Location = new System.Drawing.Point(892, 3);
            this.PnlBottomMenu_7.Name = "PnlBottomMenu_7";
            this.PnlBottomMenu_7.Size = new System.Drawing.Size(129, 79);
            this.PnlBottomMenu_7.TabIndex = 465;
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(0, 0);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(128, 79);
            this.BtnSave.TabIndex = 314;
            this.BtnSave.TabStop = false;
            this.BtnSave.Text = "保存";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.PnlBottomMenu_6.Controls.Add(this.panel3);
            this.PnlBottomMenu_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottomMenu_6.Location = new System.Drawing.Point(765, 3);
            this.PnlBottomMenu_6.Name = "PnlBottomMenu_6";
            this.PnlBottomMenu_6.Size = new System.Drawing.Size(121, 79);
            this.PnlBottomMenu_6.TabIndex = 465;
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
            this.PnlBottomMenu_5.Controls.Add(this.panel14);
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
            this.PnlBottomMenu_4.Controls.Add(this.BtnTestPrint);
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
            // CmbFormulaLabelPrinter
            // 
            this.CmbFormulaLabelPrinter.DataSource = null;
            this.CmbFormulaLabelPrinter.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CmbFormulaLabelPrinter.DropDownWidth = 500;
            this.CmbFormulaLabelPrinter.FillColor = System.Drawing.Color.White;
            this.CmbFormulaLabelPrinter.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.CmbFormulaLabelPrinter.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CmbFormulaLabelPrinter.Location = new System.Drawing.Point(372, 394);
            this.CmbFormulaLabelPrinter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbFormulaLabelPrinter.MinimumSize = new System.Drawing.Size(63, 0);
            this.CmbFormulaLabelPrinter.Name = "CmbFormulaLabelPrinter";
            this.CmbFormulaLabelPrinter.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CmbFormulaLabelPrinter.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.CmbFormulaLabelPrinter.Size = new System.Drawing.Size(313, 36);
            this.CmbFormulaLabelPrinter.Style = Sunny.UI.UIStyle.Custom;
            this.CmbFormulaLabelPrinter.TabIndex = 477;
            this.CmbFormulaLabelPrinter.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbPartsLabelPrinter
            // 
            this.CmbPartsLabelPrinter.DataSource = null;
            this.CmbPartsLabelPrinter.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CmbPartsLabelPrinter.DropDownWidth = 500;
            this.CmbPartsLabelPrinter.FillColor = System.Drawing.Color.White;
            this.CmbPartsLabelPrinter.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.CmbPartsLabelPrinter.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CmbPartsLabelPrinter.Location = new System.Drawing.Point(368, 195);
            this.CmbPartsLabelPrinter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbPartsLabelPrinter.MinimumSize = new System.Drawing.Size(63, 0);
            this.CmbPartsLabelPrinter.Name = "CmbPartsLabelPrinter";
            this.CmbPartsLabelPrinter.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CmbPartsLabelPrinter.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.CmbPartsLabelPrinter.Size = new System.Drawing.Size(317, 36);
            this.CmbPartsLabelPrinter.Style = Sunny.UI.UIStyle.Custom;
            this.CmbPartsLabelPrinter.TabIndex = 478;
            this.CmbPartsLabelPrinter.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnTestPrint
            // 
            this.BtnTestPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnTestPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnTestPrint.FlatAppearance.BorderSize = 0;
            this.BtnTestPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTestPrint.Font = new System.Drawing.Font("微软雅黑", 17F);
            this.BtnTestPrint.ForeColor = System.Drawing.Color.White;
            this.BtnTestPrint.Image = ((System.Drawing.Image)(resources.GetObject("BtnTestPrint.Image")));
            this.BtnTestPrint.Location = new System.Drawing.Point(0, 0);
            this.BtnTestPrint.Name = "BtnTestPrint";
            this.BtnTestPrint.Size = new System.Drawing.Size(120, 79);
            this.BtnTestPrint.TabIndex = 315;
            this.BtnTestPrint.TabStop = false;
            this.BtnTestPrint.Text = "测试";
            this.BtnTestPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnTestPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnTestPrint.UseVisualStyleBackColor = true;
            this.BtnTestPrint.Click += new System.EventHandler(this.BtnTestPrint_Click);
            // 
            // FrmSelectPrintTemplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.CmbPartsLabelPrinter);
            this.Controls.Add(this.CmbFormulaLabelPrinter);
            this.Controls.Add(this.TlpBottom);
            this.Controls.Add(this.BtnSelectTemplate1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFormulaLabelPrintLable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnSelectTemplate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtPartsLabelPrintLable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmSelectPrintTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmSelectPrintTemplate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSelectTemplate1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFormulaLabelPrintLable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSelectTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPartsLabelPrintLable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel TlpBottom;
        private System.Windows.Forms.Panel PnlBottomMenu_7;
        private System.Windows.Forms.Button BtnSave;
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
        private Sunny.UI.UIComboBox CmbFormulaLabelPrinter;
        private Sunny.UI.UIComboBox CmbPartsLabelPrinter;
        private System.Windows.Forms.Button BtnTestPrint;
    }
}

