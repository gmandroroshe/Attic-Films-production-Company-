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
    public partial class staff_production : Form
    {
        // Database connection string  
        string con_string = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Desktop\Unit_04DDD - Database Design and Development\Attic Films is a film production company - Copy\Attic Films is a film production company\Database2.mdf;Integrated Security=True";
        
        public staff_production()
        {
            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                SqlCommand mycmd = new SqlCommand("Select * From staff_production", con);
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

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(con_string);
                con.Open();
                SqlCommand mycmd = new SqlCommand("INSERT INTO staff_production (production_id, staff_id,number_of_members) VALUES (@pid, @sid,@nom)", con);
                mycmd.Parameters.AddWithValue("@pid", cmbproid.Text);
                mycmd.Parameters.AddWithValue("@sid", cmbsid.Text);
                mycmd.Parameters.AddWithValue("@nom", txtnom.Text);
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

                SqlCommand mycmd = new SqlCommand("UPDATE staff_production SET number_of_members=@nom WHERE production_id=@pid AND staff_id=@sid", con);
                mycmd.Parameters.AddWithValue("@pid", cmbproid.Text);
                mycmd.Parameters.AddWithValue("@sid", cmbsid.Text);
                mycmd.Parameters.AddWithValue("@nom", txtnom.Text);

                int rowsAffected = mycmd.ExecuteNonQuery();

                con.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Updated Successfully");
                }
                else
                {
                    MessageBox.Show("No matching record found for the specified production_id and staff_id.");
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
                SqlCommand mycmd = new SqlCommand("DELETE FROM staff_production WHERE production_id=@pid;", con);
                mycmd.Parameters.AddWithValue("@pid", cmbproid.Text);
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

        private void staff_production_Load(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    con.Open();

                    
                    SqlCommand productionCmd = new SqlCommand("SELECT production_id FROM production", con);
                    SqlDataReader productionReader = productionCmd.ExecuteReader();

                    while (productionReader.Read())
                    {
                        cmbproid.Items.Add(productionReader["production_id"].ToString());
                    }

                    productionReader.Close();

                    
                    SqlCommand staffCmd = new SqlCommand("SELECT staff_id FROM staff", con);
                    SqlDataReader staffReader = staffCmd.ExecuteReader();

                    while (staffReader.Read())
                    {
                        cmbsid.Items.Add(staffReader["staff_id"].ToString());
                    }

                    staffReader.Close();
                }
            }
            catch (Exception ee)
            {
                // Display error message
                MessageBox.Show("Error: " + ee.Message);
            }

        }
    }
}
