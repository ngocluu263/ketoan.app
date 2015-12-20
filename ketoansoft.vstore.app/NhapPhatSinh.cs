using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ketoansoft.app.Class.Global;
using ketoansoft.app.Class.Data;
using ketoansoft.app.Components.clsVproUtility;
namespace ketoansoft.app
{
    public partial class NhapPhatSinh : Form
    {
        #region function private
        private dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTLCTGRepo _KTLCTGRepo = new KTLCTGRepo();
        private KT_CTuGocRepo _KT_CTuGocRepo = new KT_CTuGocRepo();
        private KTTKRepo _KTTKRepo = new KTTKRepo();
        private KTDTPNRepo _KTDTPNRepo = new KTDTPNRepo();
        private KTYTCPRepo _KTYTCPRepo = new KTYTCPRepo();
        private KTDMHHRepo _KTDMHHRepo = new KTDMHHRepo();
        private KTDMHoaDonRepo _KTDMHoaDonRepo = new KTDMHoaDonRepo();
        private KTDIENGIAIRepo _KTDIENGIAIRepo = new KTDIENGIAIRepo();
        private KTMaTTRepo _KTMaTTRepo = new KTMaTTRepo();
        private KTMaHDRepo _KTMaHDRepo = new KTMaHDRepo();
        private KTCNHopDongRepo _KTCNHopDongRepo = new KTCNHopDongRepo();
        private KTDMCongTrinhRepo _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
        private List<KT_CTuGoc> _listCTuGoc = new List<KT_CTuGoc>();
        private int STT = 1;
        #endregion

        public NhapPhatSinh()
        {
            InitializeComponent();
        }

        private void NhapPhatSinh_Load(object sender, EventArgs e)
        {
            LoadLoaiChungTu();
            LoadSTT();
            LoadSoHD();
            LoadMaTT();
            LoadMaHD();
            LoadSoHopDong();
            LoadCongTrinh();
            LoadDiengiai();
            LoadMakhachhang();
            LoadGanVaoMADTPN();
            LoadNguoigiaodich();
            LoadManhanvienban();

            LoadTKNo();
            LoadDTPNNo();
            LoadYTCPNo();
            LoadVTHHNo();

            LoadTKCo();
            LoadDTPNCo();
            LoadYTCPCo();
            LoadVTHHCo();
        }

