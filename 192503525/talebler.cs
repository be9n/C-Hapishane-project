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
    public partial class talebler : Form
    {

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";
        public talebler()
        {
            InitializeComponent();
            Database.GridDoldurTaleb(guna2DataGridView1, "tbl_talebler");
            talebSayisi();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void talebSayisi()
        {
            int talebS = 0;
            string sorgu = "select talebID from tbl_talebler where talebDurumu='Onaylaniyor'";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);


            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                talebS++;
            }
            label1.Text = talebS.ToString();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static void updateDurum(string ID, string durum)
        {


            string sql = "update tbl_talebler set talebDurumu=@durum where talebID=@ID";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@durum", durum);

           Database.KomutYollaParametli(sql, cmd);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            updateDurum(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(), "Onaylandi");
            Database.GridDoldurTaleb(guna2DataGridView1, "tbl_talebler");
            talebSayisi();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            updateDurum(guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(), "Reddedildi");
            Database.GridDoldurTaleb(guna2DataGridView1, "tbl_talebler");
            talebSayisi();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Database.GridDoldurTaleb(guna2DataGridView1, "tbl_talebler");
            talebSayisi();
        }
    }
}
