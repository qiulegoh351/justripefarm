using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class DbConnector
    {
        MySqlConnection conn;

        public string connect()
        {
            string connStr = "server=localhost;user=dbcli;database=demojustripedb;port=3306;password=dbcli123";
            conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                //Perform database operations
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "Done";
        }

        public MySqlConnection getConn()
        {
            return conn;
        }
    }
}
