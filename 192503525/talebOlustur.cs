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
    public partial class talebOlustur : Form
    {
        public talebOlustur()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Database.talebOlustur(Form1.user_session, HukumluSorgula.huk_session, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), "Onaylaniyor");
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void talebOlustur_Load(object sender, EventArgs e)
        {

        }
    }
}
