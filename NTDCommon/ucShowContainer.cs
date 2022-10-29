using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTDCommon
{
    public partial class ucShowContainer : UserControl
    {
        #region 属性
        public string Ext1
        {
            set { Lbl1.Text = value; }
        }
        public string Ext2
        {
            set { Lbl2.Text = value; }
        }
        public string Ext3
        {
            set { Lbl3.Text = value; }
        }
        public string Ext4
        {
            set { Lbl4.Text = value; }
        }

        #endregion
        public ucShowContainer()
        {
            InitializeComponent();
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
        public void SetControlBackColor(Color color, string i)
        {
            switch (i)
            {
                case ("0"):
                    Lbl1.BackColor = color;
                    break;
                case ("1"):
                    Lbl2.BackColor = color;
                    break;
                case ("2"):
                    Lbl3.BackColor = color;
                    break;
                case ("3"):
                    Lbl4.BackColor = color;
                    break; 
                default:
                    break;
            }
        }
        public void SetControlForeColor(Color color, string i)
        {
            switch (i)
            {
                case ("0"):
                    Lbl1.ForeColor = color;
                    break;
                case ("1"):
                    Lbl2.ForeColor = color;
                    break;
                case ("2"):
                    Lbl3.ForeColor = color;
                    break;
                case ("3"):
                    Lbl4.ForeColor = color;
                    break;
                default:
                    break;
            }
        }

        public string Control_0
        {
            get { return Lbl1.Text.Trim(); }
            set { Lbl1.Text = value; }
        }

        public string Control_1
        {
            get { return Lbl2.Text.Trim(); }
            set { Lbl2.Text = value; }
        }
        public string Control_2
        {
            get { return Lbl3.Text.Trim(); }
            set { Lbl3.Text = value; }
        }
        public string Control_3
        {
            get { return Lbl4.Text.Trim(); }
            set { Lbl4.Text = value; }
        }

    }
}
