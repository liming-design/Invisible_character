using Chart.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chart.Client
{
    public class UDP
    {
        public static UDP myUDP = new UDP();

        Thread UdpThread;
        //用同一套接字进行通信
        UdpClient udpClient;
        IPEndPoint serverEndPoint;

        //自定义事件
        public class UserEventArgs : EventArgs
        {
            public bool Result;
            public bool OnLine;
            public string UserId;
            public string Message;
            public string[] UserList;
            public string FileName;
            public UserEventArgs(bool result)
            {
                this.Result = result;
            }

            public UserEventArgs(string UserId)
            {
                this.UserId = UserId;
            }

            public UserEventArgs(string[] userList)
            {
                this.UserList = userList;
            }

            public UserEventArgs(string UserId, string message)
            {
                this.UserId = UserId;
                this.Message = 
                    message;
            }

            public UserEventArgs(string UserId, string message,string name)
            {
                this.UserId = UserId;
                this.Message =
                    message;
                this.FileName = name;
            }

            public UserEventArgs(string UserId, bool onLine)
            {
                this.UserId = UserId;
                this.OnLine = onLine;
            }
        }

        public delegate void UserEvent(object sender, UserEventArgs e);
        public event UserEvent Login, ChangPwd, UserList, UserMessage, UserStatusChg,UserFile;
        
        protected virtual void OnLogin(UserEventArgs e)
        {
            if (Login != null)
            {
                Login(this, e);
            }
        }
        protected virtual void OnChangPwd(UserEventArgs e)
        {
            if (ChangPwd!=null)
            {
                ChangPwd(this, e);
            }
        }
     
        protected virtual void OnUserList(UserEventArgs e)
        {
            if (UserList != null)
            {
                UserList(this, e);
            }
        }

        protected virtual void OnUserMessage(UserEventArgs e)
        {
            if (UserMessage != null)
            {
                UserMessage(this, e);
            }
        }

       
        protected virtual void OnUserStatusChg(UserEventArgs e)
        {
            if (UserStatusChg != null)
            {
                UserStatusChg(this, e);
            }
        }

        protected virtual void OnUserFile(UserEventArgs e)
        {
            if (UserFile != null)
            {
                UserFile(this, e);
            }
        }

        //初始化UDP类
        public UDP()
        {
           
            UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
        }

        private void StartUdpListener()
        {
            udpClient = new UdpClient(0);
            IPEndPoint RecvIpAndPort = new IPEndPoint(
                IPAddress.Any, 0);

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
                //看看能不能用别的线程代替，这样就可以不用构造RecvDataInfo这个了
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessUdpClient),
                        recvData);
            }
        }

        private void ProcessUdpClient(Object recvObj)
        {
            RecvDataInfo recvData;

            try
            {
                recvData = (RecvDataInfo)recvObj;
                string request = Encoding.Unicode.GetString(recvData.Data);
                //string request = System.Text.Encoding.GetEncoding("gb2312").GetString(recvData.Data);
                string[] requestMsg = request.Split(':');
                //客户端收到回复的信息所作出的反应
                switch (requestMsg[0])
                {
                    //点击登录按钮后收到回复的信息
                    case "LOGIN":
                        OnLogin(new UserEventArgs(String.Equals(requestMsg[1], "1")));
                        break;
                   
                    //改变密码页面点击修改后
                    case "CHANGEPWD":
                        OnChangPwd(new UserEventArgs(String.Equals(requestMsg[1], "1")));
                        break;
                   
                    case "USERLIST":
                        OnUserList(new UserEventArgs(requestMsg));
                        break;

                    case "MESSAGE":
                        OnUserMessage(new UserEventArgs(requestMsg[1], requestMsg[2]));
                        break;

                    case "USERSTASTUSCHG":
                        OnUserStatusChg(new UserEventArgs(
                            requestMsg[1], String.Equals(requestMsg[2], "1")));
                        break;
                    case "File":
                        OnUserFile(new UserEventArgs(requestMsg[1], requestMsg[2],requestMsg[3]));
                        break;
                    default:
                        break;
                }
            }
            catch
            { }
        }

       

        public void Send(string Test)
        {
            if (String.IsNullOrEmpty(Test))
            {
                return;
            }
           
            byte[] TestToByte = Encoding.Unicode.GetBytes(Test);
            //byte[] TestToByte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(Test);
            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            udpClient.Send(TestToByte, TestToByte.Length, ServerIpAndPort);
           
        }
        
    }
}
