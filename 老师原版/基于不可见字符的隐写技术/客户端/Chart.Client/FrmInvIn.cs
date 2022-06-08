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
//using System.Windows.ApplicationModel.DataTransfer;

namespace Chart.Client
{
    public partial class FrmInvIn : Form
    {
        //从主窗体传递已经在主窗体写好的公开信息或者文件，嵌入使用
        string OpenTest;
        string FilePath;
        string FileString;
        
        
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="message"></param>
        /// <param name="filepath"></param>
        public FrmInvIn(string message,string filepath)
        {
            InitializeComponent();
          
            //初始化本窗体内的公开信息和文件路径
            this.OpenTest = message;
            this.FilePath = filepath;
            //if(this.message!=null)
            if(string.IsNullOrEmpty(this.OpenTest)==false)
            {
                this.txtOpenTest.Text = this.OpenTest;

            }
            if(string.IsNullOrEmpty(this.FilePath)==false)
            //if (this.filepath != null)
            {
                this.txtFilePath.Text = this.FilePath;
                FileString=Chart.Core.file.ReadFromFile(this.FilePath);
                this.txtFileMessage.Text = FileString;
            }
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
                this.txtFilePath.Text = ofd.FileName;
            }
        }


        /// <summary>
        /// “生成秘密信息”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakInv_Click(object sender, EventArgs e)
        {
            FrmEncode fe = new FrmEncode();
            fe.encodingresult += new FrmEncode.EncodingResult(result);
            fe.Show();
        }
        private void result(object sender, string invtest, int e)
        {
            if (e!=1)
            {
                MessageBox.Show("没有秘密信息生成");
                return;
            }
            else
            {
                this.txtInvTest.Text =invtest;
                MessageBox.Show("秘密信息生成成功！");
            }
        }


        /// <summary>
        /// “嵌入文件“按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInFile_Click_1(object sender, EventArgs e)
        {
            string InvTest;
            string FilePath;
            string results;
             
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("请选择文件路径！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtInvTest.Text))
            {
                MessageBox.Show("待隐藏信息为空！请生成！");
                return;
            }
            try
            {
                InvTest = this.txtInvTest.Text;
                FilePath = this.txtFilePath.Text;
                FileString = Chart.Core.file.ReadFromFile(FilePath);
                results = Chart.Core.Cores.InvInTest(FileString, InvTest);
                string[] result = results.Split(';');
                if (result[0] == "0")
                {
                    MessageBox.Show(result[1].ToString());
                }
                else if (result[0] == "1")
                    MessageBox.Show(result[1]);
                else
                {

                    Chart.Core.file.WriteToFile(FilePath, result[1]);
                    this.txtFileMessage.Clear();
                    this.txtSendMessage.Text = result[1];
                    MessageBox.Show("嵌入成功！");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }


        /// <summary>
        /// “嵌入公开信息”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInTest_Click_1(object sender, EventArgs e)
        {
            string InvTest=null;
            string OpenTest = null;
            string results;

            if (string.IsNullOrEmpty(this.txtOpenTest.Text))
            {
                MessageBox.Show("请输入公开信息！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtInvTest.Text))
            {
                MessageBox.Show("待隐藏信息为空！请生成！");
                return;
            }
            try
            {
                InvTest = this.txtInvTest.Text;
                OpenTest = this.txtOpenTest.Text.Trim();//如果不加“去空格”的话，那不能正确加上加密信息
                results = Chart.Core.Cores.InvInTest(OpenTest, InvTest);
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
                    this.txtOpenTest.Text = result[1];
                    MessageBox.Show("嵌入成功！");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

         
        /// <summary>
        /// "检查文件中是否已经嵌入信息"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileChek_Click(object sender, EventArgs e)
        {
            string FilePath;
            string FileString;
            string InvTest;
            //读文件内容
            FilePath = this.txtFilePath.Text;
            FileString = Chart.Core.file.ReadFromFile(FilePath);

            //提取不可见字符
            InvTest = Chart.Core.Cores.InvFromTest(FileString);
            string[] InvTestArray = InvTest.Split(';');
            //没有不可见字符
            if (InvTestArray[0] == "0")
            {
                MessageBox.Show(InvTestArray[1]);
            }
            //将不可见字符转为可见的秘密信息
            else
            {
               
                MessageBox.Show(FilePath + "文件中已经隐藏了秘密信息！");
            }
        }
        
        /// <summary>
        /// 检查嵌入好的信息中是否有秘密信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestChek_Click(object sender, EventArgs e)
        {
            string OpenTest;
            string InvTest;
            if (this.txtSendMessage.Text == null)
            {
                MessageBox.Show("嵌入的信息为空！请重新嵌入！");
                return;
            }
            //获取带有隐藏信息的文本信息。
            OpenTest = this.txtOpenTest.Text;

            //提取不可见字符
            InvTest = Chart.Core.Cores.InvFromTest(OpenTest);
            string[] InvTestArray = InvTest.Split(';');
            //没有不可见字符
            if (InvTestArray[0] == "0")
            {
                MessageBox.Show(InvTestArray[1]);
                return;
            }
            else
            {
                MessageBox.Show("该段信息存在隐藏信息！");
                return;
            }
        }

        /// <summary>
        /// ”显示文件内容“按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileShow_Click(object sender, EventArgs e)
        {
            string filepath = this.txtFilePath.Text;
            FileString = Chart.Core.file.ReadFromFile(filepath);
            this.txtFileMessage.Text = FileString;
           
        }

        /// <summary>
        /// 复制文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string textToCopy;

            textToCopy = this.txtOpenTest.Text;

           
            Clipboard.SetText(this.txtOpenTest.Text);
        }
    }
}