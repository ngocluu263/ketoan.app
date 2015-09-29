namespace Activate
{
    partial class frmActivate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActivate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKhachhang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAppcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHardwareID = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnGetHardwareID = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khách hàng";
            // 
            // txtKhachhang
            // 
            this.txtKhachhang.Location = new System.Drawing.Point(160, 37);
            this.txtKhachhang.Margin = new System.Windows.Forms.Padding(4);
            this.txtKhachhang.Name = "txtKhachhang";
            this.txtKhachhang.Size = new System.Drawing.Size(203, 23);
            this.txtKhachhang.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Appcode";
            // 
            // txtAppcode
            // 
            this.txtAppcode.Location = new System.Drawing.Point(160, 89);
            this.txtAppcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAppcode.Name = "txtAppcode";
            this.txtAppcode.Size = new System.Drawing.Size(203, 23);
            this.txtAppcode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hardware ID";
            // 
            // txtHardwareID
            // 
            this.txtHardwareID.Location = new System.Drawing.Point(160, 141);
            this.txtHardwareID.Margin = new System.Windows.Forms.Padding(4);
            this.txtHardwareID.Name = "txtHardwareID";
            this.txtHardwareID.Size = new System.Drawing.Size(203, 23);
            this.txtHardwareID.TabIndex = 3;
            // 
            // btnActivate
            // 
            this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivate.Location = new System.Drawing.Point(160, 207);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(100, 28);
            this.btnActivate.TabIndex = 5;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnGetHardwareID
            // 
            this.btnGetHardwareID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetHardwareID.Location = new System.Drawing.Point(372, 139);
            this.btnGetHardwareID.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetHardwareID.Name = "btnGetHardwareID";
            this.btnGetHardwareID.Size = new System.Drawing.Size(64, 28);
            this.btnGetHardwareID.TabIndex = 4;
            this.btnGetHardwareID.Text = "Get";
            this.btnGetHardwareID.UseVisualStyleBackColor = true;
            this.btnGetHardwareID.Click += new System.EventHandler(this.btnGetHardwareID_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(263, 207);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(515, 254);
            this.Controls.Add(this.btnGetHardwareID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.txtHardwareID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAppcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKhachhang);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmActivate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKhachhang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAppcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHardwareID;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnGetHardwareID;
        private System.Windows.Forms.Button btnClose;
    }
}

