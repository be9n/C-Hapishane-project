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
    public partial class adminPanel : Form
    {
        public adminPanel()
        {
            InitializeComponent();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminLogin a = new adminLogin();
            a.Show();
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Checked = true;
            guna2GradientButton5.Checked = false;
            guna2GradientButton2.Checked = false;
            loadForm(new dataListesi());
            this.Size = new Size(1191, 574);
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Checked = false;
            guna2GradientButton5.Checked = true;
            guna2GradientButton2.Checked = false;
            this.Size = new Size(911, 568);
            loadForm(new HukumluEkle());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            guna2GradientButton1.Checked = false;
            guna2GradientButton5.Checked = false;
            guna2GradientButton2.Checked = true;
            loadForm(new talebler());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
