using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class LabourerHandler
    {
        private String logHBFile = "AddNewLabourer_log.txt";
        private StreamWriter writer;

        private static LabourerHandler LB_instance;
        private static int counter = 0;

        public static LabourerHandler lb_instance
        {
            get
            {
                if (LB_instance == null)
                    LB_instance = new LabourerHandler();
                return LB_instance;
            }
        }
        private LabourerHandler()
        {
            try
            {
                writer = new StreamWriter(logHBFile, true);
            }
            catch (IOException e) { }
        }

        public int addNewLabourer(MySqlConnection conn, Labourer labourer)
        {
            string sql = "INSERT INTO labourer (name, age, gender) " + " VALUES ('" + 
                         labourer.Name + "'," + labourer.Age + "  , '" + labourer.Gender + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            counter++;
            writer.WriteLine(counter + ") Succcessful Add New Labourer to Database!" + '\n' + 
                            " Name: " + labourer.Name + '\n' + " Age: " + labourer.Age + '\n' + " Gender: " + labourer.Gender);

            return sqlComm.ExecuteNonQuery();
        }//The MySqlConnection is assumed to be open when the method is called and remains open after the method completes.

        public List<Labourer> getAllLabourer(MySqlConnection conn)
        {
            List<Labourer> listLabr = new List<Labourer>();
            string sql = "SELECT * FROM labourer";
            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            MySqlDataReader myReader;
            myReader = sqlComm.ExecuteReader();
            // Sends the CommandText to the Connection and builds a MySqlDataReader.

            while (myReader.Read())
            {
                Labourer aLabr = new Labourer();
                aLabr.Id = (int)myReader.GetValue(0);
                aLabr.Name = (string)myReader.GetValue(1);
                aLabr.Age = (int)myReader.GetValue(2);
                aLabr.Gender = (string)myReader.GetValue(3);
                listLabr.Add(aLabr);
            }
            return listLabr;
        }

        public void Close()
        {
            writer.Close();
        }

        public void Open()
        {
            writer = new StreamWriter(logHBFile, true);
            writer.WriteLine();
        }
    }
}
