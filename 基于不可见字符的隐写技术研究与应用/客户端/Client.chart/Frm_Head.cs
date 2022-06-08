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
    public partial class Frm_Head : Form
    {
        public Frm_Head()
        {
            InitializeComponent();
        }
        public Frm_EditInfo frmEditInfo;  //个人信息窗体
        private void Frm_Head_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < imageList_head.Images.Count; i++)//遍历ImageList列表
            {
                lvHead.Items.Add(i.ToString());//将遍历项添加到ListView列表中
                lvHead.Items[i].ImageIndex = i;//为头像设置索引
            }
        }

        //确认按钮
        private void buttOK_Click(object sender, EventArgs e)
        {
            if (lvHead.SelectedItems.Count != 0)//判断是否选中了头像
            {
                int headID = lvHead.SelectedItems[0].ImageIndex;//获得当前选中头像的索引
                frmEditInfo.ShowHead(headID);//设置个人信息窗体中显示的头像
                
                this.Close();//关闭当前窗体
            }
            else
            {
                MessageBox.Show("请选择一个头像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //取消按钮
        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //双击选择头像
        private void lvHead_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int headID = lvHead.SelectedItems[0].ImageIndex;//获得当前选中头像的索引
            frmEditInfo.ShowHead(headID);//设置个人信息窗体中显示的头像
            this.Close();//关闭当前窗体
        }
    }
}
