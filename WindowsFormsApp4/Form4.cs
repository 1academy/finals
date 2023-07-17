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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public float pageLimit;
        public int pageState = 1;
        public ButtonBase[] buttonA1;
        public int[] numberOfOrderA1;
        public int buttonA1Index = -1;
        public float totalF1 = 0;

        private void Form4_Load(object sender, EventArgs e)
        {


            //Connecting to Database
            SqlDatabaseConnection database = new SqlDatabaseConnection();
            SqlConnection connection = new SqlConnection(database.ConnectionString());
            connection.Open();

            //Sending Query
            string queryString01 = "SELECT COUNT(SerialNumber) FROM Product WHERE Availability = 1";
            SqlCommand command01 = new SqlCommand(queryString01, connection);
            int numberOfProduct = Convert.ToInt16(command01.ExecuteScalar());
            float remainder = (numberOfProduct % 9);
            pageLimit = (numberOfProduct / 9) + (remainder / 10);

            //Sending Query
            string queryString02 = "SELECT * FROM Product WHERE Availability = 1 ORDER BY ProductName";
            SqlCommand command02 = new SqlCommand(queryString02, connection);
            var reader = command02.ExecuteReader();

            //Creating a array of buttons
            buttonA1 = new ButtonBase[numberOfProduct];
            numberOfOrderA1 = new int[numberOfProduct];
            //Button buttonB = new Button();
            int startX = 1192; 
            int startY = 58;
            int distanceX = 201;
            int distanceY = 152;
            int x = startX, y = startY;
            int count = 0;

            //Creating number of button base on number of product
            for (int i = 0, a = numberOfProduct; i < a; i++)
            {
                //Reading the ProductName and Price from the Database
                reader.Read();
                float priceF1 = float.Parse(reader["Price"].ToString());
                string ProductNameS1 = reader["ProductName"].ToString() + " " + priceF1.ToString("C");
                
                //Creating a sequence of button
                CreateButton(x, y, ProductNameS1); //160 115
                x -= distanceX;
                count++;
                if (count == 3)
                {
                    y += distanceY;
                    x = startX;
                }
                if (count == 6)
                {
                    y += distanceY;
                    x = startX;
                }
                if (count == 9)
                {
                    y = startY;
                    x = startX;
                    count = 0;
                }
            }
            if (numberOfProduct < 10) button11.Enabled = false;

            pictureBox1.SendToBack();
            pictureBox2.SendToBack();
            pictureBox3.SendToBack();
            pictureBox4.SendToBack();
            pictureBox5.SendToBack();
            pictureBox6.SendToBack();
            pictureBox7.SendToBack();
            pictureBox8.SendToBack();
            pictureBox9.SendToBack();

            // button4.Text = "<<<";
            button1.Cursor = button2.Cursor = button3.Cursor = Cursors.Hand;
            button1.Text = "MENU";
            button2.Text = "PRODUCT";
            button3.Text = "SALE";
            button1.BackColor = button2.BackColor = button3.BackColor = SystemColors.Control;
        }
        public void CreateButton(int x, int y, string prductName)
        {
            //Creating a new button and setting properties
            buttonA1Index++;
            Button button = new Button();
            button.Width = 195; //155, 110
            button.Height = 146;
            button.Location = new Point(x, y);
            button.Text = prductName;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.Name = "button" + buttonA1Index;
            button.Visible = true;
            button.BackColor = Color.FromArgb(128, 255, 128);
            button.FlatStyle = FlatStyle.Popup;
            button.Cursor = Cursors.Hand;
            Controls.Add(button);

            buttonA1[buttonA1Index] = button; //Setting each button in Array
            buttonA1[buttonA1Index].Click += new EventHandler(Button_Click); //Creating a EventHandler for each button
        }
        public void Button_Click(object sender, EventArgs e) //Event when the button is clicked
        {   
            Button button = sender as Button;

            string buttonText = button.Text;
            bool priceStartIndex = false;
            string priceS1 = "";
            string productName = "";
            bool once = false;
            for (int d = 0, f = buttonText.Length; d < f; d++) //Seperating ProductName and Price from the Button Text
            {
                if (priceStartIndex == true) priceS1 += buttonText[d]; //Seperating Price from Button Text
                if (buttonText[d] == '₱') priceStartIndex = true; //finding currency to know the boarderline of ProductName and Price
                if (priceStartIndex == false) productName += buttonText[d]; //Seperating ProductName from Button Text
            }
            float pricef1 = float.Parse(priceS1);

            for (int a = 0; a <= buttonA1Index; a++) //Running all the button from button array
            {
                if (button.Text == buttonA1[a].Text) //Searching for button clicked
                {
                    for (int b = 0, c = listBox1.Items.Count; b < c; b++) //Running all items from listBox
                    {
                        if (once == false) //Updating Price
                        {
                            pricef1 *= numberOfOrderA1[a]; //Updating Price
                            totalF1 -= pricef1; //updating the Total Sum
                            once = true;
                        }
                        if (listBox1.Items[b].ToString() == (numberOfOrderA1[a] + " " + productName + pricef1.ToString("C"))) //Removing data from the listBox01
                        { 
                            listBox1.Items.Remove(listBox1.Items[b]);
                            break;
                        }
                    }
                    numberOfOrderA1[a]++; //+1 number of order
                    pricef1 = float.Parse(priceS1);
                    pricef1 *= numberOfOrderA1[a]; //Updating Price for the new item in listbox
                    //textBox1.Text = (totalF1 += pricef1).ToString("f"); //updating the Total Sum
                    TotalCompute();
                    listBox1.Items.Add(numberOfOrderA1[a] + " " + productName + pricef1.ToString("C")); //Adding data(updated) to listBox01
                    break;
                }
            }
            OrderNumberTab();
            CountNumberOfOrders();
        }
        private void button10_Click(object sender, EventArgs e) //Previous Button
        {
            for (int a = (pageState - 2) * 9, b = (pageState - 1) * 9; a < b; a++) buttonA1[a].Visible = true; //hidding the buttons
            pageState--;
            if (pageState == 1) button10.Enabled = false; //Checking if there's another page for Previous
            button11.Enabled = true;
            
        }
        private void button11_Click(object sender, EventArgs e) //Next Button
        {
            pageState++;
            for (int a = (pageState - 2) * 9, b = (pageState - 1) * 9; a < b; a++) buttonA1[a].Visible = false; //showing the buttons 
            if (pageState >= pageLimit) button11.Enabled = false; //Checking if there's another page for Next
            button10.Enabled = true;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("DO YOU WANT TO PURCHASE THIS?", "CONFIRMATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int a = 0; a < listBox1.Items.Count; a++)
                {
                    SqlDatabaseConnection connectionString = new SqlDatabaseConnection();
                    SqlConnection connection = new SqlConnection(connectionString.ConnectionString());
                    connection.Open();
                    string queryString = "INSERT INTO Sales VALUES(@SerialNumber, @ProductName, @price, @items, @total, @date)";
                    SqlCommand command = new SqlCommand(queryString, connection);


                    string items = "", productName = "", total = "", date = "";
                    bool productNameStart = false;
                    bool productNameEnd = false;
                    bool totalStart = false;

                    string listboxItem = listBox1.Items[a].ToString();
                    for (int b = 0; b < listboxItem.Length; b++)//seperating item, ProductName, and Total
                    {
                        if (totalStart == true) total += listboxItem[b];
                        if (listboxItem[b] == '₱') totalStart = true;

                        if (productNameStart == true && listboxItem[b] == ' ') productNameEnd = true;
                        if (productNameStart == true && productNameEnd == false) productName += listboxItem[b];

                        if (listboxItem[b] == ' ') productNameStart = true;
                        if (productNameStart != true) items += listboxItem[b];
                    }

                    string queryString02 = "SELECT * FROM Product WHERE ProductName = @Product";
                    SqlCommand command02 = new SqlCommand(queryString02, connection);
                    command02.Parameters.Add("@Product", productName);
                    var reader = command02.ExecuteReader();

                    reader.Read();
                    string serialNumber = reader["SerialNumber"].ToString();
                    //MessageBox.Show(serialNumber);
                    reader.Close();


                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    float price = float.Parse(total) / float.Parse(items);
                    //MessageBox.Show(productName + "-" + price + "-" + items + "-" + total + "-" + date.ToString());
                    command.Parameters.Add("@SerialNumber", serialNumber);
                    command.Parameters.Add("@ProductName", productName);
                    command.Parameters.Add("@price", price.ToString());
                    command.Parameters.Add("@items", items);
                    command.Parameters.Add("@total", total);
                    command.Parameters.Add("@date", date);

                    command.ExecuteNonQuery();
                    connection.Close();
                }

                listBox1.Items.Clear();
                textBox1.Text = textBox3.Text = 0.ToString("f");
                textBox2.Text = textBox4.Text = string.Empty;
                textBox5.Text = 1.ToString();
                for (int a = 0; a <= buttonA1Index; a++) numberOfOrderA1[a] = 0;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TotalCompute();
            string selectedItem = ""; //getting the selected item
            for (int a = 0; a < listBox1.Items.Count; a++) if (listBox1.Items[a] == listBox1.SelectedItem) selectedItem = listBox1.Items[a].ToString();

            bool productNameStart = false;
            string listBoxProductName = "";
            for (int a = 0, b = selectedItem.Length; a < b; a++) //running all the characters of Selected Item
            {
                if (productNameStart == true)
                {
                    if (selectedItem[a] == ' ') break;
                    listBoxProductName += selectedItem[a]; //getting ProductName text from selected item in listBox
                }
                if (selectedItem[a] == ' ') productNameStart = true;
            }

            for (int a = 0; a <= buttonA1Index; a++) //running all the button from buttonA1
            {
                string buttonText = buttonA1[a].Text;
                string buttonTextProductName = "";
                bool productNameEnd = false;

                bool priceStart = false;
                string buttonTextPrice = "";

                for (int b = 0, c = buttonA1[a].Text.Length; b < c; b++) //running all the characters of ButtonText
                {
                    if (buttonText[b] == ' ') productNameEnd = true;
                    if (productNameEnd == false) buttonTextProductName += buttonText[b]; //getting the ProductName text from ButtonText

                    if (priceStart == true) buttonTextPrice += buttonText[b]; //getting the Price text from ButtonText
                    if (buttonText[b] == '₱') priceStart = true;
                }
                if (buttonTextProductName == listBoxProductName) //Comparing the ProductName from ListBox and Button
                {
                    //textBox1.Text = (totalF1 -= (numberOfOrderA1[a] * float.Parse(buttonTextPrice))).ToString("f"); //Updating the Total Sum
                    //TotalCompute();
                    numberOfOrderA1[a] = 0; //Updating the number of orders
                    break;
                }
            }
            listBox1.Items.Remove(listBox1.SelectedItem);
            OrderNumberTab();
            CountNumberOfOrders();
            TotalCompute();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //TB1:total TB2:Tender TB3:Change
        {

            
            if (float.Parse(textBox1.Text) > 0)
            {
                textBox2.Enabled = true;
                textBox10.BackColor = textBox2.BackColor = Color.PaleGoldenrod;
                textBox4.BackColor = Color.PaleGoldenrod;
                ComputeChange();
            }
            else
            {

                textBox2.Enabled = false;
                textBox10.BackColor = textBox2.BackColor = SystemColors.GrayText;
                textBox4.BackColor = SystemColors.GrayText;
                textBox2.Text = string.Empty;
                button12.Enabled = false;
            }
            CountNumberOfOrders();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //tender
        {
            ComputeChange();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == 0.ToString()) textBox5.Text = 1.ToString();
            if (textBox5.Text != string.Empty)
            {
                int orderNumber = 0;
                try
                {
                    if (int.Parse(textBox5.Text) <= 1000000) orderNumber = int.Parse(textBox5.Text);
                    else
                    {
                        MessageBox.Show("EXCEED MAXIMUM INPUT", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox5.Text = 1.ToString();
                        orderNumber = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("PLEASE ENTER A NUMBER", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Text = 1.ToString();
                    orderNumber = 1;
                }
                string currentOrderListBox = "";
                if (listBox1.Items.Count != 0) currentOrderListBox = listBox1.Items[listBox1.Items.Count - 1].ToString();
                string currentOrderProductName = "";
                bool productNameStart = false;

                for (int a = 0, b = currentOrderListBox.Length; a < b; a++)
                {
                    if (productNameStart == true)
                    {
                        if (currentOrderListBox[a] == ' ') break;
                        currentOrderProductName += currentOrderListBox[a];
                    }
                    if (currentOrderListBox[a] == ' ') productNameStart = true;
                }

                for (int a = 0, b = buttonA1Index; a <= b; a++)
                {
                    string buttonTextS1 = buttonA1[a].Text;
                    string buttonProductNameS1 = "";
                    bool buttonProductNameEndB1 = false;

                    string buttonPriceS1 = "";
                    bool buttonPriceStartB1 = false;
                    float buttonPriceF1 = 0;

                    for (int c = 0, d = buttonTextS1.Length; c < d; c++)
                    {
                        if (buttonTextS1[c] == ' ') buttonProductNameEndB1 = true;
                        if (buttonProductNameEndB1 == false) buttonProductNameS1 += buttonTextS1[c];

                        if (buttonPriceStartB1 == true) buttonPriceS1 += buttonTextS1[c];
                        if (buttonTextS1[c] == '₱') buttonPriceStartB1 = true;
                    }

                    if (buttonProductNameS1 == currentOrderProductName)
                    {
                        numberOfOrderA1[a] = orderNumber;
                        buttonPriceF1 = orderNumber * float.Parse(buttonPriceS1);
                        listBox1.Items.Remove(listBox1.Items[listBox1.Items.Count - 1]);
                        listBox1.Items.Add(orderNumber + " " + buttonProductNameS1 + " " + buttonPriceF1.ToString("C"));
                        TotalCompute();
                    }
                }
            }
        }
        private void TotalCompute()
        {
            totalF1 = 0;
            for (int a = 0, b = buttonA1Index; a <= b; a++)
            {
                string buttonText = buttonA1[a].Text;
                bool buttonPriceStart = false;
                string buttonPrice = "";

                for (int c = 0, d = buttonText.Length; c < d; c++)
                {
                    if (buttonPriceStart == true) buttonPrice += buttonText[c];
                    if (buttonText[c] == '₱') buttonPriceStart = true;
                }
                totalF1 += (numberOfOrderA1[a] * float.Parse(buttonPrice));
            }
            textBox1.Text = totalF1.ToString("f");
        }

        private void OrderNumberTab()
        {
            if (listBox1.Items.Count != 0)
            {
                string currentOrderListBox = listBox1.Items[listBox1.Items.Count - 1].ToString();
                string currentOrderNoOfOrder = "";
                for (int a = 0, b = currentOrderListBox.Length; a < b; a++)
                {
                    if (currentOrderListBox[a] == ' ') break;
                    currentOrderNoOfOrder += currentOrderListBox[a];
                }
                textBox5.Text = currentOrderNoOfOrder;
            }
            else
            {
                textBox5.Text = 1.ToString();
            }
        }
        private void ComputeChange() 
        {
            float tenderF1 = 0;
            try
            {
                if (textBox2.Text != string.Empty) tenderF1 = float.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("NUMBERS ONLY PLEASE!", "INVALID INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = string.Empty;
            }
            if (tenderF1 >= totalF1)
            {
                textBox3.Text = (tenderF1 - totalF1).ToString("f");
                button12.Enabled = true;
            }
            else
            {
                textBox3.Text = 0.ToString("f");
                button12.Enabled = false;
            }
        }
        private void CountNumberOfOrders() 
        {
            int numberOfOrders = 0;
            for (int a = 0; a <= buttonA1Index; a++) numberOfOrders += numberOfOrderA1[a];
            if (numberOfOrders > 0) textBox4.Text = numberOfOrders.ToString();
            else textBox4.Text = string.Empty;
        }

        private void textBox5_Click(object sender, EventArgs e){ textBox5.SelectAll(); }

        private void button1_MouseEnter(object sender, EventArgs e) { button1.BackColor = Color.YellowGreen; }
        private void button1_MouseLeave(object sender, EventArgs e) { button1.BackColor = SystemColors.Control; }
        private void button1_Click(object sender, EventArgs e) { this.Close(); }
        private void button2_MouseEnter(object sender, EventArgs e) { button2.BackColor = Color.YellowGreen; }
        private void button2_MouseLeave(object sender, EventArgs e){ button2.BackColor = SystemColors.Control; }
        private void button2_Click(object sender, EventArgs e) { { new Form2().Show(); this.Close(); } }
        private void button3_MouseEnter(object sender, EventArgs e) { button3.BackColor = Color.YellowGreen; }
        private void button3_MouseLeave(object sender, EventArgs e) { button3.BackColor = SystemColors.Control; }
        private void button3_Click(object sender, EventArgs e) { { new Form5().Show(); this.Close(); } }
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
                button3.Text = "SALE";
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Aqua;
            }
            */
        }
    }
}