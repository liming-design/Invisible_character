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
    public partial class FrmEncode : Form
    {
        //把秘密信息返回
        public string message;
        //记录是否对秘密信息设计
        public int mmm=-1;


        public delegate void EncodingResult(object sender, string message,int e);
        public event EncodingResult encodingresult;
        protected virtual void Result(string message,int e)
        {
            if (encodingresult != null)
            {
                encodingresult
                    (this, message,e);
            }
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        public FrmEncode()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// “隐写”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInv_Click(object sender, EventArgs e)
        {
            string Test;
            string InvTest=null;
            //判断待隐藏的明文信息是否存在
            if (string.IsNullOrEmpty(txtTest.Text))
            //if (this.txtTest.Text == null)
            {
                MessageBox.Show("请在明文框输入明文");
                return;
            }

            Test = this.txtTest.Text;//记录下待隐藏信息
            try
            {
                //判断是否进行aes加密
                if (ck.Checked == false)
                {
                    DialogResult dr = MessageBox.Show("确定不对明文进行AES加密？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        InvTest = Chart.Core.Cores.TestToInv(false, null, Test);
                    }
                    else if (string.IsNullOrEmpty(this.txtKey.Text) == true && ck.Checked == false)
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
                {
                    if (string.IsNullOrEmpty(this.txtKey.Text) == true)
                    {
                        MessageBox.Show("请输入密钥！");
                        return;
                    }
                    else
                    {
                        InvTest = Chart.Core.Cores.TestToInv(true, txtKey.Text, Test);
                    }
                }

                string[] InvTestArray = InvTest.Split(';');
                this.txtInvTest.Text = InvTestArray[1];
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

                               
        /// <summary>
        /// "恢复按钮"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void btnReInv_Click_1(object sender, EventArgs e)
        {
            string InvTest;
            string Test=null;
            //判断密文框是否有数据
            //if(this.txtInvTest.Text==null)
            if (string.IsNullOrEmpty(txtInvTest.Text))
            {
                MessageBox.Show("请在密文框输入不可见字符！");
                return;
            }
            InvTest = this.txtInvTest.Text;
            try
            {
                if (ck.Checked == false)
                {
                    DialogResult dr = MessageBox.Show("是否曾对明文进行AES加密？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(this.txtKey.Text) == true && ck.Checked == false)
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
                    {
                        Test = Chart.Core.Cores.InvToTest(false, null, InvTest);
                    }
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
                        Test = Chart.Core.Cores.InvToTest(true, txtKey.Text, InvTest);
                    }
                }


                //将不可见字符恢复成可见的秘密信息

                string[] TestArray = Test.Split(';');

                this.txtTest.Text = TestArray[1];
            }
            catch (Exception m)
            {
                MessageBox.Show(m.ToString());
            }
        }

        /// <summary>
        /// “确定”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtInvTest.Text))
            {
                MessageBox.Show("秘文为空！");
                return;
            }

            //标识本次隐写结果,并委托事件跨窗体传递信息
            mmm = 1;
            message = this.txtInvTest.Text;
            this.Close();
            Result(message,mmm);

            
           

        }

        /// <summary>
        /// “取消”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReInv_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

        private void FrmEncode_Load(object sender, EventArgs e)
        {

        }
    }
}