using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTYTCPRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_YTCP GetById(int id)
        {
            try
            {
                return this.db.KT_YTCPs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual List<KT_YTCP> GetAllToList()
        {
            return this.db.KT_YTCPs.ToList();
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_YTCPs;
        }
        public virtual void Create(KT_YTCP user)
        {
            try
            {
                this.db.KT_YTCPs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_YTCP user)
        {
            try
            {
                KT_YTCP userOld = this.GetById(user.ID);
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
                KT_YTCP user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_YTCP user)
        {
            try
            {
                db.KT_YTCPs.DeleteOnSubmit(user);
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
                KT_YTCP user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_YTCP user)
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
