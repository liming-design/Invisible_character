using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chart.Core;

namespace Chart.Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //获取输入框的内容
            string UseId = this.txtUserId.Text;
            string UserPwd = this.txtPwd.Text;
            string UserInfor = String.Format("LOGIN:{0}:{1}", UseId, UserPwd);
            
            //尝试使用UDP连接
            UDP.myUDP.Send(UserInfor);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //委托，当收到服务器的恢复时触发事件
            UDP.myUDP.Login += new UDP.UserEvent(Login);
        }
        private void Login(object sender, UDP.UserEventArgs e)
        {
            //判断用户名和密码是否正确
            if (e.Result)//Result是bool值，1为允许登录，0为不允许登录
            {
                this.DialogResult = DialogResult.OK;//为什么需要写这步呢？为了给“program”传值
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //传递本窗体内的东西给主主窗体
        public string GetUserId()
        {
            return this.txtUserId.Text;
        }
    }
}
