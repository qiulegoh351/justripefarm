using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public sealed class DbConnector
    {
        MySqlConnection conn;

        private String logFile = "DatabaseConnection_log.txt";
        private StreamWriter writer;

        private static DbConnector instance;
        public static DbConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new DbConnector();
                return instance;
            }

        }

        public DbConnector()
        {
            try
            {
                writer = new StreamWriter(logFile, true);
            }
            catch (IOException e) { }
        }

        public string connect()
        {
            string connStr = "server=localhost;user=dbcli;database=demojustripedb;port=3306;password=dbcli123";
            conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                writer.WriteLine("Succcessful Connect to Database!");
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

        public void Close()
        {
            writer.Close();
        }
    }
}
