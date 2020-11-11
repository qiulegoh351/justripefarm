using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GUI___Multi_From_and_Panel
{
    public class Stock
    {
        private int type;
        private int quantity;
        private int supplierID;
        private DateTime purchaseDate;
        private DateTime expiryDate;

        public Stock()
        {
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value; }
        }
        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
    }
}
