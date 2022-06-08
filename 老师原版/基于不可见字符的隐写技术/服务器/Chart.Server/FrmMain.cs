using Chart.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                string request = Encoding.Unicode.GetString(recvData.Data);

                string[] requestMsg = request.Split(':');
                //判断客户端到底是什么要求，并进行相应的措施
                switch (requestMsg[0])
                {
                    case "LOGIN":
                        OnLogin(requestMsg[1], requestMsg[2], recvData.ipEndPoint);
                        break;
                    case "LOGOFF":
                        OnLogoff(requestMsg[1], recvData.ipEndPoint);
                        break;                  
                    case "CHANGEPWD":
                        OnChangePwd(requestMsg[1], requestMsg[2], recvData.ipEndPoint);
                        break;             
                    //客户端主窗体登录时
                    case "USERLIST":
                        OnUserList(recvData.ipEndPoint);
                        break;
                    case "MESSAGE":
                        OnMessage(requestMsg[1], requestMsg[2], recvData.ipEndPoint);
                        break;
                    case "FILE":
                        OnFile(requestMsg[1], requestMsg[2], requestMsg[3], recvData.ipEndPoint);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        //客户端发来登录请求
        private void OnLogin(string userId, string password, IPEndPoint ipEndPoint)
        {
            string sql = String.Format("select count(*) from UserList where UserId='{0}' and Password='{1}'",
                userId, password);

            int count = (int)SqlHelper.GetSingle(sql);

            //服务器端用不同的套结字进行回信--可以吗？详见python udp那里好像有
            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(
                        String.Format("LOGIN:{0}", count));
            client.Send(
                buffer, buffer.Length, ipEndPoint);

            //在界面上添加登录的用户信息
            if (count > 0)
            {
                ModifyListViewItem(userId, ipEndPoint, true);
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]登录：{1}",
                userId, count == 1 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);
        }

        private void OnLogoff(string userId, IPEndPoint ipEndPoint)
        {
            ModifyListViewItem(userId, null, false);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]注销", userId));
            AddListViewItem(lvLog, lvi);
        }

        private void OnChangePwd(string oldPwd, string newPwd, IPEndPoint ipEndPoint)
        {
            string userId = "";
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

            string response = "CHANGEPWD:";
            string sql = String.Format("select count(*) from UserList where UserId='{0}' and Password='{1}'",
                userId, oldPwd);

            int count = (int)SqlHelper.GetSingle(sql);
            if (count == 0)
            {
                response += "0";
            }
            else
            {
                sql = String.Format("update UserList set Password='{0}' where  UserId='{1}' and Password='{2}'",
                    newPwd, userId, oldPwd);
                response += SqlHelper.ExecuteSql(sql);
            }

            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(response);
            client.Send(buffer, buffer.Length, ipEndPoint);
        }

        //客户端窗体登录是自动加载
        delegate void OnUserListCallback(IPEndPoint ipEndPoint);
        private void OnUserList(IPEndPoint ipEndPoint)
        {
            if (this.InvokeRequired)
            {
                OnUserListCallback d = new OnUserListCallback(
                    OnUserList);
                this.Invoke(d, new object[]{ipEndPoint});
                return;
            }

            string response = "USERLIST";
            UdpClient client = new UdpClient(0);
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                response += String.Format(":{0}#{1}#{2}",
                    lvItem.Text, lvItem.ImageIndex, lvItem.ToolTipText);
            }

            UdpClient udpClient = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(response);
            udpClient.Send(buffer, buffer.Length, ipEndPoint);
        }

        private void OnMessage(string recvUser, string message, IPEndPoint sendIPEndPoint)
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
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 对 [{1}] 说：{2}",
                sendUser, recvUser, message));
            AddListViewItem(lvLog, lvi);
            if (!this.OnLineUserList.Contains(recvUser))//只有在线用户能够收到消息
                return;            
            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(String.Format("MESSAGE:{0}:{1}",
                sendUser, message));
            client.Send(
                buffer, buffer.Length, (IPEndPoint)OnLineUserList[recvUser]);
        }

        private void OnFile(string recvUser, string  message,string name, IPEndPoint sendIPEndPoint)
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
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 给 [{1}] 发送文件",
                sendUser, recvUser));
            AddListViewItem(lvLog, lvi);
            if (!this.OnLineUserList.Contains(recvUser))//只有在线用户能够收到消息
                return;
            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(String.Format("File:{0}:{1}:{2}",
                sendUser, message,name));
            client.Send(
                buffer, buffer.Length, (IPEndPoint)OnLineUserList[recvUser]);
        }

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
            UdpClient client = new UdpClient(0);
            string response = String.Format("USERSTASTUSCHG:{0}:{1}", userId, lvi.ImageIndex);
            byte[] buffer = Encoding.Unicode.GetBytes(response);
            foreach (DictionaryEntry de in OnLineUserList)
            {
                client.Send(buffer, buffer.Length, (IPEndPoint)de.Value);
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadUsers();
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
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["UserName"].ToString().Trim();
                lvi.ToolTipText = reader["UserId"].ToString().Trim();
                lvi.ImageIndex = 0;
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
            foreach (ListViewItem lvi in this.lvUser.Items)
            {
                if (lvi.ToolTipText.Equals(e.userId))
                {
                    lvi.Remove();
                    break;
                }
            }

            if (this.OnLineUserList.ContainsKey(e.userId))
            {
                this.OnLineUserList.Remove(e.userId);
            }
        }

        private void frmUserList_UserUpdate(object sender, UserEventArgs e)
        {
            ListViewItem lvi = null;
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                if (lvItem.ToolTipText.Equals(e.userId))
                {
                    lvi = lvItem;
                    break;
                }
            }

            string sql = String.Format("select * from UserList where UserId='{0}'",
                e.userId);
            DataSet ds = SqlHelper.Query(sql);
            DataRow row = ds.Tables[0].Rows[0];
            lvi.Text = row["UserName"].ToString().Trim();
        }
    }
}
