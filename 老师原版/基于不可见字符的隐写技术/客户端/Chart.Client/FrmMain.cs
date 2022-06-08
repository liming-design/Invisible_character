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

using System.IO;//读取文件内容

namespace Chart.Client
{
    public partial class FrmMain : Form
    {
       //在提取信息时需要传递消息参数，所以设为共开的
        private string Message;
        public string message
        {
            get
            {
                return Message;
            }
            set
            {
                Message = value;
            }
        }
        string userId;

        public FrmMain(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        /// <summary>
        /// 主窗体加载，监听服务器转发的文件和信息、监听其他用户的上线和线情况、
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //客户端登录成功后加载
            UDP.myUDP.Send("USERLIST");
            
            //触发加载所有用户的事件
            UDP.myUDP.UserList += myUDP_UserListACK;
            //当用户上线或者下线后
            UDP.myUDP.UserStatusChg += myUDP_UserStatusChg;
            //监听用户发来的信息
            UDP.myUDP.UserMessage += myUDP_UserMessage;
            //监听用户发来的文件
            UDP.myUDP.UserFile += myUDP_UserFile;
        }

        /// <summary>
        /// 客户端关闭，给服务器发送注销信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDP.myUDP.Send("LOGOFF:" + userId);
        }

        /// <summary>
        ///加载所有用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myUDP_UserListACK(object sender, UDP.UserEventArgs e)
        {
            //循环找服务器传回的用户列表中的用户
            foreach (string user in e.UserList)
            {
                //服务器在传给信息时用的“#”号隔开的
                string[] userInfo = user.Split('#');
                if (userInfo.Length != 3)
                {
                    continue;
                }

                //在listview列表中增加一行（Text、ToolTipText、ImageIndex）
                ListViewItem lvi = new ListViewItem();
                lvi.Text = userInfo[0];
                lvi.ImageIndex = int.Parse(userInfo[1]);//ImageIndex 0为在线、1为不在线
                lvi.ToolTipText = userInfo[2];

                //将自己的图标设置为另外的形式
                if (this.userId.Equals(lvi.ToolTipText))
                {
                    lvi.ImageIndex = 2;
                }

                AddListViewItem(lvUser, lvi);
            }
        }

        /// <summary>
        /// 当其他用户上线或下线时更新本窗体上的状态，传回其他用户的图标的ImageIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myUDP_UserStatusChg(object sender, UDP.UserEventArgs e)
        {
            ModifyListViewItem(e.UserId, e.OnLine);
        }
        
