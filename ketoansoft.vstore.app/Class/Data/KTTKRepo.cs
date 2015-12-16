using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTTKRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_TK GetById(int id)
        {
            try
            {
                return this.db.KT_TKs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetByListMaTK(List<string> list)
        {
            return this.db.KT_TKs.Where(u => list.Contains(u.MA_TK));
        }
        public virtual IQueryable GetByMaTK_Sub(string matkSub, string matkSub2 = "")
        {
            return this.db.KT_TKs.Where(u => u.MA_TK.Substring(0, 3) == matkSub || u.MA_TK.Substring(0, 1) == matkSub2);
        }
        public virtual List<KT_TK> GetAllToList()
        {
            return this.db.KT_TKs.ToList();
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_TKs;
        }
        public virtual List<KT_TK> GetList()
        {
            var obj = db.KT_TKs.ToList();
            return obj;
        }
        public virtual void Create(KT_TK user)
        {
            try
            {
                this.db.KT_TKs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_TK user)
        {
            try
            {
                KT_TK userOld = this.GetById(user.ID);
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
                KT_TK user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_TK user)
        {
            try
            {
                db.KT_TKs.DeleteOnSubmit(user);
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
                KT_TK user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_TK user)
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
