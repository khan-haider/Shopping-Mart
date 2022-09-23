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
    public partial class signup : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public signup()
        {
            InitializeComponent();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void CPASStextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SIGNUPbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into signup values(@name,@surname,@gender,@age,@address,@email,@pass)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", NAMEtextBox.Text);
            cmd.Parameters.AddWithValue("@surname", SURNAMEtextBox.Text);
            cmd.Parameters.AddWithValue("@gender", GENDERcomboBox.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@address", ADDRESStextBox.Text);
            cmd.Parameters.AddWithValue("@email", EMAILtextBox.Text);
            cmd.Parameters.AddWithValue("@pass", PASSWORDtextBox.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Registered Successfully !!!!!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MessageBox.Show("Username is:"+NAMEtextBox.Text + "\n\n"+ "Password is:"+PASSWORDtextBox.Text);

                this.Hide();
                Login LoginForm= new Login();   
                LoginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Registration Failed !!!!!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
    }
}
