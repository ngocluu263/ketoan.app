using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ketoansoft.app.Class.Global;

namespace ketoansoft.app.Class.Data
{
    public class XLDLRepo
    {        
        //public static string StrCnn = ConfigurationManager.ConnectionStrings["ketoansoft.app.Properties.Settings.dbConnectionString"].ConnectionString;
        public static string StrCnn = Const.ConnectionString;
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
                throw new Exception(ex.Message);
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
            catch (SqlException)
            {
                return -1;
            }
        }
    }
}
