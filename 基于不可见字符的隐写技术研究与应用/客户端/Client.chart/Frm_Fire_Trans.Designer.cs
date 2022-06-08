namespace Client.chart
{
    partial class Frm_Fire_Trans
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
            this.ck = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.rtxtBoxAfter = new System.Windows.Forms.RichTextBox();
            this.AfterFirePath = new System.Windows.Forms.TextBox();
            this.ButtSelectAfter = new System.Windows.Forms.Button();
            this.ButtExtract = new System.Windows.Forms.Button();
            this.ButtInsert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtBoxBefore = new System.Windows.Forms.RichTextBox();
            this.BeforeFirePath = new System.Windows.Forms.TextBox();
            this.rtxtBoxSecret = new System.Windows.Forms.RichTextBox();
            this.ButtSelectBefore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.Location = new System.Drawing.Point(403, 183);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(113, 19);
            this.ck.TabIndex = 3;
            this.ck.Text = "使用AES加密";
            this.ck.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(394, 221);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(232, 30);
            this.txtKey.TabIndex = 4;
            // 
            // rtxtBoxAfter
            // 
            this.rtxtBoxAfter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtBoxAfter.Location = new System.Drawing.Point(653, 181);
            this.rtxtBoxAfter.Name = "rtxtBoxAfter";
            this.rtxtBoxAfter.Size = new System.Drawing.Size(309, 444);
            this.rtxtBoxAfter.TabIndex = 7;
            this.rtxtBoxAfter.Text = "";
            // 
            // AfterFirePath
            // 
            this.AfterFirePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AfterFirePath.Location = new System.Drawing.Point(653, 129);
            this.AfterFirePath.Name = "AfterFirePath";
            this.AfterFirePath.Size = new System.Drawing.Size(309, 30);
            this.AfterFirePath.TabIndex = 6;
            this.AfterFirePath.TextChanged += new System.EventHandler(this.AfterFirePath_TextChanged);
            // 
            // ButtSelectAfter
            // 
            this.ButtSelectAfter.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtSelectAfter.Location = new System.Drawing.Point(653, 74);
            this.ButtSelectAfter.Name = "ButtSelectAfter";
            this.ButtSelectAfter.Size = new System.Drawing.Size(109, 36);
            this.ButtSelectAfter.TabIndex = 5;
            this.ButtSelectAfter.Text = "选择文件";
            this.ButtSelectAfter.UseVisualStyleBackColor = true;
            this.ButtSelectAfter.Click += new System.EventHandler(this.ButtSelectAfter_Click);
            // 
            // ButtExtract
            // 
            this.ButtExtract.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtExtract.Location = new System.Drawing.Point(544, 321);
            this.ButtExtract.Name = "ButtExtract";
            this.ButtExtract.Size = new System.Drawing.Size(82, 40);
            this.ButtExtract.TabIndex = 8;
            this.ButtExtract.Text = "提取";
            this.ButtExtract.UseVisualStyleBackColor = true;
            this.ButtExtract.Click += new System.EventHandler(this.ButtExtract_Click);
            // 
            // ButtInsert
            // 
            this.ButtInsert.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtInsert.Location = new System.Drawing.Point(394, 321);
            this.ButtInsert.Name = "ButtInsert";
            this.ButtInsert.Size = new System.Drawing.Size(82, 40);
            this.ButtInsert.TabIndex = 9;
            this.ButtInsert.Text = "嵌入";
            this.ButtInsert.UseVisualStyleBackColor = true;
            this.ButtInsert.Click += new System.EventHandler(this.ButtInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(650, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "嵌入后";
            // 
            // rtxtBoxBefore
            // 
            this.rtxtBoxBefore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtBoxBefore.Location = new System.Drawing.Point(28, 181);
            this.rtxtBoxBefore.Name = "rtxtBoxBefore";
            this.rtxtBoxBefore.Size = new System.Drawing.Size(325, 241);
            this.rtxtBoxBefore.TabIndex = 2;
            this.rtxtBoxBefore.Text = "";
            this.rtxtBoxBefore.TextChanged += new System.EventHandler(this.rtxtBoxBefore_TextChanged);
            // 
            // BeforeFirePath
            // 
            this.BeforeFirePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BeforeFirePath.Location = new System.Drawing.Point(28, 129);
            this.BeforeFirePath.Name = "BeforeFirePath";
            this.BeforeFirePath.Size = new System.Drawing.Size(325, 30);
            this.BeforeFirePath.TabIndex = 1;
            this.BeforeFirePath.TextChanged += new System.EventHandler(this.BeforeFirePath_TextChanged);
            // 
            // rtxtBoxSecret
            // 
            this.rtxtBoxSecret.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtBoxSecret.ForeColor = System.Drawing.Color.Red;
            this.rtxtBoxSecret.Location = new System.Drawing.Point(28, 495);
            this.rtxtBoxSecret.Name = "rtxtBoxSecret";
            this.rtxtBoxSecret.Size = new System.Drawing.Size(325, 130);
            this.rtxtBoxSecret.TabIndex = 10;
            this.rtxtBoxSecret.Text = "";
            // 
            // ButtSelectBefore
            // 
            this.ButtSelectBefore.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtSelectBefore.Location = new System.Drawing.Point(28, 74);
            this.ButtSelectBefore.Name = "ButtSelectBefore";
            this.ButtSelectBefore.Size = new System.Drawing.Size(107, 36);
            this.ButtSelectBefore.TabIndex = 0;
            this.ButtSelectBefore.Text = "选择文件";
            this.ButtSelectBefore.UseVisualStyleBackColor = true;
            this.ButtSelectBefore.Click += new System.EventHandler(this.ButtSelectBefore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "秘密信息（明文）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "嵌入前";
            // 
            // Frm_Fire_Trans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 651);
            this.Controls.Add(this.rtxtBoxAfter);
            this.Controls.Add(this.AfterFirePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtSelectAfter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtxtBoxSecret);
            this.Controls.Add(this.rtxtBoxBefore);
            this.Controls.Add(this.BeforeFirePath);
            this.Controls.Add(this.ButtSelectBefore);
            this.Controls.Add(this.ButtInsert);
            this.Controls.Add(this.ButtExtract);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.ck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_Fire_Trans";
            this.Text = "文件转换";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Fire_Trans_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Fire_Trans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ck;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.RichTextBox rtxtBoxAfter;
        private System.Windows.Forms.Button ButtSelectAfter;
        private System.Windows.Forms.Button ButtExtract;
        private System.Windows.Forms.Button ButtInsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtBoxBefore;
        private System.Windows.Forms.TextBox BeforeFirePath;
        private System.Windows.Forms.RichTextBox rtxtBoxSecret;
        private System.Windows.Forms.Button ButtSelectBefore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox AfterFirePath;
    }
}