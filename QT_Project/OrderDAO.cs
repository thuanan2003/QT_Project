using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT_Project
{
    public class OrderDAO
    {
        public static void Insert_Order(string id, int year, int month, int day, string custid)
        {
            
            try
            {
                string insert = string.Format("insert into Order (OrderID,OrderDate,CustID) values ('{0}','{1}/{2}/{3}', '{4}');",
                    id, year, month, day, custid);
                Connection.actionQuery(insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
