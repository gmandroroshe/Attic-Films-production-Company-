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
    public partial class Staff_frm : Form
    {
        // Database connection string  
        string con_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Desktop\Unit_04DDD - Database Design and Development\Attic Films is a film production company - Copy\Attic Films is a film production company\Database2.mdf;Integrated Security=True";
        
        public Staff_frm()
        {
            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            // Navigate back to the Main Form
            Main_frm frm = new Main_frm();
            frm.Show();
            this.Hide();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("Select * From staff", con);
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

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("DELETE FROM staff WHERE staff_id=@sid;", con);
                mycmd.Parameters.AddWithValue("@sid", txtid.Text);
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

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("INSERT INTO staff (staff_id,staff_type,fee) VALUES (@sid, @stype,@fee)", con);
                mycmd.Parameters.AddWithValue("@sid", txtid.Text);
                mycmd.Parameters.AddWithValue("@stype", txttype.Text);
                mycmd.Parameters.AddWithValue("@fee", txtfee.Text);
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
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("UPDATE staff SET staff_type=@stype,fee=@fee WHERE staff_id=@sid;", con);
                mycmd.Parameters.AddWithValue("@sid", txtid.Text);
                mycmd.Parameters.AddWithValue("@stype", txttype.Text);
                mycmd.Parameters.AddWithValue("@fee", txtfee.Text);
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

        private void Staff_frm_Load(object sender, EventArgs e)
        {

        }
    }
}
