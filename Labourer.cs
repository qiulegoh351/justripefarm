using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class Labourer
    {
        private int id;
        private string name;
        private int age;
        private string gender;

        public Labourer()
        {
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        //public string CreateTime { get => createTime; set => createTime = value; }
    }
}
