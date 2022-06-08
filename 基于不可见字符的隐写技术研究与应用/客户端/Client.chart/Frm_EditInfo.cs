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
    public partial class Frm_EditInfo : Form
    {
        public Frm_EditInfo()
        {
            InitializeComponent();
        }
        public FrmMain frmMain;

        /// <summary>
        /// 显示指定头像
        /// </summary>
        /// <param name="headID">头像ID</param>
        public void ShowHead(int headID)
        {
            pboxHead.Image = imageList_head.Images[headID];//显示头像
            pboxHead.Tag = headID;//设置Tag属性，在拼接更新SQL语句时使用
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_EditInfo_Load(object sender, EventArgs e)
        {
            txtBoxUserID.Text = frmMain.userId;
            txtBoxUName.Text = frmMain.userName;
            pboxHead.Image = imageList_head.Images[frmMain.headID];
            pboxHead.Tag = frmMain.headID;
            UDP.myUDP.ChangInfo += myUDP_ChangInfo;
        }

        private void myUDP_ChangInfo(object sender,byte[]data)
        {
            string message;
            List<string> result = UDP.GetMessage(data);
            if (result[0]=="1")
            {
                frmMain.userName = txtBoxUName.Text;
                frmMain.headID = int.Parse(pboxHead.Tag.ToString());
                frmMain.Show_Info(frmMain.LabUserName);
                
                message = "修改信息成功！";
                MessageBox.Show(message);
                
            }
            else
            {
                message = "信息修改失败，请检查原密码是否正确！";
                MessageBox.Show(message);
            }
            
            this.Close();
        }

        //选择用户头像按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Head frmHead = new Frm_Head();//创建头像窗体对象
            frmHead.frmEditInfo = this;//设置头像窗体中的个人信息窗体对象为当前窗体
            frmHead.Show();//显示头像窗体对象
            frmHead.Focus();
        }
        ///<summary>
        ///验证用户输入
        ///</summary>
        ///<returns>bool类型，表示验证结果</returns>
        private bool ValidateInput()
        {
            if (txtBoxUName.Text.Trim() == "" || txtBoxUName.Text.Length > 20)//判断昵称是否为空
            {
                MessageBox.Show("昵称输入有误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxUName.Focus();
                return false;
            }
            if (txtOldPwd.Text.Trim() != ""&& (txtNewPwd.Text.Trim() == ""|| txtNewPwdAgain.Text.Trim() == ""))
            {
                MessageBox.Show("请输入新密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPwdAgain.Focus();
                return false;
            }
            

            if (txtNewPwd.Text.Trim() != txtNewPwdAgain.Text.Trim())  //两次输入的密码是否一致
            {
                MessageBox.Show("两次输入的密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPwdAgain.Focus();
                return false;
            }

            if (txtNewPwd.Text.Trim() != "" && txtOldPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入原密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPwdAgain.Focus();
                return false;
            }

            return true;
        }
        //确认按钮
        private void buttOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())//调用自定义方法进行输入验证
            {
                List<string> result = new List<string>();                
                result.Add(txtBoxUName.Text);
                result.Add(pboxHead.Tag.ToString());
                if (txtOldPwd.Text.Trim()!="")//用户需要改密码
                {
                    result.Add(txtOldPwd.Text);
                    result.Add(txtNewPwd.Text);
                }
                string[] Result = result.ToArray();
                UDP.myUDP.Send(UDP.DataType.ChangeInfo,Result);
            }
        }
        //取消按钮
        private void buttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
