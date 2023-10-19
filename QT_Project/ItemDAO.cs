using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QT_Project
{
    public class ItemDAO
    {
        public static DataTable Load_Item()
        {
            try
            {
                string select = "SELECT * FROM Item";
                DataTable dt = Connection.selectQuery(select);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Del_Item(string id)
        {
            try
            {
                string delete = string.Format("DELETE FROM Item WHERE ItemID='{0}' ;", id);
                Connection.actionQuery(delete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Insert_Item(string id, string name, string size, float price)
        {
            try
            {
                string insert = string.Format("insert into Item(ItemID,ItemName,Size,Price) values ('{0}','{1}', '{2}', {3});",
                    id, name, size, price);
                Connection.actionQuery(insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update_Item(string id, string name, string size, float price)
        {
            try
            {

                string update = string.Format("UPDATE Item SET ItemID='{0}',ItemName='{1}',Size='{2}',Price='{3}';",
                    id, name, size, price);
                Connection.actionQuery(update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
