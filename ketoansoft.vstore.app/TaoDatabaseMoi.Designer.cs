namespace ketoansoft.app
{
    partial class TaoDatabaseMoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaoDatabaseMoi));
            this.txtThumucluu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTenDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCollation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtThumucluu
            // 
            this.txtThumucluu.BackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // 
            // 
            this.txtThumucluu.Border.Class = "TextBoxBorder";
            this.txtThumucluu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtThumucluu.ButtonCustom.Tooltip = "";
            this.txtThumucluu.ButtonCustom2.Tooltip = "";
            this.txtThumucluu.DisabledBackColor = System.Drawing.Color.White;
            this.txtThumucluu.Enabled = false;
            this.txtThumucluu.ForeColor = System.Drawing.Color.Black;
            this.txtThumucluu.Location = new System.Drawing.Point(128, 117);
            this.txtThumucluu.Name = "txtThumucluu";
            this.txtThumucluu.PreventEnterBeep = true;
            this.txtThumucluu.Size = new System.Drawing.Size(532, 20);
            this.txtThumucluu.TabIndex = 11;
            this.txtThumucluu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTenDatabase
            // 
            this.txtTenDatabase.BackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // 
            // 
            this.txtTenDatabase.Border.Class = "TextBoxBorder";
            this.txtTenDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTenDatabase.ButtonCustom.Tooltip = "";
            this.txtTenDatabase.ButtonCustom2.Tooltip = "";
            this.txtTenDatabase.DisabledBackColor = System.Drawing.Color.White;
            this.txtTenDatabase.ForeColor = System.Drawing.Color.Black;
            this.txtTenDatabase.Location = new System.Drawing.Point(128, 79);
            this.txtTenDatabase.Name = "txtTenDatabase";
            this.txtTenDatabase.PreventEnterBeep = true;
            this.txtTenDatabase.Size = new System.Drawing.Size(180, 20);
            this.txtTenDatabase.TabIndex = 10;
            this.txtTenDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(-1, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Thư mục lưu database";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(65, 50);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 7;
            this.label27.Text = "Collation";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(39, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Tên database";
            // 
            // txtCollation
            // 
            this.txtCollation.BackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // 
            // 
            this.txtCollation.Border.Class = "TextBoxBorder";
            this.txtCollation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCollation.ButtonCustom.Tooltip = "";
            this.txtCollation.ButtonCustom2.Tooltip = "";
            this.txtCollation.DisabledBackColor = System.Drawing.Color.White;
            this.txtCollation.ForeColor = System.Drawing.Color.Red;
            this.txtCollation.Location = new System.Drawing.Point(128, 43);
            this.txtCollation.Name = "txtCollation";
            this.txtCollation.PreventEnterBeep = true;
            this.txtCollation.Size = new System.Drawing.Size(532, 20);
            this.txtCollation.TabIndex = 9;
            this.txtCollation.Text = "SQL_Latin1_General_CP1_CI_AS";
            this.txtCollation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(558, 155);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 44);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(390, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 44);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(683, 71);
            this.label1.TabIndex = 18;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(684, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Thông tin để tạo database mới";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaoDatabaseMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(682, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtThumucluu);
            this.Controls.Add(this.txtTenDatabase);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtCollation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaoDatabaseMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo Database Mới";
            this.Load += new System.EventHandler(this.TaoDatabaseMoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtThumucluu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTenDatabase;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCollation;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}