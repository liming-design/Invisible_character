namespace Client.chart
{
    partial class Frm_Head
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Head));
            this.lvHead = new System.Windows.Forms.ListView();
            this.imageList_head = new System.Windows.Forms.ImageList(this.components);
            this.bttCancel = new System.Windows.Forms.Button();
            this.buttOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvHead
            // 
            this.lvHead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHead.BackColor = System.Drawing.Color.White;
            this.lvHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvHead.HideSelection = false;
            this.lvHead.LargeImageList = this.imageList_head;
            this.lvHead.Location = new System.Drawing.Point(0, 0);
            this.lvHead.Name = "lvHead";
            this.lvHead.Size = new System.Drawing.Size(450, 308);
            this.lvHead.SmallImageList = this.imageList_head;
            this.lvHead.StateImageList = this.imageList_head;
            this.lvHead.TabIndex = 0;
            this.lvHead.UseCompatibleStateImageBehavior = false;
            this.lvHead.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvHead_MouseDoubleClick);
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
            // bttCancel
            // 
            this.bttCancel.Location = new System.Drawing.Point(245, 332);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(75, 38);
            this.bttCancel.TabIndex = 1;
            this.bttCancel.Text = "取消";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // buttOK
            // 
            this.buttOK.Location = new System.Drawing.Point(365, 332);
            this.buttOK.Name = "buttOK";
            this.buttOK.Size = new System.Drawing.Size(75, 38);
            this.buttOK.TabIndex = 2;
            this.buttOK.Text = "确认";
            this.buttOK.UseVisualStyleBackColor = true;
            this.buttOK.Click += new System.EventHandler(this.buttOK_Click);
            // 
            // Frm_Head
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 382);
            this.Controls.Add(this.buttOK);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.lvHead);
            this.Name = "Frm_Head";
            this.Text = "Frm_Head";
            this.Load += new System.EventHandler(this.Frm_Head_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvHead;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Button buttOK;
        private System.Windows.Forms.ImageList imageList_head;
    }
}