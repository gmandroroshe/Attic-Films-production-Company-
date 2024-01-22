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
    public partial class Main_frm : Form
    {
        public Main_frm()
        {

            InitializeComponent();
            // Center the form on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            // Open the Client Form and hide the Main Form
            Client_frm frm = new Client_frm();
            frm.Show();
            this.Hide();
        }

        private void btnproduction_Click(object sender, EventArgs e)
        {
            // Open the Production Form and hide the Main Form
            Production_frm frm = new Production_frm();
            frm.Show();
            this.Hide();
        }

        private void btnlocation_Click(object sender, EventArgs e)
        {
            // Open the Location Form and hide the Main Form
            Location_frm frm = new Location_frm();
            frm.Show();
            this.Hide();
        }

        private void btnproperty_Click(object sender, EventArgs e)
        {
            // Open the Property Form and hide the Main Form
            Property_frm frm = new Property_frm();
            frm.Show();
            this.Hide();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            // Open the Staff Form and hide the Main Form
            Staff_frm frm = new Staff_frm();
            frm.Show();
            this.Hide();
        }

        private void btnstaffproduction_Click(object sender, EventArgs e)
        {
            // Open the Staff Production Form and hide the Main Form
            staff_production frm = new staff_production();
            frm.Show();
            this.Hide();
        }

        private void btnpropertyproduction_Click(object sender, EventArgs e)
        {
            // Open the Property Production Form and hide the Main Form
           Property_production frm = new Property_production();
            frm.Show();
            this.Hide();
        }

        private void btnexsit_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog and exit the application if user chooses 'Yes'
            var result = MessageBox.Show("Are you shour do you wantto Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnclient_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover
            btnclient.BackColor = Color.Lime;
        }

        private void btnproduction_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover
            btnproduction.BackColor = Color.Lime;
        }

        private void btnproperty_MouseHover(object sender, EventArgs e)
        {
            
            // Change the button color on mouse hover
            btnproperty.BackColor = Color.Lime;  
        }

        private void btnstaff_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover  
            btnstaff.BackColor = Color.Lime;   
        }

        private void btnstaffproduction_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover  
            btnstaffproduction.BackColor = Color.Lime;  
        }

        private void btnpropertyproduction_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover  
            btnpropertyproduction.BackColor = Color.Lime;  
        }

        private void btnexsit_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover  
            btnexsit.BackColor = Color.Red; 
        }

        private void btnlocation_MouseHover(object sender, EventArgs e)
        {
            // Change the button color on mouse hover  
            btnlocation.BackColor = Color.Lime;
        }

        private void btnclient_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnclient.BackColor = Color.Blue;
        }

        private void btnproduction_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnproduction.BackColor = Color.Blue;
        }

        private void btnlocation_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnlocation.BackColor = Color.Blue;
        }

        private void btnproperty_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnproperty.BackColor = Color.Blue;
        }

        private void btnstaff_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnstaff.BackColor = Color.Blue;
        }

        private void btnstaffproduction_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnstaffproduction.BackColor = Color.Blue;
        }

        private void btnpropertyproduction_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnpropertyproduction.BackColor = Color.Blue;
        }

        private void btnexsit_MouseLeave(object sender, EventArgs e)
        {
            // Change the button color on mouse leave
            btnexsit.BackColor = Color.Blue;
        }

        private void Main_frm_Load(object sender, EventArgs e)
        {

        }
    }
}
