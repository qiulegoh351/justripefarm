using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Multi_From_and_Panel
{
    public partial class Main_Screen_Form : Form
    {
        private bool exitWasClicked = false;

        public Main_Screen_Form()
        {
            InitializeComponent();
        }

        private void Main_Screen_Form_Load(object sender, EventArgs e)
        {
            btnShopWholesale.Text = "Shop /" + Environment.NewLine + "Wholesale";
            
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();

            panel1.Width = 852;
            panel1.Height = 386;
            panel1.Location = new Point(2, 134);
            panel2.Width = 852;
            panel2.Height = 386;
            panel2.Location = new Point(2, 134);
            panel3.Width = 852;
            panel3.Height = 386;
            panel3.Location = new Point(2, 134);
            panel4.Width = 852;
            panel4.Height = 386;
            panel4.Location = new Point(2, 134);
            panel5.Width = 852;
            panel5.Height = 386;
            panel5.Location = new Point(2, 134);
            panel6.Width = 852;
            panel6.Height = 386;
            panel6.Location = new Point(2, 134);
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();            
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
        }

        private void btnFarm_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
        }

        private void btnLabourer_Click(object sender, EventArgs e)
        {
            exitWasClicked = false;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            panel5.Hide();
            panel6.Hide();
        }

        private void btnMachines_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Show();
            panel6.Hide();
        }

        private void btnShopWholesale_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Show();
        }

        // Labourer Screen
        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = DbConnector.Instance;
            dbConn.connect();
            dbConn.Close();

            Labourer labr = new Labourer();
            labr.Name = labourerName.Text;
            labr.Age = int.Parse(labourerAge.Text);
            labr.Gender = labourerGender.Text;

            LabourerHandler labHnd = LabourerHandler.lb_instance;

            if (exitWasClicked == false)
            {
                int recordCnt = labHnd.addNewLabourer(dbConn.getConn(), labr);
                labHnd.Close();
                MessageBox.Show(recordCnt + " record has been inserted !!");
                labHnd.Open();
            }
            else if (exitWasClicked == true)
            {
                labHnd.Close();
            }
        }

        private void exitLabourerPanel_Click(object sender, EventArgs e)
        {
            exitWasClicked = true;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = DbConnector.Instance;
            dbConn.connect();

            LabourerHandler labHnd = LabourerHandler.lb_instance;

            dataGridView1.DataSource = labHnd.getAllLabourer(dbConn.getConn());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            labourerName.Text = string.Empty;
            labourerName.Clear();
            labourerName.Text = "";

            labourerAge.Text = string.Empty;
            labourerAge.Clear();
            labourerAge.Text = "";

            labourerGender.Text = string.Empty;
            labourerGender.Text = "";
        }


        // Shop Or Wholesales Screen
        private void addBtn2_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = DbConnector.Instance;
            dbConn.connect();

            ShopOrWholesales SW = new ShopOrWholesales();
            SW.Type = int.Parse(typeSoW.Text);
            SW.Name = nameSoW.Text;
            SW.Status = statusSoW.Text;
            SW.FoundationDate = DateTime.Parse(foundationDateSoW.Text);

            ShopOrWholesalesHandler SWHandler = new ShopOrWholesalesHandler();
            int recordCnt = SWHandler.addNewShopOrWholeSale(dbConn.getConn(), SW);
            MessageBox.Show(recordCnt + " record has been inserted !!");
        }

        private void clearBtn2_Click(object sender, EventArgs e)
        {
            typeSoW.Text = string.Empty;
            typeSoW.Text = "";

            nameSoW.Text = string.Empty;
            nameSoW.Clear();
            nameSoW.Text = "";

            statusSoW.Text = string.Empty;
            statusSoW.Text = "";

            foundationDateSoW.Text = string.Empty;
            foundationDateSoW.Text = "";
        }

        private void displayBtn2_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = DbConnector.Instance;
            dbConn.connect();

            ShopOrWholesalesHandler SWHnd = new ShopOrWholesalesHandler();

            dataGridView2.DataSource = SWHnd.getAllShopOrWholesales(dbConn.getConn());
        }

        private void helloBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, Test Successfully");
        }

        private void HelloBox4_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, Test Successfully");
        }

        //stock
        private void testAdd_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = DbConnector.Instance;
            dbConn.connect();

            Stock Stk = new Stock();
            Stk.Type = int.Parse(typeSH.Text);
            Stk.Quantity = int.Parse(quantitySH.Text);
            Stk.SupplierID = int.Parse(supplierSH.Text);
            Stk.PurchaseDate = DateTime.Parse(purchaseSH.Text);
            Stk.ExpiryDate = DateTime.Parse(expirySH.Text);

            StockHandler stockHnd = StockHandler.sh_instance;

            if (exitWasClicked == false)
            {
                int recordCnt = stockHnd.addNewStock(dbConn.getConn(), Stk);
                stockHnd.Close();
                MessageBox.Show(recordCnt + " record has been inserted !!");
                stockHnd.Open();
            }
            else if (exitWasClicked == true)
            {
                stockHnd.Close();
            }

        }

        private void testClear_Click(object sender, EventArgs e)
        {
            typeSH.Text = string.Empty;
            typeSH.Text = "";

            quantitySH.Text = string.Empty;
            quantitySH.Clear();
            quantitySH.Text = "";

            supplierSH.Text = string.Empty;
            supplierSH.Text = "";

            purchaseSH.Text = string.Empty;
            purchaseSH.Text = "";

            expirySH.Text = string.Empty;
            expirySH.Text = "";
        }
    }
}
