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
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ckMessage.Checked == true)
                FrmMain.VoiceMessage = 1;
            else
                FrmMain.VoiceMessage = 0;
            if (ckOnline.Checked == true)
                FrmMain.VoiceOnline = 1;
            else
                FrmMain.VoiceOnline = 0;
            this.Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            if (FrmMain.VoiceOnline == 1)
                ckOnline.Checked = true;
            else
                ckOnline.Checked = false;
            if (FrmMain.VoiceMessage == 1)
                ckMessage.Checked = true;
            else
                ckMessage.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
