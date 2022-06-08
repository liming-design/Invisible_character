namespace Client.chart
{
    partial class Frm_chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_chat));
            this.pBoxHead = new System.Windows.Forms.PictureBox();
            this.pBoxMin = new System.Windows.Forms.PictureBox();
            this.pBoxClose = new System.Windows.Forms.PictureBox();
            this.lab_name = new System.Windows.Forms.Label();
            this.rtxtChat = new System.Windows.Forms.RichTextBox();
            this.buttClose = new System.Windows.Forms.Button();
            this.buttSend = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.C0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rhTxBoxMess = new System.Windows.Forms.RichTextBox();
            this.rhTxtSecret = new System.Windows.Forms.RichTextBox();
            this.ck = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList_head = new System.Windows.Forms.ImageList(this.components);
            this.buttFire = new System.Windows.Forms.Button();
            this.buttImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxHead
            // 
            this.pBoxHead.BackColor = System.Drawing.Color.Transparent;
            this.pBoxHead.Location = new System.Drawing.Point(12, 9);
            this.pBoxHead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxHead.Name = "pBoxHead";
            this.pBoxHead.Size = new System.Drawing.Size(84, 62);
            this.pBoxHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxHead.TabIndex = 0;
            this.pBoxHead.TabStop = false;
            // 
            // pBoxMin
            // 
            this.pBoxMin.BackColor = System.Drawing.Color.Transparent;
            this.pBoxMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxMin.Image = ((System.Drawing.Image)(resources.GetObject("pBoxMin.Image")));
            this.pBoxMin.Location = new System.Drawing.Point(1031, 5);
            this.pBoxMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxMin.Name = "pBoxMin";
            this.pBoxMin.Size = new System.Drawing.Size(28, 25);
            this.pBoxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxMin.TabIndex = 1;
            this.pBoxMin.TabStop = false;
            this.pBoxMin.Click += new System.EventHandler(this.pBoxMin_Click);
            this.pBoxMin.MouseEnter += new System.EventHandler(this.pBoxMin_MouseEnter);
            this.pBoxMin.MouseLeave += new System.EventHandler(this.pBoxMin_MouseLeave);
            // 
            // pBoxClose
            // 
            this.pBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.pBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pBoxClose.Image")));
            this.pBoxClose.Location = new System.Drawing.Point(1079, 6);
            this.pBoxClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBoxClose.Name = "pBoxClose";
            this.pBoxClose.Size = new System.Drawing.Size(28, 25);
            this.pBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxClose.TabIndex = 2;
            this.pBoxClose.TabStop = false;
            this.pBoxClose.Click += new System.EventHandler(this.pBoxClose_Click);
            this.pBoxClose.MouseEnter += new System.EventHandler(this.pBoxClose_MouseEnter);
            this.pBoxClose.MouseLeave += new System.EventHandler(this.pBoxClose_MouseLeave);
            // 
            // lab_name
            // 
            this.lab_name.BackColor = System.Drawing.Color.Transparent;
            this.lab_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_name.Location = new System.Drawing.Point(101, 21);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(245, 28);
            this.lab_name.TabIndex = 3;
            this.lab_name.Text = "label1";
            this.lab_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lab_name.Click += new System.EventHandler(this.lab_name_Click);
            // 
            // rtxtChat
            // 
            this.rtxtChat.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtChat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtChat.Location = new System.Drawing.Point(13, 628);
            this.rtxtChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtChat.Name = "rtxtChat";
            this.rtxtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtChat.Size = new System.Drawing.Size(787, 70);
            this.rtxtChat.TabIndex = 5;
            this.rtxtChat.Text = "";
            this.rtxtChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtxtChat_KeyDown);
            // 
            // buttClose
            // 
            this.buttClose.Location = new System.Drawing.Point(571, 711);
            this.buttClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttClose.Name = "buttClose";
            this.buttClose.Size = new System.Drawing.Size(103, 38);
            this.buttClose.TabIndex = 6;
            this.buttClose.Text = "关闭";
            this.buttClose.UseVisualStyleBackColor = true;
            this.buttClose.Click += new System.EventHandler(this.buttClose_Click);
            // 
            // buttSend
            // 
            this.buttSend.Location = new System.Drawing.Point(679, 714);
            this.buttSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttSend.Name = "buttSend";
            this.buttSend.Size = new System.Drawing.Size(111, 35);
            this.buttSend.TabIndex = 7;
            this.buttSend.Text = "发送";
            this.buttSend.UseVisualStyleBackColor = true;
            this.buttSend.Click += new System.EventHandler(this.buttSend_Click);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.C0});
            this.lvLog.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvLog.FullRowSelect = true;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(13, 78);
            this.lvLog.Margin = new System.Windows.Forms.Padding(4);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(786, 521);
            this.lvLog.TabIndex = 8;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            this.lvLog.SelectedIndexChanged += new System.EventHandler(this.lvLog_SelectedIndexChanged);
            this.lvLog.Click += new System.EventHandler(this.lvLog_Click);
            this.lvLog.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.lvLog_ControlAdded);
            this.lvLog.DoubleClick += new System.EventHandler(this.lvLog_DoubleClick);
            // 
            // C0
            // 
            this.C0.Text = "";
            this.C0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C0.Width = 1000;
            // 
            // rhTxBoxMess
            // 
            this.rhTxBoxMess.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rhTxBoxMess.Location = new System.Drawing.Point(812, 99);
            this.rhTxBoxMess.Margin = new System.Windows.Forms.Padding(4);
            this.rhTxBoxMess.Name = "rhTxBoxMess";
            this.rhTxBoxMess.Size = new System.Drawing.Size(287, 126);
            this.rhTxBoxMess.TabIndex = 9;
            this.rhTxBoxMess.Text = "";
            this.rhTxBoxMess.TextChanged += new System.EventHandler(this.rhTxBoxMess_TextChanged);
            // 
            // rhTxtSecret
            // 
            this.rhTxtSecret.BackColor = System.Drawing.SystemColors.Window;
            this.rhTxtSecret.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rhTxtSecret.ForeColor = System.Drawing.Color.Crimson;
            this.rhTxtSecret.Location = new System.Drawing.Point(812, 470);
            this.rhTxtSecret.Margin = new System.Windows.Forms.Padding(4);
            this.rhTxtSecret.Name = "rhTxtSecret";
            this.rhTxtSecret.Size = new System.Drawing.Size(287, 118);
            this.rhTxtSecret.TabIndex = 10;
            this.rhTxtSecret.Text = "";
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.BackColor = System.Drawing.Color.Transparent;
            this.ck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ck.Location = new System.Drawing.Point(813, 288);
            this.ck.Margin = new System.Windows.Forms.Padding(4);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(141, 24);
            this.ck.TabIndex = 11;
            this.ck.Text = "使用AES加密";
            this.ck.UseVisualStyleBackColor = false;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(813, 331);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(265, 34);
            this.txtKey.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(809, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "原文";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(809, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "秘密信息（明文）";
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
            // buttFire
            // 
            this.buttFire.Location = new System.Drawing.Point(13, 600);
            this.buttFire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttFire.Name = "buttFire";
            this.buttFire.Size = new System.Drawing.Size(96, 28);
            this.buttFire.TabIndex = 15;
            this.buttFire.Text = "选择文件";
            this.buttFire.UseVisualStyleBackColor = true;
            this.buttFire.Click += new System.EventHandler(this.buttFire_Click);
            // 
            // buttImage
            // 
            this.buttImage.Location = new System.Drawing.Point(137, 600);
            this.buttImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttImage.Name = "buttImage";
            this.buttImage.Size = new System.Drawing.Size(93, 26);
            this.buttImage.TabIndex = 16;
            this.buttImage.Text = "选择图片";
            this.buttImage.UseVisualStyleBackColor = true;
            this.buttImage.Click += new System.EventHandler(this.buttImage_Click);
            // 
            // Frm_chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1116, 762);
            this.Controls.Add(this.buttImage);
            this.Controls.Add(this.buttFire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.ck);
            this.Controls.Add(this.rhTxtSecret);
            this.Controls.Add(this.rhTxBoxMess);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.buttSend);
            this.Controls.Add(this.buttClose);
            this.Controls.Add(this.rtxtChat);
            this.Controls.Add(this.lab_name);
            this.Controls.Add(this.pBoxClose);
            this.Controls.Add(this.pBoxMin);
            this.Controls.Add(this.pBoxHead);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_chat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "聊天窗体";
            this.Load += new System.EventHandler(this.Frm_chat_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_chat_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxHead;
        private System.Windows.Forms.PictureBox pBoxMin;
        private System.Windows.Forms.PictureBox pBoxClose;
        private System.Windows.Forms.Button buttClose;
        private System.Windows.Forms.Button buttSend;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader C0;
        public System.Windows.Forms.RichTextBox rtxtChat;
        private System.Windows.Forms.RichTextBox rhTxBoxMess;
        private System.Windows.Forms.RichTextBox rhTxtSecret;
        private System.Windows.Forms.CheckBox ck;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList_head;
        private System.Windows.Forms.Button buttFire;
        private System.Windows.Forms.Button buttImage;
        public System.Windows.Forms.Label lab_name;
    }
}