using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Client.core;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace Client.chart
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
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
        public  string userName;//自己用户昵称
        public int headID;//当前用户头像ID 
        public string userId;//当前用户ID
        public string frinend_message_id;
        public string Unread;
        public int [] AllHeadID;
        public bool[] unread;//记录有未读消息的用户索引
        public static int VoiceMessage = 1;
        public static int VoiceOnline = 1;
        public FrmMain(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        public void VoiceSing(string VoiceType)
        {
            switch(VoiceType)
            {
                case "Message":
                    if(VoiceMessage == 1)
                    {
                        SoundPlayer player = new SoundPlayer("msg.wav");
                        player.Play();
                    }
                    break;
                case "Online":
                    if(VoiceOnline == 1)
                    {
                        SoundPlayer player = new SoundPlayer("system.wav");
                        player.Play();
                    }
                    break;
            }
        }

        //客户端登录成功后加载，发送 USERLIST 请求，加载所有用户
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //发送请求
            UDP.myUDP.Send(UDP.DataType.UserList,new string[] { UDP.loginID});
            //用户列表
            UDP.myUDP.UserList += myUDP_UserListACK; 
            //登录成功后，未读消息提醒
            UDP.myUDP.Remind += MyUDP_Remind;
            //实时消息提醒
            UDP.myUDP.UserMessage += MessageRemind;
            //用户状态改变事件
            UDP.myUDP.UserStatusChg += myUDP_UserStatusChg;
            //接收图片
            UDP.myUDP.UserImage += MyUDP_UserImage;
            //接收文件
            UDP.myUDP.UserFile += myUDP_UserFile;
            //开始心跳
            InitHeartBeat();
            StartHeartBeatDriver(userId);
        }

        private void myUDP_UserFile(object sender, byte[] data)
        {
            List<string> result = UDP.GetMessage(data);
            message = result[1];
            string FileName = result[2];
            //接收文件
            string str = System.Windows.Forms.Application.StartupPath;
            string filepath = FileName;
            try
            {
                Client.core.file.WriteToFile(filepath, message);
            }
            catch (IOException m)

            {
                Console.WriteLine(m.ToString());
            }
            ChangeUnread(result[0], true);
            VoiceSing("Message");
        }

        private void MyUDP_UserImage(object sender, byte []data)
        {
            int index = 0;
            int length = BitConverter.ToInt32(data, index);
            index += 4;
            string FileName = Encoding.Unicode.GetString(data, index, length);
            index += length;

            length = BitConverter.ToInt32(data, index);
            index += 4;
            string FriendId = Encoding.Unicode.GetString(data, index, length);
            index += length;

            byte[] ImageByte = new byte[data.Length - index];
            Array.Copy(data, index, ImageByte, 0, data.Length - index);
                                              
            //D:\作业记录\2020下学期课程资料\1.jpg
            string str = System.Windows.Forms.Application.StartupPath;
            string ImagePath = str + "\\" + FileName;
            //MemoryStream ms = new MemoryStream(ImageByte2);
            MemoryStream ms = new MemoryStream(ImageByte);
            Bitmap bmp = new Bitmap(ms);
            bmp.Save(ImagePath, ImageFormat.Bmp);
            ms.Close();
            ChangeUnread(FriendId, true);
            VoiceSing("Message");
        }

        private void myUDP_UserStatusChg(object sender, byte[] data)
        {
            List<string> result = UDP.GetMessage(data);
            bool flag = (result[1] == "1");
            ModifyListViewItem(result[0], flag);
        }

        delegate void ModifyListViewItemCallback(string userId, bool online);
        private void ModifyListViewItem(string userId, bool online)
        {
            if (this.lv_friend.InvokeRequired)
            {
                ModifyListViewItemCallback d = new ModifyListViewItemCallback(ModifyListViewItem);
                this.Invoke(d, new object[] { userId, online });
                return;
            }
            ListViewItem lvi = FindListViewItemFromUserId(userId);
            if (lvi != null)
                lvi.Tag = online ? 1 : 0;
            else
                return;
            if(int.Parse(lvi.Tag.ToString())==1)//用户上线
            {
                lvi.BackColor = Color.Aqua;
                //SoundPlayer player = new SoundPlayer("system.wav");
                //player.Play();
                VoiceSing("Online");
                if (frmChat!=null&& frmChat.friendID==userId)
                {
                    frmChat.lab_name.BackColor = Color.Aqua;
                }
            }
           else
            {
                lvi.BackColor = Color.DarkGray;
                if (frmChat != null && frmChat.friendID == userId)
                {
                    frmChat.lab_name.BackColor = Color.DarkGray;
                }
            }


        }

        private ListViewItem FindListViewItemFromUserId(string userId)
        {
            ListViewItem lvi = null;
            foreach (ListViewItem lvItem in this.lv_friend.Items)
            {
                if (lvItem.ToolTipText.Equals(userId))
                {
                    lvi = lvItem;
                    break;
                }
            }
            return lvi;
        }

        //处理收到的未读消息提醒
        private void MyUDP_Remind(object sender, byte[] data)
        {
            List<string> result = UDP.GetMessage(data);
            string[] FromUID = result.ToArray();
            if(unread!=null)
            {
                for (int i = 0; i < FromUID.Length ; i++)
                {
                    ChangeUnread(FromUID[i], true);
                }
            }
            else
            {
                //Unread = e.Remind;
                for(int i=0;i<FromUID.Length;i++)
                {
                    Unread += FromUID[i];
                    Unread += "#";
                }
            }
                                                              
            if(FromUID.Length >0)
            {
                //SoundPlayer player = new SoundPlayer("msg.wav");
                //player.Play();
                VoiceSing("Message");
            }
        }

        //收到消息后的处理
        private  void MessageRemind(object sender, byte[] data)
        {
            List<string> result = UDP.GetMessage(data);
            message =result[1];
            frinend_message_id = result[0];
           
            //将相应的friend 索引号在unread中置为true(意思是这个索引有未读消息)
           ChangeUnread(frinend_message_id, true);

            //聊天消息提示
            // SoundPlayer player = new SoundPlayer("msg.wav");
            // player.Play();
            VoiceSing("Message");
        }
        //闪动计时器
        private void tim_remind_Tick(object sender,EventArgs e)
        {
            for (int j = 0; j < lv_friend.Items.Count; j++)
            {
                int temp = lv_friend.Items[j].ImageIndex;
                if (unread[j]==true)
                {
                    //头像闪动                  
                    if (lv_friend.Items[j].ImageIndex < 50)
                    {
                        lv_friend.Items[j].ImageIndex = 50;                       
                    }
                    else
                    {
                        //应该是原来的头像，现在先这样。
                        lv_friend.Items[j].ImageIndex = AllHeadID[j] ;
                    }
                }
               
            }
        }
       
        //修改unread数组,,,flag为 true 时置为未读，
        delegate void ChangeUnreadCallback(string friend_id, bool flag);
        public void ChangeUnread(string friend_id,bool flag)
        {
            if (lv_friend.InvokeRequired)
            {
                ChangeUnreadCallback d = new ChangeUnreadCallback(ChangeUnread);
                this.Invoke(d, new object[] { friend_id, flag });
                return;
            }
            for (int i = 0; i < lv_friend.Items.Count; i++)
            {
                if (lv_friend.Items[i].ToolTipText == friend_id)                
                    unread[i] = flag;                                                  
            }
        }

        //聊天窗体对象
        public static Frm_chat frmChat;

        //双击打开聊天窗体
        private void lv_friend_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lv_friend.SelectedItems.Count > 0)//判断是否有选中项
            {
                if (frmChat == null)//判断聊天窗体对象是否为空
                {
                    //定义此变量，暂时保存friendid
                    string  temp;
                    //创建聊天窗体对象
                    frmChat = new Frm_chat();
                    temp = lv_friend.SelectedItems[0].ToolTipText;
                    //int a = lv_friend.SelectedItems[0].ImageIndex;
                    ChangeUnread(temp, false);
                    //头像恢复原状
                    lv_friend.SelectedItems[0].ImageIndex = AllHeadID[lv_friend.SelectedItems[0].Index] ;
                    frmChat.frmMain = this;
                    //记录聊天的账号
                    frmChat.friendID = temp;
                    //Convert.ToInt32(lv_friend.SelectedItems[0].ToolTipText);
                    frmChat.headID = lv_friend.SelectedItems[0].ImageIndex;
                    //记录对方昵称
                    frmChat.nickName = lv_friend.SelectedItems[0].Text;
                    if(lv_friend.SelectedItems[0].Tag.ToString()=="1")                    
                        frmChat.online = true;
                    else
                        frmChat.online = false;

                    //以对话框显示聊天窗体对象
                    frmChat.Show();
                    //将聊天窗体对象设置为空
                    //frmChat = null;
                }
            }
        }

        //收到userlist后的处理过程
        private void myUDP_UserListACK(object sender, byte[] data)
        {
            List<string> result = UDP.GetMessage(data);
            AllHeadID = new int[result.Count];
            int k = 0;
            //循环找服务器传回的用户列表中的用户
            for (int i = 0; i < result.Count; i += 4)
            {               
                //在listview列表中增加除了自己的一行（Text、ToolTipText、ImageIndex）
                ListViewItem lvi = new ListViewItem();
                lvi.Text = result[i];//昵称
                //userInfo[1] 1为在线、0为不在线  
                if (int.Parse(result[i+1]) == 1)
                {
                    lvi.Tag = 1;
                    lvi.BackColor = Color.Aqua;
                } 
                else
                {
                    lvi.Tag = 0;
                    lvi.BackColor = Color.DarkGray;
                }
                        
                lvi.ToolTipText = result[i+2];//用户ID
                lvi.ImageIndex = int.Parse(result[i+3]);
                
                //如果此用户不是自己，则显示
                if (!this.userId.Equals(lvi.ToolTipText))
                {
                    AddListViewItem(lv_friend, lvi);
                    AllHeadID[k++] = lvi.ImageIndex;
                }
                else//否则找到了自己，于是将界面上的lab标签改成自己的昵称
                {
                    userName = lvi.Text;
                    headID = lvi.ImageIndex;
                    Show_Info(LabUserName);
                }
            }
            //将unread数组全部初始化为false         
           unread = new bool[lv_friend.Items.Count];
          
            if(Unread!=null)
            {
                string[] FromUID = Unread.Split('#');
                for (int i = 0; i < FromUID.Length - 1; i++)
                {
                    ChangeUnread(FromUID[i], true);
                }
            }
            


        }

        //定义展示自己信息的委托
        delegate void Show_InfoCallback(Label lab);
        public void Show_Info(Label lab)
        {
            if (lab.InvokeRequired)
            {
                Show_InfoCallback d = new Show_InfoCallback(Show_Info);
                this.Invoke(d, new object[] {lab});
                return;
            }
            lab.Text = userName;
            picture_user_head.Image = imageList_head.Images[headID];
        }
        
        //定义添加用户图标的委托
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
                    
        //关闭窗体
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            StopHeartBeatDriver();
            this.Close();
        }
        
        //最小化窗体
        private void pictureBox_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        //拖动窗体
        private void FrmMainMouseDown(object sender, MouseEventArgs e)
        {
            //用来释放被当前线程中某个窗口捕获的光标
            PublicClass.ReleaseCapture();
            //向Windows发送拖动窗体的消息
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);
        }

       public static Encode_Decode EnDeCode;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EnDeCode = new Encode_Decode("");
            EnDeCode.Show();
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            Point pp = new Point(Cursor.Position.X, Cursor.Position.Y);//获取鼠标在屏幕的坐标点
            Rectangle Rects = new Rectangle(this.Left, this.Top, this.Left + this.Width, this.Top + this.Height);//存储当前窗体在屏幕的所在区域
            if ((this.Top < 0) && PublicClass.PtInRect(ref Rects, pp))//当鼠标在当前窗体内，并且窗体的Top属性小于0
                this.Top = 0;//设置窗体的Top属性为0
            else
                //当窗体的上边框与屏幕的顶端的距离小于5时
                if (this.Top > -5 && this.Top < 5 && !(PublicClass.PtInRect(ref Rects, pp)))
                this.Top = 5 - this.Height;//将QQ窗体隐藏到屏幕的顶端
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDP.myUDP.Send(UDP.DataType.Logoff, new string[] { userId });
        }

        //鼠标悬停在最小化和关闭按钮时的效果
        private void pictureBox_min_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_min.BackColor = Color.Aqua;
        }

        private void pictureBox_min_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_min.BackColor = Color.Transparent;
        }

        private void pictureBox_close_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_close.BackColor = Color.Red;
        }

        private void pictureBox_close_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_close.BackColor = Color.Transparent;
        }

        //修改个人信息窗体
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Frm_EditInfo frm_EditInfo = new Frm_EditInfo();//创建个人信息窗体对象
            frm_EditInfo.frmMain = this;    //将当前窗体对象传给个人信息窗体
            frm_EditInfo.Show();
        }
        //文件嵌入提取按钮
        public static Frm_Fire_Trans frm_Fire_Trans;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Frm_Fire_Trans frm_Fire_Trans = new Frm_Fire_Trans("");
            frm_Fire_Trans.Show();
        }

        //设置按钮，设置提示音等
        private void buttSetting_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show();
        }
        #region 心跳包技术解决异常下线
        private System.Timers.Timer HeartBeatDriver;//心跳驱动器，与界面工具箱上的Timer不同，此Timer主要解决内部时序问题

        //初始化心跳驱动器
        private void InitHeartBeat()
        {
            //实例化心跳驱动器
            HeartBeatDriver = new System.Timers.Timer();
            //将心脏驱动器设置周期
            HeartBeatDriver.AutoReset = true;
            //周期默认为3秒
            HeartBeatDriver.Interval = 1000;
            //注册事件
            HeartBeatDriver.Elapsed += new System.Timers.ElapsedEventHandler(SendHeartBeatPag);
        }

        /// <summary>
        /// 开启心跳
        /// </summary>
        /// <param name="UserId"></param>
        public void StartHeartBeatDriver(string UserId)
        {
            this.userId = UserId;
            this.HeartBeatDriver.Start();
        }

        /// <summary>
        /// 关闭心跳
        /// </summary>
        public void StopHeartBeatDriver()
        {
            this.HeartBeatDriver.Stop();
        }

        /// <summary>
        /// 发送心跳包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendHeartBeatPag(object sender, System.Timers.ElapsedEventArgs e)
        {
            //发送包的类型为心跳包，需要服务器有处理该类包的功能，就是在服务器功能索引加上心跳字段。
            UDP.myUDP.Send(UDP.DataType.HeartBeat, new string[] { userId });
        }
        #endregion
    }
}
