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
    public partial class kullaniciPaneli : Form
    {

        public static string huk_isim = "";
        public static string huk_soyIsim = "";
        public static string huk_babaIsim = "";
        public static string huk_anneIsim = "";
        public kullaniciPaneli()
        {
            InitializeComponent();
            label3.Text = Form1.user_session;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void loadForm(object form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form a = form as Form;
            a.TopLevel = false;
            a.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(a);
            this.panel2.Tag = a;
            a.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Checked = true;
            guna2GradientButton2.Checked = false;
            
            loadForm(new HukumluSorgula());
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Checked = false;
            guna2GradientButton2.Checked = true;
            
            loadForm(new kullaniciTalebleri());
        }

        

        
        

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 a = new Form1();
            a.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
