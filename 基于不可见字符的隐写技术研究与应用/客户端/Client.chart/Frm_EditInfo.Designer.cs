namespace Client.chart
{
    partial class Frm_EditInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_EditInfo));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.pboxHead = new System.Windows.Forms.PictureBox();
            this.txtBoxUName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNewPwdAgain = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttCancel = new System.Windows.Forms.Button();
            this.buttOK = new System.Windows.Forms.Button();
            this.imageList_head = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHead)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 329);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.pboxHead);
            this.tabPage1.Controls.Add(this.txtBoxUName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtBoxUserID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "个人信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(359, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pboxHead
            // 
            this.pboxHead.Location = new System.Drawing.Point(349, 65);
            this.pboxHead.Name = "pboxHead";
            this.pboxHead.Size = new System.Drawing.Size(90, 72);
            this.pboxHead.TabIndex = 4;
            this.pboxHead.TabStop = false;
            this.pboxHead.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxUName
            // 
            this.txtBoxUName.Location = new System.Drawing.Point(24, 150);
            this.txtBoxUName.Name = "txtBoxUName";
            this.txtBoxUName.Size = new System.Drawing.Size(193, 25);
            this.txtBoxUName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户昵称";
            // 
            // txtBoxUserID
            // 
            this.txtBoxUserID.Location = new System.Drawing.Point(24, 65);
            this.txtBoxUserID.Name = "txtBoxUserID";
            this.txtBoxUserID.ReadOnly = true;
            this.txtBoxUserID.Size = new System.Drawing.Size(193, 25);
            this.txtBoxUserID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户账号";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNewPwdAgain);
            this.tabPage2.Controls.Add(this.txtNewPwd);
            this.tabPage2.Controls.Add(this.txtOldPwd);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(495, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "安全设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNewPwdAgain
            // 
            this.txtNewPwdAgain.Location = new System.Drawing.Point(178, 162);
            this.txtNewPwdAgain.Name = "txtNewPwdAgain";
            this.txtNewPwdAgain.Size = new System.Drawing.Size(165, 25);
            this.txtNewPwdAgain.TabIndex = 6;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(178, 117);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(165, 25);
            this.txtNewPwd.TabIndex = 5;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(178, 67);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(165, 25);
            this.txtOldPwd.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "新密码确认:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "新密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "原密码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "修改密码";
            // 
            // buttCancel
            // 
            this.buttCancel.Location = new System.Drawing.Point(295, 335);
            this.buttCancel.Name = "buttCancel";
            this.buttCancel.Size = new System.Drawing.Size(82, 35);
            this.buttCancel.TabIndex = 1;
            this.buttCancel.Text = "取消";
            this.buttCancel.UseVisualStyleBackColor = true;
            this.buttCancel.Click += new System.EventHandler(this.buttCancel_Click);
            // 
            // buttOK
            // 
            this.buttOK.Location = new System.Drawing.Point(405, 335);
            this.buttOK.Name = "buttOK";
            this.buttOK.Size = new System.Drawing.Size(81, 35);
            this.buttOK.TabIndex = 2;
            this.buttOK.Text = "确认";
            this.buttOK.UseVisualStyleBackColor = true;
            this.buttOK.Click += new System.EventHandler(this.buttOK_Click);
            // 
            // imageList_head
            // 
            this.imageList_head.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_head.ImageStream")));
            this.imageList_head.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_head.Images.SetKeyName(0, "1.bmp");
            this.imageList_head.Images.SetKeyName(1, "3.bmp");
            this.imageList_head.Images.SetKeyName(2, "5.bmp");
            this.imageList_head.Images.SetKeyName(3, "7.bmp");
            this.imageList_head.Images.SetKeyName(4, "9.bmp");
            this.imageList_head.Images.SetKeyName(5, "11.bmp");
            this.imageList_head.Images.SetKeyName(6, "13.bmp");
            this.imageList_head.Images.SetKeyName(7, "15.bmp");
            this.imageList_head.Images.SetKeyName(8, "17.bmp");
            this.imageList_head.Images.SetKeyName(9, "19.bmp");
            this.imageList_head.Images.SetKeyName(10, "21.bmp");
            this.imageList_head.Images.SetKeyName(11, "23.bmp");
            this.imageList_head.Images.SetKeyName(12, "25.bmp");
            this.imageList_head.Images.SetKeyName(13, "27.bmp");
            this.imageList_head.Images.SetKeyName(14, "29.bmp");
            this.imageList_head.Images.SetKeyName(15, "31.bmp");
            this.imageList_head.Images.SetKeyName(16, "33.bmp");
            this.imageList_head.Images.SetKeyName(17, "35.bmp");
            this.imageList_head.Images.SetKeyName(18, "37.bmp");
            this.imageList_head.Images.SetKeyName(19, "39.bmp");
            this.imageList_head.Images.SetKeyName(20, "41.bmp");
            this.imageList_head.Images.SetKeyName(21, "43.bmp");
            this.imageList_head.Images.SetKeyName(22, "45.bmp");
            this.imageList_head.Images.SetKeyName(23, "47.bmp");
            this.imageList_head.Images.SetKeyName(24, "49.bmp");
            this.imageList_head.Images.SetKeyName(25, "51.bmp");
            this.imageList_head.Images.SetKeyName(26, "53.bmp");
            this.imageList_head.Images.SetKeyName(27, "55.bmp");
            this.imageList_head.Images.SetKeyName(28, "57.bmp");
            this.imageList_head.Images.SetKeyName(29, "59.bmp");
            this.imageList_head.Images.SetKeyName(30, "61.bmp");
            this.imageList_head.Images.SetKeyName(31, "63.bmp");
            this.imageList_head.Images.SetKeyName(32, "65.bmp");
            this.imageList_head.Images.SetKeyName(33, "67.bmp");
            this.imageList_head.Images.SetKeyName(34, "69.bmp");
            this.imageList_head.Images.SetKeyName(35, "71.bmp");
            this.imageList_head.Images.SetKeyName(36, "73.bmp");
            this.imageList_head.Images.SetKeyName(37, "75.bmp");
            this.imageList_head.Images.SetKeyName(38, "77.bmp");
            this.imageList_head.Images.SetKeyName(39, "79.bmp");
            this.imageList_head.Images.SetKeyName(40, "81.bmp");
            this.imageList_head.Images.SetKeyName(41, "83.bmp");
            this.imageList_head.Images.SetKeyName(42, "85.bmp");
            this.imageList_head.Images.SetKeyName(43, "87.bmp");
            this.imageList_head.Images.SetKeyName(44, "89.bmp");
            this.imageList_head.Images.SetKeyName(45, "91.bmp");
            this.imageList_head.Images.SetKeyName(46, "93.bmp");
            this.imageList_head.Images.SetKeyName(47, "95.bmp");
            this.imageList_head.Images.SetKeyName(48, "97.bmp");
            this.imageList_head.Images.SetKeyName(49, "99.bmp");
            this.imageList_head.Images.SetKeyName(50, "back.bmp");
            // 
            // Frm_EditInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 382);
            this.Controls.Add(this.buttOK);
            this.Controls.Add(this.buttCancel);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_EditInfo";
            this.Text = "个人信息设置";
            this.Load += new System.EventHandler(this.Frm_EditInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxHead)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pboxHead;
        private System.Windows.Forms.TextBox txtBoxUName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtNewPwdAgain;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttCancel;
        private System.Windows.Forms.Button buttOK;
        private System.Windows.Forms.ImageList imageList_head;
    }
}