
using Chart.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart.Server
{
    public partial class FrmUserList : Form
    {
        #region 定义自定义事件——用户增加、修改、删除
        public event UserEventHandler UserAdd, UserUpdate, UserDelet;
        protected virtual void OnUserAdd(UserEventArgs e)
        {
            if (UserAdd != null)
            {
                UserAdd(this, e);
            }
        }
        protected virtual void OnUserUpdate(UserEventArgs e)
        {
            if (UserUpdate != null)
            {
                UserUpdate(this, e);
            }
        }

        protected virtual void OnUserDelet(UserEventArgs e)
        {
            if (UserDelet != null)
            {
                UserDelet(this, e);
            }
        }
        #endregion

        public FrmUserList()
        {
            InitializeComponent();
        }

        private void FrmUserList_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        //加载所有用户
        private void LoadUser()
        {
            this.lvUserList.BeginUpdate();
            this.lvUserList.Items.Clear();

            string sql = "select * from UserList";
            DataSet ds = SqlHelper.Query(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = row["UserName"].ToString();
                lvi.Tag = row["UserId"];
                lvi.ImageIndex = 0;
                /*if (Convert.ToBoolean(row["Locked"]))
                {
                    lvi.ImageIndex = 1;
                }*/

                lvi.Group = this.lvUserList.Groups[0];
                this.lvUserList.Items.Add(lvi);
            }

            this.lvUserList.EndUpdate();
        }

        //添加按钮
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            if (frmUser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadUser();
            OnUserAdd(new UserEventArgs(frmUser.GetUserId()));
        }

        //修改按钮
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser(this.lvUserList.FocusedItem.Tag);
            if (frmUser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadUser();
            OnUserUpdate(new UserEventArgs(frmUser.GetUserId()));
        }

        //删除按钮
        private void btnDelUser_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                String.Format("确定要删除'{0}'吗？", this.lvUserList.FocusedItem.Text), "删除",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr != DialogResult.OK)
            {
                return;
            }

            string sql = String.Format("delete from UserList where UserId={0}",
                this.lvUserList.FocusedItem.Tag);
            SqlHelper.ExecuteSql(sql);

            string DeleUserId = this.lvUserList.FocusedItem.Tag.ToString();
            this.lvUserList.FocusedItem.Remove();
            
            lvUserList_SelectedIndexChanged(null, null);
            
            OnUserDelet(new UserEventArgs(DeleUserId));
            LoadUser();
        }
        
        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnUpdateUser.Enabled =
                this.lvUserList.SelectedItems.Count > 0 &&
                this.lvUserList.FocusedItem != null;
            this.btnDelUser.Enabled = this.btnUpdateUser.Enabled;
        }

        //退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
