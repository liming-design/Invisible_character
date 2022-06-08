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


using System.IO;

namespace Chart.Client
{
    public partial class FrmInvOut : Form
    {
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="message"></param>
        /// <param name="filepath"></param>
        public FrmInvOut(string recvmessage)
        {
            InitializeComponent();
            
            string Filepath;
            string FileName;
            string FilePath;
            string fileString;
            if (recvmessage.Substring(0, 4) == "接收文件")
            {

                FileName = recvmessage.Substring(4, recvmessage.Length - 4);
                FilePath = System.Windows.Forms.Application.StartupPath;
                Filepath = Path.Combine(FilePath, FileName);
                this.txtFile.Text = Filepath;

                //显示文件内容
                fileString = Chart.Core.file.ReadFromFile(Filepath);
                this.txtFileMessage.Text = fileString;
            }
            if (recvmessage.Substring(0, 4) == "接收信息")
            {
                this.txtOpenTest.Text = recvmessage.Substring(4, recvmessage.Length - 4);
            }
        }

        public FrmInvOut()
        {
            InitializeComponent();
        }

       /// <summary>
       /// 选择文件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnSelectFile_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFile.Text = ofd.FileName;
            }
        }
       
        /// <summary>
        /// ”显示文件内容“按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileMessage_Click(object sender, EventArgs e)
        {
            string FilePath;
            string fileString;
            if (string.IsNullOrEmpty(this.txtFile.Text))
            {
                MessageBox.Show("请选择文件！");
                return;
            }
            FilePath = this.txtFile.Text;
            fileString = Chart.Core.file.ReadFromFile(FilePath);
            this.txtFileMessage.Text = fileString;
        }

       
         /// <summary>
        /// 提取文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbtnOutFile_Click(object sender, EventArgs e)
        {
            string FilePath;
            string InvTest = null;
            string FileString = null;
            string Test=null;
            if (string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("请选择带有隐藏信息的文件！");
                return;
            }

            try
            {
                //打开文件
                FilePath = this.txtFile.Text;
                FileString = Chart.Core.file.ReadFromFile(FilePath);

                //提取不可见字符
                InvTest = Chart.Core.Cores.InvFromTest(FileString);
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
                            Test = Chart.Core.Cores.InvToTest(false, null, InvTestArray[1]);
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
                            Test = Chart.Core.Cores.InvToTest(true, txtKey.Text, InvTestArray[1]);
                        }
                    }

                    string[] TestArray = Test.Split(';');
                    this.txtTest.Text = TestArray[1];
                    MessageBox.Show("提取成功！");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }


        
        }

        /// <summary>
        /// 提取公开信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutTest_Click(object sender, EventArgs e)
        {
            string OpenTest;
            string InvTest;
            string Test=null;
            if (this.txtOpenTest.Text == null)
            {
                MessageBox.Show("请输入想要提取的公开信息！");
                return;
            }
            //获取带有隐藏信息的文本信息
            OpenTest = this.txtOpenTest.Text;

            try
            {
                //提取不可见字符
                InvTest = Chart.Core.Cores.InvFromTest(OpenTest);
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
                            Test = Chart.Core.Cores.InvToTest(false, null, InvTestArray[1]);
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
                            Test = Chart.Core.Cores.InvToTest(true, txtKey.Text, InvTestArray[1]);
                        }
                    }

                    string[] TestArray = Test.Split(';');
                    this.txtTest.Text = TestArray[1];
                    MessageBox.Show("提取成功！");

                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }   
    }
}