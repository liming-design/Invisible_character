using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart.Client
{
    public partial class FrmChgPwd : Form
    {
        public FrmChgPwd(string userId)
        {
            InitializeComponent();
            this.lbUser.Text = userId;
        }

        private void FrmChgPwd_Load(object sender, EventArgs e)
        {
            UDP.myUDP.ChangPwd += myUDP_ChgPwdACK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNewPwd.Text))
            {
                MessageBox.Show("新密码不能为空！");
                return;
            }
            if (!this.txtNewPwd.Text.Equals(this.txtConfirmPwd.Text))
            {
                MessageBox.Show("确认密码与新密码不一致，请仔细检查！");
                return;
            }

            UDP.myUDP.Send(String.Format("CHANGEPWD:{0}:{1}",
                this.txtOldPwd.Text, this.txtNewPwd.Text));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        delegate void myUDP_ChgPwdACKCallback(object sender, UDP.UserEventArgs e);
        private void myUDP_ChgPwdACK(object sender, UDP.UserEventArgs e)
        {
            if (this.InvokeRequired)
            {
                myUDP_ChgPwdACKCallback d = new myUDP_ChgPwdACKCallback(
                    myUDP_ChgPwdACK);
                this.Invoke(d, new object[]{sender, e});
                return;
            }

            string message;
            if (e.Result)
            {
                message = "修改密码成功，请牢记新密码！";
                MessageBox.Show(message);
                this.Close();
            }
            else
            {
                message = "密码修改失败，请检查原密码是否正确！";
                MessageBox.Show(message);
            }
        }
    }
}
