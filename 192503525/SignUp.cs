using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _192503525
{
    public partial class SignUp : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;
        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";

        public SignUp()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Close();
            a.Show();
        }

        

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            signSifreOnay.BorderColor = Color.Salmon;
            signSifre.BorderColor = Color.Salmon;
            signKullaniciAdi.BorderColor = Color.Salmon;
            if (signKullaniciAdi.Text != "" && signSifre.Text != "" && signSifreOnay.Text != "" && Gsoru.Text != "" && Gcevap.Text != "")
            {
                if (!Database.userNameKontrol(signKullaniciAdi.Text))
                {
                    if (signSifre.Text == signSifreOnay.Text)
                    {
                        Database.signUp(signKullaniciAdi.Text, signSifre.Text, Gsoru.Text, Gcevap.Text);
                        this.Close();
                        Form1 a = new Form1();
                        a.Show();
                        guna2PictureBox4.Visible = true;
                    }
                    else
                    {
                        label2.Text= "sifre onayi hatali";
                        signSifreOnay.BorderColor = Color.Red;
                        guna2PictureBox4.Visible = true;
                    }
                }
                else
                {
                    label2.Text = "İsim kullanılmış";
                    signKullaniciAdi.BorderColor = Color.Red;
                    guna2PictureBox2.Visible = true;
                }
            }
            else
            {
                label2.Text = "Bos bir yer birakamazsiniz";
            }
            
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signSifreOnay_TextChanged(object sender, EventArgs e)
        {
            guna2PictureBox4.Visible=false;
        }

        private void signKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
        }
    }
}
