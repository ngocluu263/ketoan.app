﻿namespace ketoansoft.app
{
    partial class DanhMucSoHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhMucSoHoaDon));
            this.gridData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MATK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MADTPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENDTPN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SO_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAY_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SR_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAY_DH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_Edit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.btnSearch = new DevComponents.DotNetBar.ButtonItem();
            this.btnTick = new DevComponents.DotNetBar.ButtonItem();
            this.btnDuplicate = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnToCol = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.btnEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btnExit = new DevComponents.DotNetBar.ButtonItem();
            this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtNumRows = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtInfoRows = new System.Windows.Forms.TextBox();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEN_Edit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(30);
            this.gridData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridData.Location = new System.Drawing.Point(0, 0);
            this.gridData.MainView = this.gridView1;
            this.gridData.Name = "gridData";
            this.gridData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.TEN_Edit1});
            this.gridData.Size = new System.Drawing.Size(950, 363);
            this.gridData.TabIndex = 0;
            this.gridData.UseEmbeddedNavigator = true;
            this.gridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridData.Load += new System.EventHandler(this.gridData_Load);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.MATK,
            this.MADTPN,
            this.TENDTPN,
            this.SO_HD,
            this.NGAY_HD,
            this.SR_HD,
            this.NGAY_DH});
            this.gridView1.GridControl = this.gridData;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Click Thêm mới";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 50;
            // 
            // MATK
            // 
            this.MATK.Caption = "Mã TK";
            this.MATK.FieldName = "MATK";
            this.MATK.Name = "MATK";
            this.MATK.Visible = true;
            this.MATK.VisibleIndex = 1;
            // 
            // MADTPN
            // 
            this.MADTPN.Caption = "Mã ĐTPN";
            this.MADTPN.FieldName = "MADTPN";
            this.MADTPN.Name = "MADTPN";
            this.MADTPN.Visible = true;
            this.MADTPN.VisibleIndex = 2;
            // 
            // TENDTPN
            // 
            this.TENDTPN.Caption = "Tên đối tượng pháp nhân";
            this.TENDTPN.FieldName = "TENDTPN";
            this.TENDTPN.Name = "TENDTPN";
            this.TENDTPN.Visible = true;
            this.TENDTPN.VisibleIndex = 3;
            this.TENDTPN.Width = 120;
            // 
            // SO_HD
            // 
            this.SO_HD.Caption = "Số HĐ";
            this.SO_HD.FieldName = "SO_HD";
            this.SO_HD.Name = "SO_HD";
            this.SO_HD.Visible = true;
            this.SO_HD.VisibleIndex = 4;
            // 
            // NGAY_HD
            // 
            this.NGAY_HD.Caption = "Ngày HĐ";
            this.NGAY_HD.FieldName = "NGAY_HD";
            this.NGAY_HD.Name = "NGAY_HD";
            this.NGAY_HD.Visible = true;
            this.NGAY_HD.VisibleIndex = 5;
            this.NGAY_HD.Width = 120;
            // 
            // SR_HD
            // 
            this.SR_HD.Caption = "Seri HĐ";
            this.SR_HD.FieldName = "SR_HD";
            this.SR_HD.Name = "SR_HD";
            this.SR_HD.Visible = true;
            this.SR_HD.VisibleIndex = 6;
            // 
            // NGAY_DH
            // 
            this.NGAY_DH.Caption = "Ngày Đáo Hạn";
            this.NGAY_DH.FieldName = "NGAY_DH";
            this.NGAY_DH.Name = "NGAY_DH";
            this.NGAY_DH.Visible = true;
            this.NGAY_DH.VisibleIndex = 7;
            this.NGAY_DH.Width = 120;
            // 
            // TEN_Edit1
            // 
            this.TEN_Edit1.AutoHeight = false;
            this.TEN_Edit1.Name = "TEN_Edit1";
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.itemPanel1.BackgroundStyle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("itemPanel1.BackgroundStyle.BackgroundImage")));
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.BackgroundStyle.PaddingBottom = 5;
            this.itemPanel1.BackgroundStyle.PaddingLeft = 5;
            this.itemPanel1.BackgroundStyle.PaddingRight = 5;
            this.itemPanel1.BackgroundStyle.PaddingTop = 5;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSearch,
            this.btnTick,
            this.btnDuplicate,
            this.buttonItem3,
            this.btnRefresh,
            this.btnToCol,
            this.buttonItem6,
            this.btnEdit,
            this.btnSave,
            this.btnDelete,
            this.btnExit});
            this.itemPanel1.ItemSpacing = 5;
            this.itemPanel1.ItemTemplate = this.btnEdit;
            this.itemPanel1.Location = new System.Drawing.Point(0, 0);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(950, 60);
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.itemPanel1.TabIndex = 1;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // btnSearch
            // 
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.GlobalItem = false;
            this.btnSearch.ImagePaddingVertical = 4;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.btnSearch.Text = "F1\r\nTìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnTick
            // 
            this.btnTick.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnTick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTick.GlobalItem = false;
            this.btnTick.ImagePaddingVertical = 4;
            this.btnTick.Name = "btnTick";
            this.btnTick.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnTick.Text = "F2\r\nĐánh dấu";
            this.btnTick.Click += new System.EventHandler(this.btnTick_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnDuplicate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDuplicate.GlobalItem = false;
            this.btnDuplicate.ImagePaddingVertical = 4;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnDuplicate.Text = "F3\r\nCopy dòng";
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.buttonItem3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem3.GlobalItem = false;
            this.buttonItem3.ImagePaddingVertical = 4;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.buttonItem3.Text = "F4\r\nMáy tính";
            // 
            // btnRefresh
            // 
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.GlobalItem = false;
            this.btnRefresh.ImagePaddingVertical = 4;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnRefresh.Text = "F5\r\nLàm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnToCol
            // 
            this.btnToCol.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnToCol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToCol.GlobalItem = false;
            this.btnToCol.ImagePaddingVertical = 4;
            this.btnToCol.Name = "btnToCol";
            this.btnToCol.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnToCol.Text = "F6\r\nĐến cột";
            this.btnToCol.Click += new System.EventHandler(this.btnToCol_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.buttonItem6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem6.GlobalItem = false;
            this.buttonItem6.ImagePaddingVertical = 4;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.buttonItem6.Text = "F7\r\nLọc chứng từ";
            // 
            // btnEdit
            // 
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.GlobalItem = false;
            this.btnEdit.ImagePaddingVertical = 4;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F10);
            this.btnEdit.Text = "F10\r\nSửa chứng từ";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ImagePaddingVertical = 4;
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnSave.Text = "Ctrl + S\r\nLưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.GlobalItem = false;
            this.btnDelete.ImagePaddingVertical = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "Del\r\nXóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ImagePaddingVertical = 4;
            this.btnExit.Name = "btnExit";
            this.btnExit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlQ);
            this.btnExit.Text = "Ctrl + Q\r\nThoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // checkBoxItem1
            // 
            this.checkBoxItem1.GlobalItem = false;
            this.checkBoxItem1.Name = "checkBoxItem1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(950, 495);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panelControl1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gridData);
            this.splitContainer4.Size = new System.Drawing.Size(950, 394);
            this.splitContainer4.SplitterDistance = 27;
            this.splitContainer4.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtNumRows);
            this.panelControl1.Controls.Add(this.txtCompanyName);
            this.panelControl1.Controls.Add(this.txtDatabase);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtYear);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtMonth);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(950, 27);
            this.panelControl1.TabIndex = 0;
            // 
            // txtNumRows
            // 
            this.txtNumRows.Location = new System.Drawing.Point(784, 2);
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.ReadOnly = true;
            this.txtNumRows.Size = new System.Drawing.Size(161, 22);
            this.txtNumRows.TabIndex = 1;
            this.txtNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(395, 2);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(383, 22);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtDatabase.Location = new System.Drawing.Point(277, 2);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.ReadOnly = true;
            this.txtDatabase.Size = new System.Drawing.Size(112, 22);
            this.txtDatabase.TabIndex = 1;
            this.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(223, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Database";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtYear.Location = new System.Drawing.Point(147, 2);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(69, 22);
            this.txtYear.TabIndex = 1;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(117, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Năm";
            // 
            // txtMonth
            // 
            this.txtMonth.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtMonth.Location = new System.Drawing.Point(50, 2);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(59, 22);
            this.txtMonth.TabIndex = 1;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.itemPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(950, 97);
            this.splitContainer2.SplitterDistance = 33;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 33);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panelControl3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panelControl2);
            this.splitContainer3.Size = new System.Drawing.Size(950, 33);
            this.splitContainer3.SplitterDistance = 235;
            this.splitContainer3.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.textBox6);
            this.panelControl3.Controls.Add(this.label4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(235, 33);
            this.panelControl3.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(76, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(158, 29);
            this.textBox6.TabIndex = 3;
            this.textBox6.Text = "KT_DMHoaDon";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên bảng";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtInfoRows);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(711, 33);
            this.panelControl2.TabIndex = 0;
            // 
            // txtInfoRows
            // 
            this.txtInfoRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfoRows.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoRows.Location = new System.Drawing.Point(2, 2);
            this.txtInfoRows.Name = "txtInfoRows";
            this.txtInfoRows.ReadOnly = true;
            this.txtInfoRows.Size = new System.Drawing.Size(707, 29);
            this.txtInfoRows.TabIndex = 4;
            this.txtInfoRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.GlobalItem = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // DanhMucSoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 495);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DanhMucSoHoaDon";
            this.Text = "Danh mục số hóa đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEN_Edit1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevComponents.DotNetBar.ButtonItem btnSearch;
        private DevComponents.DotNetBar.ButtonItem btnTick;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem btnDuplicate;
        private DevComponents.DotNetBar.ButtonItem btnToCol;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem btnEdit;
        private DevComponents.DotNetBar.ButtonItem btnDelete;
        private DevComponents.DotNetBar.ButtonItem btnExit;
        private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit TEN_Edit1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumRows;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInfoRows;
        private System.Windows.Forms.TextBox textBox6;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn MATK;
        private DevExpress.XtraGrid.Columns.GridColumn MADTPN;
        private DevExpress.XtraGrid.Columns.GridColumn TENDTPN;
        private DevExpress.XtraGrid.Columns.GridColumn SO_HD;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY_HD;
        private DevExpress.XtraGrid.Columns.GridColumn SR_HD;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY_DH;
    }
}