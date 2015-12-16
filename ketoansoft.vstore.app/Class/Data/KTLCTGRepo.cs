using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTLCTGRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        public virtual List<KT_LCTG> GetAllToList()
        {
            return this.db.KT_LCTGs.ToList();
        }
        public virtual KT_LCTG GetById(int id)
        {
            try
            {
                return this.db.KT_LCTGs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_LCTGs;
        }
        public virtual void Create(KT_LCTG user)
        {
            try
            {
                this.db.KT_LCTGs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_LCTG user)
        {
            try
            {
                KT_LCTG userOld = this.GetById(user.ID);
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
                KT_LCTG user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_LCTG user)
        {
            try
            {
                db.KT_LCTGs.DeleteOnSubmit(user);
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
                KT_LCTG user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_LCTG user)
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
