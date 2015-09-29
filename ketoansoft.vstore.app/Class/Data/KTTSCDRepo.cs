using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTTSCDRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_TSCD GetById(int id)
        {
            try
            {
                return this.db.KT_TSCDs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_TSCDs;
        }
        public virtual IQueryable GetAllByThangNam(string thang, string nam)
        {
            return this.db.KT_TSCDs.Where(n => n.THANG == thang && n.NAM == nam);
        }
        public virtual void Create(KT_TSCD user)
        {
            try
            {
                this.db.KT_TSCDs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_TSCD user)
        {
            try
            {
                KT_TSCD userOld = this.GetById(user.ID);
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
                KT_TSCD user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_TSCD user)
        {
            try
            {
                db.KT_TSCDs.DeleteOnSubmit(user);
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
                KT_TSCD user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_TSCD user)
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

        public virtual bool InsertDuplicateTSCD(string nam, string thang)
        {
            try
            {
                var cus = db.KT_DMTSCDs.ToList();
                for (int i = 0; i < cus.Count;i++ )
                {
                    db.KT_TSCDs.InsertOnSubmit(
                    new KT_TSCD
                    {
                        STT = cus[i].STT,
                        NAM = nam,
                        THANG = thang,
                        MA_TS = cus[i].MA_TS,
                        TEN_TS = cus[i].TEN_TS,
                        CO_KH = cus[i].CO_KH,
                        TK_TS = cus[i].TK_TS,
                        TK_CP = cus[i].TK_CP,
                        TK_HM = cus[i].TK_HM,
                        DT_SUDUNG = cus[i].DT_SUDUNG,
                        NGUYEN_GIA = cus[i].NGUYEN_GIA,
                        NGAY_MUA = cus[i].NGAY_MUA,
                        NGAY_BAN = cus[i].NGAY_BAN,
                        NGAY_TRICH_KH = cus[i].NGAY_TRICH_KH,
                        THOI_GIAN_KH = cus[i].THOI_GIAN_KH,
                        MA_DTPN_NO = cus[i].MA_DTPN_NO,
                        MA_DTPN_CO = cus[i].MA_DTPN_CO,
                        MA_CT = cus[i].MA_CT,
                        MA_YTCP_NO = cus[i].MA_YTCP_NO
                    });
                    db.SubmitChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public virtual bool DeleteByThangNam(string nam, string thang)
        {
            try
            {
                List<KT_TSCD> obj = db.KT_TSCDs.Where(n => n.THANG == thang && n.NAM == nam).ToList();
                if (obj.Count > 0)
                {
                    db.KT_TSCDs.DeleteAllOnSubmit(obj);
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
