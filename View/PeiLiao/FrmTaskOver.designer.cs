namespace nMFStageClientWin
{
    partial class FrmTaskOver
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
            this.label1 = new System.Windows.Forms.Label();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnExit = new Sunny.UI.UIButton();
            this.BtnPrintTemplate = new Sunny.UI.UIButton();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 130);
            this.label1.TabIndex = 1;
            this.label1.Text = "本轮配方完成";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(159)))));
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(700, 50);
            this.PnlTop.TabIndex = 322;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(700, 50);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "提示";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnExit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.Location = new System.Drawing.Point(450, 254);
            this.BtnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Radius = 15;
            this.BtnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.ShowFocusLine = true;
            this.BtnExit.Size = new System.Drawing.Size(120, 60);
            this.BtnExit.Style = Sunny.UI.UIStyle.Custom;
            this.BtnExit.StyleCustomMode = true;
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "退 出";
            this.BtnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPrintTemplate
            // 
            this.BtnPrintTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrintTemplate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnPrintTemplate.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnPrintTemplate.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnPrintTemplate.Location = new System.Drawing.Point(132, 254);
            this.BtnPrintTemplate.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnPrintTemplate.Name = "BtnPrintTemplate";
            this.BtnPrintTemplate.Radius = 15;
            this.BtnPrintTemplate.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnPrintTemplate.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnPrintTemplate.ShowFocusLine = true;
            this.BtnPrintTemplate.Size = new System.Drawing.Size(120, 60);
            this.BtnPrintTemplate.Style = Sunny.UI.UIStyle.Custom;
            this.BtnPrintTemplate.StyleCustomMode = true;
            this.BtnPrintTemplate.TabIndex = 0;
            this.BtnPrintTemplate.Text = "打印标签";
            this.BtnPrintTemplate.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPrintTemplate.Click += new System.EventHandler(this.BtnPrintTemplate_Click);
            // 
            // FrmTaskOver
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnPrintTemplate);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaskOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmTaskOver_Paint);
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblTitle;
        private Sunny.UI.UIButton BtnExit;
        private Sunny.UI.UIButton BtnPrintTemplate;
    }
}