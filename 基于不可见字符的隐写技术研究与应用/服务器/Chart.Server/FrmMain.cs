using Chart.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chart.Server
{
    public partial class FrmMain : Form
    {
        Thread UdpThread;
        private Hashtable OnLineUserList;
        public FrmMain()
        {
            InitializeComponent();
        }

        public enum DataType : byte
        {
            Login = 0,
            LoginAck = 1,
            Logoff = 2,
            ChangeInfo = 3,
            ChangeInfoAck = 4,
            UserList = 5,
            UserListAck = 6,
            Message = 7,
            MessageAck=8,
            MessageHistory=9,
            MessageHistoryAck=10,
            UserStatusChange = 11,
            File = 12,
            Image=13,
            RemindAck=14,
            HeartBeat = 15
        }

        public static void Send(DataType dataType, string[] msgList, byte[] ImageByte,IPEndPoint endPoint)
        {
            if (msgList == null)
                return;
            byte[] buffer = new byte[1];
            buffer[0] = (byte)dataType; // 数据类型
            foreach (string msg in msgList)
            {
                byte[] data = Encoding.Unicode.GetBytes(msg);
                byte[] tempBuffer = new byte[buffer.Length + 4 + data.Length];
                Array.Copy(buffer, 0, tempBuffer, 0, buffer.Length); //数据长度
                Array.Copy(BitConverter.GetBytes(data.Length), 0, tempBuffer, buffer.Length, 4);
                Array.Copy(data, 0, tempBuffer, buffer.Length + 4, data.Length);//数据
                buffer = tempBuffer;
            }
            byte[] Buffer = new byte[buffer.Length + ImageByte.Length];
            Array.Copy(buffer, 0, Buffer, 0, buffer.Length);
            Array.Copy(ImageByte, 0, Buffer, buffer.Length, ImageByte.Length);
            UdpClient client = new UdpClient(0);
            client.Send(Buffer, Buffer.Length, endPoint);
        }

        public static void Send(DataType dataType, string[] msgList, IPEndPoint endPoint)
        {
            if (msgList == null)
                return;
            byte[] buffer = new byte[1];
            buffer[0] = (byte)dataType; // 数据类型
            foreach (string msg in msgList)
            {
                byte[] data = Encoding.Unicode.GetBytes(msg);
                byte[] tempBuffer = new byte[buffer.Length + 4 + data.Length];
                Array.Copy(buffer, 0, tempBuffer, 0, buffer.Length); //数据长度
                Array.Copy(BitConverter.GetBytes(data.Length), 0, tempBuffer, buffer.Length, 4);
                Array.Copy(data, 0, tempBuffer, buffer.Length + 4, data.Length);//数据
                buffer = tempBuffer;
            }
            UdpClient client = new UdpClient(0);
            client.Send(buffer, buffer.Length, endPoint);
        }


        public static List<string> GetMessage(byte[] data)
        {
            List<string> Result = new List<string>();
            int index = 0;
            while (index != data.Length)
            {
                int length = BitConverter.ToInt32(data, index);
                index += 4;
                Result.Add(Encoding.Unicode.GetString(data, index, length));
                index += length;
            }
            return Result;
        }

        public void Send(DataType dataType,IPEndPoint endPoint)
        {
            byte[] Temp = new byte[1];
            Temp[0] = (byte)dataType;
            UdpClient udpClient = new UdpClient(0);
            udpClient.Send(Temp, Temp.Length, endPoint);
        }


        private void tsbEnable_Click(object sender, EventArgs e)
        {
            //未启动状态

            if (this.tsbEnable.ToolTipText == "启动")
            {
                if (UdpThread == null)
                {
                    //只用启动一次线程，便可以循环监听，只是针对“接收信息的线程”，“发送信息的套接字”可以在每次发送时创立
                    UdpThread = new Thread(StartUdpListener);
                }
                    
                UdpThread.IsBackground = true;
                UdpThread.Start();
                
                this.tstbPort.Enabled = false;
                this.tsbEnable.ToolTipText = "停止";
                this.tsbEnable.Image = Properties.Resources.Pause;
                this.tsslSysInfo.Text = String.Format("服务器IP：{0}  端口：{1}  服务：{2}启动",
                    GetPhysicalIP(), this.tstbPort.Text, DateTime.Now);
            }
          
        }

        private void StartUdpListener()
        {
            IPEndPoint RecvIpAndPort = new IPEndPoint(
                IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(
                int.Parse(Config.GetValue("Net", "Port")));

            #region 防止出现ConnectionReset
            uint IOC_IN = 0x80000000;
            uint IOC_VENDOR = 0x18000000;
            uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;

            udpClient.Client.IOControl(
                    (int)SIO_UDP_CONNRESET,
                    new byte[] { Convert.ToByte(false) }, null);
            #endregion

            byte[] recvTestByte;
            RecvDataInfo recvData;
            while (true)
            {
    
                recvTestByte = udpClient.Receive(ref RecvIpAndPort);

                recvData = new RecvDataInfo();
                recvData.Data = recvTestByte;
                recvData.ipEndPoint = RecvIpAndPort;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessUdpClient),
                        recvData);
            }
        }

        /// <summary>
        /// 处理收到的Udp数据包
        /// </summary>
        /// <param name="recvObj"></param>
        private void ProcessUdpClient(Object recvObj)
        {
            RecvDataInfo recvData;
            try
            {
                recvData = (RecvDataInfo)recvObj;
                //string request = Encoding.Unicode.GetString(recvData.Data);

              //  string[] requestMsg = request.Split(':');
                DataType dataType = (DataType)recvData.Data[0];
                byte[] data = new byte[recvData.Data.Length - 1];
                Array.Copy(recvData.Data, 1, data, 0, data.Length);
                List<string> Temp = new List<string>();
                if(dataType!=DataType.Image)                
                    Temp = GetMessage(data);    
                string []request = Temp.ToArray();
                //判断客户端到底是什么要求，并进行相应的措施
                switch (dataType)
                {
                    case DataType.Login:
                        OnLogin(request,recvData.ipEndPoint);
                        break;
                    case DataType.Logoff:
                        OnLogoff(request, recvData.ipEndPoint);
                        break;                  
                    case DataType.ChangeInfo:                        
                        OnChangeInfo(request, recvData.ipEndPoint);                       
                        break;             
                    //客户端主窗体登录时
                    case DataType.UserList:
                        OnUserList(recvData.ipEndPoint);
                        OnSendRemind(request, recvData.ipEndPoint);
                        break;
                    case DataType.Message:
                        OnMessage(request, recvData.ipEndPoint);
                        break;
                    case DataType.MessageHistory:
                        OnMessageHistory(request, recvData.ipEndPoint);
                        break;                   
                    case DataType.File:
                        OnFile(request, recvData.ipEndPoint);
                        break;
                    case DataType.Image:
                        OnImage(data, recvData.ipEndPoint);
                        break;
                    case DataType.HeartBeat:
                        OnHeartBeat(request[0], recvData.ipEndPoint);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        private void OnHeartBeat(string userId, IPEndPoint iPEndPoint)
        {
            //查询用户列表，看看是否存在该用户
            //如果不存在则返回。
            if (!userList.ContainsKey(userId))
            {
                return;
            }
            ServiceObject sobj = (ServiceObject)userList[userId];
            //更改最后一次收到心跳包的时间。
            sobj.LastRec = DateTime.Now;
            sobj.ipEndPoint = iPEndPoint;
            //如果该用户不在线，则置为在线状态
            if (!OnLineUserList.ContainsKey(userId))
            {
                ModifyListViewItem(userId, iPEndPoint, true);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = DateTime.Now.ToString();
                lvi.SubItems.Add("用户" + "[" + userId + "]" + "恢复正常");
                AddListViewItem(lvLog, lvi);
            }       
            userList[userId] = sobj;
        }

        private void OnChangeInfo(string[] request, IPEndPoint ipEndPoint)
        {           
            string userId = "";
            string response = "";
            string Uname = request[0];
            string UHeadID = request[1];
            foreach (DictionaryEntry de in OnLineUserList)
            {
                if (ipEndPoint.Equals(de.Value))
                {
                    userId = de.Key.ToString();
                    break;
                }
            }
            if (userId == "")
                return;
            //只修改昵称和头像
            if (request.Length==2)
            {
                string sql = String.Format("update UserList set UserName='{0}',HeadId='{1}' where  UserId='{2}' ",
                        Uname, UHeadID ,userId);
                response += SqlHelper.ExecuteSql(sql);
            }//也修改密码
            else if(request.Length==4)
            {
                string oldPwd = request[2];
                string newPwd = request[3];               
                string sql = String.Format("select count(*) from UserList where UserId='{0}' and Password='{1}'",
                userId, oldPwd);
                int count = (int)SqlHelper.GetSingle(sql);
                if (count == 0)
                {
                    response += "0";
                }
                else
                {
                    sql = String.Format("update UserList set UserName='{0}',HeadId='{1}', Password='{2}' where  UserId='{3}' and Password='{4}'",
                        Uname, UHeadID, newPwd, userId, oldPwd);
                    response += SqlHelper.ExecuteSql(sql);
                }
                
            }
           
            Send(DataType.ChangeInfoAck, new string[] { response }, ipEndPoint);
            //改变用户视图中的用户信息
            ChangeListInfo(userId, Uname, UHeadID);
            
        }
        delegate void ChangeListInfoCallback( string userId, string uname, string uHeadID);
        private void ChangeListInfo(string userId, string uname, string uHeadID)
        {
            if (lvUser.InvokeRequired)
            {
                ChangeListInfoCallback d = new ChangeListInfoCallback(ChangeListInfo);
                this.Invoke(d, new object[] { userId , uname , uHeadID });
                return;
            }
            for (int i=0;i< lvUser.Items.Count;i++)
            {
                if( lvUser.Items[i].ToolTipText == userId)
                {
                    lvUser.Items[i].Text = uname;
                    lvUser.Items[i].Tag = uHeadID;
                    break;
                }
            }
        }

        delegate void ModifyListViewItemCallback(string userId, object ipEndPoint, bool online);
        private void ModifyListViewItem(string userId, object ipEndPoint, bool online)
        {
            if (this.lvUser.InvokeRequired)
            {
                ModifyListViewItemCallback d = new ModifyListViewItemCallback(ModifyListViewItem);
                this.Invoke(d, new object[] { userId, ipEndPoint, online });
                return;
            }

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
                return;

            lvi.ImageIndex = online ? 1 : 0;

            //先通知其他在线用户，初始化客户端在线表
            //UdpClient client = new UdpClient(0);
            //string response = String.Format("USERSTASTUSCHG:{0}:{1}", userId, lvi.ImageIndex);
            //byte[] buffer = Encoding.Unicode.GetBytes(response);
            foreach (DictionaryEntry de in OnLineUserList)
            {
               // client.Send(buffer, buffer.Length, (IPEndPoint)de.Value);
                Send(DataType.UserStatusChange, new string[] { userId, lvi.ImageIndex.ToString() },
                    (IPEndPoint)de.Value);
            }

            if (online &&
                !OnLineUserList.ContainsKey(userId))//上线
            {
                //将该用户添加到在线用户列表中
                OnLineUserList.Add(lvi.ToolTipText, ipEndPoint);
            }
            else//下线
            {
                //将该用户从在线用户列表中移除
                OnLineUserList.Remove(lvi.ToolTipText);
            }
            this.tsslUserInfo.Text = String.Format("用户总数：{0}  在线用户：{1}",
                this.lvUser.Items.Count, this.OnLineUserList.Count);
        }

        private void OnMessageHistory(string[] request, IPEndPoint ipEndPoint)
        {           
            string v1 = request[0];
            string v2 = request[1];            
            string message;//消息内容
            byte[] MessageByte;//存入数据库库中的字节数组           
            string sql = string.Format("select * from tb_Message" +
                " where (FromUserID = " + v1+ " and " + "ToUserID=" + v2+ ") or (FromUserID =" + v2  + " and ToUserID ="
                + v1+ ") order by MessageTime asc");
            SqlDataReader Reader;
            Reader = SqlHelper.ExecuteReader(sql);
            List<string> response=new List<string>();
            //string response = "MessageHistory";
            while (Reader.Read())
            {
                response.Add(Reader["FromUserID"].ToString());
                response.Add(Reader["ToUserID"].ToString());
                MessageByte = (byte[])Reader["message"];
                message = Encoding.Unicode.GetString(MessageByte);
                response.Add(message);
                response.Add(Reader["messageTime"].ToString());
                response.Add(Reader["messageState"].ToString());
                response.Add(Reader["MessageType"].ToString());                            
            }
            //将数据库中的消息置为已读
            string sql2 = string.Format("update tb_Message set MessageState='1' where FromUserID =" + v2 + " and " + "ToUserID=" + v1);
            int count = SqlHelper.ExecuteSql(sql2);

            //发送结果            
            Send(DataType.MessageHistoryAck, response.ToArray(), ipEndPoint);
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户{0}请求用户{1}的消息", v1, v2));
            AddListViewItem(lvLog, lvi);
        }

        //客户端发来登录请求
        private void OnLogin(string[] request, IPEndPoint ipEndPoint)
        {
            //List<string> request = GetMessage(data);
            string userId = request[0];
            string password = request[1];
            string sql = String.Format("select count(*) from UserList where UserId='{0}' and Password='{1}'",
                userId, password);

            int count = (int)SqlHelper.GetSingle(sql);

            Send(DataType.LoginAck, new string[] { count.ToString() }, ipEndPoint);

            //在界面上添加登录的用户信息，并且如果有未读消息，向客户端发送提醒。
            if (count > 0)
            {
                ModifyListViewItem(userId, ipEndPoint, true);
                ServiceObject sobj = (ServiceObject)userList[userId];
                //更改最后一次收到心跳包的时间。
                sobj.LastRec = DateTime.Now;
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]登录：{1}",
                userId, count == 1 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);
        }
      
        private void OnLogoff(string[] request, IPEndPoint ipEndPoint)
        {
            string userId = request[0];

            ModifyListViewItem(userId, null, false);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]注销", userId));
            AddListViewItem(lvLog, lvi);
        }

       
        // 如果有未读消息则发送提醒
        private void OnSendRemind(string[] request, IPEndPoint ipEndPoint)
        {
            string userId = request[0];
            string sql = String.Format("select distinct FromUserID from tb_message where ToUserID = {0} " +
                " and MessageState=0", userId);

            SqlDataReader reader = SqlHelper.ExecuteReader(sql);
            //string response = "Remind:";
            List<string> response=new List<string>();
            while (reader.Read())
            {
                response.Add( reader["FromUserID"].ToString());
            }
            string[] Temp = response.ToArray();
            //发送
            Send(DataType.RemindAck, Temp, ipEndPoint);
        }

        //客户端窗体登录是自动加载
        delegate void OnUserListCallback(IPEndPoint ipEndPoint);
        private void OnUserList( IPEndPoint ipEndPoint)
        {
            if (this.InvokeRequired)
            {
                OnUserListCallback d = new OnUserListCallback(OnUserList);                    
                this.Invoke(d, new object[]{ipEndPoint});
                return;
            }
            string[] Temp = new string[this.lvUser.Items.Count * 4];
            int k = 0;
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                Temp[k++] = lvItem.Text;
                Temp[k++] = lvItem.ImageIndex.ToString();
                Temp[k++] = lvItem.ToolTipText;
                Temp[k++] = lvItem.Tag.ToString();
            }
            Send(DataType.UserListAck, Temp, ipEndPoint);
        }

        private void OnMessage(string[] request, IPEndPoint ipEndPoint)
        {
            string recvUser = request[0];
            string message = request[1];
            string sendUser = "";
            foreach (DictionaryEntry de in OnLineUserList){           
                if (ipEndPoint.Equals(de.Value)){               
                    sendUser = de.Key.ToString();
                    break;
                }
            }
            //记录消息状态,默认0为未读
            int messageState=0;                     
           //在下面显示
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 对 [{1}] 说：{2}",
                sendUser, recvUser, message));
            AddListViewItem(lvLog, lvi);

            //如果在线，则发送
            if (this.OnLineUserList.Contains(recvUser)){            
                  Send(DataType.MessageAck, new string[] { sendUser, message }, (IPEndPoint)OnLineUserList[recvUser]);
                messageState = 1;   //已发送            
            }
            byte[] MessageByte = Encoding.Unicode.GetBytes(message);
            //byte数组现在无法直接存入数据库，暂时先将该byte数组转换为十六进制字符串，存入数据库
            string MessageASCII="0x";
            for (int i = 0; i < MessageByte.Length; i++)
            {
                MessageASCII += MessageByte[i].ToString("X2");
            }
            //将消息插入数据库
            string sql = String.Format("insert into tb_Message values('{0}','{1}',{2},'{3}','{4}','{5}')",
               sendUser, recvUser, MessageASCII, messageState, DateTime.Now,"0");
            int count = (int)SqlHelper.ExecuteSql(sql);
        }

        /*
          public static List<string> GetMessage(byte[] data)
        {
            List<string> Result = new List<string>();
            int index = 0;
            while (index != data.Length)
            {
                int length = BitConverter.ToInt32(data, index);
                index += 4;
                Result.Add(Encoding.Unicode.GetString(data, index, length));
                index += length;
            }
            return Result;
        } 
         
         */


        private void OnImage(byte[] data, IPEndPoint sendIPEndPoint)
        {
            string sendUser = "";
            foreach (DictionaryEntry de in OnLineUserList)
            {
                if (sendIPEndPoint.Equals(de.Value))
                {
                    sendUser = de.Key.ToString();
                    break;
                }
            }
            int index = 0;
            int length = BitConverter.ToInt32(data, index);
            index += 4;
            string FileName = Encoding.Unicode.GetString(data,index,length);
            index += length;

            length= BitConverter.ToInt32(data, index);
            index += 4;
            string recvUser = Encoding.Unicode.GetString(data, index, length);
            index += length;

            byte[] ImageByte = new byte[data.Length - index];
            Array.Copy(data, index, ImageByte, 0, data.Length - index);
            

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 给 [{1}] 发送图片",
                sendUser, recvUser));
            AddListViewItem(lvLog, lvi);
            //记录消息状态,默认0为未读
            int messageState = 0;
            if (this.OnLineUserList.Contains(recvUser))//在线
            {
                Send(DataType.Image, new string[] { FileName, sendUser },ImageByte, (IPEndPoint)OnLineUserList[recvUser]);
                messageState = 1;
            }
            string MessageASCII = "0x";
            byte[] MessageByte = Encoding.Unicode.GetBytes(FileName);
            for (int i = 0; i < MessageByte.Length; i++)
            {
                MessageASCII += MessageByte[i].ToString("X2");
            }

            string sql = String.Format("insert into tb_Message values('{0}','{1}',{2},'{3}','{4}','{5}')",
              sendUser, recvUser, MessageASCII, messageState, DateTime.Now, "2");
            int count = (int)SqlHelper.ExecuteSql(sql);

        }

        //string recvUser, string  message,string name, IPEndPoint sendIPEndPoint
        private void OnFile(string[] request, IPEndPoint ipEndPoint)
        {
            string recvUser = request[0];
            string message = request[1];
            string name = request[2];
            string sendUser = "";
            foreach (DictionaryEntry de in OnLineUserList)
            {
                if (ipEndPoint.Equals(de.Value))
                {
                    sendUser = de.Key.ToString();
                    break;
                }
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 给 [{1}] 发送文件",
                sendUser, recvUser));
            AddListViewItem(lvLog, lvi);
            //记录消息状态,默认0为未读
            int messageState = 0;           
            if (this.OnLineUserList.Contains(recvUser))//在线
            {                
                Send(DataType.File, new string[] { sendUser, message, name },
                    (IPEndPoint)OnLineUserList[recvUser]);
                messageState = 1;
            }

            string MessageASCII = "0x";
            byte[] MessageByte = Encoding.Unicode.GetBytes(name);
            for (int i = 0; i < MessageByte.Length; i++)
            {
                MessageASCII += MessageByte[i].ToString("X2");
            }
            string sql = String.Format("insert into tb_Message values('{0}','{1}',{2},'{3}','{4}','{5}')",
              sendUser, recvUser, MessageASCII, messageState, DateTime.Now, "1");
            int count = (int)SqlHelper.ExecuteSql(sql);

        }

        //
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadUsers();
            timer1.Start();
            OnLineUserList = new Hashtable();

            //this.tstbPort.Text = Config.GetValue("Net", "Port");
            this.tstbPort.Text = Properties.Settings.Default.ServerPort.ToString();
            this.tsslSysInfo.Text = String.Format("服务器IP：{0}  端口：{1}  服务：未启动",
                GetPhysicalIP(), this.tstbPort.Text);
            this.tsslUserInfo.Text = String.Format("用户总数：{0}  在线用户：{1}",
                this.lvUser.Items.Count, this.OnLineUserList.Count);
        }

        private void LoadUsers()
        {
            string sql = "select * from UserList";
            SqlDataReader reader = SqlHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                ServiceObject sobj = new ServiceObject();
                sobj.UserName = reader["UserName"].ToString().Trim();
                sobj.UserId = reader["UserId"].ToString().Trim();
                sobj.ipEndPoint = null;
                sobj.LastRec = DateTime.MinValue;
                this.userList.Add(sobj.UserId, sobj);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["UserName"].ToString().Trim();
                lvi.ToolTipText = reader["UserId"].ToString().Trim();
                lvi.ImageIndex = 0;
                lvi.Tag = reader["HeadId"];
                this.lvUser.Items.Add(lvi);
            }
            reader.Close();
        }

        /// <summary>
        /// 获取物理IP
        /// </summary>
        /// <returns></returns>
        private IPAddress GetPhysicalIP()
        {
            List<string> listIP = new List<string>();
            ManagementClass mcNetworkAdapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc_NetworkAdapterConfig = mcNetworkAdapterConfig.GetInstances();
            foreach (ManagementObject mo in moc_NetworkAdapterConfig)
            {
                string mServiceName = mo["ServiceName"] as string;

                //过滤非真实的网卡  
                if (!(bool)mo["IPEnabled"])
                {
                    continue;
                }

                if (mServiceName.ToLower().Contains("vmnetadapter")
                 || mServiceName.ToLower().Contains("ppoe")
                 || mServiceName.ToLower().Contains("bthpan")
                 || mServiceName.ToLower().Contains("tapvpn")
                 || mServiceName.ToLower().Contains("ndisip")
                 || mServiceName.ToLower().Contains("sinforvnic"))
                {
                    continue;
                }

                string[] mIPAddress = mo["IPAddress"] as string[];
                if (mIPAddress != null)
                {
                    foreach (string ip in mIPAddress)
                    {
                        if (ip != "0.0.0.0")
                        {
                            listIP.Add(ip);
                        }
                    }
                }
                mo.Dispose();
            }

            if (listIP.Count == 0)
                return null;

            return IPAddress.Parse(listIP[0]);
        }

        //管理用户信息窗体
        private void tsbUserManage_Click(object sender, EventArgs e)
        {
            FrmUserList frmUserList = new FrmUserList();
            frmUserList.UserAdd += frmUserList_UserAdd;
            frmUserList.UserDelet += frmUserList_UserDelet;
            frmUserList.UserUpdate += frmUserList_UserUpdate;
            frmUserList.Show();
        }

        private void frmUserList_UserAdd(object sender, UserEventArgs e)
        {
            string sql = String.Format("select * from UserList where UserId='{0}'",
                e.userId);
            DataSet ds = SqlHelper.Query(sql);
            DataRow row = ds.Tables[0].Rows[0];

            ListViewItem lvi = new ListViewItem();
            lvi.Text = row["UserName"].ToString().Trim();
            lvi.ToolTipText = row["UserId"].ToString().Trim();
            lvi.ImageIndex = 0;
            this.lvUser.Items.Add(lvi);
        }

        private void frmUserList_UserDelet(object sender, UserEventArgs e)
        {
            string UserId = e.userId.ToString();
            foreach (ListViewItem lvi in this.lvUser.Items)
            {
                if (lvi.ToolTipText.Equals(UserId))
                {
                    this.lvUser.Items.Remove(lvi);
                    break;
                }
            }

            if (this.OnLineUserList.ContainsKey(UserId))
            {
                this.OnLineUserList.Remove(UserId);
            }
        }

        private void frmUserList_UserUpdate(object sender, UserEventArgs e)
        {
            ListViewItem lvi = null;
            string UserId = e.userId.ToString();
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                if (lvItem.ToolTipText.Equals(UserId))
                {
                    lvi = lvItem;
                    break;
                }
            }

            string sql = String.Format("select * from UserList where UserId='{0}'",
                UserId);
            DataSet ds = SqlHelper.Query(sql);
            DataRow row = ds.Tables[0].Rows[0];
            lvi.Text = row["UserName"].ToString().Trim();
        }

        private void lvUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lvLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private Dictionary<object, ServiceObject> userList = new Dictionary<object, ServiceObject>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            ArrayList exceptionUsers = new ArrayList();
            //将异常下线的用户加到异常队列中去
            foreach (var dic in userList)
            {
                ServiceObject s = dic.Value;
                if (OnLineUserList.ContainsKey(s.UserId) &&
                    s.LastRec.AddSeconds(6) < DateTime.Now)
                {
                    exceptionUsers.Add(dic.Key);
                }
            }
            for (int i = 0; i < exceptionUsers.Count; i++)
            {
                string userId = (string)exceptionUsers[i];
                //更改用户状态
                ModifyListViewItem(userId, null, false);
                //将异常下线的用户写进日志
                ListViewItem lvi = new ListViewItem();
                lvi.Text = DateTime.Now.ToString();
                lvi.SubItems.Add("用户" + "[" + userId + "]" + "异常下线");
                AddListViewItem(lvLog, lvi);
            }
        }
    }
}
