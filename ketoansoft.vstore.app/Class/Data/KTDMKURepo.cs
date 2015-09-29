using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTDMKURepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_DMKU GetByPrimary(string so_ku, string so_hd, string ma_tk, string ma_dtpn)
        {
            try
            {
                return this.db.KT_DMKUs.Single(u => u.SO_KU == so_ku && u.SO_HD == so_hd && u.MA_TK == ma_tk && u.MA_DTPN == ma_dtpn);
            }
            catch
            {
                return null;
            }
        }
        public virtual KT_DMKU GetById(int id)
        {
            try
            {
                return this.db.KT_DMKUs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_DMKUs;
        }
        public virtual void Create(KT_DMKU user)
        {
            try
            {
                this.db.KT_DMKUs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_DMKU user)
        {
            try
            {
                KT_DMKU userOld = this.GetById(user.ID);
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
                KT_DMKU user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_DMKU user)
        {
            try
            {
                db.KT_DMKUs.DeleteOnSubmit(user);
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
                KT_DMKU user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_DMKU user)
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
