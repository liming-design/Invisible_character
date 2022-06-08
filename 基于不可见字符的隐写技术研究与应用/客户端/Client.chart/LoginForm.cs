using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.chart
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
     
        //登录按钮实现
        private void LoginButton_Click(object sender, EventArgs e)
        {
            //获取输入框的内容
            string UseId = this.textUID.Text;
            string UserPwd = this.textPWD.Text;
           
            UDP.myUDP.Send(UDP.DataType.Login, new string[] { UseId, UserPwd });
        }

        //撤销按钮实现
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        //加载方法
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //委托，当收到服务器的恢复时触发事件
            UDP.myUDP.Login += new UDP.UserEvent(Login);
        }

        //login 方法实现（判断允不允许登录）
        private void Login(object sender, byte[] data)
        {
            //判断用户名和密码是否正确
            List<string> result = UDP.GetMessage(data);
            if (result[0] == "1")//Result是bool值，1为允许登录，0为不允许登录
            {
                this.DialogResult = DialogResult.OK;//为什么需要写这步呢？为了给“program”传值
                UDP.loginID = this.textUID.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }

        }

        //传递本窗体内的东西给主主窗体
        public string GetUserId()
        {
            return this.textUID.Text;
        }
    
    }
}
