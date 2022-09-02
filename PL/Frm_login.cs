using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management.PL
{
    public partial class Frm_login : Form
    {
        BL.CTL_LOGIN log = new BL.CTL_LOGIN(); //create object to use it here
        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = log.Login(txtId.Text, txtPwd.Text); // get the val of object(stored procedures) to dt object 
            //check if dt return values 
            if (dt.Rows.Count > 0)
                MessageBox.Show("Login success");
            else
                MessageBox.Show("Login failed !");

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();    //fun to close the form
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
