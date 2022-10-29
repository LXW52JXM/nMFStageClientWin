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
    public partial class ucShowParts : UserControl
    {
        #region 属性
        public string GoodName
        {
            set { Lbl1.Text = value; }
        }
        public string GoodsNo
        {
            set { Lbl2.Text = value; }
        }
        public string Weight
        {
            set { Lbl3.Text = value; }
        }
        public string Order
        {
            set { Lbl4.Text = value; }
        }

        #endregion
        public ucShowParts()
        {
            InitializeComponent();
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
