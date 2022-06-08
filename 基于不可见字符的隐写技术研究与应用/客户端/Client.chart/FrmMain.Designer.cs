namespace Client.chart
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lv_friend = new System.Windows.Forms.ListView();
            this.imageList_head = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_min = new System.Windows.Forms.PictureBox();
            this.pictureBox_close = new System.Windows.Forms.PictureBox();
            this.LabUserName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.picture_user_head = new System.Windows.Forms.PictureBox();
            this.tim_remind = new System.Windows.Forms.Timer(this.components);
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            this.buttSetting = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_user_head)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_friend
            // 
            this.lv_friend.BackColor = System.Drawing.SystemColors.Window;
            this.lv_friend.HideSelection = false;
            this.lv_friend.LargeImageList = this.imageList_head;
            this.lv_friend.Location = new System.Drawing.Point(0, 149);
            this.lv_friend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lv_friend.MultiSelect = false;
            this.lv_friend.Name = "lv_friend";
            this.lv_friend.Size = new System.Drawing.Size(375, 630);
            this.lv_friend.TabIndex = 0;
            this.lv_friend.UseCompatibleStateImageBehavior = false;
            this.lv_friend.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_friend_MouseDoubleClick);
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
            // pictureBox_min
            // 
            this.pictureBox_min.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_min.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_min.Image")));
            this.pictureBox_min.Location = new System.Drawing.Point(305, 2);
            this.pictureBox_min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_min.Name = "pictureBox_min";
            this.pictureBox_min.Size = new System.Drawing.Size(28, 25);
            this.pictureBox_min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_min.TabIndex = 1;
            this.pictureBox_min.TabStop = false;
            this.pictureBox_min.Click += new System.EventHandler(this.pictureBox_min_Click);
            this.pictureBox_min.MouseEnter += new System.EventHandler(this.pictureBox_min_MouseEnter);
            this.pictureBox_min.MouseLeave += new System.EventHandler(this.pictureBox_min_MouseLeave);
            // 
            // pictureBox_close
            // 
            this.pictureBox_close.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_close.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_close.Image")));
            this.pictureBox_close.Location = new System.Drawing.Point(348, 2);
            this.pictureBox_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_close.Name = "pictureBox_close";
            this.pictureBox_close.Size = new System.Drawing.Size(28, 25);
            this.pictureBox_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_close.TabIndex = 2;
            this.pictureBox_close.TabStop = false;
            this.pictureBox_close.Click += new System.EventHandler(this.pictureBox_close_Click);
            this.pictureBox_close.MouseEnter += new System.EventHandler(this.pictureBox_close_MouseEnter);
            this.pictureBox_close.MouseLeave += new System.EventHandler(this.pictureBox_close_MouseLeave);
            // 
            // LabUserName
            // 
            this.LabUserName.AutoSize = true;
            this.LabUserName.BackColor = System.Drawing.Color.Transparent;
            this.LabUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabUserName.ForeColor = System.Drawing.Color.Red;
            this.LabUserName.Location = new System.Drawing.Point(129, 52);
            this.LabUserName.Name = "LabUserName";
            this.LabUserName.Size = new System.Drawing.Size(93, 20);
            this.LabUserName.TabIndex = 4;
            this.LabUserName.Text = "用户昵称";
            this.LabUserName.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SeaShell;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.buttSetting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 781);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(376, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // picture_user_head
            // 
            this.picture_user_head.BackColor = System.Drawing.Color.Transparent;
            this.picture_user_head.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picture_user_head.Location = new System.Drawing.Point(12, 32);
            this.picture_user_head.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picture_user_head.Name = "picture_user_head";
            this.picture_user_head.Size = new System.Drawing.Size(100, 98);
            this.picture_user_head.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_user_head.TabIndex = 3;
            this.picture_user_head.TabStop = false;
            this.picture_user_head.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tim_remind
            // 
            this.tim_remind.Enabled = true;
            this.tim_remind.Interval = 500;
            this.tim_remind.Tick += new System.EventHandler(this.tim_remind_Tick);
            // 
            // timerHide
            // 
            this.timerHide.Enabled = true;
            this.timerHide.Interval = 700;
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // buttSetting
            // 
            this.buttSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttSetting.Image = ((System.Drawing.Image)(resources.GetObject("buttSetting.Image")));
            this.buttSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttSetting.Name = "buttSetting";
            this.buttSetting.Size = new System.Drawing.Size(29, 25);
            this.buttSetting.Text = "toolStripButton4";
            this.buttSetting.Click += new System.EventHandler(this.buttSetting_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Bisque;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(376, 809);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LabUserName);
            this.Controls.Add(this.picture_user_head);
            this.Controls.Add(this.pictureBox_close);
            this.Controls.Add(this.pictureBox_min);
            this.Controls.Add(this.lv_friend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1100, 3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMainMouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_close)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_user_head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_friend;
        private System.Windows.Forms.ImageList imageList_head;
        private System.Windows.Forms.PictureBox pictureBox_min;
        private System.Windows.Forms.PictureBox pictureBox_close;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox picture_user_head;
        private System.Windows.Forms.Timer tim_remind;
        private System.Windows.Forms.Timer timerHide;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.Label LabUserName;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton buttSetting;
    }
}