using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            ListViewUpdate(); //loading the data from database


            // button4.Text = "<<<";
            button1.Cursor = button2.Cursor = button3.Cursor = Cursors.Hand;
            button1.Text = "MENU";
            button2.Text = "POS";
            button3.Text = "SALE";
            button1.BackColor = button2.BackColor = button3.BackColor = SystemColors.Control;
        }
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            //Checking if there are empty textboxt
            if (!deletePhase && !updatePhase)
            {
                if ((tb_SerialNumber.Text == string.Empty) || (tb_Product.Text == string.Empty) || (tb_Price.Text == string.Empty)) MessageBox.Show("PLEASE FILL UP EVERYTHING", "MISSING FIELD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //Connecting to the Server
                    SqlDatabaseConnection connectionS1 = new SqlDatabaseConnection();
                    SqlConnection connection = new SqlConnection(connectionS1.ConnectionString());
                    connection.Open();

                    //Sending Query to the Server
                    string queryString01 = "SELECT COUNT(SerialNumber) FROM Product WHERE SerialNumber = @SerialNumber";
                    SqlParameter param01 = new SqlParameter("@SerialNumber", tb_SerialNumber.Text);
                    SqlCommand command01 = new SqlCommand(queryString01, connection);
                    command01.Parameters.Add(param01);
                    int checkSerialNumber = Convert.ToInt16(command01.ExecuteScalar());

                    //Sending Query to the Server
                    string queryString02 = "SELECT COUNT(ProductName) FROM Product WHERE ProductName = @ProductName";
                    SqlParameter param02 = new SqlParameter("@ProductName", tb_Product.Text);
                    SqlCommand command02 = new SqlCommand(queryString02, connection);
                    command02.Parameters.Add(param02);
                    int checkProductName = Convert.ToInt16(command02.ExecuteScalar());

                    //Checking for dublicated SerialNumber and ProductName
                    if ((checkSerialNumber == 0) && (checkProductName == 0))
                    {
                        string queryString03 = "INSERT INTO Product(SerialNumber, ProductName, Price) VALUES(@Serial, @Product, @Price)"; //sending Insert Command
                        SqlParameter param03 = new SqlParameter("@Serial", tb_SerialNumber.Text);
                        SqlParameter param04 = new SqlParameter("@Product", tb_Product.Text);
                        SqlParameter param05 = new SqlParameter("@Price", tb_Price.Text);
                        SqlCommand command03 = new SqlCommand(queryString03, connection);
                        command03.Parameters.Add(param03);
                        command03.Parameters.Add(param04);
                        command03.Parameters.Add(param05);
                        command03.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("ADDED PRODUCT", "SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tb_SerialNumber.Text = tb_Product.Text = tb_Price.Text = string.Empty;


                        ListViewUpdate(); //updating the listview to new updated data
                    }
                    else if (checkSerialNumber > 0) MessageBox.Show("SERIAL NUMBER ALREADY TAKEN", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (checkProductName > 0) MessageBox.Show("PRODUCT NAME ALREADY TAKEN", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        } //button01

        private bool updatePhase = false;
        private string productName = "";
        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            
            if (!deletePhase)
            {
                if (!updatePhase)
                {

                    try
                    {
                        tb_SerialNumber.Text = lv_ProductView.SelectedItems[0].SubItems[1].Text; //getting the selected item and putting it in textbox
                        tb_Product.Text = lv_ProductView.SelectedItems[0].SubItems[2].Text;
                        tb_Price.Text = lv_ProductView.SelectedItems[0].SubItems[3].Text;
                        tb_Product.ReadOnly = tb_Price.ReadOnly = false;
                        tb_SerialNumber.ReadOnly = true;
                        updatePhase = true;
                        productName = lv_ProductView.SelectedItems[0].SubItems[2].Text;
                        SetButtonColor("btn_UpdateProduct", false);
                    }
                    catch { }

                }
                else
                {
                    bool isExistingProduct = false;

                    SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                    SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                    connection.Open();

                    string queryString1 = "SELECT ProductName FROM Product";
                    SqlCommand command1 = new SqlCommand(queryString1, connection);
                    var Reader = command1.ExecuteReader();

                    while (Reader.Read()) // checking if the ProductName is already existing
                    {
                        string productNameRead = Reader["ProductName"].ToString();
                        if (tb_Product.Text == productNameRead && productName != productNameRead)
                        {
                            MessageBox.Show("PRODUCT NAME ALREADY TAKEN", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isExistingProduct = true;
                            break;
                        }
                    }
                    Reader.Close();

                    if (isExistingProduct == false) // confirmation stage
                    {
                        if (tb_SerialNumber.Text == string.Empty || tb_Product.Text == string.Empty || tb_Price.Text == string.Empty)
                        {
                            MessageBox.Show("FILL UP EVERYTHING", "MISSING FIELD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        DialogResult result = MessageBox.Show("DO YOU WANT TO UPDATE THIS?", "CONDIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string commandString = "UPDATE Product SET ProductName = @productName, Price = @price WHERE SerialNumber = @SerialNumber";
                            SqlCommand command = new SqlCommand(commandString, connection); // sending update command 
                            command.Parameters.Add("@SerialNumber", tb_SerialNumber.Text);
                            command.Parameters.Add("@productName", tb_Product.Text);
                            command.Parameters.Add("@price", tb_Price.Text);
                            command.ExecuteNonQuery();

                            string commandString02 = "UPDATE Sales SET ProductName = @productName WHERE SerialNumber = @SerialNumber";
                            SqlCommand command02 = new SqlCommand(commandString02, connection); // sending update command 
                            command02.Parameters.Add("@SerialNumber", tb_SerialNumber.Text);
                            command02.Parameters.Add("@productName", tb_Product.Text);
                            command02.ExecuteNonQuery();

                            connection.Close();
                            ListViewUpdate(); //updating the listview to new update data

                            tb_SerialNumber.Text = tb_Product.Text = tb_Price.Text = string.Empty; // empty the textbox 
                            tb_SerialNumber.ReadOnly = false;
                            updatePhase = false;
                            SetButtonColor("btn_UpdateProduct", true);
                        }
                    }
                    connection.Close();
                }
            }
        } //button02

        private bool deletePhase = false;
        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (updatePhase == false)
            {
                if (deletePhase == false)
                {


                    try
                    {
                        tb_SerialNumber.Text = lv_ProductView.SelectedItems[0].SubItems[1].Text; //getting the selected item and putting it in textbox
                        tb_Product.Text = lv_ProductView.SelectedItems[0].SubItems[2].Text;
                        tb_Price.Text = lv_ProductView.SelectedItems[0].SubItems[3].Text;
                        tb_SerialNumber.ReadOnly = tb_Product.ReadOnly = tb_Price.ReadOnly = true;
                        deletePhase = true;
                        SetButtonColor("btn_DeleteProduct", false);
                    }
                    catch { }

                }
                else
                {
                    DialogResult result = MessageBox.Show("DO YOU WANT TO DELETE THIS?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SqlDatabaseConnection connectionString = new SqlDatabaseConnection(); //connecting to database
                        SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                        connection.Open();
                        string commnadString = "DELETE Product WHERE SerialNumber = @serialNumber"; //sending Delete command
                        SqlCommand command = new SqlCommand(commnadString, connection);
                        //MessageBox.Show("|"+lv_ProductView.SelectedItems[0].SubItems[1].Text+"|");
                        command.Parameters.Add("@serialNumber", tb_SerialNumber.Text);
                        command.ExecuteNonQuery();

                        string commnadString02 = "DELETE Sales WHERE SerialNumber = @serialNumber"; //sending Delete command
                        SqlCommand command02 = new SqlCommand(commnadString02, connection);
                        //MessageBox.Show("|"+lv_ProductView.SelectedItems[0].SubItems[1].Text+"|");
                        command02.Parameters.Add("@serialNumber", tb_SerialNumber.Text);
                        command02.ExecuteNonQuery();
                        
                        connection.Close();
                        ListViewUpdate(); //updating the listview to new updated data 

                        tb_SerialNumber.Text = tb_Product.Text = tb_Price.Text = string.Empty; //setting textbox to default
                        tb_SerialNumber.ReadOnly = tb_Product.ReadOnly = tb_Price.ReadOnly = false;
                        deletePhase = false;
                        SetButtonColor("btn_DeleteProduct", true);
                    }
                    lv_ProductView.SelectedItems.Clear();
                }
            }


        } //button03

        private void SetButtonColor(string BtnName, bool isdefault)
        {
            if (isdefault)
            {
                if (BtnName == "btn_UpdateProduct")
                {
                    btn_UpdateProduct.BackColor = Color.MediumSpringGreen;
                    //btn_UpdateProduct.FlatAppearance.BorderColor = Color.Black;
                }
                else if (BtnName == "btn_DeleteProduct")
                {
                    btn_DeleteProduct.BackColor = Color.MediumSpringGreen;
                    //btn_DeleteProduct.FlatAppearance.BorderColor = Color.Black;
                }
            }
            else
            {
                if (BtnName == "btn_UpdateProduct")
                {
                    btn_UpdateProduct.BackColor = Color.Orange;
                    //btn_UpdateProduct.FlatAppearance.BorderColor = Color.DarkOliveGreen;
                }
                else if (BtnName == "btn_DeleteProduct")
                {
                    btn_DeleteProduct.BackColor = Color.Orange;
                    //btn_DeleteProduct.FlatAppearance.BorderColor = Color.DarkOliveGreen;
                }
            }

        }

        private void btn_ClearTextbox_Click(object sender, EventArgs e)
        {
            SetButtonColor("btn_UpdateProduct", true);
            SetButtonColor("btn_DeleteProduct", true);
            tb_SerialNumber.Text = tb_Product.Text = tb_Price.Text = string.Empty; //setting textbox to default
            tb_SerialNumber.ReadOnly = tb_Product.ReadOnly = tb_Price.ReadOnly = false;
            updatePhase = deletePhase = false;
            lv_ProductView.SelectedItems.Clear();
        } //button04

        private void tb_Price_TextChanged(object sender, EventArgs e)
        {
            try // allowing only number to be inputed
            {
                if (tb_Price.Text != string.Empty)
                {
                    double number = Convert.ToDouble(tb_Price.Text);
                    if (number > 2147483647) //Setting the maximum amount can put
                    {
                        MessageBox.Show("EXCEED MAXIMUM INPUT", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_Price.Text = string.Empty;
                    }
                }
            }
            catch
            {
                MessageBox.Show("PLEASE ENTER NUMBERS ONLY", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_Price.Text = string.Empty;
            }
        }

        private void tb_Product_TextChanged(object sender, EventArgs e)
        {
            LengthLimitation(tb_Product, 30);
        }

        private void tb_SerialNumber_TextChanged(object sender, EventArgs e)
        {
            LengthLimitation(tb_SerialNumber, 9);
        }
        public void LengthLimitation(TextBox textbox, double maximumCharacter)
        {
            if (textbox.TextLength > maximumCharacter) //Setting the maximum character can put 
            {
                MessageBox.Show("EXCEED MAXIMUM INPUT", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Text = string.Empty;
            }

            if (textbox.Text.IndexOf(" ") != -1)
            {
                MessageBox.Show("NO SPACE ALLOWED", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Text = string.Empty;
            }
        }

        private void lv_ProductView_Click(object sender, EventArgs e)
        {
            tb_SerialNumber.Text = tb_Product.Text = tb_Price.Text = string.Empty;
            tb_SerialNumber.ReadOnly = tb_Product.ReadOnly = tb_Price.ReadOnly = false;
            updatePhase = deletePhase = false; //setting phase to default
            SetButtonColor("btn_DeleteProduct", true);
            SetButtonColor("btn_UpdateProduct", true);
        }

        private void lv_ProductView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
            connection.Open();

            try
            {
                //MessageBox.Show(listView1.Items.Count.ToString());
                for (int a = 0, b = lv_ProductView.Items.Count; a < b; a++)
                {
                    //MessageBox.Show(listView1.Items[a].SubItems[1].Text);
                    //MessageBox.Show(listView1.Items[a].Checked.ToString());
                    bool check = lv_ProductView.Items[a].Checked;

                    string commandString = "UPDATE Product SET Availability = @availability WHERE SerialNumber = @serialNumber";
                    SqlCommand command = new SqlCommand(commandString, connection);

                    if (lv_ProductView.Items[a].Checked == true) command.Parameters.Add("@availability", true);
                    else command.Parameters.Add("@availability", false);
                    command.Parameters.Add("@serialNumber", lv_ProductView.Items[a].SubItems[1].Text);

                    command.ExecuteNonQuery();
                }
            }
            catch { }
            connection.Close();
        }
        private void ListViewUpdate()
        {
            lv_ProductView.Items.Clear();
            SqlDatabaseConnection database = new SqlDatabaseConnection(); //connecting to database
            SqlConnection connection = new SqlConnection(database.ConnectionString());
            connection.Open();

            string queryString = "SELECT * FROM Product ORDER BY SerialNumber"; //sending select command
            SqlCommand command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();

            while (reader.Read()) //reading all the data from the database
            {
                string serialNumber = reader["SerialNumber"].ToString(); //temporary storing data from database
                string productName = reader["ProductName"].ToString();
                string price = reader["Price"].ToString();
                string availability = reader["availability"].ToString();

                ListViewItem myListView = new ListViewItem(); //setting the data from database to listview
                myListView.SubItems.Add(serialNumber);
                myListView.SubItems.Add(productName);
                myListView.SubItems.Add((float.Parse(price)).ToString("N"));
                lv_ProductView.Items.Add(myListView); //adding data from database to listview
                if (availability == "True") myListView.Checked = true;
                else myListView.Checked = false;
            }

            reader.Close();
            connection.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.YellowGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.YellowGreen;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
             button2.BackColor = SystemColors.Control;
        }
        private void button2_Click(object sender, EventArgs e) {  { new Form4().Show(); this.Close(); }; }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.YellowGreen;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.Control;
        }
        private void button3_Click(object sender, EventArgs e)
        {
             { new Form5().Show(); this.Close(); };
        }

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
                button2.Text = "POS";
                button3.Text = "SALE";
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Aqua;
            }
            */
        }
    }
}
