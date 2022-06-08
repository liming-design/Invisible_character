using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.core;
namespace Client.chart
{
    public partial class Frm_chat : Form
    {
        public FrmMain frmMain;
        public int MessageType = 0;//发送的消息类型
        public string FirePath;//文件路径
        public string  friendID ;//当前聊天的好友号码
        public string nickName;//当前聊天的好友昵称
        public int headID;//当前聊天的好友头像ID    
        public bool online;
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
       
        public Frm_chat()
        {
            InitializeComponent();

        }

        //加载的方法
        private void Frm_chat_Load(object sender, EventArgs e)
        {
            //向服务器发送历史消息请求           
            UDP.myUDP.Send(UDP.DataType.MessageHistory,new string[] { UDP.loginID,friendID});
            //把朋友标签做好
            lab_name.Text = nickName+"("+friendID+")";
            if (online == true)
                lab_name.BackColor = Color.Aqua;
            else
                lab_name.BackColor = Color.DarkGray;
            pBoxHead.Image = imageList_head.Images[headID];
            //处理实时消息
            UDP.myUDP.UserMessage += myUDP_UserMessage;
            //处理历史消息
            UDP.myUDP.MessageHistory += myUDP_MessageHistory;
            //处理文件
            UDP.myUDP.UserFile += myUDP_UserFile;
            //处理图片
            UDP.myUDP.UserImage += MyUDP_userImage;
        }

        private void MyUDP_userImage(object sender,byte[]data)
        {
            List<string> result = UDP.GetMessage(data);
            string SendUser = result[1];
            if (SendUser == friendID)
            {
                string FileName = result[0];
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(String.Format("[我] 接收图片    {0}", DateTime.Now.ToString()));
                lvi.ForeColor = Color.Green;
                lvi.Tag = 3;
                AddListViewItem(lvLog, lvi);
                lvi = new ListViewItem();
                lvi.Text = string.Format("  {0}", FileName);
                lvi.Tag = 2;
                AddListViewItem(lvLog, lvi);
            }
        }

        private void myUDP_UserFile(object sender, byte[]data)
        {          
            List<string> result = UDP.GetMessage(data);
            string SendUser = result[0];
            if (SendUser == friendID)
            {
                message = result[1];
                string FileName = result[2];
                ListViewItem lvi = new ListViewItem();
                lvi.Text = String.Format("[我] 接收文件    {0}", DateTime.Now.ToString());//
                lvi.ForeColor = Color.Green;
                lvi.Tag = 3;
                AddListViewItem(lvLog, lvi);
                lvi = new ListViewItem();
                lvi.Text = string.Format("  {0}", FileName);
                lvi.Tag = 1;
                AddListViewItem(lvLog, lvi);
            }            
        }

        // //处理历史消息
        private void myUDP_MessageHistory(object sender,byte[]data)
        {
            string Messagetype="";
            List<string> result = UDP.GetMessage(data);
            for (int i= 0;i < result.Count; i+=6)
            {            
                ListViewItem lvi = new ListViewItem();
                if (result[i+5] == "0")
                    Messagetype = "";
                else if (result[i + 5] == "1")
                    Messagetype = "发送文件";
                else if (result[i + 5] == "2")
                    Messagetype = "发送图片";
                //Tag 为0是消息行，1是文件行，2是图片行，3是时间行
                if (result[i] == friendID)//DateTime.Now.ToString()
                {
                    lvi.Text =String.Format("[{0}] {1}   {2}", nickName,Messagetype, result[i + 3]);          
                    lvi.Tag = 3;//时间行
                    AddListViewItem(lvLog, lvi);
                    lvi = new ListViewItem();
                    lvi.Text = string.Format("  {0}", result[i + 2]);
                    lvi.ForeColor = Color.Blue;
                    lvi.Tag = result[i + 5];
                    AddListViewItem(lvLog, lvi);
                }
                else
                {
                    lvi.Text=String.Format("[我] {0}   {1}", Messagetype, result[i + 3]);
                    lvi.Tag = 3;//时间行
                    AddListViewItem(lvLog, lvi);
                    lvi = new ListViewItem();
                    lvi.Text = string.Format("  {0}", result[i + 2]);
                    lvi.ForeColor = Color.Green;
                    lvi.Tag = result[i + 5];
                    AddListViewItem(lvLog, lvi);
                }                
            } 
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
            //if(lvi.Tag.ToString()=="3")
              //  lvi.Font=new Font("宋体",10);
            lv.Items.Add(lvi);
        }

        //插入实时消息到聊天框中
        delegate void InsertCallback(RichTextBox Box1, string message);
        private void  Insert(RichTextBox Box1,string message)
        {
            if (Box1.InvokeRequired)
            {
                InsertCallback d = new InsertCallback(Insert);
                this.Invoke(d, new object[] { Box1, message });
                return;
            }
            Box1.Text += "\n" + nickName +"  [回复]  "+ DateTime.Now +"\n  " + message;
            //"\n" + FrmMain.userName + "   [我]   " + DateTime.Now + "\n  " + rtxtChat.Text + "";
        }
     
