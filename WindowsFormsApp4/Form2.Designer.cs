namespace WindowsFormsApp4
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_SerialNumber = new System.Windows.Forms.TextBox();
            this.tb_Product = new System.Windows.Forms.TextBox();
            this.tb_Price = new System.Windows.Forms.TextBox();
            this.btn_AddProduct = new System.Windows.Forms.Button();
            this.lv_ProductView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_UpdateProduct = new System.Windows.Forms.Button();
            this.btn_DeleteProduct = new System.Windows.Forms.Button();
            this.btn_ClearTextbox = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_SerialNumber
            // 
            this.tb_SerialNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_SerialNumber.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tb_SerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_SerialNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_SerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.tb_SerialNumber.Location = new System.Drawing.Point(1409, 52);
            this.tb_SerialNumber.Margin = new System.Windows.Forms.Padding(4);
            this.tb_SerialNumber.Name = "tb_SerialNumber";
            this.tb_SerialNumber.Size = new System.Drawing.Size(481, 75);
            this.tb_SerialNumber.TabIndex = 0;
            this.tb_SerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_SerialNumber.TextChanged += new System.EventHandler(this.tb_SerialNumber_TextChanged);
            // 
            // tb_Product
            // 
            this.tb_Product.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Product.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tb_Product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Product.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.tb_Product.Location = new System.Drawing.Point(1409, 134);
            this.tb_Product.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Product.Name = "tb_Product";
            this.tb_Product.Size = new System.Drawing.Size(481, 75);
            this.tb_Product.TabIndex = 4;
            this.tb_Product.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Product.TextChanged += new System.EventHandler(this.tb_Product_TextChanged);
            // 
            // tb_Price
            // 
            this.tb_Price.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Price.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tb_Price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Price.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.tb_Price.Location = new System.Drawing.Point(1409, 215);
            this.tb_Price.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Price.Name = "tb_Price";
            this.tb_Price.Size = new System.Drawing.Size(481, 75);
            this.tb_Price.TabIndex = 5;
            this.tb_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Price.TextChanged += new System.EventHandler(this.tb_Price_TextChanged);
            // 
            // btn_AddProduct
            // 
            this.btn_AddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_AddProduct.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_AddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_AddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btn_AddProduct.Location = new System.Drawing.Point(956, 298);
            this.btn_AddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btn_AddProduct.Name = "btn_AddProduct";
            this.btn_AddProduct.Size = new System.Drawing.Size(299, 80);
            this.btn_AddProduct.TabIndex = 6;
            this.btn_AddProduct.Text = "ADD";
            this.btn_AddProduct.UseVisualStyleBackColor = false;
            this.btn_AddProduct.Click += new System.EventHandler(this.btn_AddProduct_Click);
            // 
            // lv_ProductView
            // 
            this.lv_ProductView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lv_ProductView.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lv_ProductView.CheckBoxes = true;
            this.lv_ProductView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_ProductView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lv_ProductView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_ProductView.FullRowSelect = true;
            this.lv_ProductView.GridLines = true;
            this.lv_ProductView.HideSelection = false;
            this.lv_ProductView.Location = new System.Drawing.Point(13, 13);
            this.lv_ProductView.Margin = new System.Windows.Forms.Padding(4);
            this.lv_ProductView.MultiSelect = false;
            this.lv_ProductView.Name = "lv_ProductView";
            this.lv_ProductView.Size = new System.Drawing.Size(935, 1007);
            this.lv_ProductView.TabIndex = 8;
            this.lv_ProductView.UseCompatibleStateImageBehavior = false;
            this.lv_ProductView.View = System.Windows.Forms.View.Details;
            this.lv_ProductView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_ProductView_ItemChecked);
            this.lv_ProductView.Click += new System.EventHandler(this.lv_ProductView_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Avl";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SerialNumber";
            this.columnHeader2.Width = 215;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.Width = 200;
            // 
            // btn_UpdateProduct
            // 
            this.btn_UpdateProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_UpdateProduct.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_UpdateProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_UpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btn_UpdateProduct.Location = new System.Drawing.Point(1263, 298);
            this.btn_UpdateProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UpdateProduct.Name = "btn_UpdateProduct";
            this.btn_UpdateProduct.Size = new System.Drawing.Size(315, 80);
            this.btn_UpdateProduct.TabIndex = 9;
            this.btn_UpdateProduct.Text = "UPDATE";
            this.btn_UpdateProduct.UseVisualStyleBackColor = false;
            this.btn_UpdateProduct.Click += new System.EventHandler(this.btn_UpdateProduct_Click);
            // 
            // btn_DeleteProduct
            // 
            this.btn_DeleteProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_DeleteProduct.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_DeleteProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DeleteProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btn_DeleteProduct.Location = new System.Drawing.Point(1586, 298);
            this.btn_DeleteProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DeleteProduct.Name = "btn_DeleteProduct";
            this.btn_DeleteProduct.Size = new System.Drawing.Size(304, 80);
            this.btn_DeleteProduct.TabIndex = 10;
            this.btn_DeleteProduct.Text = "DELETE";
            this.btn_DeleteProduct.UseVisualStyleBackColor = false;
            this.btn_DeleteProduct.Click += new System.EventHandler(this.btn_DeleteProduct_Click);
            // 
            // btn_ClearTextbox
            // 
            this.btn_ClearTextbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ClearTextbox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_ClearTextbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ClearTextbox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ClearTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btn_ClearTextbox.Location = new System.Drawing.Point(956, 386);
            this.btn_ClearTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ClearTextbox.Name = "btn_ClearTextbox";
            this.btn_ClearTextbox.Size = new System.Drawing.Size(934, 80);
            this.btn_ClearTextbox.TabIndex = 11;
            this.btn_ClearTextbox.Text = "CLEAR";
            this.btn_ClearTextbox.UseVisualStyleBackColor = false;
            this.btn_ClearTextbox.Click += new System.EventHandler(this.btn_ClearTextbox_Click);
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.textBox4.Location = new System.Drawing.Point(956, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(446, 75);
            this.textBox4.TabIndex = 12;
            this.textBox4.Text = "Serial Number:";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.textBox5.Location = new System.Drawing.Point(956, 134);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(446, 75);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "Product: ";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.textBox6.Location = new System.Drawing.Point(956, 215);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(446, 75);
            this.textBox6.TabIndex = 14;
            this.textBox6.Text = "Price:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(956, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 35);
            this.button1.TabIndex = 17;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1222, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 35);
            this.button2.TabIndex = 18;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1488, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(260, 35);
            this.button3.TabIndex = 19;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(1754, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 35);
            this.button4.TabIndex = 20;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(1214, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(417, 35);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(956, 473);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(934, 547);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btn_ClearTextbox);
            this.Controls.Add(this.btn_DeleteProduct);
            this.Controls.Add(this.btn_UpdateProduct);
            this.Controls.Add(this.lv_ProductView);
            this.Controls.Add(this.btn_AddProduct);
            this.Controls.Add(this.tb_Price);
            this.Controls.Add(this.tb_Product);
            this.Controls.Add(this.tb_SerialNumber);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_SerialNumber;
        private System.Windows.Forms.TextBox tb_Product;
        private System.Windows.Forms.TextBox tb_Price;
        private System.Windows.Forms.Button btn_AddProduct;
        private System.Windows.Forms.ListView lv_ProductView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_UpdateProduct;
        private System.Windows.Forms.Button btn_DeleteProduct;
        private System.Windows.Forms.Button btn_ClearTextbox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}