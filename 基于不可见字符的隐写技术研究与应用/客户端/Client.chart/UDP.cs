using Client.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Client.chart
{
    class UDP
    {
        public static string  loginID;//记录登录用户ID
        public static UDP myUDP = new UDP();
        Thread UdpThread;
        UdpClient udpClient;

        IPEndPoint serverEndPoint;
        //初始化UDP类
        public UDP()
        {

            UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
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
            MessageAck = 8,
            MessageHistory = 9,
            MessageHistoryAck = 10,
            UserStatusChange = 11,
            File = 12,
            Image = 13,
            RemindAck = 14,
            HeartBeat = 15
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="msgList"></param>
        public void Send(DataType dataType, string[] msgList)
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
            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            udpClient.Send(buffer, buffer.Length, ServerIpAndPort);
        }

        public void Send(DataType dataType)
        {
            byte[] Temp = new byte[1];
            Temp[0] = (byte)dataType;
            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            udpClient.Send(Temp, Temp.Length, ServerIpAndPort);
        }

        public  void Send(DataType dataType, string[] msgList, byte[] ImageByte)
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

            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            udpClient.Send(Buffer, Buffer.Length, ServerIpAndPort);
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

        public delegate void UserEvent(object sender, byte[] data);
        public event UserEvent Login, ChangInfo, UserList, UserMessage, 
            UserStatusChg, UserFile, MessageHistory, Remind,UserImage;


        private void ProcessUdpClient(Object recvObj)
        {
            RecvDataInfo recvData;

            try
            {
                recvData = (RecvDataInfo)recvObj;
                DataType dataType = (DataType)recvData.Data[0];
                byte[] data = new byte[recvData.Data.Length - 1];
                Array.Copy(recvData.Data, 1, data, 0, data.Length);
                //客户端收到回复的信息所作出的反应
                switch (dataType)
                {
                    //点击登录按钮后收到回复的信息
                    case DataType.LoginAck:
                        OnLogin(data);
                        break;
                    case DataType.UserListAck:
                        OnUserList(data);
                        break;
                   case DataType.MessageHistoryAck:
                        OnMessageHistory(data);
                        break;
                    case DataType.MessageAck:
                        OnUserMessage(data);
                        break;
                    case DataType.RemindAck:
                        OnRemind(data);
                        break;

                    case DataType.UserStatusChange:
                        OnUserStatusChg(data);
                        break;
                    case DataType.ChangeInfoAck:
                        OnChangInfo(data);
                        break;

                    case DataType.File:
                        OnUserFile(data);
                        break;
                    case DataType.Image:
                        OnImage(data);
                        break;
                    default:
                        break;
                }
            }
            catch
            { }
        }

        private void OnImage(byte[]data)
        {
            if (UserImage != null)
            {
                UserImage(this, data);
            }
        }

        private void OnUserFile(byte[] data)
        {
            if (UserFile != null)
            {
                UserFile(this, data);
            }
        }

        private void OnRemind(byte[]data)
        {

            if (Remind != null)
            {
                Remind(this, data);
            }


        }

        public class UserEventArgs : EventArgs
        {
            public bool Result;
            public bool OnLine;
            public string UserId;
            public string Remind;
            public string Message;
            public string[] UserList;
            public string[] MessageHistory;
            public string FileName;
            public byte[] RecvByte;
            public UserEventArgs(bool result)
            {
                this.Result = result;
            }

            public UserEventArgs(string UserId)
            {
                this.UserId = UserId;
            }

            public UserEventArgs(string Remind,int a)
            {
                this.Remind = Remind;
            }

            public UserEventArgs(string[] userList)
            {
                this.UserList = userList;
            }

            public UserEventArgs(string[] MessageHistory, int a)
            {
                this.MessageHistory = MessageHistory;
            }

            public UserEventArgs(byte[] RecvByte)
            {
                this.RecvByte = RecvByte;

            }


            public UserEventArgs(string UserId, string message)
            {
                this.UserId = UserId;
                this.Message =message;                  
            }

            public UserEventArgs(string UserId, string message, string name)
            {
                this.UserId = UserId;
                this.Message =message;                   
                this.FileName = name;
            }

            public UserEventArgs(string UserId, bool onLine)
            {
                this.UserId = UserId;
                this.OnLine = onLine;
            }
        }


        protected virtual void OnLogin(byte[] data)
        {
            if (Login != null)
            {
                Login(this, data);
            }
        }

        protected virtual void OnUserList(byte[] data)
        {
            if (UserList != null)
            {
                UserList(this, data);
            }
        }

        protected virtual void OnUserMessage(byte[] data)
        {
            if (UserMessage != null)
            {
                UserMessage(this, data);
            }
        }

        protected virtual void OnMessageHistory(byte[] data)
        {
            if (MessageHistory != null)
            {
                MessageHistory(this, data);
            }
        }


        protected virtual void OnUserStatusChg(byte[] data)
        {
            if (UserStatusChg != null)
            {
                UserStatusChg(this, data);
            }
        }

        protected virtual void OnChangInfo(byte[] data)
        {
            if (ChangInfo != null)
            {
                ChangInfo(this, data);
            }
        }
        public void Send(byte[] Test)
        {
            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP), Properties.Settings.Default.ServerPort);
            udpClient.Send(Test, Test.Length, ServerIpAndPort);
        }

        public void Send(string Test)
        {
            if (String.IsNullOrEmpty(Test))
            {
                return;
            }

            byte[] TestToByte = Encoding.Unicode.GetBytes(Test);
            //byte[] TestToByte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(Test);
            IPEndPoint ServerIpAndPort = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP),
                                                                         Properties.Settings.Default.ServerPort);
            udpClient.Send(TestToByte, TestToByte.Length, ServerIpAndPort);

        }
    }
    
}
