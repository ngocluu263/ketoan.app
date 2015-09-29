using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KBLCTT_TTRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KB_LCTT_TT GetById(string id)
        {
            try
            {
                return this.db.KB_LCTT_TTs.Single(u => u.CHI_TIEU == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KB_LCTT_TTs;
        }
        public virtual void Create(KB_LCTT_TT user)
        {
            try
            {
                this.db.KB_LCTT_TTs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KB_LCTT_TT user)
        {
            try
            {
                KB_LCTT_TT userOld = this.GetById(user.CHI_TIEU);
                userOld = user;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public virtual void Remove(string id)
        {
            try
            {
                KB_LCTT_TT user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KB_LCTT_TT user)
        {
            try
            {
                db.KB_LCTT_TTs.DeleteOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(string id)
        {
            try
            {
                KB_LCTT_TT user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KB_LCTT_TT user)
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