        //处理收到的message（显示到聊天框上）
        private void myUDP_UserMessage(object sender,byte[]data)
        {
            List<string> result = UDP.GetMessage(data);
            string SendUser = result[0];
            if(SendUser==friendID)
            {
                message = result[1];
                ListViewItem lvi = new ListViewItem();
                lvi.Text = String.Format("[{0}]     {1}", nickName, DateTime.Now.ToString());
                lvi.ForeColor = Color.Blue;
                lvi.Tag = 3;
                AddListViewItem(lvLog, lvi);

                lvi = new ListViewItem();
                lvi.Text = string.Format("  {0}",message);
                lvi.Tag = 0;
                AddListViewItem(lvLog, lvi);
            }                      
        }
        
        //发送按钮
        private void buttSend_Click(object sender, EventArgs e)
        {
            if (rtxtChat.Text.Trim() == "") //不能发送空消息
            {
                MessageBox.Show("不能发送空消息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(MessageType==0)//发送消息            
                SendMessage();
            
            else if(MessageType==1)
            {
                if(rtxtChat.Text==FirePath)                
                    SendFire();                                    
                else                
                    SendMessage();                                
            }
            else if(MessageType==2)
            {
                if (rtxtChat.Text == FirePath)
                    SendImage();
                else
                    SendMessage();              
            }
            MessageType = 0;
            FirePath = "";
        }

       

        /// <summary>
        /// 文件选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttFire_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rtxtChat.Text = ofd.FileName;
                FirePath = ofd.FileName;
                MessageType = 1;
            }
        }

