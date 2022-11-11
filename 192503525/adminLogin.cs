using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _192503525
{
    public partial class adminLogin : Form
    {
        string admin_session = "";
        public adminLogin()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if(Database.adminLoginKontrol(adminAdi.Text, adminSifre.Text))
            {
                adminPanel a = new adminPanel();
                admin_session = adminAdi.Text;
                this.Hide();
                a.Show();
            }
            else
            {
                label2.Text = "Admin isim veya sifre yanlistir!";
                label2.Visible = true;
                adminAdi.Clear();
                adminSifre.Clear();
                adminAdi.BorderColor = Color.Red;
                adminSifre.BorderColor = Color.Red;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Close();
            a.Show();
        }

        private void adminLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
