using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Class.Global;
using System.Data;
using ketoansoft.app.Components.clsVproUtility;

namespace ketoansoft.app.Class.Data
{
    public class KTXuLySoDuRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        #region Xử lý số dư tài khoản
        public virtual double GetTongByTkNo(DateTime ngayBD, DateTime ngayKT, string fieldName, string caption)
        {
            try
            {
                double temp = 0;
                var obj = db.KT_CTuGocs.Where(n => n.NGAY_CTU >= ngayBD && n.NGAY_CTU <= ngayKT && n.TK_NO == caption).AsParallel().Sum(n => n.THANH_TIEN_VND);
                if (obj.Value > 0)
                    temp = obj.Value;
                return temp;
            }
            catch (Exception ex) { return 0; }
        }
        public virtual DataTable GetTongBySoDuTk(string ngayBT, string ngayKT)
        {
            try
            {
                string lenh = String.Format("Exec SP_SoDuTK '{0}','{1}'", ngayBT, ngayKT);
                DataTable dt = XLDLRepo.ReadData(lenh);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch (Exception ex) { return null; }
        }
        public virtual bool InsertSoDuTk(DateTime ngayBT, DateTime ngayKT)
        {
            try
            {
                string _ngayBT = ngayBT.Month + "/" + ngayBT.Day + "/" + ngayBT.Year;
                string _ngayKT = ngayKT.Month + "/" + ngayKT.Day + "/" + ngayKT.Year;
                DataTable dt = GetTongBySoDuTk(_ngayBT, _ngayKT);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    db.KT_SoDu_TKs.InsertOnSubmit(
                        new KT_SoDu_TK
                        {
                            MA_TK = Utils.CStrDef(dt.Rows[i]["MA_TK"], ""),
                            TEN_TK = Utils.CStrDef(dt.Rows[i]["TEN_TK"], ""),
                            NGAY_BD = ngayBT,
                            NGAY_KT = ngayKT,
                            VND_DU_NO = Utils.CDblDef(dt.Rows[i]["DuNoVnd"], 0),
                            VND_DU_CO = Utils.CDblDef(dt.Rows[i]["DuCoVnd"], 0),
                            VND_PS_NO = Utils.CDblDef(dt.Rows[i]["PsNoVnd"], 0),
                            VND_PS_CO = Utils.CDblDef(dt.Rows[i]["PsCoVnd"], 0),
                            VND_CK_NO =
                                Utils.CDblDef(dt.Rows[i]["DuNoVnd"], 0) +
                                Utils.CDblDef(dt.Rows[i]["PsNoVnd"], 0) -
                                Utils.CDblDef(dt.Rows[i]["DuCoVnd"], 0) -
                                Utils.CDblDef(dt.Rows[i]["PsCoVnd"], 0),
                            VND_CK_CO =
                                Utils.CDblDef(dt.Rows[i]["DuCoVnd"], 0) +
                                Utils.CDblDef(dt.Rows[i]["PsCoVnd"], 0) -
                                Utils.CDblDef(dt.Rows[i]["DuNoVnd"], 0) -
                                Utils.CDblDef(dt.Rows[i]["PsNoVnd"], 0),
                        });
                    db.SubmitChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public virtual List<KT_SoDu_TK> GetSoDuTk(DateTime ngayBT, DateTime ngayKT)
        {
            var obj = this.db.KT_SoDu_TKs.Where(u => u.NGAY_BD >= ngayBT && u.NGAY_KT <= ngayKT).ToList();
            if (obj.Count > 0)
                return obj;
            else return null;
        }
        public virtual bool DeleteSoDuTk(DateTime ngayBT, DateTime ngayKT)
        {
            var obj = GetSoDuTk(ngayBT, ngayKT);
            if (obj != null)
            {
                db.KT_SoDu_TKs.DeleteAllOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
