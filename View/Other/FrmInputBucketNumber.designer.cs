namespace nMFStageClientWin
{
    partial class FrmInputBucketNumber
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
            this.TxtContainerCode = new System.Windows.Forms.TextBox();
            this.TxtContainerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTareValue = new System.Windows.Forms.TextBox();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.BtnExit = new Sunny.UI.UIButton();
            this.BtnSave = new Sunny.UI.UIButton();
            this.BtnSetTareAndSave = new Sunny.UI.UIButton();
            this.BtnSelect = new Sunny.UI.UIButton();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.Location = new System.Drawing.Point(41, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 39);
            this.label1.TabIndex = 125;
            this.label1.Text = "容器编号";
            // 
            // TxtContainerCode
            // 
            this.TxtContainerCode.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtContainerCode.Location = new System.Drawing.Point(158, 86);
            this.TxtContainerCode.Name = "TxtContainerCode";
            this.TxtContainerCode.ReadOnly = true;
            this.TxtContainerCode.Size = new System.Drawing.Size(296, 39);
            this.TxtContainerCode.TabIndex = 127;
            this.TxtContainerCode.TabStop = false;
            // 
            // TxtContainerName
            // 
            this.TxtContainerName.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtContainerName.Location = new System.Drawing.Point(158, 142);
            this.TxtContainerName.Name = "TxtContainerName";
            this.TxtContainerName.ReadOnly = true;
            this.TxtContainerName.Size = new System.Drawing.Size(296, 39);
            this.TxtContainerName.TabIndex = 314;
            this.TxtContainerName.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.Location = new System.Drawing.Point(41, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 39);
            this.label2.TabIndex = 313;
            this.label2.Text = "容器名称";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label5.Location = new System.Drawing.Point(41, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 39);
            this.label5.TabIndex = 309;
            this.label5.Text = "容器重量";
            // 
            // TxtTareValue
            // 
            this.TxtTareValue.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.TxtTareValue.Location = new System.Drawing.Point(158, 198);
            this.TxtTareValue.Name = "TxtTareValue";
            this.TxtTareValue.ReadOnly = true;
            this.TxtTareValue.Size = new System.Drawing.Size(296, 39);
            this.TxtTareValue.TabIndex = 310;
            this.TxtTareValue.TabStop = false;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(603, 50);
            this.LblTitle.TabIndex = 311;
            this.LblTitle.Text = "选中容器";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlTop
            // 
            this.PnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(65)))), ((int)(((byte)(159)))));
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(603, 50);
            this.PnlTop.TabIndex = 318;
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnExit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.Location = new System.Drawing.Point(397, 288);
            this.BtnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Radius = 15;
            this.BtnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnExit.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnExit.ShowFocusLine = true;
            this.BtnExit.Size = new System.Drawing.Size(120, 60);
            this.BtnExit.Style = Sunny.UI.UIStyle.Custom;
            this.BtnExit.StyleCustomMode = true;
            this.BtnExit.TabIndex = 3;
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
            this.BtnSave.Location = new System.Drawing.Point(69, 288);
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
            // BtnSetTareAndSave
            // 
            this.BtnSetTareAndSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSetTareAndSave.FillColor = System.Drawing.Color.DarkGreen;
            this.BtnSetTareAndSave.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnSetTareAndSave.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnSetTareAndSave.Location = new System.Drawing.Point(233, 288);
            this.BtnSetTareAndSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSetTareAndSave.Name = "BtnSetTareAndSave";
            this.BtnSetTareAndSave.Radius = 15;
            this.BtnSetTareAndSave.RectColor = System.Drawing.Color.DarkGreen;
            this.BtnSetTareAndSave.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnSetTareAndSave.ShowFocusLine = true;
            this.BtnSetTareAndSave.Size = new System.Drawing.Size(120, 60);
            this.BtnSetTareAndSave.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSetTareAndSave.StyleCustomMode = true;
            this.BtnSetTareAndSave.TabIndex = 2;
            this.BtnSetTareAndSave.Text = "去皮保存";
            this.BtnSetTareAndSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSetTareAndSave.Click += new System.EventHandler(this.BtnSetTareAndSave_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSelect.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.BtnSelect.ForeSelectedColor = System.Drawing.Color.Empty;
            this.BtnSelect.Location = new System.Drawing.Point(460, 86);
            this.BtnSelect.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Radius = 15;
            this.BtnSelect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(46)))), ((int)(((byte)(154)))));
            this.BtnSelect.RectSelectedColor = System.Drawing.Color.Empty;
            this.BtnSelect.ShowFocusLine = true;
            this.BtnSelect.Size = new System.Drawing.Size(85, 46);
            this.BtnSelect.Style = Sunny.UI.UIStyle.Custom;
            this.BtnSelect.StyleCustomMode = true;
            this.BtnSelect.TabIndex = 0;
            this.BtnSelect.Text = "选 择";
            this.BtnSelect.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // FrmInputBucketNumber
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(603, 389);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.BtnSetTareAndSave);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.PnlTop);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTareValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtContainerCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtContainerName);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInputBucketNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmInputBucketNumber_Paint);
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtContainerCode;
        private System.Windows.Forms.TextBox TxtContainerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTareValue;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Panel PnlTop;
        private Sunny.UI.UIButton BtnSetTareAndSave;
        private Sunny.UI.UIButton BtnExit;
        private Sunny.UI.UIButton BtnSave;
        private Sunny.UI.UIButton BtnSelect;
    }
}