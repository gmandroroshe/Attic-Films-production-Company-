using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
//add sql databse 
using System.Data.SqlClient;
namespace Attic_Films_is_a_film_production_company
{
    public partial class Production_frm : Form
    {
        // Database connection string  
        string con_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Desktop\Unit_04DDD - Database Design and Development\Attic Films is a film production company - Copy\Attic Films is a film production company\Database2.mdf;Integrated Security=True";
        public Production_frm()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("INSERT INTO production (production_id, production_type,client_id) VALUES (@pid, @ptype,@cid)", con);
                mycmd.Parameters.AddWithValue("@pid", txtpid.Text);
                mycmd.Parameters.AddWithValue("@ptype", ptype.Text);
                mycmd.Parameters.AddWithValue("@cid", comboBox1.Text);
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

        private void Production_frm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();

                    SqlCommand mycmd = new SqlCommand("SELECT client_id FROM client", con);
                    SqlDataReader r = mycmd.ExecuteReader();

                    while (r.Read())
                    {
                        comboBox1.Items.Add(r["client_id"].ToString());
                    }

                    r.Close();
                }
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

                SqlCommand mycmd = new SqlCommand("UPDATE production SET production_type=@ptype, client_id=@cid WHERE production_id=@pid", con);
                mycmd.Parameters.AddWithValue("@pid", txtpid.Text);
                mycmd.Parameters.AddWithValue("@ptype", ptype.Text);
                mycmd.Parameters.AddWithValue("@cid", comboBox1.Text);

                int rowsAffected = mycmd.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                {
                    // Display success message
                    MessageBox.Show("Data Updated Successfully");
                }
                else
                {
                    MessageBox.Show("No matching record found for the specified production_id.");
                }
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
                SqlCommand mycmd = new SqlCommand("DELETE FROM production WHERE production_id=@pid;", con);
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
                SqlCommand mycmd = new SqlCommand("Select * From production", con);
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
