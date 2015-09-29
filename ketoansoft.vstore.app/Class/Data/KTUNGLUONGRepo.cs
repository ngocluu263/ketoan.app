using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTUNGLUONGRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_UNG_LUONG GetById(int id)
        {
            try
            {
                return this.db.KT_UNG_LUONGs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_UNG_LUONGs;
        }
        public virtual void Create(KT_UNG_LUONG user)
        {
            try
            {
                this.db.KT_UNG_LUONGs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_UNG_LUONG user)
        {
            try
            {
                KT_UNG_LUONG userOld = this.GetById(user.ID);
                userOld = user;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual bool InsertDuplicate(List<KT_NHANVIEN> cus, string nam, string thang, string loaibangluong)
        {
            try
            {
                KTCTLUONGRepo _KTCTLUONGRepo = new KTCTLUONGRepo();
                for (int i = 0; i < cus.Count; i++)
                {
                    db.KT_UNG_LUONGs.InsertOnSubmit(
                        new KT_UNG_LUONG
                        {
                            STT = cus[i].STT,
                            TEN_NV = cus[i].TEN_NV_VIET,
                            NAM = nam,
                            THANG = thang,
                            LOAI_BL = loaibangluong,
                            MA_NV = cus[i].MA_NV,
                            PHONG_BAN = cus[i].PHONG_BAN,
                            TEN_PHONG_BAN = cus[i].TEN_PHONG_BAN,
                            LUONG_CB = cus[i].LUONG_CB,
                            TAM_UNG = _KTCTLUONGRepo.CongThucTinhLuong("KT_NHANVIEN", "TAM_UNG", cus[i].ID)
                        });
                    db.SubmitChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public virtual List<KT_UNG_LUONG> Check_PhongBan(string nam, string thang, string phongban)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_UNG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
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
        public virtual bool DeleteByPhongBan(List<KT_UNG_LUONG> l)
        {
            try
            {
                var obj = l;
                if (obj.Count > 0)
                {
                    db.KT_UNG_LUONGs.DeleteAllOnSubmit(obj);
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

        public virtual void Remove(int id)
        {
            try
            {
                KT_UNG_LUONG user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_UNG_LUONG user)
        {
            try
            {
                db.KT_UNG_LUONGs.DeleteOnSubmit(user);
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
                KT_UNG_LUONG user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_UNG_LUONG user)
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

        public virtual double TongTienUng(string nam, string thang)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_UNG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)).Sum(n => n.TAM_UNG);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual double TongTienUngByMaNV(string nam, string thang, string maNV)
        {
            try
            {
                double temp = 0;
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_UNG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)
                                   && u.MA_NV == maNV).Sum(n => n.TAM_UNG);
                if (obj != null)
                {
                    return Utils.CDblDef(obj, 0);
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual List<KT_UNG_LUONG> DanhSachUngLuong(string nam, string thang)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_UNG_LUONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                    && (u.THANG == thang || u.THANG == _thang)
                    && u.TAM_UNG > 0).ToList();
                if (obj.Count > 0)
                {
                    return obj;
                }
                else { return null; }
            }
            catch { return null; }
        }
    }
}
