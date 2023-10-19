using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace QT_Project
{
    public class Connection
    {
        static string connstring = ConfigurationManager.ConnectionStrings["DN_QT1"].ConnectionString;
        private static SqlConnection cn;
        public static void connect()
        {
            cn = new SqlConnection(connstring);
            cn.Open();
        }
        public static void actionQuery(string sql)
        {
            connect();
            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.ExecuteNonQuery();
        }

        public static DataTable selectQuery(string sql)
        {
            connect();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
    }
}
