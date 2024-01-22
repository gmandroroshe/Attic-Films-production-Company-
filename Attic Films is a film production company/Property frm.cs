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
    public partial class Property_frm : Form
    {
        // Database connection string  
        string con_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Desktop\Unit_04DDD - Database Design and Development\Attic Films is a film production company - Copy\Attic Films is a film production company\Database2.mdf;Integrated Security=True";
        
        public Property_frm()
        {
            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Property_frm_Load(object sender, EventArgs e)
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
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("INSERT INTO property (property_id, property_name,property_type) VALUES (@pid, @pname, @ptype)", con);
                mycmd.Parameters.AddWithValue("@pid", txtpid.Text);
                mycmd.Parameters.AddWithValue("@pname", txtpname.Text);
                mycmd.Parameters.AddWithValue("@ptype", txtptype.Text);
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
                SqlCommand mycmd = new SqlCommand("UPDATE property SET property_name=@pname, property_type=@ptype WHERE property_id=@pid;", con);
                mycmd.Parameters.AddWithValue("@pid", txtpid.Text);
                mycmd.Parameters.AddWithValue("@pname", txtpname.Text);
                mycmd.Parameters.AddWithValue("@ptype", txtptype.Text);
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
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("DELETE FROM property WHERE property_id=@pid;", con);
                mycmd.Parameters.AddWithValue("@pid", txtpid.Text);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("Select * From property", con);
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
    }
}
