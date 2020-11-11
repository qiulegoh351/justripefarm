using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class ShopOrWholesalesHandler
    {
        public int addNewShopOrWholeSale(MySqlConnection conn, ShopOrWholesales SoW)
        {
            string sql = "INSERT INTO shoporwholesales (type, name, status_, foundation_date) "
                            + " VALUES (" + SoW.Type + ", '" + SoW.Name + "', '" + SoW.Status
                            + "'    , '" + SoW.FoundationDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            return sqlComm.ExecuteNonQuery();
        }

        public List<ShopOrWholesales> getAllShopOrWholesales(MySqlConnection conn)
        {
            List<ShopOrWholesales> listSoW = new List<ShopOrWholesales>();
            string sql = "SELECT * FROM shoporwholesales";
            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            MySqlDataReader myReader;
            myReader = sqlComm.ExecuteReader();

            while (myReader.Read())
            {

                ShopOrWholesales aSoW = new ShopOrWholesales();
                aSoW.Id = (int)myReader.GetValue(0);
                aSoW.Type = (int)myReader.GetValue(1);
                aSoW.Name = (string)myReader.GetValue(2);
                aSoW.Status = (string)myReader.GetValue(3);
                aSoW.FoundationDate = (DateTime)myReader.GetValue(4);
                listSoW.Add(aSoW);
            }
            return listSoW;
        }
    }
}