        /// <summary>
        /// 接收到公开信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myUDP_UserMessage(object sender, UDP.UserEventArgs e)
        {
            message = e.Message;
         
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}]>接收信息{1}",
                FindUserNameFromUserId(e.UserId), message));
            lvi.ForeColor = Color.Blue;
            AddListViewItem(lvLog, lvi);
        }

        /// <summary>
        /// 接收到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myUDP_UserFile(object sender, UDP.UserEventArgs e)
        {
            message = e.Message;
            byte[] MessageByte = new byte[Message.Length];
            string FileName = e.FileName;
            //接收文件
            string str = System.Windows.Forms.Application.StartupPath;
            //string filepath=str + "\\" + "Files" + "\\"+FileName;
            string filepath =FileName;
            try
            {
                Chart.Core.file.WriteToFile(filepath, message);
            }
            catch (IOException m)

            {
                Console.WriteLine(m.ToString());
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}]>接收文件{1}",
                FindUserNameFromUserId(e.UserId), filepath));
            lvi.ForeColor = Color.Blue;
            AddListViewItem(lvLog, lvi);
        }

        /// <summary>
        /// 添加到listview上
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="lvi"></param>
        delegate void AddListViewItemCallback(ListView lv, ListViewItem lvi);
        private void AddListViewItem(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                AddListViewItemCallback d = new AddListViewItemCallback(AddListViewItem);
                this.Invoke(d, new object[] { lv, lvi });
                return;
            }

            lv.Items.Add(lvi);
        }

        /// <summary>
        /// 更新用户图标和日志
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="online"></param>
        delegate void ModifyListViewItemCallback(string userId, bool online);
        private void ModifyListViewItem(string userId, bool online)
        {
            if (this.lvUser.InvokeRequired)
            {
                ModifyListViewItemCallback d = new ModifyListViewItemCallback(ModifyListViewItem);
                this.Invoke(d, new object[] { userId, online });
                return;
            }

            //将该用户的图标点亮或弄暗
            ListViewItem lvi = FindListViewItemFromUserId(userId);
            lvi.ImageIndex = online ? 1 : 0;
            //体现用户上线或下线
            lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}] {1}", lvi.Text,
                online ? "上线" : "下线"));
            lvi.ForeColor = online ? Color.Green : Color.DarkRed;
            AddListViewItem(lvLog, lvi);
        }

        /// <summary>
        /// 通过用户ID找用户姓名
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        delegate String FindUserNameFromUserIdCallback(string userId);
        private String FindUserNameFromUserId(string userId)
        {
            if (this.InvokeRequired)
            {
                FindUserNameFromUserIdCallback d = new FindUserNameFromUserIdCallback(
                    FindUserNameFromUserId);
                Object obj = this.Invoke(d, new object[] { userId });
                return obj.ToString();
            }

            string userName = null;
            ListViewItem lvi = null;
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                if (lvItem.ToolTipText.Equals(userId))
                {
                    lvi = lvItem;
                    break;
                }
            }
            if (lvi == null)
                userName = "未知用户";

            userName = lvi.Text;

            return userName;
        }

        /// <summary>
        /// 通过用户id找listview中的一行
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private ListViewItem FindListViewItemFromUserId(string userId)
        {
            ListViewItem lvi = null;
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                if (lvItem.ToolTipText.Equals(userId))
                {
                    lvi = lvItem;
                    break;
                }
            }

            return lvi;
        }

       /// <summary>
       /// 选择文件按钮
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// 发送信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.lvUser.FocusedItem == null)
            {
                MessageBox.Show("请选择好友！");
                return;
            }
            UDP.myUDP.Send(String.Format("MESSAGE:{0}:{1}",
                lvUser.FocusedItem.ToolTipText,
                txtMessage.Text));

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}]>发送信息{1}",
                this.lvUser.FocusedItem.Text, this.txtMessage.Text));
            lvi.ForeColor = Color.Green;
            //将发送的信息显示在窗体上
            AddListViewItem(lvLog, lvi);
        }

        /// <summary>
        /// 发送文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileSend_Click(object sender, EventArgs e)
        {
            if (this.lvUser.FocusedItem == null)
            {
                MessageBox.Show("请选择好友！");
                return;
            }
            string FilePath = this.txtFile.Text;
            String FileName = FilePath.Substring(FilePath.LastIndexOf("\\") + 1);
            if (FilePath == null)
            {
                MessageBox.Show("请选择文件！");
                return;

            }

           string fileString =Chart.Core.file.ReadFromFile(FilePath);
           if (this.lvUser.FocusedItem == null)
                return;

           UDP.myUDP.Send(String.Format("FILE:{0}:{1}:{2}",
                lvUser.FocusedItem.ToolTipText,
               fileString,FileName));

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}]>发送文件{1}",
                this.lvUser.FocusedItem.Text, txtFile.Text));
            lvi.ForeColor = Color.Green;
            //将发送的信息显示在窗体上
            AddListViewItem(lvLog, lvi);
        }

        /// <summary>
        /// 秘密信息嵌入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlsIn_Click(object sender, EventArgs e)
        {
            //把已经输入的消息或者文件名传给嵌入窗体
            FrmInvIn Fi = new FrmInvIn(this.txtMessage.Text,this.txtFile.Text);
            Fi.Show();
        }

        /// <summary>
        /// 秘密信息提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TlsOut_Click(object sender, EventArgs e)
        {
            if(this.lvLog.FocusedItem==null)
            {
                //可以多种途径提取密文
                DialogResult dr=MessageBox.Show("将不会对接收到的信息解密，如果对其解密，请在“通讯显示”除选择一行！", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //弹出窗体
                    FrmInvOut f1 = new FrmInvOut();
                    f1.ShowDialog();
                    return;
                }
                else
                   return;
            }
            string message = this.lvLog.FocusedItem.SubItems[1].Text;
            string[] sArray = message.Split('>');

            //弹出窗体
            FrmInvOut f2 = new FrmInvOut(sArray[1]);
            f2.ShowDialog();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiChgPwd_Click(object sender, EventArgs e)
        {
            FrmChgPwd chgPwd = new FrmChgPwd(this.userId);
            chgPwd.Show();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
