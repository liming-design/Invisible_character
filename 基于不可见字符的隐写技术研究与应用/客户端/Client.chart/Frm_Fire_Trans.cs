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
    public partial class Frm_Fire_Trans : Form
    {
        public Frm_Fire_Trans(string RecvPath)
        {
            InitializeComponent();
            this.AfterFirePath.Text = RecvPath;
        }

        private void ButtSelectBefore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BeforeFirePath.Text = ofd.FileName;
                string fileString;
                string FilePath = ofd.FileName;
                fileString = Client.core.file.ReadFromFile(FilePath);
                this.rtxtBoxBefore.Text = fileString;
            }
        }

        private void ButtSelectAfter_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.AfterFirePath.Text = ofd.FileName;
                string fileString;
                string FilePath = ofd.FileName;
                fileString = Client.core.file.ReadFromFile(FilePath);
                this.rtxtBoxAfter.Text = fileString;
            }
        }

        private void ButtExtract_Click(object sender, EventArgs e)
        {
            string FilePath;
            string InvTest = null;
            string FileString = null;
            string Test = null;
            if (string.IsNullOrEmpty(AfterFirePath.Text))
            {
                MessageBox.Show("请选择带有隐藏信息的文件！");
                return;
            }
            try
            {
                //打开文件
                FilePath = this.AfterFirePath.Text;
                FileString = Client.core.file.ReadFromFile(FilePath);

                //提取不可见字符
                InvTest = Client.core.Cores.InvFromTest(FileString);
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

                    string[] TestArray = Test.Split(';');
                    this.rtxtBoxSecret.Text = TestArray[1];
                    this.BeforeFirePath.Text = AfterFirePath.Text;
                    MessageBox.Show("提取成功！");                   
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

        public string CheckAES()
        {
            string Test;
            string InvTest = "";
            Test = this.rtxtBoxSecret.Text;
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


        private void ButtInsert_Click(object sender, EventArgs e)
        {
            string InvTest;
            string FilePath;
            string results;
            string FileString;
            if (string.IsNullOrEmpty(BeforeFirePath.Text))
            {
                MessageBox.Show("请选择文件路径！");
                return;
            }
            if (string.IsNullOrEmpty(this.rtxtBoxSecret.Text))
            {
                MessageBox.Show("待隐藏信息为空！请生成！");
                return;
            }

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

            try
            {
                FilePath = this.BeforeFirePath.Text;
                FileString = Client.core.file.ReadFromFile(FilePath);
                results = Client.core.Cores.InvInTest(FileString, InvTest);
                string[] result = results.Split(';');
                if (result[0] == "0")
                {
                    MessageBox.Show(result[1].ToString());
                }
                else if (result[0] == "1")
                    MessageBox.Show(result[1]);
                else
                {
                    Client.core.file.WriteToFile(FilePath, result[1]);
                    //this.txtFileMessage.Clear();
                    this.rtxtBoxAfter.Text = result[1];
                    AfterFirePath.Text = BeforeFirePath.Text;
                    MessageBox.Show("嵌入成功！");
                    //BeforeFirePath.Clear();
                    
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

        private void Frm_Fire_Trans_Load(object sender, EventArgs e)
        {

        }

        private void AfterFirePath_TextChanged(object sender, EventArgs e)
        {
            string fileString;
            string FilePath = this.AfterFirePath.Text;
            if (FilePath != null)
            {
                fileString = Client.core.file.ReadFromFile(FilePath);
                this.rtxtBoxAfter.Text = fileString;
            }
        }

        private void BeforeFirePath_TextChanged(object sender, EventArgs e)
        {
            string fileString;
            string FilePath = this.BeforeFirePath.Text;
            if (FilePath != null)
            {
                fileString = Client.core.file.ReadFromFile(FilePath);
                this.rtxtBoxBefore.Text = fileString;
            }

        }

        private void rtxtBoxBefore_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Frm_Fire_Trans_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.frm_Fire_Trans = null;
        }
    }
}
