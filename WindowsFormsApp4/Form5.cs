using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SelectAllOption();

            SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
            connection.Open();

            string queryString01 = "SELECT ProductName, SUM(Items)[Total] FROM Sales GROUP BY ProductName ORDER BY ProductName";
            SqlCommand command01 = new SqlCommand(queryString01, connection);
            var reader01 = command01.ExecuteReader();

            while (reader01.Read())
            {
                string productName = reader01["ProductName"].ToString();
                string total = reader01["Total"].ToString();
                chart1.Series["Series1"].Points.AddXY(productName, total);
                
            }

            reader01.Close();
            connection.Close();
            // chart1.Series["Series1"]["PieLabelStyle"] = "Disabled";

            // button4.Text = "<<<";
            button1.Cursor = button2.Cursor = button3.Cursor = Cursors.Hand;
            button1.Text = "MENU";
            button2.Text = "PRODUCT";
            button3.Text = "POS";
            button1.BackColor = button2.BackColor = button3.BackColor = SystemColors.Control;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelectAllOption();
        }

        private void SelectAllOption()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Product");
            listView1.Columns[0].Width = 250;
            listView1.Columns.Add("Items");
            listView1.Columns[1].Width = 125;
            listView1.Columns.Add("Total");
            listView1.Columns[2].Width = 150;
            listView1.Columns.Add("Date");
            listView1.Columns[3].Width = 300;

            if (radioButton1.Checked == true) //activate when click
            {
                SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                connection.Open();

                string queryString = "SELECT * FROM Sales ORDER BY Date DESC";
                SqlCommand command = new SqlCommand(queryString, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productName = reader["ProductName"].ToString();
                    string items = reader["Items"].ToString();
                    string total = reader["Total"].ToString();
                    string date = reader["Date"].ToString();

                    ListViewItem myListView = new ListViewItem(productName);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add((float.Parse(total)).ToString("N"));
                    myListView.SubItems.Add(date);

                    listView1.Items.Add(myListView);
                }
                reader.Close();
                connection.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Product (Serial No.)");
            listView1.Columns[0].Width = 175;
            listView1.Columns.Add("Price");
            listView1.Columns[1].Width = 125;
            listView1.Columns.Add("Items");
            listView1.Columns[2].Width = 125;
            listView1.Columns.Add("Total");
            listView1.Columns[3].Width = 125;

            if (radioButton4.Checked == true) //activate when click
            {
                SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                connection.Open();

                string queryString01 = "SELECT SerialNumber, ProductName, Price, SUM(items)[Items], SUM(Total)[Total] FROM Sales GROUP BY SerialNumber, ProductName, Price ORDER BY ProductName";
                SqlCommand command01 = new SqlCommand(queryString01, connection);
                var reader01 = command01.ExecuteReader();

                while (reader01.Read())
                {
                    string serialNumber = reader01["SerialNumber"].ToString();
                    string productName = reader01["ProductName"].ToString();
                    string price = reader01["Price"].ToString();
                    string items = reader01["Items"].ToString();
                    string total = reader01["Total"].ToString();

                    

                    ListViewItem myListView = new ListViewItem(productName +" (" + serialNumber + ")");
                    myListView.SubItems.Add(price);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);

                    listView1.Items.Add(myListView);
                }
                reader01.Close();
                connection.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Product (Serial No.)");
            listView1.Columns[0].Width = 175;
            listView1.Columns.Add("Price");
            listView1.Columns[1].Width = 125;
            listView1.Columns.Add("Items");
            listView1.Columns[2].Width = 125;
            listView1.Columns.Add("Total");
            listView1.Columns[3].Width = 125;

            if (radioButton2.Checked == true) //activate when click
            {
                SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                connection.Open();

                string queryString01 = "SELECT SerialNumber, ProductName, AVG(Price)[Price], SUM(items)[Items], SUM(Total)[Total] FROM Sales GROUP BY SerialNumber, ProductName ORDER BY ProductName";
                SqlCommand command01 = new SqlCommand(queryString01, connection);
                var reader01 = command01.ExecuteReader();

                while (reader01.Read())
                {
                    string serialNumber = reader01["SerialNumber"].ToString();
                    string productName = reader01["ProductName"].ToString();
                    string price = reader01["Price"].ToString();
                    string items = reader01["Items"].ToString();
                    string total = reader01["Total"].ToString();

                    ListViewItem myListView = new ListViewItem(productName + " (" + serialNumber + ")");
                    myListView.SubItems.Add(price);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);

                    listView1.Items.Add(myListView);
                }
                reader01.Close();
                connection.Close();
            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Serial Number");
            listView1.Columns[0].Width = 250;
            listView1.Columns.Add("Items");
            listView1.Columns[1].Width = 125;
            listView1.Columns.Add("Total");
            listView1.Columns[2].Width = 150;

            SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
            connection.Open();


            string queryString01 = "SELECT SerialNumber, SUM(items)[Items], SUM(Total)[Total] FROM Sales GROUP BY SerialNumber ORDER BY SerialNumber";
            SqlCommand command01 = new SqlCommand(queryString01, connection);
            var reader01 = command01.ExecuteReader();
            if (radioButton3.Checked == true)
            {
                while (reader01.Read())
                {
                    string serialNumber = reader01["SerialNumber"].ToString();
                    string items = reader01["Items"].ToString();
                    string total = reader01["Total"].ToString();

                    ListViewItem myListView = new ListViewItem(serialNumber);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add((float.Parse(total)).ToString("N"));

                    listView1.Items.Add(myListView);
                }
            }
            reader01.Close();
            connection.Close();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 aFrom = new Form3();
            string rawName = listView1.SelectedItems[0].SubItems[0].Text;
            string name = "";            
            if (radioButton3.Checked == false)
            {
                aFrom.isRadioButton3 = false;
                for (int a = 0, b = rawName.Length; a < b; a++)
                {
                    if (rawName[a] == ' ') break;
                    name += rawName[a];
                }
                aFrom.Name = name;
            }
            else
            {
                aFrom.isRadioButton3 = true;
                aFrom.Name = rawName;
            }
            aFrom.Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e) {  button1.BackColor = Color.YellowGreen; }
        private void button1_MouseLeave(object sender, EventArgs e) {  button1.BackColor = SystemColors.Control; }
        private void button1_Click(object sender, EventArgs e) {  this.Close(); }
        private void button2_MouseEnter(object sender, EventArgs e) {  button2.BackColor = Color.YellowGreen; }
        private void button2_MouseLeave(object sender, EventArgs e) {  button2.BackColor = SystemColors.Control; }
        private void button2_Click(object sender, EventArgs e) {  { new Form2().Show(); this.Close(); } }
        private void button3_MouseEnter(object sender, EventArgs e) {  button3.BackColor = Color.YellowGreen; }
        private void button3_MouseLeave(object sender, EventArgs e) {  button3.BackColor = SystemColors.Control; }
        private void button3_Click(object sender, EventArgs e) {  { new Form4().Show(); this.Close(); } }
        private void button4_Click(object sender, EventArgs e)
        {
            /*
            if (button4.Text == "<<<")
            {
                button4.Text = ">>>";
                button1.Cursor = button2.Cursor = button3.Cursor = Cursors.Default;
                button1.Text = button2.Text = button3.Text = string.Empty;
                button1.BackColor = button2.BackColor = button3.BackColor = SystemColors.Control;
            }
            else
            {
                button4.Text = "<<<";
                button1.Cursor = button2.Cursor = button3.Cursor = Cursors.Hand;
                button1.Text = "MENU";
                button2.Text = "PRODUCT";
                button3.Text = "POS";
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Aqua;
            }
            */
        }
    }
}
