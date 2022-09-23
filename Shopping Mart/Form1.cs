using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Shopping_Mart
{
    public partial class Form1 : Form
    {
        int FinalCost = 0;
        int SrNo = 0;
        int tax = 0;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            getInvoiceID();
            USERtextBox.Text = Login.username;
            GetItems();
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR NO";
            dataGridView1.Columns[1].Name = "ITEM NAME";
            dataGridView1.Columns[2].Name = "UNIT PRICE";
            dataGridView1.Columns[3].Name = "DISCOUNT PER ITEM";
            dataGridView1.Columns[4].Name = "QUANTITY";
            dataGridView1.Columns[5].Name = "SUB TOTAL";
            dataGridView1.Columns[6].Name = "TAX";
            dataGridView1.Columns[7].Name = "TOTAL COST";
        }


        // GetItem Method
        void GetItems()
        {
            ITEMScomboBox.Items.Clear();
            SqlConnection con=new SqlConnection(cs);
            string query = "select * from items_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string item_names = dr.GetString(1);
                ITEMScomboBox.Items.Add(item_names);
            }
            ITEMScomboBox.Sorted = true;
            con.Close();
        }


        // getPrice Method
        void getPrice()
        {
            if (ITEMScomboBox.SelectedItem == null)
            {

            }
            else
            {
                int price = 0;
                SqlConnection con = new SqlConnection(cs);
                string query = "select item_price from items_tbl where item_name=@name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@name", ITEMScomboBox.SelectedItem.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);
                if (data.Rows.Count > 0)
                {
                    price = Convert.ToInt32(data.Rows[0]["item_price"]);
                }
                PRICEtextBox.Text = price.ToString();
            }
        }


        // getDiscount Method
        void getDiscount()
        {
            if (ITEMScomboBox.SelectedItem == null)
            {

            }
            else
            {
                int discount = 0;
                SqlConnection con = new SqlConnection(cs);
                string query = "select item_discount from items_tbl where item_name=@name";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@name", ITEMScomboBox.SelectedItem.ToString());
                DataTable data = new DataTable();
                sda.Fill(data);

                if (data.Rows.Count > 0)
                {
                    discount = Convert.ToInt32(data.Rows[0]["item_discount"]);
                }
                DISCOUNTtextBox.Text = discount.ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ITEMScomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPrice();
            getDiscount();
            QUANTITYtextBox.Enabled = true;
        }
        private void QUANTITYtextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(QUANTITYtextBox.Text)==true)
            {

            }
            else
            {
                int price = Convert.ToInt32(PRICEtextBox.Text);
                int discount = Convert.ToInt32(DISCOUNTtextBox.Text);
                int quantity = Convert.ToInt32(QUANTITYtextBox.Text);
                int subTotal = price * quantity;
                subTotal = subTotal - discount * quantity;
                SUBTOTALtextBox.Text = subTotal.ToString();
            }
        }
        private void SUBTOTALtextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SUBTOTALtextBox.Text) == true)
            {

            }
            else
            {
                int subTotal = Convert.ToInt32(SUBTOTALtextBox.Text);
                if (subTotal >= 10000)
                {
                    tax = (int)(subTotal * 0.15);
                    TAXtextBox.Text = tax.ToString();
                }
                else if (subTotal >= 6000)
                {
                    tax = (int)(subTotal * 0.10);
                    TAXtextBox.Text = tax.ToString();
                }
                else if (subTotal >= 3000)
                {
                    tax = (int)(subTotal * 0.07);
                    TAXtextBox.Text = tax.ToString();
                }
                else if (subTotal >= 1000)
                {
                    tax = (int)(subTotal * 0.05);
                    TAXtextBox.Text = tax.ToString();
                }
                else
                {
                    tax = (int)(subTotal * 0.03);
                    TAXtextBox.Text = tax.ToString();
                }
            }
        }

        private void TAXtextBox_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TAXtextBox.Text) == true)
            {

            }
            else
            {
                int subTotal = Convert.ToInt32(SUBTOTALtextBox.Text);
                int tax = Convert.ToInt32(TAXtextBox.Text);
                int TotalCost = subTotal + tax;
                TOTALCOSTtextBox.Text = TotalCost.ToString();
            }
        }

        void AddDataToGridView(string Sr_No, string item_name, string unit_price, string discount, string quantity, string sub_total, string tax, string total_cost)
        {

            string[] row = {Sr_No, item_name, unit_price, discount, quantity, sub_total, tax, total_cost};
            dataGridView1.Rows.Add(row);

        }

        private void ADDbutton_Click(object sender, EventArgs e)
        {
            if (ITEMScomboBox.SelectedItem != null)
            {
                AddDataToGridView((++SrNo).ToString(), ITEMScomboBox.SelectedItem.ToString(), PRICEtextBox.Text, DISCOUNTtextBox.Text, QUANTITYtextBox.Text, SUBTOTALtextBox.Text, TAXtextBox.Text, TOTALCOSTtextBox.Text);
                ResetControls();
                CalculateFinalCost();
            }
            else
            {
                MessageBox.Show("Please Select An Item !!");
            }
        }


        // ResetControls Method
        void ResetControls()
        {
            ITEMScomboBox.SelectedItem = null;
            PRICEtextBox.Clear();
            DISCOUNTtextBox.Clear();
            QUANTITYtextBox.Clear();
            SUBTOTALtextBox.Clear();
            TAXtextBox.Clear();
            TOTALCOSTtextBox.Clear();
            FINALCOSTtextBox.Clear();
            AMOUNTPAIDtextBox.Clear();
            CHANGEtextBox.Clear();
            QUANTITYtextBox.Enabled = false;
        }


        void CalculateFinalCost()
        {
            FinalCost = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                FinalCost=FinalCost + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
            FINALCOSTtextBox.Text = FinalCost.ToString();
        }


        private void AMOUNTtextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AMOUNTPAIDtextBox.Text)==true)
            {

            }
            else
            {
                int AmountPaid=Convert.ToInt32(AMOUNTPAIDtextBox.Text);
                int FCost = Convert.ToInt32(FINALCOSTtextBox.Text);
                int change = AmountPaid - FCost;
                CHANGEtextBox.Text = change.ToString();
            }
        }

        private void RESETbutton_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void CLEARGRIDVIEWbutton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SrNo = 0;
        }

        void getInvoiceID()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select invoice_ID from order_master";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);

            if (data.Rows.Count < 1)
            {
                INVOICEtextBox.Text = "1";
            }
            else
            {
                string query2 = "select max(invoice_ID) from order_master"; //max return single value; it is also called scalar method
                SqlCommand cmd = new SqlCommand(query2, con);
                con.Open();
                int a=Convert.ToInt32(cmd.ExecuteScalar()); // ExecuteScalar is used due to "max"
                a = a + 1;
                INVOICEtextBox.Text = a.ToString();
                con.Close();

            }
        }

        private void INSERTbutton_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into order_master values(@id,@user,@datetime,@finalcost)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", INVOICEtextBox.Text);
            cmd.Parameters.AddWithValue("@user", USERtextBox.Text);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@finalcost", FINALCOSTtextBox.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Inserted Successfully !!!!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getInvoiceID();
                ResetControls();
            }
            else
            {

                MessageBox.Show("Insertion Failed !!!!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
            InsertIntoOrderDetails();
        }

        int getLastInsertedInvoiceId()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select max(invoice_id) from order_master";
            SqlCommand cmd= new SqlCommand(query, con);

            con.Open();
            int MaxInvoiceId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return MaxInvoiceId; 
        
        }

        void InsertIntoOrderDetails()
        {
            int a = 0;
            SqlConnection con = new SqlConnection(cs);


            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string query = "insert into order_details values (@invoice_id, @name, @price,@discount,@quantity,@subtotal, @tax, @finalcost)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@invoice_id", getLastInsertedInvoiceId());
                    cmd.Parameters.AddWithValue("@name", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("subtotal", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("tax", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("finalcost", dataGridView1.Rows[i].Cells[7].Value);

                    con.Open();
                    a = a + cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {

            }
                if (a > 0)
                {
                    MessageBox.Show("Data Added In Order Details Table");
                }
                else
                {
                    MessageBox.Show("Data Not Added In Order Details Table");
                }        

        }





        private void QUANTITYtextBox_KeyPress(object sender, KeyPressEventArgs e)
        
        {

            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;

            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled=true;
            }

        }
        
        private void AMOUNTPAIDtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;

            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void PrintPreviewbutton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.Receipt;
            Image img = bmp;
            e.Graphics.DrawImage(img,0,0,850,650);
            e.Graphics.DrawString("Invoice ID:  " + INVOICEtextBox.Text, new Font("Arial",15,FontStyle.Bold),Brushes.Black, new Point(30,350));
            e.Graphics.DrawString("User Name:  " + USERtextBox.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 375));
            e.Graphics.DrawString("Date:  " + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 400));
            e.Graphics.DrawString("Time  :  " + DateTime.Now.ToLongTimeString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 425));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
            e.Graphics.DrawString("Item", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 475));
            e.Graphics.DrawString("Quantity", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250+25, 475));
            e.Graphics.DrawString("Price", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(400+25, 475));
            e.Graphics.DrawString("Discount", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(550+25, 475));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 500)); 

            // Item
            int gap1 = 525;
            if(dataGridView1.Rows.Count > 0)
            {
                for(int i=0; i<dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap1));
                        gap1 = gap1 + 25;
                    }
                    catch
                    {

                    }
                    
                }
            }

            // Discount
            int gap2 = 525;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(350+75, gap2));
                        gap2 = gap2 + 25;
                    }
                    catch
                    {

                    }

                }
            }

            // Price
            int gap3 = 525;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(500+75, gap3));
                        gap3 = gap3 + 25;
                    }
                    catch
                    {

                    }

                }
            }

            // Quantity
            int gap4 = 525;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250 + 25, gap4));
                        gap4 = gap4 + 25;
                    }
                    catch
                    {

                    }

                }
            }

            int SubtotalPrint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SubtotalPrint = SubtotalPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 840));

            e.Graphics.DrawString("Subtotal:" + SubtotalPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 860));

            int Tax = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Tax = Tax + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }

            e.Graphics.DrawString("Tax :" + Tax.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 880));
            e.Graphics.DrawString("Final Amount :" + FINALCOSTtextBox.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 900));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 920));
            e.Graphics.DrawString("Amount Paid :" + AMOUNTPAIDtextBox.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 940));
            e.Graphics.DrawString("Change :" + CHANGEtextBox.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 960));

        }

        private void Printbutton_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddItemForm adf= new AddItemForm();
            adf.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            GetItems();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItemForm edf = new EditItemForm();
            edf.ShowDialog(); 
        }

        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDataForm vdf = new ViewDataForm();
            vdf.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void detailsAndSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsAndSearch das= new DetailsAndSearch();
            das.ShowDialog();
        }
    }
}
