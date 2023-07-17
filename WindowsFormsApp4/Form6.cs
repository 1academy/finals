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
    public partial class Form6 : Form
    {
        public string SerialNumber { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = SerialNumber;
            textBox2.Text = Product;
            textBox3.Text = Price;     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to Delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (answer == DialogResult.Yes)
            {
                SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                connection.Open();

                string queryString = "DELETE Product WHERE SerialNumber  = @SerialNumber";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("SerialNumber", textBox1.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Deleted Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Refresh();
        }
    }
}
