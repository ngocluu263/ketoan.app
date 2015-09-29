using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTNHANVIENRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_NHANVIEN GetById(int id)
        {
            try
            {
                return this.db.KT_NHANVIENs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_NHANVIENs;
        }

        public class cls_nhanvien
        {
            public string PHONG_BAN {get; set;}
            public string TEN_PHONG_BAN {get; set;}
        }
        public virtual List<cls_nhanvien> Get_Departments()
        {
            List<cls_nhanvien> l = new List<cls_nhanvien>();
            var list = (from a in db.KT_NHANVIENs
                       select new { a.PHONG_BAN, a.TEN_PHONG_BAN}).Distinct();
            foreach (var i in list)
            {
                cls_nhanvien p = new cls_nhanvien();
                p.PHONG_BAN = i.PHONG_BAN;
                p.TEN_PHONG_BAN = i.TEN_PHONG_BAN;
                l.Add(p);
            }

            return l;
        }
        public virtual List<KT_NHANVIEN> GetDataByPB(string ma_phong_bang)
        {
            try
            {
                return this.db.KT_NHANVIENs.Where(u => u.PHONG_BAN == ma_phong_bang).ToList();
            }
            catch
            {
                return null;
            }
        }
        public virtual void Create(KT_NHANVIEN user)
        {
            try
            {
                this.db.KT_NHANVIENs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_NHANVIEN user)
        {
            try
            {
                KT_NHANVIEN userOld = this.GetById(user.ID);
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
                KT_NHANVIEN user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_NHANVIEN user)
        {
            try
            {
                db.KT_NHANVIENs.DeleteOnSubmit(user);
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
                KT_NHANVIEN user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_NHANVIEN user)
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

    }
}