        /// <summary>
        /// 图片选择按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.rtxtChat.Text = ofd.FileName;
                FirePath = ofd.FileName;
                MessageType = 2;
            }
        }

        //发送消息
        private void SendMessage()
        {
           
            UDP.myUDP.Send(UDP.DataType.Message, new string[] { friendID, rtxtChat.Text });
            ListViewItem lvi = new ListViewItem();
            lvi.Text=String.Format("[我]   {0}", DateTime.Now.ToString());
            lvi.ForeColor = Color.Green;
            lvi.Tag = 3;
            
            AddListViewItem(lvLog, lvi);

            lvi = new ListViewItem();
            lvi.Text = string.Format("  {0}", rtxtChat.Text);
            lvi.Tag = 0;
            AddListViewItem(lvLog, lvi);
            rtxtChat.Text = "";  //清空消息
            rtxtChat.Focus();//定位鼠标输入焦点

        }

        //发送文件
        private void SendFire()
        {
            string FilePath = this.rtxtChat.Text;
            String FileName = FilePath.Substring(FilePath.LastIndexOf("\\") + 1);
            if (FilePath == null)
            {
                MessageBox.Show("请选择文件！");
                return;
            }
            string fileString = Client.core.file.ReadFromFile(FilePath);
            UDP.myUDP.Send(UDP.DataType.File, new string[] { friendID, fileString, FileName });
            ListViewItem lvi = new ListViewItem();
            lvi.Text=String.Format("[我] 发送文件   {0}", DateTime.Now.ToString());
            lvi.ForeColor = Color.Green;
            lvi.Tag = 3;
            AddListViewItem(lvLog, lvi);

            lvi = new ListViewItem();
            lvi.Text = string.Format("  {0}", rtxtChat.Text);
            lvi.Tag = 1;
            AddListViewItem(lvLog, lvi);
            rtxtChat.Text = "";  //清空消息
            rtxtChat.Focus();//定位鼠标输入焦点      
        }
        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] SaveImage(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
            BinaryReader br = new BinaryReader(fs);
            byte[] imgBytesIn = br.ReadBytes((int)fs.Length); //将流读入到字节数组中
            return imgBytesIn;
        }

        /// <summary>
        /// 发送图片
        /// </summary>
        private void SendImage()
        {
            string FilePath = this.rtxtChat.Text;
            string FileName = FilePath.Substring(FilePath.LastIndexOf("\\") + 1);
            if (FilePath == null)
            {
                MessageBox.Show("请选择图片！");
                return;
            }
            byte[] ImageByte = SaveImage(FilePath);
            UDP.myUDP.Send(UDP.DataType.Image, new string[] { FileName, friendID }, ImageByte);                  

            ListViewItem lvi = new ListViewItem();
            lvi.Text=String.Format("[我] 发送图片   {0}", DateTime.Now.ToString());
            lvi.ForeColor = Color.Green;
            lvi.Tag = 3;
            AddListViewItem(lvLog, lvi);

            lvi = new ListViewItem();
            lvi.Text = string.Format("  {0}", rtxtChat.Text);
            lvi.Tag = 2;
            AddListViewItem(lvLog, lvi);
            rtxtChat.Text = "";  //清空消息
            rtxtChat.Focus();//定位鼠标输入焦点      
        }

        //发送文件



        /*  private void rtxtMessage_TextChanged(object sender, EventArgs e)
          {
             lvLog.SelectionStart = lvLog.TextLength;
             lvLog.ScrollToCaret();
          }
*///聊天窗体保持在最后一行
        private void lvLog_ControlAdded(object sender, ControlEventArgs e)
         {
            this.lvLog.Items[this.lvLog.Items.Count - 1].EnsureVisible();
        }

     


    //最小化窗体
    private void pBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
      
        //关闭窗体
        private void pBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMain.frmChat = null;
        }
        
        //关闭按钮
        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMain.frmChat = null;
        }

        //实现拖动
        private void Frm_chat_MouseDown(object sender, MouseEventArgs e)
        {
            PublicClass.ReleaseCapture();//用来释放被当前线程中某个窗口捕获的光标
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);//向Windows发送拖动窗体的消息
        }


       
        //当同时按下Ctrl和Enter时，发送消息
        private void rtxtChat_KeyDown(object sender, KeyEventArgs e)
        {
            //当同时按下Ctrl和Enter时，发送消息
            if (e.Control && e.KeyValue == 13)
            {
                e.Handled = true;
                buttSend_Click(this, null);//发送消息
            }
        }
        //点击消息时传给解码端
        private void lvLog_Click(object sender, EventArgs e)
        {
            string temp;
            string result;
            result = lvLog.FocusedItem.SubItems[0].Text;
            if (lvLog.FocusedItem.Tag.ToString() != "3")
                temp = result.Substring(2);
            else
                temp = result;
            this.rhTxBoxMess.Text = temp;
        }

        private void rhTxBoxMess_TextChanged(object sender, EventArgs e)
        {
            string OpenTest;
            string InvTest;
            string Test = null;
            rhTxtSecret.Clear();
            if (this.rhTxBoxMess.Text == null)
            {
                //MessageBox.Show("请输入想要提取的公开信息！");
                return;
            }
            //获取带有隐藏信息的文本信息
            OpenTest = this.rhTxBoxMess.Text;
            try
            {
                //提取不可见字符
                InvTest = Client.core.Cores.InvFromTest(OpenTest);
                string[] InvTestArray = InvTest.Split(';');
                //没有不可见字符
                if (InvTestArray[0] == "0")
                {
                    //MessageBox.Show(InvTestArray[1]);
                    rhTxtSecret.Text = "[无密文！]";                    
                    return;
                }
                //将不可见字符转为可见的秘密信息
                else
                {
                    if (ck.Checked == false)
                    {
                        
                            Test = Client.core.Cores.InvToTest(false, null, InvTestArray[1]);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.txtKey.Text) == true)
                        {
                            MessageBox.Show("请输入密钥！");
                            return;
                        }
                        else
                        {
                            Test = Client.core.Cores.InvToTest(true, txtKey.Text, InvTestArray[1]);
                        }
                    }                    
                    //将秘密信息显示出来（右下）屏幕
                    string[] TestArray = Test.Split(';');
                    this.rhTxtSecret.Text = TestArray[1];                 
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }

        }

        private void lvLog_DoubleClick(object sender, EventArgs e)
        {
            //"[{0}] 接收文件    {1}", nickName, filepath);
            string temp;
            string result;
            result = lvLog.FocusedItem.SubItems[0].Text;
            if (lvLog.FocusedItem.Tag.ToString() != "3")
                temp = result.Substring(2);
            else
                temp = result;
            if(lvLog.FocusedItem.Tag.ToString()=="1")
            {
                string FilePath;
                string Filepath;
                FilePath = System.Windows.Forms.Application.StartupPath;
                Filepath = Path.Combine(FilePath, temp);
                if (FrmMain.frm_Fire_Trans == null)
                {                    
                    FrmMain.frm_Fire_Trans = new Frm_Fire_Trans(Filepath);
                    FrmMain.frm_Fire_Trans.Show();
                }
                else
                    FrmMain.frm_Fire_Trans.AfterFirePath.Text = Filepath;
            }
            else
            {
                if (FrmMain.EnDeCode == null)
                {
                    FrmMain.EnDeCode = new Encode_Decode(temp);
                    FrmMain.EnDeCode.Show();
                }
                else
                    FrmMain.EnDeCode.txtSendMessage.Text = temp;
            }
            
        }

        private void lab_name_Click(object sender, EventArgs e)
        {

        }
        //鼠标悬停在最小化和关闭按钮时的效果
        private void pBoxClose_MouseEnter(object sender, EventArgs e)
        {
            pBoxClose.BackColor = Color.Red;
        }

        private void pBoxClose_MouseLeave(object sender, EventArgs e)
        {
            pBoxClose.BackColor = Color.Transparent;
        }

        private void pBoxMin_MouseEnter(object sender, EventArgs e)
        {
            pBoxMin.BackColor = Color.Aqua;
        }

        private void pBoxMin_MouseLeave(object sender, EventArgs e)
        {
            pBoxMin.BackColor = Color.Transparent;
        }




        private void lvLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
    
}
