using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT_Project
{
    public class OrderDetailDAO
    {
        public static DataTable Load_OD()
        {
            try
            {
                string select = "SELECT * FROM OrderDetail";
                DataTable dt = Connection.selectQuery(select);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Del_OD(string id)
        {
            try
            {
                string delete = string.Format("DELETE FROM OrderDetail WHERE ID='{0}' ;", id);
                Connection.actionQuery(delete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Insert_OD(string id, string orderid, string itemid, int quantity, float ua)
        {
            try
            {
                string insert = string.Format("insert into OrderDetail(ID,OrderID,ItemID,Quantity,UnitAmount) values ('{0}','{1}', '{2}', {3}, {4});",
                    id, orderid, itemid, quantity, ua);
                Connection.actionQuery(insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
