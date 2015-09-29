using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;
using System.Data;

namespace ketoansoft.app.Class.Data
{
    public class KTBANGLUONGRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        Unit _unit = new Unit();

        public virtual KT_BANG_LUONG GetById(int id)
        {
            try
            {
                return this.db.KT_BANG_LUONGs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_BANG_LUONGs;
        }
        public virtual void Create(KT_BANG_LUONG user)
        {
            try
            {
                this.db.KT_BANG_LUONGs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_BANG_LUONG user)
        {
            try
            {
                KT_BANG_LUONG userOld = this.GetById(user.ID);
                userOld = user;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public virtual void Remove(int id)
        {
            try
            {
                KT_BANG_LUONG user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_BANG_LUONG user)
        {
            try
            {
                db.KT_BANG_LUONGs.DeleteOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(int id)
        {
            try
            {
                KT_BANG_LUONG user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_BANG_LUONG user)
        {
            try
            {
                //user.IsDelete = true;
                db.SubmitChanges();
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual double TongLuong(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.TONG_LUONG);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongLuongTN(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.LUONG_TN);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongBHXHCty(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.BHXH_CTY);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongBHYTCty(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.BHYT_CTY);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongBHXHNld(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.BHXH_NLD);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongBHYTNld(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.BHYT_NLD);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongBHTNNld(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.BHTN_NLD);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual List<KT_BANG_LUONG> DanhSachBangLuong(string nam, string thang)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                    && (u.THANG == thang || u.THANG == _thang)
                    && u.LUONG_TN > 0).ToList();
                if (obj.Count > 0)
                {
                    return obj;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public virtual DataTable LuongTheoPhongBan(string nam, string thang)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                DataTable dt = new DataTable();
                string lenh = String.Format("Select PHONG_BAN, TEN_PHONG_BAN, SUM(LUONG_TN) as TLuong From KT_BANG_LUONG Where THANG = {0} and NAM = {1} Group by PHONG_BAN, TEN_PHONG_BAN"
                    , thang, nam);
                dt = XLDLRepo.ReadData(lenh);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public virtual List<KT_BANG_LUONG> Check_PhongBan(string nam, string thang, string phongban)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_BANG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                    && (u.THANG == thang || u.THANG == _thang)
                    && u.PHONG_BAN == phongban).ToList();
                if (obj.Count > 0)
                {
                    return obj;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public virtual bool DeleteByPhongBan(List<KT_BANG_LUONG> l)
        {
            try
            {
                var obj = l;
                if (obj.Count > 0)
                {
                    db.KT_BANG_LUONGs.DeleteAllOnSubmit(obj);
                    db.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }
        public virtual bool InsertDuplicate(List<KT_NHANVIEN> cus, string nam, string thang, string loaibangluong)
        {
            try
            {
                //Khai báo Class
                KTCTLUONGRepo _KTCTLUONGRepo = new KTCTLUONGRepo();
                KTUNGLUONGRepo _KTUNGLUONGRepo = new KTUNGLUONGRepo();
                KTCHAMCONGRepo _KTCHAMCONGRepo = new KTCHAMCONGRepo();

                for (int i = 0; i < cus.Count; i++)
                {
                    //Công thức tính
                    double _tongLuong = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "TONG_LUONG", cus[i].ID);
                    double _bhxhNLD = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHXH_NLD", cus[i].ID);
                    double _bhxhCty = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHXH_CTY", cus[i].ID);
                    double _bhytNLD = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHYT_NLD", cus[i].ID);
                    double _bhytCty = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHYT_CTY", cus[i].ID);
                    double _bhtnNLD = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHTN_NLD", cus[i].ID);
                    double _bhtnCty = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "BHTN_CTY", cus[i].ID);
                    double _kpCD = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "KP_CD", cus[i].ID);
                    double _luongTN = _KTCTLUONGRepo.CongThucTinhLuongTN("KT_NHANVIEN", "LUONG_TN", cus[i].ID
                                    , Utils.CIntDef(thang, 0), Utils.CIntDef(nam, 0), _tongLuong, _bhxhNLD, _bhytNLD, _bhtnNLD);
                    //===========================//

                    db.KT_BANG_LUONGs.InsertOnSubmit(
                        new KT_BANG_LUONG
                        {
                            STT = cus[i].STT,
                            TEN_NV_VIET = cus[i].TEN_NV_VIET,
                            NAM = nam,
                            THANG = thang,
                            LOAI_BL = loaibangluong,
                            MA_NV = cus[i].MA_NV,
                            HSO_LUONG = cus[i].HSO_LUONG,
                            TK_LUONG = cus[i].TK_LUONG,
                            TK_CP_LUONG = cus[i].TK_CP_LUONG,
                            TK_KPCD = cus[i].TK_KPCD,
                            TK_BHXH = cus[i].TK_BHXH,
                            TK_BHYT = cus[i].TK_BHYT,
                            TK_BHTN = cus[i].TK_BHTN,
                            TK_TNCN = cus[i].TK_TNCN,
                            NGAY_CONG = _KTCHAMCONGRepo.getNgayCongByMaNV(nam, thang, cus[i].MA_NV).Count > 0 
                                    ? _KTCHAMCONGRepo.getNgayCongByMaNV(nam, thang, cus[i].MA_NV)[0] : 0,
                            NGAY_NGHI = _KTCHAMCONGRepo.getNgayCongByMaNV(nam, thang, cus[i].MA_NV).Count > 0
                                    ? _KTCHAMCONGRepo.getNgayCongByMaNV(nam, thang, cus[i].MA_NV)[1] : 0,
                            LUONG_CB = cus[i].LUONG_CB,
                            PC_CHUCVU = cus[i].PC_CHUCVU,
                            PC_TRACH_NHIEM = cus[i].PC_TRACH_NHIEM,
                            PC_AN = cus[i].PC_AN,
                            PC_THAM_NIEN = cus[i].PC_THAM_NIEN,
                            TONG_LUONG = _tongLuong,
                            BHXH_NLD = _bhxhNLD,
                            BHXH_CTY = _bhxhCty,
                            BHYT_NLD = _bhytNLD,
                            BHYT_CTY = _bhytCty,
                            BHTN_NLD = _bhtnNLD,
                            BHTN_CTY = _bhtnCty,
                            KP_CD = _kpCD,
                            LUONG_TN =  _unit.Round(_luongTN, -3),
                            TEN_NV_ANH = cus[i].TEN_NV_ANH,
                            TEN_NV_HOA = cus[i].TEN_NV_HOA,
                            NGAY_SINH = cus[i].NGAY_SINH,
                            GIOI_TINH = cus[i].GIOI_TINH,
                            NOI_SINH = cus[i].NOI_SINH,
                            QUOC_GIA = cus[i].QUOC_GIA,
                            TINH_TP = cus[i].TINH_TP,
                            QUAN_HUYEN = cus[i].QUAN_HUYEN,
                            CMND = cus[i].CMND,
                            NGAY_CAP = cus[i].NGAY_CAP,
                            NOI_CAP = cus[i].NOI_CAP,
                            QUE_QUAN = cus[i].QUE_QUAN,
                            THUONG_TRU = cus[i].THUONG_TRU,
                            TAM_TRU = cus[i].TAM_TRU,
                            DIEN_THOAI1 = cus[i].DIEN_THOAI1,
                            DIEN_THOAI2 = cus[i].DIEN_THOAI2,
                            EMAIL = cus[i].EMAIL,
                            DAN_TOC = cus[i].DAN_TOC,
                            TON_GIAO = cus[i].TON_GIAO,
                            QUOC_TICH = cus[i].QUOC_TICH,
                            VAN_HOA = cus[i].VAN_HOA,
                            CHUYEN_NGANH = cus[i].CHUYEN_NGANH,
                            CHUC_VU = cus[i].CHUC_VU,
                            CHUC_DANH = cus[i].CHUC_DANH,
                            CHUC_VU_DN = cus[i].CHUC_VU_DN,
                            PHONG_BAN = cus[i].PHONG_BAN,
                            THUOC_TO = cus[i].THUOC_TO,
                            NGAY_LUU = cus[i].NGAY_LUU,
                            GHI_CHU = cus[i].GHI_CHU,
                            TEN_PHONG_BAN = cus[i].TEN_PHONG_BAN,
                            TAM_UNG = _KTUNGLUONGRepo.TongTienUngByMaNV(nam,thang,cus[i].MA_NV)
                        });
                    db.SubmitChanges();
                }
                return true;
            }
            catch { return false; }
        }
    }
}
