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
    public partial class dataListesi : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";

        
        public dataListesi()
        {
            InitializeComponent();
            Database.GridDoldurHuk(guna2DataGridView1, "tbl_hukumlu");
            kisiSayisi();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            guna2TextBox1.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            guna2Button3.Visible = true;
            Database.huk_delete(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            hukumluGuncelle a = new hukumluGuncelle();
            a.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            HukumluEkle a = new HukumluEkle();
            a.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
        }

        public void kisiSayisi()
        {
            int kisiS = 0;
            string sorgu = "select huk_isim from tbl_hukumlu";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kisiS++;
            }
            label1.Text = kisiS.ToString();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Database.GridDoldurHuk(guna2DataGridView1, "hukumluler");
            kisiSayisi();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (Database.kayitKontrol(guna2TextBox1.Text))
            {
                guna2Button1.Visible = true;
                guna2TextBox1.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                guna2Button3.Visible = false;
                Database.huk_delete(guna2TextBox1.Text);
                Database.GridDoldurHuk(guna2DataGridView1, "hukumluler");
                kisiSayisi();
            }
            else
            {
                MessageBox.Show("Girdiğiniz kayıt numarası mevcut değildir");
            }
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            //Database.hukumluIsimKontrol(guna2TextBox2.Text);
            Database.searchedHukGridDoldur(guna2DataGridView1, "tbl_hukumlu", guna2TextBox2.Text);
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = true;
            guna2TextBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            guna2Button3.Visible = false;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox1.Text = guna2DataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
