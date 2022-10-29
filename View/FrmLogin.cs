using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTDCommon;
using System.Drawing.Drawing2D;
using NTDCommLib;
using DBService;
using Model;

namespace nMFStageClientWin
{
    public partial class FrmLogin : Form
    {
        AppSettings AppSet=>AppSettings.AppSet;
        SystemSettings SystemSet =>  AppSet.SystemSet;

        int WaitTime = 60;
        int _RunTime = 0;
        TextBox FocusTextBox = null;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(bool isChange)
        {
            InitializeComponent();

        }
        private void FrmAdminLogin_Paint(object sender, PaintEventArgs e)
        {
            FormHelper.BorderSettings(sender, e, DashStyle.Solid, 5, PnlTop.BackColor, "");
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
       
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
              

                var user = new nmfs_user();
                string account = TxtAccount.Text.Trim();
                string password = TxtPwd.Text.Trim();

                if (string.IsNullOrEmpty(account))
                {
                    NTDMsg.TouchFlatMsgError("用户名不能为空！");
                    TxtAccount.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    NTDMsg.TouchFlatMsgError("密码不能为空！");
                    TxtPwd.Focus();
                    return;
                }
                //超级管理员登录
                if (account == "0000" && password == "9999")
                {
                    user = new nmfs_user();
                    {
                        user.id = "9999";
                        user.account = "0000";
                        user.username = "管理员";
                        user.password = "9999";
                        user.role_name = "超级管理员";
                    }
                    //保存登录人信息到全局
                    AppSet.CurrentLoginUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    return;

                }
                else
                {
                    //密码MD5加密
                    password = MD5Helper.MD5Return(password);
                    user = NmfsUserService.UserLoginAccount
                        (account);
                    if (user == null)
                    {
                        NTDMsg.TouchFlatMsgError("用户名不存在，请重新输入！");
                        return;
                    }

                    //查询密码是否出错
                    user = NmfsUserService.UserLogin(account, password);
                    if (user == null)
                    {
                        NTDMsg.TouchFlatMsgError("密码输入错误，请重新输入！");
                        return;
                    }
                    //保存登录人信息到全局
                    AppSet.CurrentLoginUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    return;
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
            finally
            {
             
            }
        }


   

        private void TxtPWD_Enter(object sender, EventArgs e)
        {
            FocusTextBox = (TextBox)sender;
        }

        private void FrmAdminLogin_Load(object sender, EventArgs e)
        {
            TxtAccount.Focus();
        }
        private void BtnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != FocusTextBox)
                {
                    Button b = (Button)sender;
                    if (b.Text.Trim() == "全键盘")
                    {
                        StartKeyBoard.StartKeyBoardFun();
                    }
                    else
                    {
                        NTDKeyBoard.KeyboardClickFunc(b, FocusTextBox);
                    }
                }
            }
            catch (Exception ex)
            {
                NTDMsg.TouchFlatMsgError(ex.Message);
            }
        }
    }
}

