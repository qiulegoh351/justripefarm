using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class ShopOrWholesales
    {
        private int id;
        private int type;
        private string name;
        private string status;
        private DateTime foundationDate;

        public ShopOrWholesales()
        {
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime FoundationDate
        {
            get { return foundationDate; }
            set { foundationDate = value; }
        }
    }
}
