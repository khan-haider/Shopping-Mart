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
    public partial class DetailsAndSearch : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public DetailsAndSearch()
        {
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "sp_getBothTablesData";
            SqlCommand cmd =new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void SEARCHbutton_Click(object sender, EventArgs e)
        {
            
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "sp_getBothTablesDataByInvoice";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@invoiceID", SEARCHtextBox.Text);
                SqlDataAdapter sda = new SqlDataAdapter();
                //sda.SelectCommand.Parameters.AddWithValue("@invoiceID", SEARCHtextBox.Text); 
                sda.SelectCommand = cmd;
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
                dataGridView1.Columns[10].Visible = false;
                FINALCOSTtextBox.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
            }


        }
    }    
}  
