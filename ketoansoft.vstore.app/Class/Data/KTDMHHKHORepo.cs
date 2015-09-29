using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTDMHHKHORepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_DMHH_Kho GetById(int id)
        {
            try
            {
                return this.db.KT_DMHH_Khos.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual KT_DMHH_Kho GetByPrimary(string ma_tk, string ma_dtpn, string ma_dm)
        {
            try
            {
                return this.db.KT_DMHH_Khos.Single(u => u.MA_TK == ma_tk && u.MA_DTPN == ma_dtpn && u.MA_DM == ma_dm);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_DMHH_Khos;
        }
        public virtual void Create(KT_DMHH_Kho user)
        {
            try
            {
                this.db.KT_DMHH_Khos.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_DMHH_Kho user)
        {
            try
            {
                KT_DMHH_Kho userOld = this.GetById(user.ID);
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
                KT_DMHH_Kho user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_DMHH_Kho user)
        {
            try
            {
                db.KT_DMHH_Khos.DeleteOnSubmit(user);
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
                KT_DMHH_Kho user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_DMHH_Kho user)
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
