using Chart.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart.Server
{
    public partial class FrmUser : Form
    {
        private object userID;

        public FrmUser()
        {
            InitializeComponent();
        }

        public FrmUser(object userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            //新增
            if (this.userID == null)
            {
                this.lblUserID.Text = GetAvailableUserId().ToString();
                return;
            }
            else
            {
                this.lblUserID.Text = this.userID.ToString();
            }

            //修改
            string sql = String.Format("select * from UserList where UserId='{0}'",
                userID);
            DataSet ds = SqlHelper.Query(sql);
            DataRow row = ds.Tables[0].Rows[0];
            this.txtUserName.Text = row["UserName"].ToString();
            this.txtPassword.Text = row["Password"].ToString();
        }

        private int GetAvailableUserId()
        {
            int userId = 100;

            string sql = String.Format("select * from UserList where UserId='{0}'",
                userId);
            while (SqlHelper.Exists(sql))
            {
                userId++;
                sql = String.Format("select * from UserList where UserId='{0}'",
                    userId);
            }

            return userId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string sql;

            SqlParameter[] paramList = new SqlParameter[3];
            paramList[0] = new SqlParameter("UserId", this.lblUserID.Text);
            paramList[1] = new SqlParameter("UserName", this.txtUserName.Text);
            if (String.IsNullOrEmpty(this.txtPassword.Text))
            {
                paramList[2] = new SqlParameter("Password", this.lblUserID.Text);
            }
            else
            {
                paramList[2] = new SqlParameter("Password", this.txtPassword.Text);
            }

            if (userID == null)//新增用户
            {
                //保存用户信息
                this.userID = this.lblUserID.Text;
                sql = "insert into UserList (UserId, UserName, Password, CodeRule, Locked) values(@UserId, @UserName, @Password,'', 0)";
                SqlHelper.ExecuteSql(sql, paramList);
            }
            else//修改用户
            {
                //保存用户信息
                sql = "Update UserList set UserName=@UserName, Password=@Password";
                sql += " where UserId=@UserId";
                SqlHelper.ExecuteSql(sql, paramList);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = !String.IsNullOrEmpty(this.txtUserName.Text);
        }

        public object GetUserId()
        {
            return this.userID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
