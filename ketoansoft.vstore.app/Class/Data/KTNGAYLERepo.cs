using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTNGAYLERepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_NGAY_LE GetById(int id)
        {
            try
            {
                return this.db.KT_NGAY_LEs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual bool CheckExist(int ngay, int thang)
        {
            try
            {
                var obj = db.KT_NGAY_LEs.Single(u => u.NGAY == ngay && u.THANG == thang);
                if (obj != null) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_NGAY_LEs;
        }
        public virtual void Create(KT_NGAY_LE user)
        {
            try
            {
                this.db.KT_NGAY_LEs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_NGAY_LE user)
        {
            try
            {
                KT_NGAY_LE userOld = this.GetById(user.ID);
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
                KT_NGAY_LE user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_NGAY_LE user)
        {
            try
            {
                db.KT_NGAY_LEs.DeleteOnSubmit(user);
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
                KT_NGAY_LE user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_NGAY_LE user)
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
