namespace Chart.Client
{
    partial class FrmInvOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvOut));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ck = new System.Windows.Forms.CheckBox();
            this.txtTest = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnFileMessage = new System.Windows.Forms.Button();
            this.bbtnOutFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFileMessage = new System.Windows.Forms.RichTextBox();
            this.btnOutTest = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOpenTest = new System.Windows.Forms.RichTextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.splitContainer1.Panel1.Controls.Add(this.txtKey);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.ck);
            this.splitContainer1.Panel1.Controls.Add(this.txtTest);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(815, 583);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 36;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(41, 48);
            this.txtKey.MaxLength = 16;
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(253, 29);
            this.txtKey.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "密钥";
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.ck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.ck.Location = new System.Drawing.Point(14, 26);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(90, 16);
            this.ck.TabIndex = 46;
            this.ck.Text = "使用AES加密";
            this.ck.UseVisualStyleBackColor = false;
            // 
            // txtTest
            // 
            this.txtTest.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTest.Location = new System.Drawing.Point(0, 124);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(343, 454);
            this.txtTest.TabIndex = 43;
            this.txtTest.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label7.Location = new System.Drawing.Point(3, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "秘密信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "秘密信息提取模块";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.splitContainer2.Panel1.Controls.Add(this.btnFileMessage);
            this.splitContainer2.Panel1.Controls.Add(this.bbtnOutFile);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtFile);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.btnSelectFile);
            this.splitContainer2.Panel1.Controls.Add(this.txtFileMessage);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.splitContainer2.Panel2.Controls.Add(this.btnOutTest);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.txtOpenTest);
            this.splitContainer2.Size = new System.Drawing.Size(454, 583);
            this.splitContainer2.SplitterDistance = 332;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnFileMessage
            // 
            this.btnFileMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnFileMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnFileMessage.Image")));
            this.btnFileMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileMessage.Location = new System.Drawing.Point(62, 74);
            this.btnFileMessage.Name = "btnFileMessage";
            this.btnFileMessage.Size = new System.Drawing.Size(55, 23);
            this.btnFileMessage.TabIndex = 39;
            this.btnFileMessage.Text = "显示";
            this.btnFileMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileMessage.UseVisualStyleBackColor = false;
            this.btnFileMessage.Click += new System.EventHandler(this.btnFileMessage_Click);
            // 
            // bbtnOutFile
            // 
            this.bbtnOutFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.bbtnOutFile.Image = ((System.Drawing.Image)(resources.GetObject("bbtnOutFile.Image")));
            this.bbtnOutFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbtnOutFile.Location = new System.Drawing.Point(166, 286);
            this.bbtnOutFile.Name = "bbtnOutFile";
            this.bbtnOutFile.Size = new System.Drawing.Size(69, 33);
            this.bbtnOutFile.TabIndex = 38;
            this.bbtnOutFile.Text = "提取";
            this.bbtnOutFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bbtnOutFile.UseVisualStyleBackColor = false;
            this.bbtnOutFile.Click += new System.EventHandler(this.bbtnOutFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "提取文件模块";
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(93, 26);
            this.txtFile.MaxLength = 10;
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(275, 30);
            this.txtFile.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label5.Location = new System.Drawing.Point(3, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 41;
            this.label5.Text = "文件内容";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFile.Location = new System.Drawing.Point(5, 26);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(85, 30);
            this.btnSelectFile.TabIndex = 17;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click_1);
            // 
            // txtFileMessage
            // 
            this.txtFileMessage.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFileMessage.Location = new System.Drawing.Point(5, 94);
            this.txtFileMessage.Name = "txtFileMessage";
            this.txtFileMessage.Size = new System.Drawing.Size(435, 179);
            this.txtFileMessage.TabIndex = 39;
            this.txtFileMessage.Text = "";
            // 
            // btnOutTest
            // 
            this.btnOutTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnOutTest.Image = ((System.Drawing.Image)(resources.GetObject("btnOutTest.Image")));
            this.btnOutTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutTest.Location = new System.Drawing.Point(166, 197);
            this.btnOutTest.Name = "btnOutTest";
            this.btnOutTest.Size = new System.Drawing.Size(69, 33);
            this.btnOutTest.TabIndex = 40;
            this.btnOutTest.Text = "提取";
            this.btnOutTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOutTest.UseVisualStyleBackColor = false;
            this.btnOutTest.Click += new System.EventHandler(this.btnOutTest_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label6.Location = new System.Drawing.Point(0, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "公开信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "提取语句模块";
            // 
            // txtOpenTest
            // 
            this.txtOpenTest.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOpenTest.Location = new System.Drawing.Point(5, 54);
            this.txtOpenTest.Name = "txtOpenTest";
            this.txtOpenTest.Size = new System.Drawing.Size(435, 137);
            this.txtOpenTest.TabIndex = 0;
            this.txtOpenTest.Text = "";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "C:\\Users\\wmr\\Desktop\\修改\\Chart.Client\\bin\\Debug\\WaveColor2.ssk";
            // 
            // FrmInvOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 583);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmInvOut";
            this.Text = "提取不可见字符";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.RichTextBox txtOpenTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtFileMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bbtnOutFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOutTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ck;
        private System.Windows.Forms.Button btnFileMessage;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}