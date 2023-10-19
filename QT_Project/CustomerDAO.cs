using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT_Project
{
    public class CustomerDAO
    {
        public static DataTable Load_Cust()
        {
            try
            {
                string select = "SELECT * FROM Customer";
                DataTable dt = Connection.selectQuery(select);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Del_Cust(string id)
        {
            try
            {
                string delete = string.Format("DELETE FROM Customer WHERE CustID='{0}' ;", id);
                Connection.actionQuery(delete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Insert_Cust(string id, string name, string address)
        {
            try
            {
                string insert = string.Format("insert into Customer(CustID,CustName,Address) values ('{0}','{1}', '{2}');",
                    id, name, address);
                Connection.actionQuery(insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
