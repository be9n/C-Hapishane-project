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
    public partial class Form1 : Form
    {
       public static string user_session = "";

        public Form1()
        {
            InitializeComponent();
            
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SignUp a = new SignUp();
            this.Hide();
            a.Show();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            user_session = guna2TextBox3.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text != "")
            {
                if (Database.userNameKontrol(user_session))
                {
                    SifreDegistir a = new SifreDegistir();
                    this.Hide();
                    a.Show();
                }
                else
                {
                    label2.Text = "kullanici adi mevcut degil";
                    label2.Visible = true;
                }
                
            }
            else
            {
                label2.Text = "kullanici adini bos biraktin";
                label2.Visible = true;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (Database.LoginKontrol(guna2TextBox3.Text, guna2TextBox4.Text))
            {
                kullaniciPaneli a = new kullaniciPaneli();
                a.Show();
                user_session = guna2TextBox3.Text;
                this.Hide();
            }
            else
            {
                label2.Text = "Kullanici ismi veya sifresi yanlistir!";
                label2.Visible = true;
                guna2TextBox3.BorderColor = Color.Red;
                guna2TextBox4.BorderColor = Color.Red;
            }
        }

        

        

        private void label1_Click_2(object sender, EventArgs e)
        {
            adminLogin a = new adminLogin();
            a.Show();
            this.Hide();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
