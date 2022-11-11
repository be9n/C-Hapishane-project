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
    public partial class hukumluGuncelle : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";

        public hukumluGuncelle()
        {
            InitializeComponent();
        }

        public void hukBilgileri(string kayit)
        {
            string sorgu = "select * from tbl_hukumlu where huk_kayitNumarasi=@kayit";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kayit", kayit);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                isim.Text = dr[1].ToString();
                SoyAd.Text = dr[2].ToString();
                yas.Text = dr[3].ToString();
                cin.Text = dr[4].ToString();
                uyruk.Text = dr[5].ToString();
                cezaS.Text = dr[6].ToString();
                anaAdi.Text = dr[7].ToString();
                babaAdi.Text = dr[8].ToString();
                sucT.Text = dr[9].ToString();
                islenenS.Text = dr[10].ToString();
                dogumY.Text = dr[11].ToString();
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Database.kayitKontrol(guna2TextBox1.Text))
            {
                hukBilgileri(guna2TextBox1.Text);
                isim.Enabled = true;
                SoyAd.Enabled = true;
                yas.Enabled = true;
                cin.Enabled = true;
                uyruk.Enabled = true;
                cezaS.Enabled = true;
                anaAdi.Enabled = true;
                babaAdi.Enabled = true;
                sucT.Enabled = true;
                islenenS.Enabled = true;
                dogumY.Enabled = true;
                label14.Visible = false;
                guna2TextBox1.BorderColor = Color.IndianRed;
            }
            else
            {
                label14.Visible = true;
                label15.Visible = false;
                label14.Text = "Girdiginiz kayit numarasi yanlistir!";
                guna2TextBox1.BorderColor = Color.Red;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void hukumluGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void uyruk_TextChanged(object sender, EventArgs e)
        {

        }

        private void cin_TextChanged(object sender, EventArgs e)
        {

        }

        private void yas_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void SoyAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void isim_TextChanged(object sender, EventArgs e)
        {

        }

        private void cezaS_TextChanged(object sender, EventArgs e)
        {

        }

        private void kayitNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void dogumY_TextChanged(object sender, EventArgs e)
        {

        }

        private void islenenS_TextChanged(object sender, EventArgs e)
        {

        }

        private void sucT_TextChanged(object sender, EventArgs e)
        {

        }

        private void babaAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void anaAdi_TextChanged(object sender, EventArgs e)
        {

        }

        public bool yasIntKontrol()
        {
            string tString = yas.Text;

            for (int i = 0; i < tString.Length; i++)
            {
                if (!char.IsNumber(tString[i]))
                {
                    return false;
                }

            }

            return true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (yasIntKontrol())
            {

                if (isim.Enabled == false)
                {
                    label15.Visible = true;
                    label14.Visible = false;
                    label15.Text = "istediginiz kisiyi bulamadan guncelleme yapamazsiniz";

                }
                else
                {
                    Database.hukBilgiGuncelle(isim.Text, SoyAd.Text, Convert.ToInt16(yas.Text), cin.Text, uyruk.Text, cezaS.Text,
                         anaAdi.Text, babaAdi.Text, sucT.Text, islenenS.Text, dogumY.Text, guna2TextBox1.Text);
                    this.Close();
                }
            }
            else
            {
                label7.Text = "Yaş sayı olmalıdır";
                label7.Visible = true;
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
          
            this.Close();
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
