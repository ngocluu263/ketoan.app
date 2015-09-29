using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;
using System.Data;
using System.Threading;
namespace ketoansoft.app.Class.Data
{
    public class KT_CTuGocRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_CTuGoc GetById(int id)
        {
            try
            {
                return this.db.KT_CTuGocs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetByMaCT(string ma_ct, int month, int year, string soctu)
        {
            return this.db.KT_CTuGocs.Where(u => u.MA_CTU == ma_ct && (u.NGAY_CTU.Value.Month == month || month == -1) && (u.NGAY_CTU.Value.Year == year || year == -1) && (u.SO_CTU == soctu || soctu == ""));
        }
        public virtual List<KT_CTuGoc> GetByMaCTToList(string ma_ct, int month, int year, string soctu)
        {
            return this.db.KT_CTuGocs.Where(u => u.MA_CTU == ma_ct && (u.NGAY_CTU.Value.Month == month || month == -1) && (u.NGAY_CTU.Value.Year == year || year == -1) && (u.SO_CTU == soctu || soctu == "")).ToList();
        }
        public virtual int GetByHDBR(string ma_ct, int month, int year)
        {
            try
            {
                int temp = 0;
                var obj = db.KT_CTuGocs.Where(u => u.MA_CTU == ma_ct
                    && (u.NGAY_CTU.Value.Month == month || month == -1)
                    && (u.NGAY_CTU.Value.Year == year || year == -1)).ToList();
                if (obj.Count > 0)
                {
                    foreach (var i in obj) 
                    {
                        i.DG_VON = 0;
                        i.GIA_VON = 0;
                        i.LAI_GOP = Utils.CDblDef(i.THANH_TIEN_VND, 0) - Utils.CDblDef(i.CHIET_KHAU_VND, 0);
                        db.SubmitChanges();
                    }
                    temp = obj.Count;
                }
                return temp;
            }
            catch { return 0; }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_CTuGocs;
        }
        public virtual IQueryable GetAllByThangNam(int month, int year)
        {
            return this.db.KT_CTuGocs.Where(u => (u.NGAY_CTU.Value.Month == month || month == -1) && (u.NGAY_CTU.Value.Year == year || year == -1));
        }
        public virtual void Create(KT_CTuGoc user)
        {
            try
            {
                this.db.KT_CTuGocs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Create(List<KT_CTuGoc> user)
        {
            try
            {
                this.db.KT_CTuGocs.InsertAllOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_CTuGoc user)
        {
            try
            {
                KT_CTuGoc userOld = this.GetById(user.ID);
                userOld = user;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual bool InsertUngLuong(string loaiCT, string soCT, string soPC, DateTime ngayCT, string dienGiai, string tkNo, string tkCo, double tongTien, string maDTPNno)
        {
            try
            {
                KT_CTuGoc obj = new KT_CTuGoc();
                obj.MA_CTU = loaiCT;
                obj.SO_CTU = soCT;
                obj.SO_PC = soPC;
                obj.NGAY_CTU = ngayCT;
                obj.DIEN_GIAI = dienGiai;
                obj.TK_NO = tkNo;
                obj.TK_CO = tkCo;
                obj.TONG_TIEN_VND = tongTien;
                obj.MA_DTPN_NO = maDTPNno;
                obj.MA_DTPN_CO = maDTPNno;
                db.KT_CTuGocs.InsertOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public virtual bool InsertChiPhiLuong(string loaiCT, string soCT, DateTime ngayCT, string dienGiai, string tkNo, string tkCo, double tongTien)
        {
            try
            {
                KT_CTuGoc obj = new KT_CTuGoc();
                obj.MA_CTU = loaiCT;
                obj.SO_CTU = soCT;
                obj.NGAY_CTU = ngayCT;
                obj.DIEN_GIAI = dienGiai;
                obj.TK_NO = tkNo;
                obj.TK_CO = tkCo;
                obj.TONG_TIEN_VND = tongTien;
                db.KT_CTuGocs.InsertOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public virtual bool InsertLuongTheoPhongBan(string loaiCT, string soCT, DateTime ngayCT, string dienGiai, string tkNo, string tkCo, double tongTien, string maPB)
        {
            try
            {
                KT_CTuGoc obj = new KT_CTuGoc();
                obj.MA_CTU = loaiCT;
                obj.SO_CTU = soCT;
                obj.NGAY_CTU = ngayCT;
                obj.DIEN_GIAI = dienGiai;
                obj.TK_NO = tkNo;
                obj.TK_CO = tkCo;
                obj.MA_DTPN_NO = maPB;
                obj.MA_DTPN_CO = maPB;
                obj.TONG_TIEN_VND = tongTien;
                db.KT_CTuGocs.InsertOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        public virtual void Remove(int id)
        {
            try
            {
                KT_CTuGoc user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_CTuGoc user)
        {
            try
            {
                db.KT_CTuGocs.DeleteOnSubmit(user);
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
                KT_CTuGoc user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_CTuGoc user)
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

        public virtual bool DeleteByMaCT(string maCT, int thang, int nam)
        {
            try
            {
                var obj = db.KT_CTuGocs.Where(n => n.MA_CTU == maCT 
                    && n.NGAY_CTU.Value.Month == thang
                    && n.NGAY_CTU.Value.Year == nam).ToList();
                if (obj.Count > 0)
                {

                    db.KT_CTuGocs.DeleteAllOnSubmit(obj);
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
    }
}