        #region Load cbo
        private void LoadLoaiChungTu()
        {
            _KTLCTGRepo = new KTLCTGRepo();
            var list = _KTLCTGRepo.GetAll();
            cboLoaiCTu.DisplayMember = "ID_LOAI";
            cboLoaiCTu.ValueMember = "ID_LOAI";
            cboLoaiCTu.DropDownColumns = "ID_LOAI,TEN_CT,SO_CT";
            cboLoaiCTu.DataSource = list;
            cboLoaiCTu.SelectedIndex = -1;

            _KTLCTGRepo = new KTLCTGRepo();
            var list2 = _KTLCTGRepo.GetAll();
            cboLoaiCTuCopy.DisplayMember = "ID_LOAI";
            cboLoaiCTuCopy.ValueMember = "ID_LOAI";
            cboLoaiCTuCopy.DropDownColumns = "ID_LOAI,TEN_CT,SO_CT";
            cboLoaiCTuCopy.DataSource = list2;
            cboLoaiCTuCopy.SelectedIndex = -1;
        }
        private void cboLoaiCTu_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "TEN_CT")
            {
                header.Width.Relative = 50; // 20% of available width
            }
            else { header.Width.Relative = 25; }
        }
        private void LoadSoHD()
        {
            //_KTDMHoaDonRepo = new KTDMHoaDonRepo();
            //cboSoHD.DataSource = _KTDMHoaDonRepo.GetAll();
            cboSoHD.DisplayMember = "SO_HD";
            cboSoHD.ValueMember = "SO_HD";
            cboSoHD.DropDownColumns = "SO_HD,SR_HD,NGAY_HD,MATK,MADTPN,TENDTPN";
            cboSoHD.DataSource = _db.KT_DMHoaDons.Select(s => new
            {
                SO_HD = s.SO_HD,
                SR_HD = s.SR_HD,
                NGAY_HD = Utils.CDateDef(s.NGAY_HD, DateTime.MinValue).ToString("dd/MM/yyyy"),
                MATK = s.MATK,
                MADTPN = s.MADTPN,
                TENDTPN = s.TENDTPN
            });
            cboSoHD.SelectedIndex = -1;
        }
        private void cboSoHD_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "TENDTPN")
            {
                header.Width.Relative = 25; // 20% of available width
            }
            else
            {
                header.Width.Relative = 15;
            }
        }
        private void LoadMaTT()
        {
            _KTMaTTRepo = new KTMaTTRepo();
            cboMaTT.DisplayMember = "KY_HIEU";
            cboMaTT.ValueMember = "KY_HIEU";
            cboMaTT.DropDownColumns = "KY_HIEU,DIEN_GIAI,GHI_CHU";
            cboMaTT.DataSource = _KTMaTTRepo.GetAll();
            cboMaTT.SelectedIndex = -1;
        }
        private void cboMaTT_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "KY_HIEU")
            {
                header.Width.Relative = 20; // 20% of available width
            }
            else
            {
                header.Width.Relative = 40;
            }
        }
        private void LoadMaHD()
        {
            _KTMaHDRepo = new KTMaHDRepo();
            cboMaHD.DisplayMember = "KY_HIEU";
            cboMaHD.ValueMember = "KY_HIEU";
            cboMaHD.DropDownColumns = "KY_HIEU,DIEN_GIAI,GHI_CHU";
            cboMaHD.DataSource = _KTMaHDRepo.GetAll();
            cboMaHD.SelectedIndex = -1;
        }
        private void cboMaHD_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "KY_HIEU")
            {
                header.Width.Relative = 20; // 20% of available width
            }
            else
            {
                header.Width.Relative = 40;
            }
        }
        private void LoadDiengiai()
        {
            _KTDIENGIAIRepo = new KTDIENGIAIRepo();
            cboDiengiai.DisplayMember = "DIEN_GIAI1";
            cboDiengiai.ValueMember = "ID";
            cboDiengiai.DropDownColumns = "DIEN_GIAI1,DIEN_GIAI2";
            cboDiengiai.DataSource = _KTDIENGIAIRepo.GetAll();
            cboDiengiai.SelectedIndex = -1;
        }
        private void cboDiengiai_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "DIEN_GIAI1")
            {
                header.Width.Relative = 50; // 20% of available width
            }
            else
            {
                header.Width.Relative = 50;
            }
        }
        private void LoadSoHopDong()
        {
            _KTCNHopDongRepo = new KTCNHopDongRepo();
            cboSoHopDong.DisplayMember = "SO_HD";
            cboSoHopDong.ValueMember = "SO_HD";
            cboSoHopDong.DropDownColumns = "SO_HD,MA_TK";
            cboSoHopDong.DataSource = _KTCNHopDongRepo.GetAll();
            cboSoHopDong.SelectedIndex = -1;
        }
        private void cboSoHopDong_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "SO_HD")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadCongTrinh()
        {
            _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
            cboCongtrinh.DisplayMember = "MA_CT";
            cboCongtrinh.ValueMember = "ID";
            cboCongtrinh.DropDownColumns = "MA_CT,TEN_CT";
            cboCongtrinh.DataSource = _KTDMCongTrinhRepo.GetAll();
            cboCongtrinh.SelectedIndex = -1;
        }
        private void cboCongtrinh_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_CT")
            {
                header.Width.Relative = 40; // 20% of available width
            }
            else
            {
                header.Width.Relative = 60;
            }
        }
        private void LoadMakhachhang()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboMakhachhang.DisplayMember = "MA_DTPN";
            cboMakhachhang.ValueMember = "ID";
            cboMakhachhang.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboMakhachhang.DataSource = _KTDTPNRepo.GetAll();
            cboMakhachhang.SelectedIndex = -1;
        }
        private void cboMakhachhang_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadGanVaoMADTPN()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboGanvaomaMADTPN.DisplayMember = "MA_DTPN";
            cboGanvaomaMADTPN.ValueMember = "ID";
            cboGanvaomaMADTPN.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboGanvaomaMADTPN.DataSource = _KTDTPNRepo.GetAll();
            cboGanvaomaMADTPN.SelectedIndex = -1;
        }
        private void cboGanvaomaMADTPN_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadNguoigiaodich()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboNguoigiaodich.DisplayMember = "MA_DTPN";
            cboNguoigiaodich.ValueMember = "ID";
            cboNguoigiaodich.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboNguoigiaodich.DataSource = _KTDTPNRepo.GetAll();
            cboNguoigiaodich.SelectedIndex = -1;
        }
        private void cboNguoigiaodich_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadManhanvienban()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboManhanvienban.DisplayMember = "MA_DTPN";
            cboManhanvienban.ValueMember = "ID";
            cboManhanvienban.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboManhanvienban.DataSource = _KTDTPNRepo.GetAll();
            cboManhanvienban.SelectedIndex = -1;
        }
        private void cboManhanvienban_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }

        private void LoadTKNo()
        {
            _KTTKRepo = new KTTKRepo();
            
            cboTKNo.DisplayMember = "MA_TK";
            cboTKNo.ValueMember = "ID";
            cboTKNo.DropDownColumns = "MA_TK,TEN_TK";
            cboTKNo.DataSource = _KTTKRepo.GetAll();
            cboTKNo.SelectedIndex = -1;
        }
        private void cboTKNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadDTPNNo()
        {
            _KTDTPNRepo = new KTDTPNRepo();
            cboDTPNNo.DisplayMember = "MA_DTPN";
            cboDTPNNo.ValueMember = "ID";
            cboDTPNNo.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboDTPNNo.DataSource = _KTDTPNRepo.GetAll();
            cboDTPNNo.SelectedIndex = -1;
        }
        private void cboDTPNNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadYTCPNo()
        {
            _KTYTCPRepo = new KTYTCPRepo();
            cboYTCPNo.DisplayMember = "MA_YTCP";
            cboYTCPNo.ValueMember = "ID";
            cboYTCPNo.DropDownColumns = "MA_YTCP,TEN_YTCP_V";
            cboYTCPNo.DataSource = _KTYTCPRepo.GetAll();
            cboYTCPNo.SelectedIndex = -1;
        }
        private void cboYTCPNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_YTCP")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadVTHHNo()
        {
            _KTDMHHRepo = new KTDMHHRepo();
            cboVTHHNo.DisplayMember = "MA_DM";
            cboVTHHNo.ValueMember = "ID";
            cboVTHHNo.DropDownColumns = "MA_DM,TEN_DM";
            cboVTHHNo.DataSource = _KTDMHHRepo.GetAll();
            cboVTHHNo.SelectedIndex = -1;
        }
        private void cboVTHHNo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DM")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }

        private void LoadTKCo()
        {
            _KTTKRepo = new KTTKRepo();
            cboTKCo.DisplayMember = "MA_TK";
            cboTKCo.ValueMember = "ID";
            cboTKCo.DropDownColumns = "MA_TK,TEN_TK";
            cboTKCo.DataSource = _KTTKRepo.GetAll();
            cboTKCo.SelectedIndex = -1;
        }
        private void cboTKCo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_TK")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadDTPNCo()
        {
            _KTDTPNRepo = new KTDTPNRepo();            
            cboDTPNCo.DisplayMember = "MA_DTPN";
            cboDTPNCo.ValueMember = "ID";
            cboDTPNCo.DropDownColumns = "MA_DTPN,TEN_DTPN";
            cboDTPNCo.DataSource = _KTDTPNRepo.GetAll();
            cboDTPNCo.SelectedIndex = -1;
        }
        private void cboDTPNCo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DTPN")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadYTCPCo()
        {
            _KTYTCPRepo = new KTYTCPRepo();
            cboYTCPCo.DisplayMember = "MA_YTCP";
            cboYTCPCo.ValueMember = "ID";
            cboYTCPCo.DropDownColumns = "MA_YTCP,TEN_YTCP_V";
            cboYTCPCo.DataSource = _KTYTCPRepo.GetAll();
            cboYTCPCo.SelectedIndex = -1;
        }
        private void cboYTCPCo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_YTCP")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        private void LoadVTHHCo()
        {
            _KTDMHHRepo = new KTDMHHRepo();
            cboVTHHCo.DisplayMember = "MA_DM";
            cboVTHHCo.ValueMember = "ID";
            cboVTHHCo.DropDownColumns = "MA_DM,TEN_DM";
            cboVTHHCo.DataSource = _KTDMHHRepo.GetAll();
            cboVTHHCo.SelectedIndex = -1;
        }
        private void cboVTHHCo_DataColumnCreated(object sender, DevComponents.DotNetBar.Controls.DataColumnEventArgs e)
        {
            DevComponents.AdvTree.ColumnHeader header = e.ColumnHeader;
            if (header.DataFieldName == "MA_DM")
            {
                header.Width.Relative = 30; // 20% of available width
            }
            else
            {
                header.Width.Relative = 70;
            }
        }
        #endregion

        #region cbo change
        public int tek = 0;
        //private void cboLoaiCTu_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //tek++;
        //    //if (cboLoaiCTu.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    EnableCtr(cboLoaiCTu.Text);
        //    //    _KT_CTuGocRepo = new KT_CTuGocRepo();
        //    //    gridControl1.DataSource = _KT_CTuGocRepo.GetByMaCT(Utils.CStrDef(cboLoaiCTu.SelectedValue, ""), Utils.CIntDef(fTerm._month, 0), Utils.CIntDef(fTerm._year, 0), "");
        //    //}
        //}
        //private void cboTKNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboTKNo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTTKRepo = new KTTKRepo();
        //    //    var item = _KTTKRepo.GetById(Utils.CIntDef(cboTKNo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtTKNo.Text = item.TEN_TK;
        //    //}
        //}
        //private void cboDTPNNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboDTPNNo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTDTPNRepo = new KTDTPNRepo();
        //    //    var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNNo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtDTPNNo.Text = item.TEN_DTPN;
        //    //}
        //}
        //private void cboYTCPNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboYTCPNo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTYTCPRepo = new KTYTCPRepo();
        //    //    var item = _KTYTCPRepo.GetById(Utils.CIntDef(cboYTCPNo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtYTCPNo.Text = item.TEN_YTCP_V;
        //    //}
        //}
        //private void cboVTHHNo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboVTHHNo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTDMHHRepo = new KTDMHHRepo();
        //    //    var item = _KTDMHHRepo.GetById(Utils.CIntDef(cboVTHHNo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtVTHHNo.Text = item.TEN_DM;
        //    //}
        //}
        //private void cboTKCo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboTKCo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTTKRepo = new KTTKRepo();
        //    //    var item = _KTTKRepo.GetById(Utils.CIntDef(cboTKCo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtTKCo.Text = item.TEN_TK;
        //    //}
        //}
        //private void cboDTPNCo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboDTPNCo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTDTPNRepo = new KTDTPNRepo();
        //    //    var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNCo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtDTPNCo.Text = item.TEN_DTPN;
        //    //}
        //}
        //private void cboYTCPCo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboYTCPCo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTYTCPRepo = new KTYTCPRepo();
        //    //    var item = _KTYTCPRepo.GetById(Utils.CIntDef(cboYTCPCo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtYTCPCo.Text = item.TEN_YTCP_V;
        //    //}
        //}
        //private void cboVTHHCo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (cboVTHHCo.SelectedIndex > -1 && tek > 2)
        //    //{
        //    //    _KTDMHHRepo = new KTDMHHRepo();
        //    //    var item = _KTDMHHRepo.GetById(Utils.CIntDef(cboVTHHCo.SelectedValue, 0));
        //    //    if (item != null)
        //    //        txtVTHHCo.Text = item.TEN_DM;
        //    //}
        //}
        private void cboMakhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVTHHCo.SelectedIndex > -1 && tek > 2)
            {
                _KTDTPNRepo = new KTDTPNRepo();
                var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboMakhachhang.SelectedValue, 0));
                if (item != null)
                {
                    txtTenkhachhang.Text = item.TEN_DTPN;
                    txtMasothue.Text = item.MA_SO_THUE;
                    txtDiachi.Text = item.DIA_CHI;
                }
            }
        }
        private void cboNguoigiaodich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNguoigiaodich.SelectedIndex > -1 && tek > 2)
            {
                _KTDTPNRepo = new KTDTPNRepo();
                var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboNguoigiaodich.SelectedValue, 0));
                if (item != null)
                {
                    txtTennguoigiaodich.Text = item.TEN_DTPN;
                    txtDiachiNGD.Text = item.DIA_CHI;
                }
            }
        }
        private void cboManhanvienban_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManhanvienban.SelectedIndex > -1 && tek > 2)
            {
                _KTDTPNRepo = new KTDTPNRepo();
                var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboManhanvienban.SelectedValue, 0));
                if (item != null)
                    txtTennhanvienban.Text = item.TEN_DTPN;
            }
        }
        private void cboLoaiCTuCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = _db.KT_CTuGocs.Where(u => u.MA_CTU == Utils.CStrDef(cboLoaiCTuCopy.SelectedValue, "")).Select(s => new
            {
                SO_CTU = s.SO_CTU,
            }).Distinct();
            cboSoCTuCopy.DisplayMember = "SO_CTU";
            cboSoCTuCopy.ValueMember = "SO_CTU";
            cboSoCTuCopy.DataSource = list;
            
        }
        #endregion

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colSTT) //colSTT là tên cột tạo số thứ tự
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }
        private void gridControl3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView3.Columns.Count; i++)
            {
                gridView3.Columns[i].MinWidth = 100;
            }
        }

        #region process
        private void LoadSTT()
        {
            if (_listCTuGoc != null)
                STT = _listCTuGoc.Count + 1;
            txtSTT.Text = STT.ToString();
        }
        private void EnableCtu(bool b)
        {
            cboLoaiCTu.Enabled = b;
            txtSoCTu.Enabled = b;
            dtpNgayCTu.Enabled = b;
        }
        private void EnableCtr(string s)
        {
            if (s == "")
            {
                #region false
                txtSoCTu.Visible = false;
                lbSoCTu.Visible = false;
                dtpNgayCTu.Visible = false;
                lbNgayCTu.Visible = false;
                cboDiengiai.Visible = false;
                lbDiengiai.Visible = false;
                cboMaTT.Visible = false;
                lbMaTT.Visible = false;
                cboMaHD.Visible = false;
                lbMaHD.Visible = false;
                txtKHMHD.Visible = false;
                lbKHMHD.Visible = false;
                txtSeriHD.Visible = false;
                lbSeriHD.Visible = false;
                cboSoHD.Visible = false;
                lbSoHD.Visible = false;
                dtpNgayHD.Visible = false;
                lbNgayHD.Visible = false;
                cboHDVat.Visible = false;
                lbHDVat.Visible = false;
                txtSTT.Visible = false;
                lbSTT.Visible = false;
                cboSoHopDong.Visible = false;
                lbSoHopDong.Visible = false;
                cboCongtrinh.Visible = false;
                lbCongtrinh.Visible = false;
                grpNoCo.Visible = false;
                grpSoducuoingay.Visible = false;
                grpSoducuoithang.Visible = false;
                grpSoluongDongia.Visible = false;
                grpTHTT.Visible = false;
                btnNext.Visible = false;
                gridControl1.Visible = false;
                gridControl2.Visible = false;
                superTabItem2.Visible = false;
                superTabItem4.Visible = false;
                #endregion
            }
            else
            {
                #region true
                txtSoCTu.Visible = true;
                lbSoCTu.Visible = true;
                dtpNgayCTu.Visible = true;
                lbNgayCTu.Visible = true;
                cboDiengiai.Visible = true;
                lbDiengiai.Visible = true;
                cboMaHD.Visible = true;
                lbMaHD.Visible = true;                
                txtKHMHD.Visible = true;
                lbKHMHD.Visible = true;
                txtSeriHD.Visible = true;
                lbSeriHD.Visible = true;
                cboSoHD.Visible = true;
                lbSoHD.Visible = true;
                dtpNgayHD.Visible = true;
                lbNgayHD.Visible = true;
                cboHDVat.Visible = true;
                lbHDVat.Visible = true;
                txtSTT.Visible = true;
                lbSTT.Visible = true;
                grpNoCo.Visible = true;
                grpSoducuoingay.Visible = true;
                grpSoducuoithang.Visible = true;
                grpSoluongDongia.Visible = true;
                grpTHTT.Visible = true;
                btnNext.Visible = true;
                gridControl1.Visible = true;
                gridControl2.Visible = true;
                superTabItem2.Visible = true;
                superTabItem4.Visible = true;

                cboMaTT.Visible = true;
                lbMaTT.Visible = true;
                cboSoHopDong.Visible = true;
                lbSoHopDong.Visible = true;
                cboCongtrinh.Visible = true;
                lbCongtrinh.Visible = true;

                cboYTCPNo.Visible = true;
                lbYTCPNo.Visible = true;
                txtYTCPNo.Visible = true;
                txtYTCPDuNgay.Visible = true;
                txtYTCPDuThang.Visible = true;
                cboYTCPCo.Visible = true;
                lbYTCPCo.Visible = true;
                txtYTCPCo.Visible = true;
                txtYTCPDuNgayCo.Visible = true;
                txtYTCPDuThangCo.Visible = true;
                cboVTHHNo.Visible = true;
                lbVTHHNo.Visible = true;
                txtVTHHNo.Visible = true;
                txtVTHHDuNgay.Visible = true;
                txtVTHHDuThang.Visible = true;
                cboVTHHCo.Visible = true;
                lbVTHHCo.Visible = true;
                txtVTHHCo.Visible = true;
                txtVTHHDuNgayCo.Visible = true;
                txtVTHHDuThangCo.Visible = true;

                txtTygia.Visible = true;
                lbTygia.Visible = true;
                txtTienUsd.Visible = true;
                lbTienUsd.Visible = true;
                txtPTNK.Visible = true;
                lbPTNK.Visible = true;
                txtThueNK.Visible = true;
                lbThueNK.Visible = true;

                comboBoxEx9.Visible = true;
                txtSoluong.Visible = true;
                lbSoluong.Visible = true;
                txtDongia.Visible = true;
                lbDongia.Visible = true;
                txtTienVnd.Visible = true;
                lbTienVnd.Visible = true;
                txtTS.Visible = true;
                lbTS.Visible = true;
                txtTKThue.Visible = true;
                lbTKThue.Visible = true;
                txtTongtien.Visible = true;
                lbTongtien.Visible = true;
                #endregion

                switch (cboLoaiCTu.Text.ToUpper())
                {
                    case "BG":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "CNH":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "CTGS":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        break;
                    case "CTNH":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "DHB":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "DMH":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "HD":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "HDBR":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PBCP":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PC":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PCK":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PKT":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PKT02":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PNK":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PNKGC":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PNKNK":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;
                        break;
                    case "PNKNL":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PNKTP":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PT":
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PXK":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;

                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PXKGC":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;

                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "PXKNL":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;

                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "TNH":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "TTTU":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "UNC":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTS.Visible = false;
                        lbTS.Visible = false;
                        txtTKThue.Visible = false;
                        lbTKThue.Visible = false;
                        txtThueVND.Visible = false;
                        lbThueVND.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "VAT_R":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "VAT_V":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboVTHHNo.Visible = false;
                        lbVTHHNo.Visible = false;
                        txtVTHHNo.Visible = false;
                        txtVTHHDuNgay.Visible = false;
                        txtVTHHDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        comboBoxEx9.Visible = false;
                        txtSoluong.Visible = false;
                        lbSoluong.Visible = false;
                        txtDongia.Visible = false;
                        lbDongia.Visible = false;
                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    case "XGG":
                        cboMaTT.Visible = false;
                        lbMaTT.Visible = false;
                        cboSoHopDong.Visible = false;
                        lbSoHopDong.Visible = false;
                        cboCongtrinh.Visible = false;
                        lbCongtrinh.Visible = false;

                        cboYTCPNo.Visible = false;
                        lbYTCPNo.Visible = false;
                        txtYTCPNo.Visible = false;
                        txtYTCPDuNgay.Visible = false;
                        txtYTCPDuThang.Visible = false;
                        cboYTCPCo.Visible = false;
                        lbYTCPCo.Visible = false;
                        txtYTCPCo.Visible = false;
                        txtYTCPDuNgayCo.Visible = false;
                        txtYTCPDuThangCo.Visible = false;
                        cboVTHHCo.Visible = false;
                        lbVTHHCo.Visible = false;
                        txtVTHHCo.Visible = false;
                        txtVTHHDuNgayCo.Visible = false;
                        txtVTHHDuThangCo.Visible = false;

                        txtTygia.Visible = false;
                        lbTygia.Visible = false;
                        txtTienUsd.Visible = false;
                        lbTienUsd.Visible = false;
                        txtPTNK.Visible = false;
                        lbPTNK.Visible = false;
                        txtThueNK.Visible = false;
                        lbThueNK.Visible = false;
                        break;
                    default:
                        break;
                }
                #region
                //if (cboLoaiCTu.Text.ToUpper() == "BG")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "CNH")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "CTGS")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "CTNH")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "DHB")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "DMH")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "HD")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "HDBR")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PBCP")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PC")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PCK")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;
                                        
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PKT")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PKT02")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}                
                //if (cboLoaiCTu.Text.ToUpper() == "PNK")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PNKGC")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PNKNK")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;                                        
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PNKNL")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PNKTP")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PT")
                //{
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PXK")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;                    

                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PXKGC")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;

                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "PXKNL")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;

                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "TNH")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;                    
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;                    
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "TTTU")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "UNC")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTS.Visible = false;
                //    lbTS.Visible = false;
                //    txtTKThue.Visible = false;
                //    lbTKThue.Visible = false;
                //    txtThueVND.Visible = false;
                //    lbThueVND.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "VAT_R")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "VAT_V")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboVTHHNo.Visible = false;
                //    lbVTHHNo.Visible = false;
                //    txtVTHHNo.Visible = false;
                //    txtVTHHDuNgay.Visible = false;
                //    txtVTHHDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;

                //    comboBoxEx9.Visible = false;
                //    txtSoluong.Visible = false;
                //    lbSoluong.Visible = false;
                //    txtDongia.Visible = false;
                //    lbDongia.Visible = false;
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                //if (cboLoaiCTu.Text.ToUpper() == "XGG")
                //{
                //    cboMaTT.Visible = false;
                //    lbMaTT.Visible = false;
                //    cboSoHopDong.Visible = false;
                //    lbSoHopDong.Visible = false;
                //    cboCongtrinh.Visible = false;
                //    lbCongtrinh.Visible = false;

                //    cboYTCPNo.Visible = false;
                //    lbYTCPNo.Visible = false;
                //    txtYTCPNo.Visible = false;
                //    txtYTCPDuNgay.Visible = false;
                //    txtYTCPDuThang.Visible = false;
                //    cboYTCPCo.Visible = false;
                //    lbYTCPCo.Visible = false;
                //    txtYTCPCo.Visible = false;
                //    txtYTCPDuNgayCo.Visible = false;
                //    txtYTCPDuThangCo.Visible = false;
                //    cboVTHHCo.Visible = false;
                //    lbVTHHCo.Visible = false;
                //    txtVTHHCo.Visible = false;
                //    txtVTHHDuNgayCo.Visible = false;
                //    txtVTHHDuThangCo.Visible = false;
                                        
                //    txtTygia.Visible = false;
                //    lbTygia.Visible = false;
                //    txtTienUsd.Visible = false;
                //    lbTienUsd.Visible = false;
                //    txtPTNK.Visible = false;
                //    lbPTNK.Visible = false;
                //    txtThueNK.Visible = false;
                //    lbThueNK.Visible = false;
                //}
                #endregion
            }
        }
        private void LoadGrid2()
        {
            gridControl2.DataSource = null;
            gridControl2.DataSource = _listCTuGoc;
            gridControl2.RefreshDataSource();
            gridView2.RefreshData();
        }
        private void Tinhtien()
        {
            double? thanhtien = _listCTuGoc.Sum(n => n.THANH_TIEN_VND);
            double? tienthue = _listCTuGoc.Sum(n => n.TIEN_THUE_VND);
            double? tongcong = _listCTuGoc.Sum(n => n.TONG_TIEN_VND);
            txtTH.Text = string.Format("{0:###,##0}", thanhtien);
            txtTT.Text = string.Format("{0:###,##0}", tienthue);
            txtTC.Text = string.Format("{0:###,##0}", tongcong);
        }

        #endregion

        #region btn click
        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            superTabControl1.SelectedTab = superTabItem1;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cboLoaiCTu.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng từ!", "Thông báo");
                return;
            }
            if (txtSoCTu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập số chứng từ!", "Thông báo");
                return;
            }
            if (dtpNgayCTu.Value == null || dtpNgayCTu.Value.Month != Utils.CIntDef(fTerm._month, 0) || dtpNgayCTu.Value.Year != Utils.CIntDef(fTerm._year, 0))
            {
                MessageBox.Show("Ngày chứng từ không hợp lệ!", "Thông báo");
                return;
            }
            if (cboTKNo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn TK Nợ!", "Thông báo");
                return;
            }
            if (cboDTPNNo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn ĐTPN Nợ!", "Thông báo");
                return;
            }
            if (cboTKCo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn TK Có!", "Thông báo");
                return;
            }
            if (cboDTPNCo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn ĐTPN Có!", "Thông báo");
                return;
            }
            KT_CTuGoc CTGoc = new KT_CTuGoc();
            CTGoc.MA_CTU = Utils.CStrDef(cboLoaiCTu.SelectedValue, "");
            CTGoc.MA_TT = Utils.CStrDef(cboMaTT.SelectedValue, "");
            CTGoc.MA_HD = Utils.CStrDef(cboMaHD.SelectedValue, "");
            CTGoc.KY_HIEU_MAU_HD = Utils.CStrDef(txtKHMHD.Text, "");
            CTGoc.HD_SR = Utils.CStrDef(txtSeriHD.Text, "");
            CTGoc.HD_SO = Utils.CStrDef(cboSoHD.SelectedValue, "");
            DateTime? temp = null;
            if (Utils.CDateDef(dtpNgayHD.Value, DateTime.MinValue) != DateTime.MinValue)
                temp = Utils.CDateDef(dtpNgayHD.Value, DateTime.MinValue);
            CTGoc.HD_NGAY = temp;
            CTGoc.LOAI_THUE = Utils.CStrDef(cboHDVat.SelectedValue, "");
            CTGoc.SO_CTU = Utils.CStrDef(txtSoCTu.Text, "");
            temp = null;
            if (Utils.CDateDef(dtpNgayCTu.Value, DateTime.MinValue) != DateTime.MinValue)
                temp = Utils.CDateDef(dtpNgayCTu.Value, DateTime.MinValue);
            CTGoc.NGAY_CTU = temp;
            var itemDiengiai = _KTDIENGIAIRepo.GetById(Utils.CIntDef(cboDiengiai.SelectedValue, 0));
            if (itemDiengiai != null)
            {
                CTGoc.DIEN_GIAI = Utils.CStrDef(itemDiengiai.DIEN_GIAI1, "");
                CTGoc.DIEN_GIAI2 = Utils.CStrDef(itemDiengiai.DIEN_GIAI2, "");
            }
            CTGoc.SO_HOPDONG = Utils.CStrDef(cboSoHopDong.SelectedValue, "");
            var itemCongtrinh = _KTDMCongTrinhRepo.GetById(Utils.CIntDef(cboCongtrinh.SelectedValue, 0));
            if (itemCongtrinh != null)
            {
                CTGoc.MA_CTRINH = Utils.CStrDef(itemCongtrinh.MA_CT, "");
                CTGoc.TEN_CTRINH = Utils.CStrDef(itemCongtrinh.TEN_CT, "");
            }
            CTGoc.TK_NO = Utils.CStrDef(cboTKNo.Text, "");
            CTGoc.TK_CO = Utils.CStrDef(cboTKCo.Text, "");
            CTGoc.MA_DTPN_NO = Utils.CStrDef(cboDTPNNo.Text, "");
            CTGoc.MA_DTPN_CO = Utils.CStrDef(cboDTPNCo.Text, "");
            CTGoc.MA_YTCP_NO = Utils.CStrDef(cboYTCPNo.Text, "");
            CTGoc.MA_YTCP_CO = Utils.CStrDef(cboYTCPCo.Text, "");
            //CTGoc.MA_VTHH_NO = Utils.CStrDef(cboYTCPNo.SelectedText, "");
            //CTGoc.MA_VTHH_CO = Utils.CStrDef(cboYTCPCo.SelectedText, "");
            CTGoc.SO_LUONG = Utils.CDblDef(txtSoluong.Text.Replace(",", ""), 0);
            CTGoc.DON_GIA_VND = Utils.CDblDef(txtDongia.Text.Replace(",", ""), 0);
            CTGoc.THANH_TIEN_VND = Utils.CDblDef(txtTienVnd.Text.Replace(",", ""), 0) > 0 ? Utils.CDblDef(txtTienVnd.Text.Replace(",", ""), 0) : CTGoc.SO_LUONG * CTGoc.DON_GIA_VND;
            CTGoc.TS_GTGT = Utils.CStrDef(txtTS.Text, "");
            CTGoc.TK_THUE = Utils.CStrDef(txtTKThue.Text, "");
            double tienthue = (Utils.CDblDef(CTGoc.THANH_TIEN_VND, 0)* Utils.CIntDef(CTGoc.TS_GTGT, 0))/100;
            CTGoc.TIEN_THUE_VND = Utils.CDblDef(txtThueVND.Text.Replace(",", ""), 0) > 0 ? Utils.CDblDef(txtThueVND.Text.Replace(",", ""), 0) : tienthue;
            //CTGoc.TONG_TIEN_VND = Utils.CDblDef(txtTongtien.Text, 0);
            CTGoc.TONG_TIEN_VND = CTGoc.THANH_TIEN_VND + CTGoc.TIEN_THUE_VND;
            CTGoc.TY_GIA = Utils.CDblDef(txtTygia.Text.Replace(",", ""), 0);
            CTGoc.THANH_TIEN_USD = Utils.CDblDef(txtTienUsd.Text.Replace(",", ""), 0);
            CTGoc.TS_NK = Utils.CDblDef(txtPTNK.Text, 0);
            CTGoc.THUE_NK_USD = Utils.CDblDef(txtThueNK.Text.Replace(",", ""), 0);

            //Thông tin khách hàng
            CTGoc.MA_KH = cboMakhachhang.Text;
            CTGoc.TEN_KH = txtTenkhachhang.Text;
            CTGoc.MASO_THUE = txtMasothue.Text;
            CTGoc.DIA_CHI = txtDiachi.Text;
            CTGoc.MAT_HANG = txtMathang.Text;
            //CTGoc.GanMaDTPN = txtDiachi.Text;
            CTGoc.TEN_KH_GD = txtTennguoigiaodich.Text;
            CTGoc.DIA_CHI_NGD = txtDiachiNGD.Text;
            CTGoc.MA_NV_BAN = cboManhanvienban.Text;
            CTGoc.TEN_NV_BAN = txtTennhanvienban.Text;
            CTGoc.GHI_CHU = txtGhichu.Text;

            _listCTuGoc.Add(CTGoc);

            Tinhtien();
            EnableCtu(false);
            LoadGrid2();
            LoadSTT();
        }
        private void btnXemtruoc_Click(object sender, EventArgs e)
        {
            int month = -1;
            int year = -1;
            if (dtpNgayCTuCopy.Value != DateTime.MinValue)
            {
                month = dtpNgayCTuCopy.Value.Month;
                year = dtpNgayCTuCopy.Value.Year;
            }
            gridControl3.DataSource = _KT_CTuGocRepo.GetByMaCT(Utils.CStrDef(cboLoaiCTuCopy.SelectedValue, ""), month, year, cboSoCTuCopy.Text);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cboLoaiCTu.Text != cboLoaiCTuCopy.Text)
            {
                MessageBox.Show("Chọn loại chứng từ không hợp lệ!", "Thông báo");
                return;
            }
            int month = -1;
            int year = -1;
            if (dtpNgayCTuCopy.Value != DateTime.MinValue)
            {
                month = dtpNgayCTuCopy.Value.Month;
                year = dtpNgayCTuCopy.Value.Year;
            }
            var list = _KT_CTuGocRepo.GetByMaCTToList(Utils.CStrDef(cboLoaiCTuCopy.SelectedValue, ""), month, year, cboSoCTuCopy.Text);

            _listCTuGoc.AddRange(list);

            Tinhtien();
            cboLoaiCTu.Enabled = false;
            LoadGrid2();
            LoadSTT();
            superTabControl1.SelectedTab = superTabItem1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_listCTuGoc != null && _listCTuGoc.Count > 0)
            {
                _KT_CTuGocRepo = new KT_CTuGocRepo();
                _KT_CTuGocRepo.Create(_listCTuGoc);

                MessageBox.Show("Lưu thành công", "Thông báo");
                EnableCtu(true);
                _listCTuGoc = new List<KT_CTuGoc>();
                LoadGrid2();
                LoadSTT();
            }
        }
        #endregion 

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.F1)
            {

            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                btnSave_Click(null, null); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion        

        #region text changed
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            txtSoluong.Text = string.Format("{0:#,#}", Utils.CDecDef(txtSoluong.Text, 0));
            txtSoluong.SelectionStart = txtSoluong.Text.Length;
        }
        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            txtDongia.Text = string.Format("{0:#,#}", Utils.CDecDef(txtDongia.Text, 0));
            txtDongia.SelectionStart = txtDongia.Text.Length;

            int TienVnd = Utils.CIntDef(txtDongia.Text.Replace(",", ""), 0) * Utils.CIntDef(txtSoluong.Text.Replace(",", ""), 0);
            txtTienVnd.Text = string.Format("{0:#,#}", TienVnd);
        }
        private void txtTienVnd_TextChanged(object sender, EventArgs e)
        {
            txtTienVnd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtTienVnd.Text, 0));
            txtTienVnd.SelectionStart = txtTienVnd.Text.Length;

            int Dongia = Utils.CIntDef(txtTienVnd.Text.Replace(",", ""), 0) / Utils.CIntDef(txtSoluong.Text.Replace(",", ""), 0);
            txtDongia.Text = string.Format("{0:#,#}", Dongia);
        }

        private void txtThueVND_TextChanged(object sender, EventArgs e)
        {
            txtThueVND.Text = string.Format("{0:#,#}", Utils.CDecDef(txtThueVND.Text, 0));
            txtThueVND.SelectionStart = txtThueVND.Text.Length;
        }

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {
            txtTongtien.Text = string.Format("{0:#,#}", Utils.CDecDef(txtTongtien.Text, 0));
            txtTongtien.SelectionStart = txtTongtien.Text.Length;
        }

        private void txtTienUsd_TextChanged(object sender, EventArgs e)
        {
            txtTienUsd.Text = string.Format("{0:#,#}", Utils.CDecDef(txtTienUsd.Text, 0));
            txtTienUsd.SelectionStart = txtTienUsd.Text.Length;
        }
        #endregion

        #region cbo textchanged
        private void cboLoaiCTu_TextChanged(object sender, EventArgs e)
        {
            _KTLCTGRepo = new KTLCTGRepo();
            var list = _KTLCTGRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.ID_LOAI);
            }
            cboLoaiCTu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboLoaiCTu.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboLoaiCTu.AutoCompleteCustomSource = auto1;
        }
        private void cboTKNo_TextChanged(object sender, EventArgs e)
        {
            _KTTKRepo = new KTTKRepo();
            var list = _KTTKRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_TK);
            }
            cboTKNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTKNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTKNo.AutoCompleteCustomSource = auto1;
        }
        private void cboDTPNNo_TextChanged(object sender, EventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var list = _KTDTPNRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_DTPN);
            }
            cboDTPNNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDTPNNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDTPNNo.AutoCompleteCustomSource = auto1;
        }
        private void cboYTCPNo_TextChanged(object sender, EventArgs e)
        {
            _KTYTCPRepo = new KTYTCPRepo();
            var list = _KTYTCPRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_YTCP);
            }
            cboYTCPNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboYTCPNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboYTCPNo.AutoCompleteCustomSource = auto1;
        }
        private void cboVTHHNo_TextChanged(object sender, EventArgs e)
        {
            _KTDMHHRepo = new KTDMHHRepo();
            var list = _KTDMHHRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_DM);
            }
            cboVTHHNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboVTHHNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboVTHHNo.AutoCompleteCustomSource = auto1;
        }

        private void cboTKCo_TextChanged(object sender, EventArgs e)
        {
            _KTTKRepo = new KTTKRepo();
            var list = _KTTKRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_TK);
            }
            cboTKCo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTKCo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTKCo.AutoCompleteCustomSource = auto1;
        }
        private void cboDTPNCo_TextChanged(object sender, EventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var list = _KTDTPNRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_DTPN);
            }
            cboDTPNCo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDTPNCo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDTPNCo.AutoCompleteCustomSource = auto1;
        }
        private void cboYTCPCo_TextChanged(object sender, EventArgs e)
        {
            _KTYTCPRepo = new KTYTCPRepo();
            var list = _KTYTCPRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_YTCP);
            }
            cboYTCPCo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboYTCPCo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboYTCPCo.AutoCompleteCustomSource = auto1;
        }
        private void cboVTHHCo_TextChanged(object sender, EventArgs e)
        {
            _KTDMHHRepo = new KTDMHHRepo();
            var list = _KTDMHHRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_DM);
            }
            cboVTHHCo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboVTHHCo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboVTHHCo.AutoCompleteCustomSource = auto1;
        }
        private void cboMaTT_TextChanged(object sender, EventArgs e)
        {
            _KTMaTTRepo = new KTMaTTRepo();
            var list = _KTMaTTRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.KY_HIEU);
            }
            cboMaTT.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMaTT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboMaTT.AutoCompleteCustomSource = auto1;
        }
        private void cboMaHD_TextChanged(object sender, EventArgs e)
        {
            _KTMaHDRepo = new KTMaHDRepo();
            var list = _KTMaHDRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.KY_HIEU);
            }
            cboMaHD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMaHD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboMaHD.AutoCompleteCustomSource = auto1;
        }
        private void cboSoHD_TextChanged(object sender, EventArgs e)
        {
            _KTDMHoaDonRepo = new KTDMHoaDonRepo();
            var list = _KTDMHoaDonRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.SO_HD);
            }
            cboSoHD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSoHD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboSoHD.AutoCompleteCustomSource = auto1; 
        }
        private void cboHDVat_TextChanged(object sender, EventArgs e)
        {
            //_KTDMHoaDonRepo = new KTDMHoaDonRepo();
            //var list = _KTDMHoaDonRepo.GetAllToList();
            //AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            //foreach (var item in list)
            //{
            //    auto1.Add(item.SO_HD);
            //}
            //cboHDVat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cboHDVat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cboHDVat.AutoCompleteCustomSource = auto1; 
        }
        private void cboSoHopDong_TextChanged(object sender, EventArgs e)
        {
            _KTCNHopDongRepo = new KTCNHopDongRepo();
            var list = _KTCNHopDongRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.SO_HD);
            }
            cboSoHopDong.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboSoHopDong.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboSoHopDong.AutoCompleteCustomSource = auto1; 
        }
        private void cboCongtrinh_TextChanged(object sender, EventArgs e)
        {
            _KTDMCongTrinhRepo = new KTDMCongTrinhRepo();
            var list = _KTDMCongTrinhRepo.GetAllToList();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (var item in list)
            {
                auto1.Add(item.MA_CT);
            }
            cboCongtrinh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCongtrinh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboCongtrinh.AutoCompleteCustomSource = auto1; 
        }
        #endregion

        #region cbo keydown
        protected void cboLoaiCTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnableCtr(cboLoaiCTu.Text);
                _KT_CTuGocRepo = new KT_CTuGocRepo();
                gridControl1.DataSource = _KT_CTuGocRepo.GetByMaCT(Utils.CStrDef(cboLoaiCTu.SelectedValue, ""), Utils.CIntDef(fTerm._month, 0), Utils.CIntDef(fTerm._year, 0), "");

                #region move_focus
                TextBox[] arrTxt = { txtSeriHD };
                ComboBox[] arrCbo = { cboMaTT, cboMaHD };
                next_focus(arrTxt, arrCbo, 2);
                #endregion
            }
        }
        private void cboTKNo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTTKRepo = new KTTKRepo();
            var item = _KTTKRepo.GetById(Utils.CIntDef(cboTKNo.SelectedValue, 0));
            if (item != null)
                txtTKNo.Text = item.TEN_TK;
        }
        private void cboDTPNNo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNNo.SelectedValue, 0));
            if (item != null)
                txtDTPNNo.Text = item.TEN_DTPN;
        }
        private void cboYTCPNo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTYTCPRepo = new KTYTCPRepo();
            var item = _KTYTCPRepo.GetById(Utils.CIntDef(cboYTCPNo.SelectedValue, 0));
            if (item != null)
                txtYTCPNo.Text = item.TEN_YTCP_V;
        }
        private void cboVTHHNo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTDMHHRepo = new KTDMHHRepo();
            var item = _KTDMHHRepo.GetById(Utils.CIntDef(cboVTHHNo.SelectedValue, 0));
            if (item != null)
                txtVTHHNo.Text = item.TEN_DM;
        }
        private void cboMaHD_KeyDown(object sender, KeyEventArgs e)
        {
            #region move_focus
            TextBox[] arrTxt = { txtKHMHD, txtSeriHD };
            next_focus(arrTxt, null, 1);
            #endregion
        }
        private void cboTKCo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTTKRepo = new KTTKRepo();
            var item = _KTTKRepo.GetById(Utils.CIntDef(cboTKCo.SelectedValue, 0));
            if (item != null)
                txtTKCo.Text = item.TEN_TK;
        }
        private void cboDTPNCo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTDTPNRepo = new KTDTPNRepo();
            var item = _KTDTPNRepo.GetById(Utils.CIntDef(cboDTPNCo.SelectedValue, 0));
            if (item != null)
                txtDTPNCo.Text = item.TEN_DTPN;
        }
        private void cboYTCPCo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTYTCPRepo = new KTYTCPRepo();
            var item = _KTYTCPRepo.GetById(Utils.CIntDef(cboYTCPCo.SelectedValue, 0));
            if (item != null)
                txtYTCPCo.Text = item.TEN_YTCP_V;
        }
        private void cboVTHHCo_KeyDown(object sender, KeyEventArgs e)
        {
            _KTDMHHRepo = new KTDMHHRepo();
            var item = _KTDMHHRepo.GetById(Utils.CIntDef(cboVTHHCo.SelectedValue, 0));
            if (item != null)
                txtVTHHCo.Text = item.TEN_DM;
        }
        #endregion

        #region txt keydown
        private void txtKHMHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox[] arrTxt = { txtSeriHD};
                ComboBox[] arrCbo = { cboSoHD };
                next_focus(arrTxt, arrCbo, 1);
            }
        }
        private void txtSeriHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox[] arrCbo = { cboSoHD };
                next_focus(null, arrCbo, 2);
            }
        }
        #endregion

        #region funtion
        private void next_focus(TextBox[] arrTxt, ComboBox[] arrCbo, int pri)
        {//pri-1-Textbox/pri-2-Combobox
            if (pri == 1)
            {
                if (txt_focus(arrTxt) != true)
                    cbo_focus(arrCbo);
            }
            else
            {
                if (cbo_focus(arrCbo) != true)
                    txt_focus(arrTxt);
            }
        }
        private bool txt_focus(TextBox[] arrTxt)
        {
            if (arrTxt != null)
            {
                int countTxt = arrTxt.Count();
                for (int i = 0; i < countTxt; i++)
                {
                    TextBox txt = arrTxt[i];
                    if (txt.Visible == true && txt.Enabled == true)
                    {
                        txt.Focus();
                        return true;
                    }
                }
            }
            return false;
        }
        private bool cbo_focus(ComboBox[] arrCbo)
        {
            if (arrCbo != null)
            {
                int countCbo = arrCbo.Count();
                for (int i = 0; i < countCbo; i++)
                {
                    ComboBox cbo = arrCbo[i];
                    if (cbo.Visible == true && cbo.Enabled)
                    {
                        cbo.Focus();
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}