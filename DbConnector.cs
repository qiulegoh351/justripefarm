using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    //Declare as sealed which will ensure that it cannot be inherited. 
    //This is going to be useful when you are dealing with the nested class. 
    public sealed class DbConnector
    {
        MySqlConnection conn;

        private String logFile = "DatabaseConnection_log.txt";
        private StreamWriter writer;

        //Create a private static variable that is going to hold a reference to the single created instance of the class if any.
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

        //constructor should be private and parameterless.
        //because it is not allowed the class to be instantiated from outside the class. 
        //It only instantiates from within the class.
        private DbConnector()
        {
            try
            {
                writer = new StreamWriter(logFile, true);
            }
            catch (IOException e) { }
        }

        //Create a public static property/method which will return the single created instance of the singleton class. 
        //This method or property first check if an instance of the singleton class is available or not. 
        //If the singleton instance is available, then it returns that singleton instance 
        //otherwise it will create an instance and then return that instance.
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
