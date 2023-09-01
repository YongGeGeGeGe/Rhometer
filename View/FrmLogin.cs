using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rheometer_Torque.Model;
using Utils.Utils;

namespace Rheometer_Torque.View
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private int userLoginCount = 0;
        private const int MAX_LOGIN_COUNT = 3;
        private User userLogin;
        public FrmLogin(ref User user)
        {
            InitializeComponent();
            userLogin = user;
            TxtUserName.Focus();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            User user = userLogin.Login(TxtUserName.Text, Tools.MD5Encrypt32(TxtPWD.Text));
            Tools.Clone(user, userLogin);
            if (userLogin.UserName != null)
            {
                if (ChkIsOffLine.Checked)
                {
                    userLogin.IsOffLine = true;
                }
                else
                {
                    userLogin.IsOffLine = false;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                userLoginCount++;
                if (userLoginCount >= MAX_LOGIN_COUNT)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    TxtUserName.Focus();
                }
            }
        }
    }
}