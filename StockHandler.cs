using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class StockHandler
    {
        public int addNewStock(MySqlConnection conn, Stock stock)
        {
            string sql = "INSERT INTO stock (type, quantity, supplier_id, purchase_date, expiry_date) "
                        + " VALUES (" + stock.Type + ", " + stock.Quantity + ", " + stock.SupplierID
                        + "    , '" + stock.PurchaseDate.ToString("yyyy-MM-dd HH:mm:ss")
                        + "   ', '" + stock.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            return sqlComm.ExecuteNonQuery();
        }
    }
}
