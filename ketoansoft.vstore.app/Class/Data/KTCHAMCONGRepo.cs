using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ketoansoft.app.Components.clsVproUtility;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class KTCHAMCONGRepo
    {
        dbVstoreAppDataContext db = new dbVstoreAppDataContext(Const.builder.ConnectionString);

        public virtual KT_CHAM_CONG GetById(int id)
        {
            try
            {
                return this.db.KT_CHAM_CONGs.Single(u => u.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public virtual IQueryable GetAll()
        {
            return this.db.KT_CHAM_CONGs;
        }
        public virtual void Create(KT_CHAM_CONG user)
        {
            try
            {
                this.db.KT_CHAM_CONGs.InsertOnSubmit(user);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Update(KT_CHAM_CONG user)
        {
            try
            {
                KT_CHAM_CONG userOld = this.GetById(user.ID);
                userOld = user;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual bool InsertDuplicate(List<KT_NHANVIEN> cus, string nam, string thang, string loaibangluong, List<string> _day)
        {
            try
            {
                for (int i = 0; i < cus.Count; i++)
                {
                    db.KT_CHAM_CONGs.InsertOnSubmit(
                        new KT_CHAM_CONG
                        {
                            STT = cus[i].STT,
                            TEN_NV = cus[i].TEN_NV_VIET,
                            NAM = nam,
                            THANG = thang,
                            LOAI_BL = loaibangluong,
                            MA_NV = cus[i].MA_NV,
                            PHONG_BAN = cus[i].PHONG_BAN,
                            TEN_PHONG_BAN = cus[i].TEN_PHONG_BAN,
                            TONG_NC = 0,
                            TONG_NN = 0,
                            N01 = _day.Count > 0 ? _day[0] : "",
                            N02 = _day.Count > 1 ? _day[1] : "",
                            N03 = _day.Count > 2 ? _day[2] : "",
                            N04 = _day.Count > 3 ? _day[3] : "",
                            N05 = _day.Count > 4 ? _day[4] : "",
                            N06 = _day.Count > 5 ? _day[5] : "",
                            N07 = _day.Count > 6 ? _day[6] : "",
                            N08 = _day.Count > 7 ? _day[7] : "",
                            N09 = _day.Count > 8 ? _day[8] : "",
                            N10 = _day.Count > 9 ? _day[9] : "",
                            N11 = _day.Count > 10 ? _day[10] : "",
                            N12 = _day.Count > 11 ? _day[11] : "",
                            N13 = _day.Count > 12 ? _day[12] : "",
                            N14 = _day.Count > 13 ? _day[13] : "",
                            N15 = _day.Count > 14 ? _day[14] : "",
                            N16 = _day.Count > 15 ? _day[15] : "",
                            N17 = _day.Count > 16 ? _day[16] : "",
                            N18 = _day.Count > 17 ? _day[17] : "",
                            N19 = _day.Count > 18 ? _day[18] : "",
                            N20 = _day.Count > 19 ? _day[19] : "",
                            N21 = _day.Count > 20 ? _day[20] : "",
                            N22 = _day.Count > 21 ? _day[21] : "",
                            N23 = _day.Count > 22 ? _day[22] : "",
                            N24 = _day.Count > 23 ? _day[23] : "",
                            N25 = _day.Count > 24 ? _day[24] : "",
                            N26 = _day.Count > 25 ? _day[25] : "",
                            N27 = _day.Count > 26 ? _day[26] : "",
                            N28 = _day.Count > 27 ? _day[27] : "",
                            N29 = _day.Count > 28 ? _day[28] : "",
                            N30 = _day.Count > 29 ? _day[29] : "",
                            N31 = _day.Count > 30 ? _day[30] : ""
                        });
                    db.SubmitChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public virtual List<KT_CHAM_CONG> Check_PhongBan(string nam, string thang, string phongban)
        {
            try
            {
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = this.db.KT_CHAM_CONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                    && (u.THANG == thang || u.THANG == _thang)
                    && u.PHONG_BAN == phongban).ToList();
                if (obj.Count > 0)
                {
                    return obj;
                }
                else { return null; }
            }
            catch { return null; }
        }
        public virtual bool DeleteByPhongBan(List<KT_CHAM_CONG> l)
        {
            try
            {
                var obj = l;
                if (obj.Count > 0)
                {
                    db.KT_CHAM_CONGs.DeleteAllOnSubmit(obj);
                    db.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public virtual void Remove(int id)
        {
            try
            {
                KT_CHAM_CONG user = this.GetById(id);
                this.Remove(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public virtual void Remove(KT_CHAM_CONG user)
        {
            try
            {
                db.KT_CHAM_CONGs.DeleteOnSubmit(user);
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
                KT_CHAM_CONG user = this.GetById(id);
                return this.Delete(user);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public virtual int Delete(KT_CHAM_CONG user)
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

        //Ngày công
        public virtual bool CapNhatNgayCong(string nam, string thang)
        {
            try
            {
                double tempCong = 0;
                double tempNghi = 0;
                var obj = db.KT_CHAM_CONGs.Where(n => n.NAM == nam && n.THANG == thang).ToList();
                for (int i = 0; i < obj.Count; i++)
                {
                    tempCong = songaycong(obj[i].N01);
                    tempNghi = songaynghi(obj[i].N01);
                    tempCong += songaycong(obj[i].N02);
                    tempNghi += songaynghi(obj[i].N02);
                    tempCong += songaycong(obj[i].N03);
                    tempNghi += songaynghi(obj[i].N03);
                    tempCong += songaycong(obj[i].N04);
                    tempNghi += songaynghi(obj[i].N04);
                    tempCong += songaycong(obj[i].N05);
                    tempNghi += songaynghi(obj[i].N05);
                    tempCong += songaycong(obj[i].N06);
                    tempNghi += songaynghi(obj[i].N06);
                    tempCong += songaycong(obj[i].N07);
                    tempNghi += songaynghi(obj[i].N07);
                    tempCong += songaycong(obj[i].N08);
                    tempNghi += songaynghi(obj[i].N08);
                    tempCong += songaycong(obj[i].N09);
                    tempNghi += songaynghi(obj[i].N09);
                    tempCong += songaycong(obj[i].N10);
                    tempNghi += songaynghi(obj[i].N10);
                    tempCong += songaycong(obj[i].N11);
                    tempNghi += songaynghi(obj[i].N11);
                    tempCong += songaycong(obj[i].N12);
                    tempNghi += songaynghi(obj[i].N12);
                    tempCong += songaycong(obj[i].N13);
                    tempNghi += songaynghi(obj[i].N13);
                    tempCong += songaycong(obj[i].N14);
                    tempNghi += songaynghi(obj[i].N14);
                    tempCong += songaycong(obj[i].N15);
                    tempNghi += songaynghi(obj[i].N15);
                    tempCong += songaycong(obj[i].N16);
                    tempNghi += songaynghi(obj[i].N16);
                    tempCong += songaycong(obj[i].N17);
                    tempNghi += songaynghi(obj[i].N17);
                    tempCong += songaycong(obj[i].N18);
                    tempNghi += songaynghi(obj[i].N18);
                    tempCong += songaycong(obj[i].N19);
                    tempNghi += songaynghi(obj[i].N19);
                    tempCong += songaycong(obj[i].N20);
                    tempNghi += songaynghi(obj[i].N20);
                    tempCong += songaycong(obj[i].N21);
                    tempNghi += songaynghi(obj[i].N21);
                    tempCong += songaycong(obj[i].N22);
                    tempNghi += songaynghi(obj[i].N22);
                    tempCong += songaycong(obj[i].N23);
                    tempNghi += songaynghi(obj[i].N23);
                    tempCong += songaycong(obj[i].N24);
                    tempNghi += songaynghi(obj[i].N24);
                    tempCong += songaycong(obj[i].N25);
                    tempNghi += songaynghi(obj[i].N25);
                    tempCong += songaycong(obj[i].N26);
                    tempNghi += songaynghi(obj[i].N26);
                    tempCong += songaycong(obj[i].N27);
                    tempNghi += songaynghi(obj[i].N27);
                    tempCong += songaycong(obj[i].N28);
                    tempNghi += songaynghi(obj[i].N28);
                    tempCong += songaycong(obj[i].N29);
                    tempNghi += songaynghi(obj[i].N29);
                    tempCong += songaycong(obj[i].N30);
                    tempNghi += songaynghi(obj[i].N30);
                    tempCong += songaycong(obj[i].N31);
                    tempNghi += songaynghi(obj[i].N31);
                    obj[i].TONG_NC = tempCong;
                    obj[i].TONG_NN = tempNghi;
                    db.SubmitChanges();
                    tempCong = 0;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<double> getNgayCongByMaNV(string nam, string thang, string maNV)
        {
            try
            {
                List<double> temp = new List<double>();
                string _thang = Utils.CStrDef(Utils.CIntDef(thang, 0), "");
                string _nam = Utils.CStrDef(Utils.CIntDef(nam, 0), "");
                var obj = db.KT_CHAM_CONGs.Where(u => (u.NAM == nam || u.NAM == _nam)
                                   && (u.THANG == thang || u.THANG == _thang)
                                   && u.MA_NV == maNV).ToList();
                if (obj.Count > 0)
                {
                    temp.Add(Utils.CDblDef(obj[0].TONG_NC, 0));
                    temp.Add(Utils.CDblDef(obj[0].TONG_NN, 0));
                }
                else { return null; }
                return temp;
            }
            catch
            {
                return null;
            }
        }
        private double songaycong(string temp)
        {
            KTMACONGRepo _KTMACONGRepo = new KTMACONGRepo();
            double k = 0;
            var obj = _KTMACONGRepo.GetById(temp);
            if (obj != null)
            {
                k = Utils.CDblDef(obj.SO_NGAY_CONG, 0);
            }
            return k;
        }
        private double songaynghi(string temp)
        {
            double k = 0;
            switch (temp)
            {
                case "0": k = 1; break;
                case "N4": k = 1; break;
                case "NK": k = 1; break;
            }
            return k;
        }
    }
}
