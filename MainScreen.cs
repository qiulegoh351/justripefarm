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
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Labourer labr = new Labourer();
            labr.Name = labourerName.Text;
            labr.Age = int.Parse(labourerAge.Text);
            labr.Gender = labourerGender.Text;

            LabourerHandler labHnd = new LabourerHandler();
            int recordCnt = labHnd.addNewLabourer(dbConn.getConn(), labr);
            MessageBox.Show(recordCnt + " record has been inserted !!");
        }

        private void displayBtn_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            LabourerHandler labHnd = new LabourerHandler();

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
            DbConnector dbConn = new DbConnector();
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
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            ShopOrWholesalesHandler SWHnd = new ShopOrWholesalesHandler();

            dataGridView2.DataSource = SWHnd.getAllShopOrWholesales(dbConn.getConn());
        }

        private void helloBox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, Test Successfully");
        }
    }
}
