using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTCTLUONGRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_CTLUONG GetById(int id)
        {
            try
            {
                return this.db.KT_CTLUONGs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_CTLUONGs;
        }
        public virtual void Create(KT_CTLUONG user)
        {
            try
            {
                this.db.KT_CTLUONGs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_CTLUONG user)
        {
            try
            {
                KT_CTLUONG userOld = this.GetById(user.ID);
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
                KT_CTLUONG user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_CTLUONG user)
        {
            try
            {
                db.KT_CTLUONGs.DeleteOnSubmit(user);
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
                KT_CTLUONG user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_CTLUONG user)
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
        public virtual double CongThucTinhLuong(string ten_bang, string fieldCongThuc, int id)
        {
            double k = 0;
            string cong_thuc = "";
            var obj = db.KT_CTLUONGs.ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                string temp = "";
                if (obj[i].CONG_THUC.Split().Count() > 0) 
                {
                    temp = obj[i].CONG_THUC.Split()[0];
                }
                if (fieldCongThuc == temp)
                {
                    cong_thuc = obj[i].CONG_THUC;
                    string lenh = String.Format("Select {0} From {1} Where ID='{2}'", cong_thuc, ten_bang, id);
                    DataTable dt = new DataTable();
                    dt = XLDLRepo.ReadData(lenh);
                    if (dt.Rows.Count > 0)
                    {
                        k = Utils.CDblDef(dt.Rows[0][0], 0);
                    }
                }
            }
            return k;
        }
        public virtual double CongThucTinhLuongTN(string ten_bang, string fieldCongThuc, int id, int thang, int nam, double tongLuong, double bhxhNLD, double bhytNLD, double bhtnNLD)
        {
            double k = 0;
            string cong_thuc = "";
            var obj = db.KT_CTLUONGs.ToList();
            for (int i = 0; i < obj.Count; i++)
            {
                string temp = "";
                if (obj[i].CONG_THUC.Split().Count() > 0)
                {
                    temp = obj[i].CONG_THUC.Split()[0];
                }
                if (fieldCongThuc == temp)
                {
                    cong_thuc = obj[i].CONG_THUC
                        .Replace("TONG_LUONG", tongLuong.ToString())
                        .Replace("BHXH_NLD", bhxhNLD.ToString())
                        .Replace("BHYT_NLD", bhytNLD.ToString())
                        .Replace("BHTN_NLD", bhtnNLD.ToString());
                    string lenh = String.Format("Select {0} From {1} a Join KT_CHAM_CONG b on a.MA_NV = b.MA_NV Where a.ID = {2} and b.THANG = {3} and b.NAM = {4}"
                        , cong_thuc, ten_bang, id, thang, nam);
                    DataTable dt = new DataTable();
                    dt = XLDLRepo.ReadData(lenh);
                    if (dt.Rows.Count > 0)
                    {
                        k = Utils.CDblDef(dt.Rows[0][0], 0);
                    }
                }
            }
            return k;
        }
    }
}
