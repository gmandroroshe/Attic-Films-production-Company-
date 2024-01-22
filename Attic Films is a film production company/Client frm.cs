using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//add sql databse 
using System.Data.Sql;
using System.Data.SqlClient;

namespace Attic_Films_is_a_film_production_company
{
    public partial class Client_frm : Form
    {
        // Database connection string 
        
        string con_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Desktop\Unit_04DDD - Database Design and Development\Attic Films is a film production company - Copy\Attic Films is a film production company\Database2.mdf;Integrated Security=True";
        public Client_frm()
        {
            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            // Navigate back to the Main Form
           
                Main_frm frm = new Main_frm();
                frm.Show();
                this.Hide();
            
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            // Insert Button 
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("INSERT INTO client (client_id, client_name, phone_number, address) VALUES (@cid, @name, @pnumber, @address)", con);
                mycmd.Parameters.AddWithValue("@cid", txtcid.Text);
                mycmd.Parameters.AddWithValue("@name", txtcname.Text);
                mycmd.Parameters.AddWithValue("@pnumber", txtpnumber.Text);
                mycmd.Parameters.AddWithValue("@address", txtaddress.Text);
                mycmd.ExecuteNonQuery();
                con.Close();
                // Display success message
                MessageBox.Show("Data Inserted Successfully");
            }
            catch (Exception ee)
            {
                // Display error message 
                MessageBox.Show("Error: " + ee.Message);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //update button 
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("UPDATE client SET client_name=@name, phone_number=@pnumber, address=@address WHERE client_id=@cid;", con);
                mycmd.Parameters.AddWithValue("@cid", txtcid.Text);
                mycmd.Parameters.AddWithValue("@name", txtcname.Text);
                mycmd.Parameters.AddWithValue("@pnumber", txtpnumber.Text);
                mycmd.Parameters.AddWithValue("@address", txtaddress.Text);
                mycmd.ExecuteNonQuery();
                con.Close();
                // Display success message
                MessageBox.Show("Your Entered Data has been Updated");
            }
            catch (Exception ee)
            {
                // Display error message 
                MessageBox.Show("Error: " + ee.Message);
            }

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            //Delete massage 
            var result = MessageBox.Show("Are you shour do you wantto Delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                //Delete 
                try
                {
                    SqlConnection con = new SqlConnection(con_string);
                    con.Open();
                    SqlCommand mycmd = new SqlCommand("DELETE FROM client WHERE client_id=@cid;", con);
                    mycmd.Parameters.AddWithValue("@cid", txtcid.Text);
                    mycmd.ExecuteNonQuery();
                    con.Close();
                    // Display success message
                    MessageBox.Show("DELETE COMPLETE");
                }
                catch (Exception ex)
                {
                    // Display error message 
                    MessageBox.Show("Error");
                }
            }
            
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            //Search button 
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("Select * From client", con);
                SqlDataAdapter ad = new SqlDataAdapter(mycmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ee)
            {
                // Display error message 
                MessageBox.Show("Invalid");
            }
        }

        private void Client_frm_Load(object sender, EventArgs e)
        {

        }
    }
}
