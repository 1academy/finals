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
    public partial class Form3 : Form
    {
        public string Name { get; set; }
        public bool isRadioButton3 { get; set; }
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlDatabaseConnection database = new SqlDatabaseConnection();
            SqlConnection connection = new SqlConnection(database.ConnectionString());
            connection.Open();


            if (isRadioButton3 == false)
            {
                /*
                listView2.Items.Clear();
                listView2.Columns.Clear();
                listView2.Columns.Add("Serial Number");
                listView2.Columns[0].Width = 175;
                listView2.Columns.Add("Product");
                listView2.Columns[1].Width = 175;
                listView2.Columns.Add("Price");
                listView2.Columns[2].Width = 125;
                listView2.Columns.Add("Items");
                listView2.Columns[3].Width = 125;
                listView2.Columns.Add("Total");
                listView2.Columns[4].Width = 125;
                */
                string queryString = "SELECT SerialNumber, SUM(Items)[Items], SUM(Total)[Total] FROM Sales WHERE ProductName = @ProductName GROUP BY ProductName, SerialNumber";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ProductName", Name);
                var reader01 = command.ExecuteReader();

                while (reader01.Read())
                {
                    string serialNumber = reader01["SerialNumber"].ToString();
                    string items = reader01["Items"].ToString();
                    string total = reader01["Total"].ToString();


                    ListViewItem myListView = new ListViewItem(serialNumber);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);

                    listView2.Items.Add(myListView);
                }
                reader01.Close();

                string queryString02 = "SELECT * FROM Sales WHERE ProductName = @ProductName ORDER BY Date";
                SqlCommand command02 = new SqlCommand(queryString02, connection);
                command02.Parameters.Add("@ProductName", Name);
                var reader02 = command02.ExecuteReader();

                while (reader02.Read())
                {
                    string productName = reader02["ProductName"].ToString();
                    string price = reader02["Price"].ToString();
                    string items = reader02["Items"].ToString();
                    string total = reader02["Total"].ToString();
                    string date = reader02["Date"].ToString();

                    ListViewItem myListView = new ListViewItem(productName);
                    myListView.SubItems.Add(price);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);
                    myListView.SubItems.Add(date);

                    listView1.Items.Add(myListView);
                }
                reader02.Close();
            }
            else 
            {
                string queryString = "SELECT SerialNumber, SUM(Items)[Items], SUM(Total)[Total] FROM Sales WHERE SerialNumber = @serialNumber GROUP BY SerialNumber";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@serialNumber", Name);
                var reader01 = command.ExecuteReader();

                while (reader01.Read())
                {
                    string serialNumber = reader01["SerialNumber"].ToString();
                    string items = reader01["Items"].ToString();
                    string total = reader01["Total"].ToString();

                    ListViewItem myListView = new ListViewItem(serialNumber);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);

                    listView2.Items.Add(myListView);
                }
                reader01.Close();
                
                string queryString02 = "SELECT * FROM Sales WHERE SerialNumber = @serialNumber ORDER BY Date";
                SqlCommand command02 = new SqlCommand(queryString02, connection);
                command02.Parameters.Add("@serialNumber", Name);
                var reader02 = command02.ExecuteReader();

                while (reader02.Read())
                {
                    string productName = reader02["ProductName"].ToString();
                    string price = reader02["Price"].ToString();
                    string items = reader02["Items"].ToString();
                    string total = reader02["Total"].ToString();
                    string date = reader02["Date"].ToString();

                    ListViewItem myListView = new ListViewItem(productName);
                    myListView.SubItems.Add(price);
                    myListView.SubItems.Add(items);
                    myListView.SubItems.Add(total);
                    myListView.SubItems.Add(date);

                    listView1.Items.Add(myListView);
                }
                reader02.Close();
            }
            
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) { this.Close(); }
    }
}
