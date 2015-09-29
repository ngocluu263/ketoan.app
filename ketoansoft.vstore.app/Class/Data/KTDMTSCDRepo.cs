using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTDMTSCDRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_DMTSCD GetById(int id)
        {
            try
            {
                return this.db.KT_DMTSCDs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual string GetMaTSCuoi()
        {
            string s = "";
            var list = this.db.KT_DMTSCDs.OrderByDescending(u=>u.ID);
            if (list != null && list.ToList().Count > 0)
                s = list.ToList()[0].MA_TS;
            return s;
        }
        public virtual IQueryable GetAll(int id)
        {
            return this.db.KT_DMTSCDs.Where(u => u.ID == id);
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_DMTSCDs;
        }
        public virtual void Create(KT_DMTSCD user)
        {
            try
            {
                this.db.KT_DMTSCDs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_DMTSCD user)
        {
            try
            {
                KT_DMTSCD userOld = this.GetById(user.ID);
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
                KT_DMTSCD user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_DMTSCD user)
        {
            try
            {
                db.KT_DMTSCDs.DeleteOnSubmit(user);
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
                KT_DMTSCD user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_DMTSCD user)
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
