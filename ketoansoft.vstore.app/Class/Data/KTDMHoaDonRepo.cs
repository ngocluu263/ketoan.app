using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTDMHoaDonRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_DMHoaDon GetById(int id)
        {
            try
            {
                return this.db.KT_DMHoaDons.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual List<KT_DMHoaDon> GetAllToList()
        {
            return this.db.KT_DMHoaDons.ToList();
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_DMHoaDons;
        }
        public virtual void Create(KT_DMHoaDon user)
        {
            try
            {
                this.db.KT_DMHoaDons.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_DMHoaDon user)
        {
            try
            {
                KT_DMHoaDon userOld = this.GetById(user.ID);
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
                KT_DMHoaDon user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_DMHoaDon user)
        {
            try
            {
                db.KT_DMHoaDons.DeleteOnSubmit(user);
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
                KT_DMHoaDon user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_DMHoaDon user)
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
