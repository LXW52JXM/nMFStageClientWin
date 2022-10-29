
using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NTDCommon
{
    public partial class ucShowTask : UserControl
    {
        private nmfs_task _Task;
        public nmfs_task Task
        {
            get { return _Task; }

            set
            {
                _Task = value;
                if (_Task != null)
                {
                    Lbl_0.Text = _Task.serial_number;
                    Lbl_1.Text = _Task.name;
                    Lbl_2.Text = _Task.formula_name;
                    Lbl_3.Text = _Task.batching_way;
                    Lbl_4.Text = _Task.plan_time.ToString();
                    switch (_Task.status_batching)
                    {
                        case (0):
                            Lbl_5.Text = "新建";
                            break;
                        case (1):
                            Lbl_5.Text = "已下载";
                            break;
                        case (2):
                            Lbl_5.Text = "已完成";
                            break;
                    }
                    switch (_Task.task_level)
                    {
                        case (0):
                            Lbl_5.Text = Lbl_5.Text.Trim()+"(普通任务)";
                            break;
                        case (1):
                            Lbl_5.Text = Lbl_5.Text.Trim() + "(紧急任务)";
                            Lbl_5.BackColor = Color.Red;
                            break;
                   
                    }
                   
                    Lbl_6.Text= _Task.num.ToString();

                }
            }
        }
        public ucShowTask()
        {
            InitializeComponent();
        }

        public void SetDefaultControlBackColor()
        {
            Lbl_0.BackColor = Lbl_1.BackColor = Lbl_2.BackColor = Lbl_3.BackColor = Lbl_4.BackColor = Lbl_5.BackColor = this.BackColor;
        }

        public void SetControlBackColor(Color color, string i)
        {
            switch (i)
            {
                case ("0"):
                    Lbl_0.BackColor = color;
                    break;
                case ("1"):
                    Lbl_1.BackColor = color;
                    break;
                case ("2"):
                    Lbl_2.BackColor = color;
                    break;
                case ("3"):
                    Lbl_3.BackColor = color;
                    break;
                case ("4"):
                    Lbl_4.BackColor = color;
                    break;
                case ("5"):
                    Lbl_5.BackColor = color;
                    break;
                case ("6"):
                    Lbl_6.BackColor = color;
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
                    Lbl_0.ForeColor = color;
                    break;
                case ("1"):
                    Lbl_1.ForeColor = color;
                    break;
                case ("2"):
                    Lbl_2.ForeColor = color;
                    break;
                case ("3"):
                    Lbl_3.ForeColor = color;
                    break;
                case ("4"):
                    Lbl_4.ForeColor = color;
                    break;
                case ("5"):
                    Lbl_5.ForeColor = color;
                    break;
                case ("6"):
                    Lbl_6.ForeColor = color;
                    break;
                default:
                    break;
            }
        } 
        private void label1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
        public string Control_0
        {
            get { return Lbl_0.Text.Trim(); }
            set { Lbl_0.Text = value; }
        }

        public string Control_1
        {
            get { return Lbl_1.Text.Trim(); }
            set { Lbl_1.Text = value; }
        }
        public string Control_2
        {
            get { return Lbl_2.Text.Trim(); }
            set { Lbl_2.Text = value; }
        }
        public string Control_3
        {
            get { return Lbl_3.Text.Trim(); }
            set { Lbl_3.Text = value; }
        }
        public string Control_4
        {
            get { return Lbl_4.Text.Trim(); }
            set { Lbl_4.Text = value; }
        }
        public string Control_5
        {
            get { return Lbl_5.Text.Trim(); }
            set { Lbl_5.Text = value; }
        }
        public string Control_6
        {
            get { return Lbl_6.Text.Trim(); }
            set { Lbl_6.Text = value; }
        }
    }
}
