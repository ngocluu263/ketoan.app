using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Activate
{
    public class XLDLRepo
    {
        public static string StrCnn = "Data Source=.\\SQL2008R2;Initial Catalog=db_ketoan_admin;Persist Security Info=True;User ID=sa;Password=123";
        static SqlConnection Cnn;
        public static DataTable ReadData(string comm)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Cnn == null) Cnn = new SqlConnection(StrCnn);
                SqlDataAdapter da = new SqlDataAdapter(comm, Cnn);
                da.FillSchema(dt, SchemaType.Mapped);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public static int DataCommand(string comm)
        {
            try
            {
                if (Cnn == null) Cnn = new SqlConnection(StrCnn);
                if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                SqlCommand cmd = new SqlCommand(comm, Cnn);
                int kq = cmd.ExecuteNonQuery();
                Cnn.Close();
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
    public class Utils
    {
        public static int CIntDef(object Expression, int DefaultValue)
        {
            try
            {
                return System.Convert.ToInt32(Expression);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static string CStrGuid(object Expression, string DefaultValue)
        {
            try
            {
                Guid g;
                g = new Guid(Expression.ToString());
                return Expression.ToString();
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static long CLngDef(object Expression, int DefaultValue)
        {
            try
            {
                return System.Convert.ToInt32(Expression);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static bool CBoolDef(object Experssion, bool DefaultValue)
        {
            try
            {
                return System.Convert.ToBoolean(Experssion);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static decimal CDecDef(object Expression, decimal DefaultValue)
        {
            try
            {
                return System.Convert.ToDecimal(Expression);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static double CDblDef(object Expression, double DefaultValue)
        {
            try
            {
                return System.Convert.ToDouble(Expression);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static DateTime CDateDef(object Expression, DateTime DefaultValue)
        {
            try
            {
                return System.Convert.ToDateTime(Expression);
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }

        public static string CStrDef(object Expression, string DefaultValue)
        {
            try
            {
                return Expression.ToString().Trim();
            }
            catch (Exception)
            {
                return DefaultValue;
            }
        }
    }
}
