namespace Chart.Server
{
    partial class FrmUserList
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("用户列表", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserList));
            this.lvUserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLock = new System.Windows.Forms.ToolStripMenuItem();
            this.UserImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvUserList
            // 
            this.lvUserList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvUserList.ContextMenuStrip = this.contextMenuStrip1;
            this.lvUserList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            listViewGroup1.Header = "用户列表";
            listViewGroup1.Name = "listViewGroup1";
            this.lvUserList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvUserList.LargeImageList = this.UserImageList;
            this.lvUserList.Location = new System.Drawing.Point(20, 33);
            this.lvUserList.MultiSelect = false;
            this.lvUserList.Name = "lvUserList";
            this.lvUserList.ShowItemToolTips = true;
            this.lvUserList.Size = new System.Drawing.Size(500, 381);
            this.lvUserList.TabIndex = 29;
            this.lvUserList.UseCompatibleStateImageBehavior = false;
            this.lvUserList.SelectedIndexChanged += new System.EventHandler(this.lvUserList_SelectedIndexChanged);
            this.lvUserList.DoubleClick += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddUser,
            this.menuUpdateUser,
            this.menuDeleteUser,
            this.toolStripMenuItem1,
            this.menuLock});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 130);
          //  this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menuAddUser
            // 
            this.menuAddUser.Image = ((System.Drawing.Image)(resources.GetObject("menuAddUser.Image")));
            this.menuAddUser.Name = "menuAddUser";
            this.menuAddUser.Size = new System.Drawing.Size(108, 30);
            this.menuAddUser.Text = "增加";
            this.menuAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // menuUpdateUser
            // 
            this.menuUpdateUser.Image = ((System.Drawing.Image)(resources.GetObject("menuUpdateUser.Image")));
            this.menuUpdateUser.Name = "menuUpdateUser";
            this.menuUpdateUser.Size = new System.Drawing.Size(108, 30);
            this.menuUpdateUser.Text = "修改";
            this.menuUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // menuDeleteUser
            // 
            this.menuDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("menuDeleteUser.Image")));
            this.menuDeleteUser.Name = "menuDeleteUser";
            this.menuDeleteUser.Size = new System.Drawing.Size(108, 30);
            this.menuDeleteUser.Text = "删除";
            this.menuDeleteUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // menuLock
            // 
            this.menuLock.Image = ((System.Drawing.Image)(resources.GetObject("menuLock.Image")));
            this.menuLock.Name = "menuLock";
            this.menuLock.Size = new System.Drawing.Size(108, 30);
            this.menuLock.Text = "锁定";
            //this.menuLock.Click += new System.EventHandler(this.menuLock_Click);
            // 
            // UserImageList
            // 
            this.UserImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("UserImageList.ImageStream")));
            this.UserImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.UserImageList.Images.SetKeyName(0, "20131231104315324_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(1, "20131231104315324_easyicon_net_648.png");
            this.UserImageList.Images.SetKeyName(2, "20131230113437371_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(3, "20131230113437371_easyicon_net_643.png");
            this.UserImageList.Images.SetKeyName(4, "20131230112048108_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(5, "20131230112048108_easyicon_net_642.png");
            this.UserImageList.Images.SetKeyName(6, "20131230113657426_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(7, "20131230113657426_easyicon_net_644.png");
            this.UserImageList.Images.SetKeyName(8, "20131230114024323_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(9, "20131230114024323_easyicon_net_645.png");
            this.UserImageList.Images.SetKeyName(10, "20131230114153538_easyicon_net_64.png");
            this.UserImageList.Images.SetKeyName(11, "20131230114153538_easyicon_net_646.png");
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUser.Location = new System.Drawing.Point(549, 33);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(114, 38);
            this.btnAddUser.TabIndex = 30;
            this.btnAddUser.Text = "  增加";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(549, 249);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 38);
            this.btnExit.TabIndex = 30;
            this.btnExit.Text = "  退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelUser
            // 
            this.btnDelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnDelUser.Enabled = false;
            this.btnDelUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDelUser.Image")));
            this.btnDelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelUser.Location = new System.Drawing.Point(549, 133);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(114, 38);
            this.btnDelUser.TabIndex = 30;
            this.btnDelUser.Text = "  删除";
            this.btnDelUser.UseVisualStyleBackColor = false;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnUpdateUser.Enabled = false;
            this.btnUpdateUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateUser.Image")));
            this.btnUpdateUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateUser.Location = new System.Drawing.Point(549, 83);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(114, 38);
            this.btnUpdateUser.TabIndex = 30;
            this.btnUpdateUser.Text = "  修改";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "C:\\Users\\wmr\\Desktop\\修改\\Chart.Client\\bin\\Debug\\WaveColor2.ssk";
            // 
            // FrmUserList
            // 
            this.AcceptButton = this.btnAddUser;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(707, 487);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelUser);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lvUserList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(707, 487);
            this.MinimumSize = new System.Drawing.Size(707, 487);
            this.Name = "FrmUserList";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.FrmUserList_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvUserList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAddUser;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateUser;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteUser;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuLock;
        private System.Windows.Forms.ImageList UserImageList;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnDelUser;
        private System.Windows.Forms.Button btnExit;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}