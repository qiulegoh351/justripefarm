using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class StockHandler
    {
        private String logStFile = "Stock_log.txt";
        private StreamWriter writer;

        private static StockHandler SH_instance;

        public static StockHandler sh_instance
        {
            get
            {
                if (SH_instance == null)
                    SH_instance = new StockHandler();
                return SH_instance;
            }
        }

        private StockHandler()
        {
            try
            {
                writer = new StreamWriter(logStFile, true);
            }
            catch (IOException e) { }
        }

        public int addNewStock(MySqlConnection conn, Stock stock)
        {
            string sql = "INSERT INTO stock (type, quantity, supplier_id, purchase_date, expiry_date) "
                        + " VALUES (" + stock.Type + ", " + stock.Quantity + ", " + stock.SupplierID
                        + "    , '" + stock.PurchaseDate.ToString("yyyy-MM-dd HH:mm:ss")
                        + "   ', '" + stock.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            writer.WriteLine(" Succcessful Add New Labourer to Database!" + '\n' +
            " Type: " + stock.Type + '\n' + " Quantity: " + stock.Quantity + '\n' + " Supplier ID: " + stock.SupplierID + '\n' + " Purchase Date: " + stock.PurchaseDate + " /nPurchase Date: " + ExpiryDate);
            return sqlComm.ExecuteNonQuery();
        }

        public void Close()
        {
            writer.Close();
        }

        public void Open()
        {
            writer = new StreamWriter(logStFile, true);
            writer.WriteLine();
        }
    }
}
