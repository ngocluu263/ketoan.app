namespace ketoansoft.app
{
    partial class BackupDatabase
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnChonthumuc = new DevComponents.DotNetBar.ButtonX();
            this.lbDuongdan = new System.Windows.Forms.Label();
            this.rdoAccess = new System.Windows.Forms.RadioButton();
            this.rdoXml = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(671, 51);
            this.label2.TabIndex = 19;
            this.label2.Text = "Smart khuyên bạn lên sao lưu data vào cuối tháng hoặc cuối tuần để phòng hờ. Tron" +
    "g trường hợp máy bị virus hoặc sự cố bất thường làm hư database thì khôi phục lạ" +
    "i data rất dễ dàng.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(331, 208);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 44);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(474, 208);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 44);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 21;
            this.btnThoat.Text = "Thoát";
            // 
            // btnChonthumuc
            // 
            this.btnChonthumuc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChonthumuc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChonthumuc.Location = new System.Drawing.Point(276, 19);
            this.btnChonthumuc.Name = "btnChonthumuc";
            this.btnChonthumuc.Size = new System.Drawing.Size(122, 27);
            this.btnChonthumuc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChonthumuc.TabIndex = 20;
            this.btnChonthumuc.Text = "Chọn thư mục lưu ...";
            this.btnChonthumuc.Click += new System.EventHandler(this.btnChonthumuc_Click);
            // 
            // lbDuongdan
            // 
            this.lbDuongdan.AutoSize = true;
            this.lbDuongdan.BackColor = System.Drawing.Color.Transparent;
            this.lbDuongdan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuongdan.Location = new System.Drawing.Point(6, 67);
            this.lbDuongdan.Name = "lbDuongdan";
            this.lbDuongdan.Size = new System.Drawing.Size(0, 20);
            this.lbDuongdan.TabIndex = 22;
            // 
            // rdoAccess
            // 
            this.rdoAccess.AutoSize = true;
            this.rdoAccess.Checked = true;
            this.rdoAccess.Location = new System.Drawing.Point(12, 30);
            this.rdoAccess.Name = "rdoAccess";
            this.rdoAccess.Size = new System.Drawing.Size(214, 17);
            this.rdoAccess.TabIndex = 23;
            this.rdoAccess.TabStop = true;
            this.rdoAccess.Text = "1. Lưu ra file Microsoft Access database";
            this.rdoAccess.UseVisualStyleBackColor = true;
            // 
            // rdoXml
            // 
            this.rdoXml.AutoSize = true;
            this.rdoXml.Location = new System.Drawing.Point(12, 83);
            this.rdoXml.Name = "rdoXml";
            this.rdoXml.Size = new System.Drawing.Size(89, 17);
            this.rdoXml.TabIndex = 24;
            this.rdoXml.TabStop = true;
            this.rdoXml.Text = "2. Lưu file xml";
            this.rdoXml.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChonthumuc);
            this.groupBox1.Controls.Add(this.lbDuongdan);
            this.groupBox1.Location = new System.Drawing.Point(8, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 100);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn đường dẫn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAccess);
            this.groupBox2.Controls.Add(this.rdoXml);
            this.groupBox2.Location = new System.Drawing.Point(8, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 130);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Access Files | *.mdb";
            // 
            // BackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(670, 319);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup database";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnChonthumuc;
        private System.Windows.Forms.Label lbDuongdan;
        private System.Windows.Forms.RadioButton rdoAccess;
        private System.Windows.Forms.RadioButton rdoXml;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}