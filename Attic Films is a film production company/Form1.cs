using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attic_Films_is_a_film_production_company
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private int incorrectAttempts = 0;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            //login Button 
            if (txtuser.Text == "Admin" && txtpwd.Text == "123")
            {
                // Correct credentials
                BTNlogin.BackColor = Color.Green;
                Main_frm frm = new Main_frm();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Incorrect credentials
                incorrectAttempts++;

                if (incorrectAttempts >= 5) //Exit 
                {
                    MessageBox.Show("Too many incorrect attempts. The application will now exit.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    BTNlogin.BackColor = Color.Red;
                    MessageBox.Show("Incorrect Password. Please try again. Attempts left: {5 - incorrectAttempts}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnexsit_Click(object sender, EventArgs e)
        {
            //exit button 
            var result = MessageBox.Show("Are you shour do you wantto Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BTNlogin_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover
            BTNlogin.BackColor = Color.Lime;
        }

        private void BTNlogin_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            BTNlogin.BackColor = Color.Blue;
        }

        private void btnexsit_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover
            btnexsit.BackColor = Color.Red;
        }

        private void btnexsit_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnexsit.BackColor = Color.Blue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
