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
    public partial class SifreDegistir : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;
        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";

        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Gsoru_SelectedIndexChanged(object sender, EventArgs e)
        {
            guna2PictureBox4.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            if (yeniSifre.Text != "" && yeniSifreOnayi.Text != "" && GsoruSifre.Text != "" && GcevapSifre.Text != "")
            {
                if (yeniSifre.Text == yeniSifreOnayi.Text)
                {
                    if (guvenlikSoruKontrol())
                    {
                        Database.updatePass(Form1.user_session, yeniSifre.Text);
                        Form1 a = new Form1();
                        this.Close();
                        a.Show();
                    }
                    else
                    {
                        guna2PictureBox3.Visible = true;
                        guna2PictureBox4.Visible = true;
                        label1.Text = "Guvenlik sorusu veya cevabi yanlistir";
                        label1.Visible = true;
                    }
                }
                else
                {
                    guna2PictureBox2.Visible = true;
                    label1.Text = "Yeni sifre onayi hatali";
                    label1.Visible = true;
                }
            }
            else
            {
                label1.Text = "Bos bir yer birakamazsiniz";
                label1.Visible = true;
            }
        }

       /* public bool EskiSifreKontrol()
        {
            string sorgu = "select user_pass from tbl_login where user_name=@user and user_pass=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.user_session);
            cmd.Parameters.AddWithValue("@pass", Database.MD5sifreleme(EskiSifre.Text));
            
            
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        public bool guvenlikSoruKontrol()
        {
            string sorgu = "select sec_question, sec_answer from tbl_login where user_name=@user and sec_question=@soru and sec_answer=@cevap";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.user_session);
            cmd.Parameters.AddWithValue("@soru", GsoruSifre.Text);
            cmd.Parameters.AddWithValue("@cevap", GcevapSifre.Text);
            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Close();
            a.Show();
            guna2PictureBox2.Visible = false;

        }

        private void GcevapSifre_TextChanged(object sender, EventArgs e)
        {
            guna2PictureBox3.Visible = false;
        }

        private void YeniSifreOnayi_TextChanged(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
        }
    }
}
