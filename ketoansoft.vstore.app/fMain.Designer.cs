namespace ketoansoft.app
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDanhmuc = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDanhmuctaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDanhmuccacloaichungtu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDoituongphapnhan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDanhmucnhom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDanhmucdiengiai = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDanhmuccongtrinh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDMCauthanhSP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDanhmuckheuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDMSoHD = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhmuc,
            this.toolStripSeparator4,
            this.toolStripDropDownButton2,
            this.toolStripSeparator7,
            this.toolStripButton1,
            this.toolStripSeparator6,
            this.toolStripDropDownButton3,
            this.toolStripSeparator5,
            this.toolStripDropDownButton4,
            this.toolStripSeparator8,
            this.toolStripDropDownButton5,
            this.toolStripSeparator9,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnDanhmuc
            // 
            this.btnDanhmuc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDanhmuctaikhoan,
            this.toolStripSeparator1,
            this.btnDanhmuccacloaichungtu,
            this.toolStripSeparator2,
            this.btnDoituongphapnhan,
            this.toolStripSeparator3,
            this.btnDanhmucnhom,
            this.toolStripSeparator10,
            this.btnDanhmucdiengiai,
            this.toolStripSeparator11,
            this.btnDanhmuccongtrinh,
            this.toolStripSeparator12,
            this.btnDMCauthanhSP,
            this.toolStripSeparator13,
            this.btnDanhmuckheuoc,
            this.toolStripSeparator14,
            this.btnDMSoHD});
            this.btnDanhmuc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDanhmuc.Name = "btnDanhmuc";
            this.btnDanhmuc.Size = new System.Drawing.Size(87, 22);
            this.btnDanhmuc.Text = "1. Danh mục";
            // 
            // btnDanhmuctaikhoan
            // 
            this.btnDanhmuctaikhoan.Name = "btnDanhmuctaikhoan";
            this.btnDanhmuctaikhoan.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmuctaikhoan.Text = "Danh mục tài khoản";
            this.btnDanhmuctaikhoan.Click += new System.EventHandler(this.btnDanhmuctaikhoan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDanhmuccacloaichungtu
            // 
            this.btnDanhmuccacloaichungtu.Name = "btnDanhmuccacloaichungtu";
            this.btnDanhmuccacloaichungtu.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmuccacloaichungtu.Text = "Danh mục các loại chứng từ";
            this.btnDanhmuccacloaichungtu.Click += new System.EventHandler(this.btnDanhmuccacloaichungtu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDoituongphapnhan
            // 
            this.btnDoituongphapnhan.Name = "btnDoituongphapnhan";
            this.btnDoituongphapnhan.Size = new System.Drawing.Size(244, 22);
            this.btnDoituongphapnhan.Text = "Danh mục đối tượng pháp nhân";
            this.btnDoituongphapnhan.Click += new System.EventHandler(this.btnDoituongphapnhan_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDanhmucnhom
            // 
            this.btnDanhmucnhom.Name = "btnDanhmucnhom";
            this.btnDanhmucnhom.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmucnhom.Text = "Danh mục nhóm";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDanhmucdiengiai
            // 
            this.btnDanhmucdiengiai.Name = "btnDanhmucdiengiai";
            this.btnDanhmucdiengiai.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmucdiengiai.Text = "Danh mục diễn giải";
            this.btnDanhmucdiengiai.Click += new System.EventHandler(this.btnDanhmucdiengiai_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDanhmuccongtrinh
            // 
            this.btnDanhmuccongtrinh.Name = "btnDanhmuccongtrinh";
            this.btnDanhmuccongtrinh.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmuccongtrinh.Text = "Danh mục công trình";
            this.btnDanhmuccongtrinh.Click += new System.EventHandler(this.btnDanhmuccongtrinh_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDMCauthanhSP
            // 
            this.btnDMCauthanhSP.Name = "btnDMCauthanhSP";
            this.btnDMCauthanhSP.Size = new System.Drawing.Size(244, 22);
            this.btnDMCauthanhSP.Text = "Danh mục cấu thành sản phẩm";
            this.btnDMCauthanhSP.Click += new System.EventHandler(this.btnDMCauthanhSP_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDanhmuckheuoc
            // 
            this.btnDanhmuckheuoc.Name = "btnDanhmuckheuoc";
            this.btnDanhmuckheuoc.Size = new System.Drawing.Size(244, 22);
            this.btnDanhmuckheuoc.Text = "Danh mục khế ước";
            this.btnDanhmuckheuoc.Click += new System.EventHandler(this.btnDanhmuckheuoc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(88, 22);
            this.toolStripDropDownButton2.Text = "2. Xem số dư";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton1.Text = "3. Export ra Excel";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton3.Text = "4. Edit";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton4.Text = "5. View";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton5.Image")));
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(114, 22);
            this.toolStripDropDownButton5.Text = "6. Quản trị dữ liệu";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton2.Text = "7. Help";
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(241, 6);
            // 
            // btnDMSoHD
            // 
            this.btnDMSoHD.Name = "btnDMSoHD";
            this.btnDMSoHD.Size = new System.Drawing.Size(244, 22);
            this.btnDMSoHD.Text = "Danh mục số hóa đơn";
            this.btnDMSoHD.Click += new System.EventHandler(this.btnDMSoHD_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(747, 464);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.Text = "Phần mềm kế toán SmartV1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnDanhmuc;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmuctaikhoan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmuccacloaichungtu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDoituongphapnhan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmucnhom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmucdiengiai;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmuccongtrinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem btnDMCauthanhSP;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem btnDanhmuckheuoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem btnDMSoHD;

    }
}