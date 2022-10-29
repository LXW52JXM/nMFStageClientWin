namespace nMFStageClientWin
{
    partial class FrmNotifyFinish
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
            this.label1 = new System.Windows.Forms.Label();
            this.TmrWeight = new System.Windows.Forms.Timer(this.components);
            this.PnlTop = new System.Windows.Forms.Panel();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnClearTare = new Sunny.UI.UIButton();
            this.BtnSetTare = new Sunny.UI.UIButton();
            this.BtnUsePrint = new Sunny.UI.UIButton();
            this.BtnZero = new Sunny.UI.UIButton();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(676, 130);
            this.label1.TabIndex = 1;
            this.label1.Text = "称量完成，请清空秤台。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TmrWeight
            // 
            this.TmrWeight.Interval = 200;
            this.TmrWeight.Tick += new System.EventHandler(this.TmrWeight_Tick);
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(159)))));
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(700, 50);
            this.PnlTop.TabIndex = 321;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.LblTitle.Size = new System.Drawing.Size(700, 50);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "提示";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnClearTare
            // 
            this.BtnClearTare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearTare.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnClearTare.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnClearTare.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnClearTare.Location = new System.Drawing.Point(364, 247);
            this.BtnClearTare.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnClearTare.Name = "BtnClearTare";
            this.BtnClearTare.Radius = 15;
            this.BtnClearTare.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnClearTare.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnClearTare.ShowFocusLine = true;
            this.BtnClearTare.Size = new System.Drawing.Size(120, 60);
            this.BtnClearTare.Style = Sunny.UI.UIStyle.Custom;
            this.BtnClearTare.StyleCustomMode = true;
            this.BtnClearTare.TabIndex = 2;
            this.BtnClearTare.Text = "清  皮";
            this.BtnClearTare.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnClearTare.Click += new System.EventHandler(this.BtnClearTare_Click);
            // 
            // BtnSetTare
            // 
            this.BtnSetTare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetTare.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSetTare.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnSetTare.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnSetTare.Location = new System.Drawing.Point(54, 247);
            this.BtnSetTare.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSetTare.Name = "BtnSetTare";
            this.BtnSetTare.Radius = 15;
            this.BtnSetTare.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSetTare.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnSetTare.ShowFocusLine = true;
            this.BtnSetTare.Size = new System.Drawing.Size(120, 60);
            this.BtnSetTare.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSetTare.StyleCustomMode = true;
            this.BtnSetTare.TabIndex = 0;
            this.BtnSetTare.Text = "去 皮";
            this.BtnSetTare.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSetTare.Click += new System.EventHandler(this.BtnSetTare_Click);
            // 
            // BtnUsePrint
            // 
            this.BtnUsePrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUsePrint.FillColor = System.Drawing.Color.Maroon;
            this.BtnUsePrint.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnUsePrint.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnUsePrint.Location = new System.Drawing.Point(519, 247);
            this.BtnUsePrint.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnUsePrint.Name = "BtnUsePrint";
            this.BtnUsePrint.Radius = 15;
            this.BtnUsePrint.RectColor = System.Drawing.Color.Maroon;
            this.BtnUsePrint.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnUsePrint.ShowFocusLine = true;
            this.BtnUsePrint.Size = new System.Drawing.Size(120, 60);
            this.BtnUsePrint.Style = Sunny.UI.UIStyle.Custom;
            this.BtnUsePrint.StyleCustomMode = true;
            this.BtnUsePrint.TabIndex = 3;
            this.BtnUsePrint.Text = "补  打";
            this.BtnUsePrint.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnUsePrint.Click += new System.EventHandler(this.BtnUsePrint_Click);
            // 
            // BtnZero
            // 
            this.BtnZero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnZero.FillColor = System.Drawing.Color.DarkGreen;
            this.BtnZero.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnZero.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnZero.Location = new System.Drawing.Point(209, 247);
            this.BtnZero.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnZero.Name = "BtnZero";
            this.BtnZero.Radius = 15;
            this.BtnZero.RectColor = System.Drawing.Color.DarkGreen;
            this.BtnZero.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnZero.ShowFocusLine = true;
            this.BtnZero.Size = new System.Drawing.Size(120, 60);
            this.BtnZero.Style = Sunny.UI.UIStyle.Custom;
            this.BtnZero.StyleCustomMode = true;
            this.BtnZero.TabIndex = 1;
            this.BtnZero.Text = "清  零";
            this.BtnZero.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnZero.Click += new System.EventHandler(this.BtnZero_Click);
            // 
            // FrmNotifyFinish
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.BtnUsePrint);
            this.Controls.Add(this.BtnZero);
            this.Controls.Add(this.BtnClearTare);
            this.Controls.Add(this.BtnSetTare);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNotifyFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNotifyFinish_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmNotifyFinish_Paint);
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TmrWeight;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Label LblTitle;
        private Sunny.UI.UIButton BtnClearTare;
        private Sunny.UI.UIButton BtnSetTare;
        private Sunny.UI.UIButton BtnUsePrint;
        private Sunny.UI.UIButton BtnZero;
    }
}