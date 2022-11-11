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
    public partial class HukumluSorgula : Form
    {
        public static string huk_session = "";

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";
        public HukumluSorgula()
        {
            InitializeComponent();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (Database.hukumluAra(isim.Text, guna2TextBox1.Text, guna2TextBox2.Text))
            {
                guna2Panel1.Visible = false;
                guna2Panel2.Visible = true;
                hukBilgileri(isim.Text, guna2TextBox1.Text, guna2TextBox2.Text);
                huk_session = ad.Text;
            }
            else
            {
                MessageBox.Show("Girdiginiz bazi bilgiler yanlis olabilir");
            }
        }


        public void hukBilgileri(string Ad, string soyIsim, string anaAdi)
        {
            string sorgu = "select * from tbl_hukumlu where" +
                " huk_isim=@isim and huk_soyisim=@soyIsim and huk_anaAdi=@anneAdi";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@isim", Ad);
            cmd.Parameters.AddWithValue("@soyIsim", soyIsim);
            cmd.Parameters.AddWithValue("@anneAdi", anaAdi);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ad.Text = dr[1].ToString();
                Soyad.Text = dr[2].ToString();
                yas.Text = dr[3].ToString();
                cin.Text = dr[4].ToString();
                uyruk.Text = dr[5].ToString();
                cezaS.Text = dr[6].ToString();
                anneAdi.Text = dr[7].ToString();
                babaAdi.Text = dr[8].ToString();
                sucT.Text = dr[9].ToString();
                islenenS.Text = dr[10].ToString();
                dogumY.Text = dr[11].ToString();
                kayitN.Text = dr[12].ToString();
            }

        }


        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            talebOlustur a = new talebOlustur();
            a.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
