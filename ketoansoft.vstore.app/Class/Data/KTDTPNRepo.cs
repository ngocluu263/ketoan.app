using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTDTPNRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_DTPN GetById(int id)
        {
            try
            {
                return this.db.KT_DTPNs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual List<KT_DTPN> GetAllToList()
        {
            return this.db.KT_DTPNs.ToList();
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_DTPNs;
        }
        public virtual void Create(KT_DTPN user)
        {
            try
            {
                this.db.KT_DTPNs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_DTPN user)
        {
            try
            {
                KT_DTPN userOld = this.GetById(user.ID);
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
                KT_DTPN user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_DTPN user)
        {
            try
            {
                db.KT_DTPNs.DeleteOnSubmit(user);
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
                KT_DTPN user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_DTPN user)
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
