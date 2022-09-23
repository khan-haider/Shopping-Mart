﻿using System;
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
    public partial class Login : Form
    {
        public static string username = "";
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void LOGINbutton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from signup where name= @user and password=@pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", USERNAMEtextBox.Text);
            cmd.Parameters.AddWithValue("@pass", PASSWORDtextBox.Text);

            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login Successful !!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                username=USERNAMEtextBox.Text;
                this.Hide();
                Form1 MainForm = new Form1();
                MainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Failed !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    PASSWORDtextBox.UseSystemPasswordChar = false;
                    break;
                default:
                    PASSWORDtextBox.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup su = new signup();
            this.Hide();
            su.ShowDialog();
        }
    }
}
