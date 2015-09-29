using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app
{
    public partial class fMain : DevComponents.DotNetBar.OfficeForm
    {
        public fMain()
        {
            InitializeComponent();
        }

        #region Form function
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                MessageBox.Show("Bạn phải đóng tất cả form con trước khi đóng form main!", "Thông báo", MessageBoxButtons.OK);
                e.Cancel = true;
            }
            base.OnFormClosing(e);
            if (!e.Cancel)
            {
                if (MessageBox.Show("Bạn có muốn đóng form Main không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    //foreach (Form frm in this.MdiChildren)
                    //{
                    //    frm.Close();
                    //}
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region showForm
        #region nhập phát sinh->bàn làm việc
        private void showForm_SoChungTuGoc()
        {
            if (Unit.IsFormActived("SoChungTuGoc")) return;

            SoChungTuGoc _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoChungTuGoc();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region nhập phát sinh->khai báo thông tin
        private void showForm_CaiThongSo()
        {
            if (Unit.IsFormActived("CaiThongSo")) return;

            CaiThongSo _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new CaiThongSo();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoCacTuyChonRieng()
        {
            if (Unit.IsFormActived("KhaiBaoCacTuyChonRieng")) return;

            KhaiBaoCacTuyChonRieng _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoCacTuyChonRieng();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoChoHoTroKeKhai()
        {
            if (Unit.IsFormActived("KhaiBaoChoHoTroKeKhai")) return;

            KhaiBaoChoHoTroKeKhai _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoChoHoTroKeKhai();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region nhập phát sinh->quản lý đơn hàng
        private void showForm_ChiTietDonMuaHang()
        {
            if (Unit.IsFormActived("ChiTietDonMuaHang")) return;

            ChiTietDonMuaHang _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new ChiTietDonMuaHang();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region hệ thống danh mục->danh mục chung
        private void showForm_DanhMucTaiKhoan()
        {
            if (Unit.IsFormActived("DanhMucTaiKhoan")) return;

            DanhMucTaiKhoan _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucTaiKhoan();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucCacLoaiChungTu()
        {
            if (Unit.IsFormActived("DanhMucCacLoaiChungTu")) return;

            DanhMucCacLoaiChungTu _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucCacLoaiChungTu();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DoiTuongPhapNhan()
        {
            if (Unit.IsFormActived("DoiTuongPhapNhan")) return;

            DoiTuongPhapNhan _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DoiTuongPhapNhan();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucDienGiai()
        {
            if (Unit.IsFormActived("DanhMucDienGiai")) return;

            DanhMucDienGiai _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucDienGiai();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucCongTrinh()
        {
            if (Unit.IsFormActived("DanhMucCongTrinh")) return;

            DanhMucCongTrinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucCongTrinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucKheUoc()
        {
            if (Unit.IsFormActived("DanhMucKheUoc")) return;

            DanhMucKheUoc _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucKheUoc();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucSoHoaDon()
        {
            if (Unit.IsFormActived("DanhMucSoHoaDon")) return;

            DanhMucSoHoaDon _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucSoHoaDon();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucCauthanhSP()
        {
            if (Unit.IsFormActived("CauThanhSanPham")) return;

            CauThanhSanPham _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new CauThanhSanPham();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucNhomHH()
        {
            if (Unit.IsFormActived("DanhMucNhomHH")) return;

            DanhMucNhomHH _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucNhomHH();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region hệ thống danh mục->hàng hóa chung
        private void showForm_DanhMucHangHoaChung()
        {
            if (Unit.IsFormActived("DanhMucHangHoaChung")) return;

            DanhMucHangHoaChung _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucHangHoaChung();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucHangHoaTheoKho()
        {
            if (Unit.IsFormActived("DanhMucHangHoaTheoKho")) return;

            DanhMucHangHoaTheoKho _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucHangHoaTheoKho();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoDonGiaBanTheoVung()
        {
            if (Unit.IsFormActived("KhaiBaoDonGiaBanTheoVung")) return;

            KhaiBaoDonGiaBanTheoVung _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoDonGiaBanTheoVung();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucVatTuHangHoaTheoLo()
        {
            if (Unit.IsFormActived("DanhMucVatTuHangHoaTheoLo")) return;

            DanhMucVatTuHangHoaTheoLo _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucVatTuHangHoaTheoLo();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoDonGiaBanTheoNhomDoiTuong()
        {
            if (Unit.IsFormActived("KhaiBaoDonGiaBanTheoNhomDoiTuong")) return;

            KhaiBaoDonGiaBanTheoNhomDoiTuong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoDonGiaBanTheoNhomDoiTuong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucLenhSanXuat()
        {
            if (Unit.IsFormActived("DanhMucLenhSanXuat")) return;

            DanhMucLenhSanXuat _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucLenhSanXuat();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_ChiTietLenhSanXuat()
        {
            if (Unit.IsFormActived("ChiTietLenhSanXuat")) return;

            ChiTietLenhSanXuat _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new ChiTietLenhSanXuat();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DonGiaBanTheoHangHoaVaNgayApDung()
        {
            if (Unit.IsFormActived("DonGiaBanTheoHangHoaVaNgayApDung")) return;

            DonGiaBanTheoHangHoaVaNgayApDung _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DonGiaBanTheoHangHoaVaNgayApDung();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region hệ thống danh mục->công nợ
        private void showForm_SoCongNoTheoDoiTuong()
        {
            if (Unit.IsFormActived("SoCongNoTheoDoiTuong")) return;

            SoCongNoTheoDoiTuong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoDoiTuong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoCongTrinh()
        {
            if (Unit.IsFormActived("SoCongNoTheoCongTrinh")) return;

            SoCongNoTheoCongTrinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoCongTrinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoTungHoaDon()
        {
            if (Unit.IsFormActived("SoCongNoTheoTungHoaDon")) return;

            SoCongNoTheoTungHoaDon _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoTungHoaDon();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoHopDong()
        {
            if (Unit.IsFormActived("SoCongNoTheoHopDong")) return;

            SoCongNoTheoHopDong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoHopDong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoDoiTuongVaChungTu()
        {
            if (Unit.IsFormActived("SoCongNoTheoDoiTuongVaChungTu")) return;

            SoCongNoTheoDoiTuongVaChungTu _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoDoiTuongVaChungTu();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoHopDongVaHangHoa()
        {
            if (Unit.IsFormActived("SoCongNoTheoHopDongVaHangHoa")) return;

            SoCongNoTheoHopDongVaHangHoa _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoHopDongVaHangHoa();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoCongTrinhVaDotThanhToan()
        {
            if (Unit.IsFormActived("SoCongNoTheoCongTrinhVaDotThanhToan")) return;

            SoCongNoTheoCongTrinhVaDotThanhToan _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoCongTrinhVaDotThanhToan();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoCongNoTheoKheUocVay()
        {
            if (Unit.IsFormActived("SoCongNoTheoKheUocVay")) return;

            SoCongNoTheoKheUocVay _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoCongNoTheoKheUocVay();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region hệ thống danh mục->chi phí
        private void showForm_DanhMucYeuToChiPhi()
        {
            if (Unit.IsFormActived("DanhMucYeuToChiPhi")) return;

            DanhMucYeuToChiPhi _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucYeuToChiPhi();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoTheoDoiChiPhiTheoBoPhan()
        {
            if (Unit.IsFormActived("SoTheoDoiChiPhiTheoBoPhan")) return;

            SoTheoDoiChiPhiTheoBoPhan _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoTheoDoiChiPhiTheoBoPhan();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_SoTongHopChiPhiTheoCongTrinh()
        {
            if (Unit.IsFormActived("SoTongHopChiPhiTheoCongTrinh")) return;

            SoTongHopChiPhiTheoCongTrinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new SoTongHopChiPhiTheoCongTrinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region báo cáo tài chính->khai báo
        private void showForm_KhaiBaoCanDoiKeToan()
        {
            if (Unit.IsFormActived("KhaiBaoCanDoiKeToan")) return;

            KhaiBaoCanDoiKeToan _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoCanDoiKeToan();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoKetQuaKinhDoanh()
        {
            if (Unit.IsFormActived("KhaiBaoKetQuaKinhDoanh")) return;

            KhaiBaoKetQuaKinhDoanh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoKetQuaKinhDoanh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoLuuChuyenTienTeTT()
        {
            if (Unit.IsFormActived("KhaiBaoLuuChuyenTienTeTT")) return;

            KhaiBaoLuuChuyenTienTeTT _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoLuuChuyenTienTeTT();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoLuuChuyenTienTeGT()
        {
            if (Unit.IsFormActived("KhaiBaoLuuChuyenTienTeGT")) return;

            KhaiBaoLuuChuyenTienTeGT _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoLuuChuyenTienTeGT();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoThuyetMinh()
        {
            if (Unit.IsFormActived("KhaiBaoThuyetMinh")) return;

            KhaiBaoThuyetMinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoThuyetMinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoKetQuaKinhDoanhPT()
        {
            if (Unit.IsFormActived("KhaiBaoKetQuaKinhDoanhPT")) return;

            KhaiBaoKetQuaKinhDoanhPT _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoKetQuaKinhDoanhPT();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region công trình->khai báo cho công trình
        private void showForm_XemBangKhaiBaoTyLeDePhanBoChiPhi()
        {
            if (Unit.IsFormActived("XemBangKhaiBaoTyLeDePhanBoChiPhi")) return;

            XemBangKhaiBaoTyLeDePhanBoChiPhi _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new XemBangKhaiBaoTyLeDePhanBoChiPhi();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_XemBangPhanBoChiPhiChung()
        {
            if (Unit.IsFormActived("XemBangPhanBoChiPhiChung")) return;

            XemBangPhanBoChiPhiChung _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new XemBangPhanBoChiPhiChung();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucCongTrinhVaThanhPham()
        {
            if (Unit.IsFormActived("DanhMucCongTrinhVaThanhPham")) return;

            DanhMucCongTrinhVaThanhPham _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucCongTrinhVaThanhPham();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region công trình->xử lý giá thành
        private void showForm_BangGiaThanhCongTrinhGopCaNam()
        {
            if (Unit.IsFormActived("BangGiaThanhCongTrinhGopCaNam")) return;

            BangGiaThanhCongTrinhGopCaNam _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new BangGiaThanhCongTrinhGopCaNam();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_BangGiaThanhCongTrinh()
        {
            if (Unit.IsFormActived("BangGiaThanhCongTrinh")) return;

            BangGiaThanhCongTrinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new BangGiaThanhCongTrinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region tài sản cố định->tài sản cố định
        private void showForm_DanhMucTaiSanCoDinh()
        {
            if (Unit.IsFormActived("DanhMucTaiSanCoDinh")) return;

            DanhMucTaiSanCoDinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucTaiSanCoDinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_BangKhauHaoTaiSanCoDinh()
        {
            if (Unit.IsFormActived("BangKhauHaoTaiSanCoDinh")) return;

            BangKhauHaoTaiSanCoDinh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new BangKhauHaoTaiSanCoDinh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region tài sản cố định->chi phí chờ phân bổ
        private void showForm_DanhMucChiPhiChoPhanBo()
        {
            if (Unit.IsFormActived("DanhMucChiPhiChoPhanBo")) return;

            DanhMucChiPhiChoPhanBo _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucChiPhiChoPhanBo();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_BangChiPhiChoPhanBoSauKhiXuLy()
        {
            if (Unit.IsFormActived("BangChiPhiChoPhanBoSauKhiXuLy")) return;

            BangChiPhiChoPhanBoSauKhiXuLy _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new BangChiPhiChoPhanBoSauKhiXuLy();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region tài sản cố định->lương thời vụ
        private void showForm_DanhSachCongNhanLuongThoiVu()
        {
            if (Unit.IsFormActived("DanhSachCongNhanLuongThoiVu")) return;

            DanhSachCongNhanLuongThoiVu _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhSachCongNhanLuongThoiVu();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_TongHopLuongThoiVu()
        {
            if (Unit.IsFormActived("TongHopLuongThoiVu")) return;

            TongHopLuongThoiVu _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new TongHopLuongThoiVu();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region quản lý lương->xử lý lương
        private void showForm_DanhMucNhanVien()
        {
            if (Unit.IsFormActived("DanhMucNhanVien")) return;

            DanhMucNhanVien _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucNhanVien();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_ChamCong()
        {
            if (Unit.IsFormActived("ChamCong")) return;

            ChamCong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new ChamCong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_TienUngLuong()
        {
            if (Unit.IsFormActived("TienUngLuong")) return;

            TienUngLuong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new TienUngLuong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_DanhMucBangLuong()
        {
            if (Unit.IsFormActived("DanhMucBangLuong")) return;

            DanhMucBangLuong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucBangLuong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_CongThucTinhLuong()
        {
            if (Unit.IsFormActived("CongThucTinhLuong")) return;

            CongThucTinhLuong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new CongThucTinhLuong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoMaTinhNgayCong()
        {
            if (Unit.IsFormActived("KhaiBaoMaNgayCong")) return;

            KhaiBaoMaTinhNgayCong _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoMaTinhNgayCong();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_KhaiBaoNgayLe()
        {
            if (Unit.IsFormActived("KhaiBaoNgayLe")) return;

            KhaiBaoNgayLe _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new KhaiBaoNgayLe();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        #region quản lý bảo hành->bảo hành
        private void showForm_DanhMucBaoHanh()
        {
            if (Unit.IsFormActived("DanhMucBaoHanh")) return;

            DanhMucBaoHanh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new DanhMucBaoHanh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        private void showForm_BangTongHopBaoHanh()
        {
            if (Unit.IsFormActived("BangTongHopBaoHanh")) return;

            BangTongHopBaoHanh _from = null;
            if (_from == null || _from.IsDisposed)
            {
                _from = new BangTongHopBaoHanh();
                _from.MdiParent = this;
                _from.Show();
            }
            else
            {
                _from.Activate();
            }
        }
        #endregion
        private void showForm(int iform)
        {
            switch (iform) 
            {
                case Const.CAIDATTHONGSO: showForm_CaiThongSo(); break;
                case Const.KHAIBAOCACTUYCHONRIENG: showForm_KhaiBaoCacTuyChonRieng(); break;
                case Const.KHAIBAOCHOHOTROKEKHAI: showForm_KhaiBaoChoHoTroKeKhai(); break;
                case Const.DANHMUCTAIKHOAN: showForm_DanhMucTaiKhoan(); break;
                case Const.DANHMUCCACLOAICHUNGTU: showForm_DanhMucCacLoaiChungTu(); break;
                case Const.DOITUONGPHAPNHAN: showForm_DoiTuongPhapNhan(); break;
                case Const.DANHMUCDIENGIAI: showForm_DanhMucDienGiai(); break;
                case Const.DANHMUCCACCONGTRINH: showForm_DanhMucCongTrinh(); break;
                case Const.DANHMUCCAUTHANHSANPHAM: showForm_DanhMucCauthanhSP(); break;
                case Const.DANHMUCKHEUOC: showForm_DanhMucKheUoc(); break;
                case Const.DANHMUCSOHOADON: showForm_DanhMucSoHoaDon(); break;
                case Const.HANGHOACHUNG: showForm_DanhMucHangHoaChung(); break;
                case Const.HANGHOATHEOKHO: showForm_DanhMucHangHoaTheoKho(); break;
                case Const.KHAIBAODONGIABANTHEOVUNG: showForm_KhaiBaoDonGiaBanTheoVung(); break;
                case Const.HANGHOATHEOLO: showForm_DanhMucVatTuHangHoaTheoLo(); break;
                case Const.KHAIBAODONGIABANTHEONHOMDOITUONG: showForm_KhaiBaoDonGiaBanTheoNhomDoiTuong(); break;
                case Const.DANHMUCLENHSANXUAT: showForm_DanhMucLenhSanXuat(); break;
                case Const.CHITIETLENHSANXUAT: showForm_ChiTietLenhSanXuat(); break;
                case Const.GIABANTHEOHANGHOAVANGAYAPDUNG: showForm_DonGiaBanTheoHangHoaVaNgayApDung(); break;
                case Const.THEODOITUONG: showForm_SoCongNoTheoDoiTuong(); break;
                case Const.THEOCONGTRINH: showForm_SoCongNoTheoCongTrinh(); break;
                case Const.THEOHOADON: showForm_SoCongNoTheoTungHoaDon(); break;
                case Const.THEOHOPDONG: showForm_SoCongNoTheoHopDong(); break;
                case Const.THEOCHUNGTUVANCHUYEN: showForm_SoCongNoTheoDoiTuongVaChungTu(); break;
                case Const.THEOHANGHOA: showForm_SoCongNoTheoHopDongVaHangHoa(); break;
                case Const.THEOCONGTRINHVADOTTHANHTOAN: showForm_SoCongNoTheoCongTrinhVaDotThanhToan(); break;
                case Const.THEOKHEUOCVAY: showForm_SoCongNoTheoKheUocVay(); break;
                case Const.YEUTOCHIPHI: showForm_DanhMucYeuToChiPhi(); break;
                case Const.SOTHEODOICHIPHITHEOBOPHAN: showForm_SoTheoDoiChiPhiTheoBoPhan(); break;
                case Const.SOTONGHOPCHIPHITHEOCONGTRINH: showForm_SoTongHopChiPhiTheoCongTrinh(); break;
                case Const.XEMBANGTYLEPHANBO: showForm_XemBangKhaiBaoTyLeDePhanBoChiPhi(); break;
                case Const.XEMBANGPHANBOCHIPHI: showForm_XemBangPhanBoChiPhiChung(); break;
                case Const.DANHMUCCONGTRINHVATHANHPHAM: showForm_DanhMucCongTrinhVaThanhPham(); break;
                case Const.BANGGIATHANHCONGTRINHVATHANHPHAM: showForm_BangGiaThanhCongTrinhGopCaNam(); break;
                case Const.BANGGIATHANHCONGTRINHSAUKHIXULYTHEOTHANG: showForm_BangGiaThanhCongTrinh(); break;
                case Const.DANHMUCTAISANCODINH: showForm_DanhMucTaiSanCoDinh(); break;
                case Const.SOCHUNGTUGOC: showForm_SoChungTuGoc(); break;
                case Const.CHITIETDONMUAHANG: showForm_ChiTietDonMuaHang(); break;
                case Const.BANGKHAUHAOTSCDSAUKHIXULY: showForm_BangKhauHaoTaiSanCoDinh(); break;
                case Const.DANHMUCCHIPHICHOPHANBO: showForm_DanhMucChiPhiChoPhanBo(); break;
                case Const.BANGCPCPBSAUKHIXULY: showForm_BangChiPhiChoPhanBoSauKhiXuLy(); break;
                case Const.DANHMUCNHANVIEN: showForm_DanhMucNhanVien(); break;
                case Const.CHAMCONG: showForm_ChamCong(); break;
                case Const.TIENUNGLUONG: showForm_TienUngLuong(); break;
                case Const.DANHMUCBANGLUONG: showForm_DanhMucBangLuong(); break;
                case Const.DANHSACHCONGNHANTHOIVU: showForm_DanhSachCongNhanLuongThoiVu(); break;
                case Const.TONGHOPLUONGCONGNHANTHEOCONGTRINH: showForm_TongHopLuongThoiVu(); break;
                case Const.DANHMUCBAOHANH: showForm_DanhMucBaoHanh(); break;
                case Const.BANGTONGHOPBAOHANH: showForm_BangTongHopBaoHanh(); break;
                case Const.CONGTHUCTINHLUONG: showForm_CongThucTinhLuong(); break;
                case Const.KHAIBAOMANGAYCONG: showForm_KhaiBaoMaTinhNgayCong(); break;
                case Const.KHAIBAOMANGAYLE: showForm_KhaiBaoNgayLe(); break;
                case Const.KHAIBAOCANDOIKETOAN: showForm_KhaiBaoCanDoiKeToan(); break;
                case Const.KHAIBAOKETQUAKINHDOANH: showForm_KhaiBaoKetQuaKinhDoanh(); break;
                case Const.KHAIBAOLUUCHUYENTIENTETT: showForm_KhaiBaoLuuChuyenTienTeTT(); break;
                case Const.KHAIBAOLUUCHUYENTIENTEGT: showForm_KhaiBaoLuuChuyenTienTeGT(); break;
                case Const.KHAIBAOTHUYETMINH: showForm_KhaiBaoThuyetMinh(); break;
                case Const.KHAIBAOKETQUAKINHDOANHPT: showForm_KhaiBaoKetQuaKinhDoanhPT(); break;
                case Const.DANHMUCNHOMHH: showForm_DanhMucNhomHH(); break;
            }
        }
        #endregion

        private void fMain_Load(object sender, EventArgs e)
        {
            try
            {
                showForm(fHome._IdAction);
            }
            catch (Exception) { }
        }

        #region buttonItem Click
        private void btnDanhmuctaikhoan_Click(object sender, EventArgs e)
        {
            showForm_DanhMucTaiKhoan();
        }
        private void btnDanhmuccacloaichungtu_Click(object sender, EventArgs e)
        {
            showForm_DanhMucCacLoaiChungTu();
        }
        private void btnDoituongphapnhan_Click(object sender, EventArgs e)
        {
            showForm_DoiTuongPhapNhan();
        }
        private void btnDanhmucdiengiai_Click(object sender, EventArgs e)
        {
            showForm_DanhMucDienGiai();
        }
        private void btnDanhmuccongtrinh_Click(object sender, EventArgs e)
        {
            showForm_DanhMucCongTrinh();
        }
        private void btnDMCauthanhSP_Click(object sender, EventArgs e)
        {
            showForm_DanhMucCongTrinh();
        }
        private void btnDanhmuckheuoc_Click(object sender, EventArgs e)
        {
            showForm_DanhMucKheUoc();
        }
        private void btnDMSoHD_Click(object sender, EventArgs e)
        {
            showForm_DanhMucSoHoaDon();
        }
        #endregion

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.Q && e.Control)
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion        


    }
}