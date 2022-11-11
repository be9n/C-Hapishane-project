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
    public partial class HukumluEkle : Form
    {
        public HukumluEkle()
        {
            InitializeComponent();
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
            if (isim.Text != "" && SoyAd.Text != "" && yas.Text != "" && cin.Text != "" && uyruk.Text != "" &&
                cezaS.Text != "" && anaAdi.Text != "" && babaAdi.Text != "" && sucT.Text != "" && islenenS.Text != "" &&
                dogumY.Text != "" && kayitNum.Text != "")
            {
                if (yasIntKontrol())
                {
                    if (!Database.kayitKontrol(kayitNum.Text))
                    {
                        Database.hukumluEkle(isim.Text, SoyAd.Text, Convert.ToInt16(yas.Text), cin.Text, uyruk.Text, cezaS.Text,
                            anaAdi.Text, babaAdi.Text, sucT.Text, islenenS.Text, dogumY.Text, kayitNum.Text);
                        label3.ForeColor = Color.DeepSkyBlue;
                        label3.Visible = true;
                        label3.Text = "Hükümlü eklendi";
                    }
                    else
                    {
                        label2.Text = "Bu kayit numarasi mevcuttur";
                        label2.Visible = true;
                        label3.Visible = false;
                        kayitNum.BorderColor = Color.Red;
                    }
                }
                else
                {
                    label1.Text = "Yaşı sayı olarak giriniz";
                    label1.Visible = true;
                    label3.Visible = false;
                    yas.BorderColor = Color.Red;
                }
            }
            else
            {
                label3.Text = "Bosluk birakamazsiniz";
                label3.Visible = true;

            }
        }

        private void ilkAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void SoyAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void yas_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            yas.BorderColor = Color.IndianRed;
        }

        private void HukumluEkle_Load(object sender, EventArgs e)
        {

        }

        private void kayitNum_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            kayitNum.BorderColor = Color.IndianRed;
        }

        private void sucT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
