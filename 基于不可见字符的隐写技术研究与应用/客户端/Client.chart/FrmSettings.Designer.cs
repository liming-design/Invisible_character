namespace Client.chart
{
    partial class FrmSettings
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
            this.ckMessage = new System.Windows.Forms.CheckBox();
            this.ckOnline = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ckMessage
            // 
            this.ckMessage.AutoSize = true;
            this.ckMessage.Checked = true;
            this.ckMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckMessage.Location = new System.Drawing.Point(142, 67);
            this.ckMessage.Name = "ckMessage";
            this.ckMessage.Size = new System.Drawing.Size(171, 24);
            this.ckMessage.TabIndex = 2;
            this.ckMessage.Text = "消息提醒提示音";
            this.ckMessage.UseVisualStyleBackColor = true;
            // 
            // ckOnline
            // 
            this.ckOnline.AutoSize = true;
            this.ckOnline.Checked = true;
            this.ckOnline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOnline.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckOnline.Location = new System.Drawing.Point(142, 129);
            this.ckOnline.Name = "ckOnline";
            this.ckOnline.Size = new System.Drawing.Size(171, 24);
            this.ckOnline.TabIndex = 3;
            this.ckOnline.Text = "用户上线提示音";
            this.ckOnline.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(231, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(359, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 313);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ckOnline);
            this.Controls.Add(this.ckMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSettings";
            this.Text = "提示音设置";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckMessage;
        private System.Windows.Forms.CheckBox ckOnline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}