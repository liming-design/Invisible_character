namespace Chart.Client
{
    partial class FrmEncode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEncode));
            this.btnInv = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.ck = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtInvTest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnReInv = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.SuspendLayout();
            // 
            // btnInv
            // 
            this.btnInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnInv.Image = ((System.Drawing.Image)(resources.GetObject("btnInv.Image")));
            this.btnInv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInv.Location = new System.Drawing.Point(83, 229);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(68, 30);
            this.btnInv.TabIndex = 18;
            this.btnInv.Text = "隐写";
            this.btnInv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInv.UseVisualStyleBackColor = false;
            this.btnInv.Click += new System.EventHandler(this.btnInv_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnCancle.Image = ((System.Drawing.Image)(resources.GetObject("btnCancle.Image")));
            this.btnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancle.Location = new System.Drawing.Point(356, 400);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(64, 30);
            this.btnCancle.TabIndex = 20;
            this.btnCancle.Text = "取消";
            this.btnCancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnReInv_Click);
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.ck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.ck.Location = new System.Drawing.Point(12, 3);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(90, 16);
            this.ck.TabIndex = 26;
            this.ck.Text = "使用AES加密";
            this.ck.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "密钥";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(39, 22);
            this.txtKey.MaxLength = 16;
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(289, 29);
            this.txtKey.TabIndex = 28;
            // 
            // txtInvTest
            // 
            this.txtInvTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvTest.Location = new System.Drawing.Point(12, 276);
            this.txtInvTest.MaxLength = 65535;
            this.txtInvTest.Multiline = true;
            this.txtInvTest.Name = "txtInvTest";
            this.txtInvTest.Size = new System.Drawing.Size(316, 129);
            this.txtInvTest.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "密文";
            // 
            // txtTest
            // 
            this.txtTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTest.Location = new System.Drawing.Point(12, 80);
            this.txtTest.MaxLength = 65536;
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(316, 130);
            this.txtTest.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(119)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "明文";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(356, 364);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(64, 30);
            this.btnOk.TabIndex = 34;
            this.btnOk.Text = "确定";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnReInv
            // 
            this.btnReInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnReInv.Image = ((System.Drawing.Image)(resources.GetObject("btnReInv.Image")));
            this.btnReInv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReInv.Location = new System.Drawing.Point(184, 229);
            this.btnReInv.Name = "btnReInv";
            this.btnReInv.Size = new System.Drawing.Size(68, 30);
            this.btnReInv.TabIndex = 35;
            this.btnReInv.Text = "恢复";
            this.btnReInv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReInv.UseVisualStyleBackColor = false;
            this.btnReInv.Click += new System.EventHandler(this.btnReInv_Click_1);
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "C:\\Users\\wmr\\Desktop\\修改\\Chart.Client\\bin\\Debug\\WaveColor2.ssk";
            // 
            // FrmEncode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 461);
            this.Controls.Add(this.btnReInv);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInvTest);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ck);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnInv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmEncode";
            this.Text = "不可见字符编码";
            this.Load += new System.EventHandler(this.FrmEncode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInv;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.CheckBox ck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtInvTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnReInv;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}