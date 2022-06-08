using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.core;

namespace Client.chart
{
    public partial class Encode_Decode : Form
    {
        public Encode_Decode(string Message)
        {
            InitializeComponent();
            txtSendMessage.Text = Message;

        }
        //判断是否进行aes加密,并得到InvTest不可见字符串
        public   string CheckAES()
        {
            string Test;
            string InvTest="";
            Test = this.txtTest.Text;
            if (ck.Checked == false)
            {                
                DialogResult dr = MessageBox.Show("确定不对明文进行AES加密？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)                
                    InvTest = Client.core.Cores.TestToInv(false, null, Test);                                  
                else if (string.IsNullOrEmpty(this.txtKey.Text) == true && ck.Checked == false)
                {
                    MessageBox.Show("请选中“使用AES加密”复选框，并输入密钥！");
                    return "";
                }
                else if (string.IsNullOrEmpty(this.txtKey.Text) == false && ck.Checked == false)
                {
                    MessageBox.Show("请选中“使用AES加密”复选框！");
                    return "";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtKey.Text) == true)
                {
                    MessageBox.Show("请输入密钥！");
                    return "";
                }
                else               
                    InvTest = Client.core.Cores.TestToInv(true, txtKey.Text, Test);                    
                
            }
            return InvTest;
        }


        //向上转换按钮实现(嵌入)
        private void transformbutt_Click(object sender, EventArgs e)
        {           
            string InvTest = null;
            string OpenTest = null;
            string results;
            if (string.IsNullOrEmpty(txtTest.Text))
            {
                MessageBox.Show("请在明文框输入明文");
                return;
            }
            if (string.IsNullOrEmpty(this.txtOpenTest.Text))
            {
                MessageBox.Show("请输入公开信息！");
                return;
            }
           
            //生成不可见字符串的尝试
            try
            {
                //判断是否进行aes加密,并得到InvTest不可见字符串
                //如果直接写在这里的话代码太长了，所以建了一个函数 CheckAES ，调用
                InvTest = CheckAES();
                if (InvTest == "")
                    return;
                string[] InvTestArray = InvTest.Split(';');
                InvTest = InvTestArray[1];             
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
                return;
            }

            //嵌入信息的尝试
            try
            {               
                OpenTest = this.txtOpenTest.Text.Trim();//如果不加“去空格”的话，那不能正确加上加密信息
                results = Client.core.Cores.InvInTest(OpenTest, InvTest);
                string[] result = results.Split(';');
                if (result[0] == "0")
                {
                    MessageBox.Show(result[1].ToString());
                }
                else if (result[0] == "1")
                    MessageBox.Show(result[1]);
                else
                {
                    this.txtSendMessage.Text = result[1];
                    //this.txtOpenTest.Text = result[1];
                    MessageBox.Show("嵌入成功！");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

        //向下转换按钮实现
        private void buttDown_Click(object sender, EventArgs e)
        {
            string OpenTest;
            string InvTest;
            string Test = null;
            string OpenTest1;
            string OpenTest2;
            if (this.txtSendMessage.Text == null)
            {
                MessageBox.Show("请输入想要提取的公开信息！");
                return;
            }
            //获取带有隐藏信息的文本信息
            OpenTest = this.txtSendMessage.Text;

            try
            {
                //提取不可见字符
                InvTest = Client.core.Cores.InvFromTest(OpenTest);
                string[] InvTestArray = InvTest.Split(';');
                //没有不可见字符
                if (InvTestArray[0] == "0")
                {
                    MessageBox.Show(InvTestArray[1]);
                    return;
                }
                //将不可见字符转为可见的秘密信息
                else
                {
                    if (ck.Checked == false)
                    {
                        DialogResult dr = MessageBox.Show("是否曾对明文进行AES加密？", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            if (string.IsNullOrEmpty(this.txtKey.Text) == true)
                            {
                                MessageBox.Show("请选中“使用AES加密”复选框，并输入密钥！");
                                return;
                            }
                            else if (string.IsNullOrEmpty(this.txtKey.Text) == false && ck.Checked == false)
                            {
                                MessageBox.Show("请选中“使用AES加密”复选框！");
                                return;
                            }
                        }
                        else
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
                    this.txtTest.Text = TestArray[1];
                    
                    //去掉不可见的部分，将可见的显示在（左下）屏幕上
                    string[]OpenTestArray = OpenTest.Split('.');
                    OpenTest1 = OpenTestArray[0];
                    int t = OpenTest.IndexOf('.');
                    string temp = OpenTest.Substring(t);
                    t = temp.IndexOf(' ');
                    OpenTest2 = temp.Substring(t+1);
                    this.txtOpenTest.Text = OpenTest1 + '.' + OpenTest2;
                    MessageBox.Show("提取成功！");

                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }

        }

        //最小化按钮
        private void pBoxmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //关闭按钮
        private void pBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();           
            this.Dispose();//释放资源
            FrmMain.EnDeCode = null;
        }

        //拖动按钮
        private void Encode_Decode_MouseDown(object sender, MouseEventArgs e)
        {
            //用来释放被当前线程中某个窗口捕获的光标
            PublicClass.ReleaseCapture();
            //向Windows发送拖动窗体的消息
            PublicClass.SendMessage(this.Handle, PublicClass.WM_SYSCOMMAND, PublicClass.SC_MOVE + PublicClass.HTCAPTION, 0);

        }

        //清屏按钮实现（3个）
        private void labTestClear_Click(object sender, EventArgs e)
        {
            txtTest.Clear();           
        }

        private void labTxtOpenClear_Click(object sender, EventArgs e)
        {
            txtOpenTest.Clear();
        }

        private void labsendMessClear_Click(object sender, EventArgs e)
        {
            txtSendMessage.Clear();
        }
        //复制按钮
        private void label4_Click(object sender, EventArgs e)
        {          
            Clipboard.SetText(this.txtSendMessage.Text);
        }
        //一键导入按钮实现
        private void button1_Click(object sender, EventArgs e)
        {      
            if(FrmMain.frmChat!=null)
                FrmMain.frmChat.rtxtChat.Text = txtSendMessage.Text;
            else
            {
                MessageBox.Show("请先打开一个聊天窗体");
            }
        }

        private void pBoxClose_MouseEnter(object sender, EventArgs e)
        {
            pBoxClose.BackColor = Color.Red;
        }

        private void pBoxClose_MouseLeave(object sender, EventArgs e)
        {
            pBoxClose.BackColor = Color.Transparent;
        }

        private void pBoxmin_MouseEnter(object sender, EventArgs e)
        {
            pBoxmin.BackColor = Color.Aqua;
        }

        private void pBoxmin_MouseLeave(object sender, EventArgs e)
        {
            pBoxmin.BackColor = Color.Transparent;
        }
    }
}
