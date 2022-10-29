namespace nMFStageClientWin
{
    partial class FrmReviewBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReviewBarcode));
            this.TxtInputVale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtGoodsName = new System.Windows.Forms.TextBox();
            this.TxtGoodsNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.TmrInit = new System.Windows.Forms.Timer(this.components);
            this.BtnSave = new Sunny.UI.UIButton();
            this.BtnExit = new Sunny.UI.UIButton();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtInputVale
            // 
            this.TxtInputVale.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtInputVale.ForeColor = System.Drawing.Color.White;
            this.TxtInputVale.Location = new System.Drawing.Point(241, 209);
            this.TxtInputVale.Name = "TxtInputVale";
            this.TxtInputVale.Size = new System.Drawing.Size(275, 39);
            this.TxtInputVale.TabIndex = 0;
            this.TxtInputVale.Enter += new System.EventHandler(this.TxtInputVale_Enter);
            this.TxtInputVale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtInputVale_KeyDown);
            this.TxtInputVale.Leave += new System.EventHandler(this.TxtInputVale_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.Location = new System.Drawing.Point(64, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 36);
            this.label2.TabIndex = 131;
            this.label2.Text = "当前物料编号";
            // 
            // TxtGoodsName
            // 
            this.TxtGoodsName.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtGoodsName.Location = new System.Drawing.Point(241, 147);
            this.TxtGoodsName.Name = "TxtGoodsName";
            this.TxtGoodsName.ReadOnly = true;
            this.TxtGoodsName.Size = new System.Drawing.Size(275, 39);
            this.TxtGoodsName.TabIndex = 2;
            this.TxtGoodsName.TabStop = false;
            // 
            // TxtGoodsNo
            // 
            this.TxtGoodsNo.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtGoodsNo.Location = new System.Drawing.Point(241, 85);
            this.TxtGoodsNo.Name = "TxtGoodsNo";
            this.TxtGoodsNo.ReadOnly = true;
            this.TxtGoodsNo.Size = new System.Drawing.Size(275, 39);
            this.TxtGoodsNo.TabIndex = 1;
            this.TxtGoodsNo.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label3.Location = new System.Drawing.Point(64, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 36);
            this.label3.TabIndex = 134;
            this.label3.Text = "复核条码";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.Location = new System.Drawing.Point(64, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 36);
            this.label1.TabIndex = 133;
            this.label1.Text = "当前物料名称";
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(159)))));
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(594, 50);
            this.PnlTop.TabIndex = 319;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(594, 50);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "条码复核";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TmrInit
            // 
            this.TmrInit.Tick += new System.EventHandler(this.TmrInit_Tick);
            // 
            // BtnSave
            // 
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSave.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnSave.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnSave.Location = new System.Drawing.Point(78, 281);
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
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnExit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.Location = new System.Drawing.Point(396, 281);
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
            // FrmReviewBarcode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(594, 378);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.TxtInputVale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtGoodsName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtGoodsNo);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReviewBarcode";
            this.Text = "FrmLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReviewBarcode_FormClosing);
            this.Load += new System.EventHandler(this.FrmReviewBarcode_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmReviewBarcode_Paint);
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtInputVale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtGoodsName;
        private System.Windows.Forms.TextBox TxtGoodsNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Timer TmrInit;
        private Sunny.UI.UIButton BtnSave;
        private Sunny.UI.UIButton BtnExit;
    }
}