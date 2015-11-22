using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Global;
using ketoansoft.app.UIs;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app
{
    public partial class fHome : DevComponents.DotNetBar.OfficeForm
    {
        public fHome()
        {
            InitializeComponent();
        }
        public static int _IdAction = 0;
        public fHome(int idAction)
        {
            idAction = _IdAction;
        }

        #region Form function
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (MessageBox.Show("Bạn có muốn đóng phần mềm không?", "Hỏi", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        private void Load_InfoBottom()
        {
            lblBottom_Month.Text = Utils.CStrDef(fTerm._month, "") + "/" + Utils.CStrDef(fTerm._year, "");
            lblBottomDatabase.Text = Unit.Get_DatabaseName();
            lblBottom_Company.Text = Unit.Get_CompanyName();
        }
        #endregion

        #region DoubleClick

        #region nhập phát sinh->bàn làm việc
        private void btnSoChungTuGoc_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.SOCHUNGTUGOC;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnNhapphatsinh_DoubleClick(object sender, EventArgs e)
        {
            NhapPhatSinh f = new NhapPhatSinh();
            f.Show();
        }
        private void btnXemSuaChungtu_DoubleClick(object sender, EventArgs e)
        {
            XemVaSuaChungTuGoc f = new XemVaSuaChungTuGoc();
            f.Show();
        }
        private void btnQuanTriDataNguoc_DoubleClick(object sender, EventArgs e)
        {
            QuanTriDataNguoc f = new QuanTriDataNguoc();
            f.Show();
        }
        #endregion

        #region nhập phát sinh->khai báo thông tin
        private void btnCfg_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.CAIDATTHONGSO;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaibaocactuychonrieng_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOCACTUYCHONRIENG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaibaochohotrokekhai_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOCHOHOTROKEKHAI;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region nhập phát sinh->quản lý đơn hàng
        private void btnChiTietDonMuaHang_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.CHITIETDONMUAHANG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region hệ thống danh mục->danh mục chung
        private void buttonItem14_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCTAIKHOAN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDMCauthanhSP_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCCAUTHANHSANPHAM;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void buttonItem15_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCCACLOAICHUNGTU;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDoituongphapnhan_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DOITUONGPHAPNHAN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void buttonItem22_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCDIENGIAI;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void buttonItem23_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCCACCONGTRINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDMKheuoc_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCKHEUOC;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }        
        private void btnDMSoHD_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCSOHOADON;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDanhMucNhomHH_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCNHOMHH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region hệ thống danh mục->hàng hóa chung
        private void btnHanghoachung_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.HANGHOACHUNG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnHanghoatheokho_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.HANGHOATHEOKHO;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaibaodongiabantheonhomvung_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAODONGIABANTHEOVUNG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnHanghoatheolo_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.HANGHOATHEOLO;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaibaodongiabantheonhomdoituong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAODONGIABANTHEONHOMDOITUONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDanhmuclenhsanxuat_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCLENHSANXUAT;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnChitietlenhsanxuat_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.CHITIETLENHSANXUAT;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnGiabantheohanghoavangayapdung_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.GIABANTHEOHANGHOAVANGAYAPDUNG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region hệ thống danh mục->công nợ
        private void btnTheodoituong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEODOITUONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheocongtrinh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOCONGTRINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheohoadon_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOHOADON;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheohopdong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOHOPDONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheochungtuvanchuyen_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOCHUNGTUVANCHUYEN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheohanghoa_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOHANGHOA;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheocongtrinhvadotthanhtoan_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOCONGTRINHVADOTTHANHTOAN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnTheokheuocvay_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.THEOKHEUOCVAY;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region hệ thống danh mục->chi phí
        private void btnYeutochiphi_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.YEUTOCHIPHI;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnSotheodoichiphitheobophan_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.SOTHEODOICHIPHITHEOBOPHAN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnSotonghopchiphitheocongtrinh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.SOTONGHOPCHIPHITHEOCONGTRINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region báo cáo tài chính->in báo cáo
        private void btnInCanDoiPhatSinhTaiKhoan_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            InCanDoiPhatSinhTaiKhoan f = new InCanDoiPhatSinhTaiKhoan();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region báo cáo tài chính->khai báo
        private void btnKhaiBaoCanDoiKeToan_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOCANDOIKETOAN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoKetQuaKinhDoanh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOKETQUAKINHDOANH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoLuuChuyenTT_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOLUUCHUYENTIENTETT;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoLuuChuyenGT_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOLUUCHUYENTIENTEGT;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoThuyetMinh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOTHUYETMINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoKetQuaPT_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOKETQUAKINHDOANHPT;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region công trình->khai báo cho công trình
        private void btnXembangtylephanbo_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.XEMBANGTYLEPHANBO;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnXembangphanbochiphi_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.XEMBANGPHANBOCHIPHI;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDanhmucCongtrinhvaThanhpham_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCCONGTRINHVATHANHPHAM;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region công trình->xử lý giá thành
        private void btnXuatkhotudongchocongtrinhtuPNK_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnKetchuyenchiphi621622623627sang154_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnPhanbochiphigiantiep_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnPhanbochiphitructiep_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnKetchuyengiavonnhieucongtrinh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnKetchuyengiavon1congtrinh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnXulygiathanhcongtrinh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnBanggiathanhcongtrinhsaukhixulytheothang_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.BANGGIATHANHCONGTRINHSAUKHIXULYTHEOTHANG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnGopbanggiathanhcongtrinhcanam_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnGopbanggiathanhcongtrinhtuthangdenthang_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnXulygiathanh1congtrinhconhieuthanhpham_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnXulygiathanhMacongtrinhlamathanhpham_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnBanggiathanhcongtrinhvaphanmem_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.BANGGIATHANHCONGTRINHVATHANHPHAM;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region tài sản cố định->tài sản cố định
        private void btnDanhmuctaisancodinh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCTAISANCODINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnXulykhauhao_DoubleClick(object sender, EventArgs e)
        {
            UIs.XuLyKhauHao f = new UIs.XuLyKhauHao();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnBangkhauhaoTSCDsaukhixuly_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.BANGKHAUHAOTSCDSAUKHIXULY;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnHachtoankhauhaovaoKTSC_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnInbangkhauhaoTSCD_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnCapnhatlaitudanhmucTSCDvaobangKHTSCD_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnThemTSCDvaodanhmucTSCD_DoubleClick(object sender, EventArgs e)
        {
            //_IdAction = Const.THEMTSCDVAODANHMUCTSCD;
            //fMain f = new fMain();
            //f.ShowDialog();
            //f.Dispose();
            ThemTSCD f = new ThemTSCD();
            f.Show();
        }

        private void btnGiamtaisancodinh_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Giảm tài sản cố định bằng hình thức nhập phát sinh. Bạn có thể dùng PKT!", "Thông báo");
            NhapPhatSinh f = new NhapPhatSinh();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region tài sản cố định->chi phí chờ phân bổ
        private void btnDanhmucchiphichophanbo_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCCHIPHICHOPHANBO;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnXulychiphichophanbo_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnBangCPCPBsaukhixuly_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.BANGCPCPBSAUKHIXULY;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnHachtoantrichchiphichophanbo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnInbangchiphichophanbo_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region tài sản cố định->lương thời vụ
        private void btnDanhsachcongnhanthoivu_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHSACHCONGNHANTHOIVU;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnInhopdonglaodongthoivu_DoubleClick(object sender, EventArgs e)
        {

        }
        private void btnTonghopluongcongnhantheocongtrinh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.TONGHOPLUONGCONGNHANTHEOCONGTRINH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnInbangluongthoivutheocongtrinh_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnInbangchamcongtheotungcongtrinh_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region công cụ tiện ích
        private void btnChuyenQuaThangKhac_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            fTerm f = new fTerm();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnChuyenSangDatabaseKhac_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            fLogin f = new fLogin();
            f.ShowDialog();
            f.Dispose();
        }
        private void buttonItem38_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            TaoDatabaseMoi f = new TaoDatabaseMoi();
            f.ShowDialog();
            f.Dispose();
        }
        private void buttonItem40_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            BackupDatabase f = new BackupDatabase();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnXuLyGiaVonLaiGop_DoubleClick(object sender, EventArgs e)
        {
            UIs.XuLyGiaVonLaiGop f = new UIs.XuLyGiaVonLaiGop();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region quản lý lương->xử lý lương
        private void btnDMNhanVien_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCNHANVIEN;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnChamCong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.CHAMCONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnTienUngLuong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.TIENUNGLUONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnBangLuongDaNhap_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCBANGLUONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnCongThucTinhLuong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.CONGTHUCTINHLUONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoMaTinhNgayCong_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOMANGAYCONG;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnKhaiBaoNgayLe_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.KHAIBAOMANGAYLE;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnLapBangChamCong_DoubleClick(object sender, EventArgs e)
        {
            UIs.LapBangChamCong f = new UIs.LapBangChamCong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnTinhSoNgayCong_DoubleClick(object sender, EventArgs e)
        {
            UIs.TinhSoNgayCong f = new UIs.TinhSoNgayCong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnBangUngLuong_DoubleClick(object sender, EventArgs e)
        {
            UIs.LapBangUngLuong f = new UIs.LapBangUngLuong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnHoachToanUngLuong_DoubleClick(object sender, EventArgs e)
        {
            UIs.HachToanUngLuong f = new UIs.HachToanUngLuong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnLapBangLuong_DoubleClick(object sender, EventArgs e)
        {
            UIs.LapBangLuong f = new UIs.LapBangLuong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnHachToanChiPhiLuong_DoubleClick(object sender, EventArgs e)
        {
            UIs.HachToanChiPhiLuong f = new UIs.HachToanChiPhiLuong();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnTraLuong_DoubleClick(object sender, EventArgs e)
        {
            UIs.HachToanTraTienLuong f = new UIs.HachToanTraTienLuong();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #region quản lý bảo hành->bảo hành
        private void btnDanhmucbaohanh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.DANHMUCBAOHANH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnBangtonghopbaohanh_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = Const.BANGTONGHOPBAOHANH;
            fMain f = new fMain();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnInsobaohanh_DoubleClick(object sender, EventArgs e)
        {

        }
        private void btnCapnhatthongtintusochungtugocvaodmbaohanh_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region sổ công nợ->theo đối tượng
        private void btnInsochitietcongnotheodoituong1_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            SOCTCN11 f = new SOCTCN11();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnInsochitietcongnotheodoituong2_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            SOCTCN19 f = new SOCTCN19();
            f.ShowDialog();
            f.Dispose();
        }
        private void buttonItem7_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            SOCTCN14 f = new SOCTCN14();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnXacnhancongno_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            SOCTCN21 f = new SOCTCN21();
            f.ShowDialog();
            f.Dispose();
        }
        private void btnDoichieucongno_DoubleClick(object sender, EventArgs e)
        {
            _IdAction = 112233;
            SOCTCN20 f = new SOCTCN20();
            f.ShowDialog();
            f.Dispose();
        }
        #endregion

        #endregion

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.Q && e.Control)
            {
                Application.Exit();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void fHome_Load(object sender, EventArgs e)
        {
            Load_InfoBottom();
        }

    }
}