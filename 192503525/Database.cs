using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;



namespace _192503525
{
    internal class Database
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;

        public static string SqlCon = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = 192503525; Integrated Security = True";

        public static string MD5sifreleme(string sifrelenecek)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecek);
            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        public static void hukBilgiGuncelle(string isim, string soyisim, int yas, string cin,
            string uyruk, string cezaS, string anaAdi, string babaAdi, string sucT, string islenenS, string dogumY, string kayitN)
        {
            string sql = "update tbl_hukumlu set huk_isim=@isim, huk_soyisim=@soyisim, huk_yas=@yas, huk_cinsiyet=@cin," +
                "huk_uyruk=@uyruk, huk_cezaSuresi=@cezaS, huk_anaAdi=@anaAdi, huk_babaAdi=@babaAdi," +
                " huk_sucTipi=@sucT, huk_islenenSuc=@islenenS, huk_dogumYeri=@dogumY, huk_kayitNumarasi=@kayitN where huk_kayitNumarasi=@kayitN";
            
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@soyisim", soyisim);
            cmd.Parameters.AddWithValue("@yas", yas);
            cmd.Parameters.AddWithValue("@cin", cin);
            cmd.Parameters.AddWithValue("@uyruk", uyruk);
            cmd.Parameters.AddWithValue("@cezaS", cezaS);
            cmd.Parameters.AddWithValue("@anaAdi", anaAdi);
            cmd.Parameters.AddWithValue("@babaAdi", babaAdi);
            cmd.Parameters.AddWithValue("@sucT", sucT);
            cmd.Parameters.AddWithValue("@islenenS", islenenS);
            cmd.Parameters.AddWithValue("@dogumY", dogumY);
            cmd.Parameters.AddWithValue("@kayitN", kayitN);

            KomutYollaParametli(sql, cmd);
        }

        public static void KomutYollaParametli(string sql, SqlCommand cmd)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static bool adminLoginKontrol(string adminAdi, string sifre)
        {
            string sorgu = "select * from tbl_admin where admin_name=@user and admin_pass=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", adminAdi);
            cmd.Parameters.AddWithValue("@pass", sifre);

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;

            }
        }


        public static bool LoginKontrol(string kullaniciAdi, string sifre)
        {
            string sorgu = "select * from tbl_login where user_name=@user and user_pass=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", kullaniciAdi);
            cmd.Parameters.AddWithValue("@pass",MD5sifreleme(sifre));

            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                con.Close();
                return true;
            }
            else
            {
                
                con.Close();
                return false;

            }
        }
        
        

        public static DataGridView GridDoldurHuk(DataGridView girdim, string sqlSelectSorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_hukumlu", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);

            girdim.DataSource = ds.Tables[sqlSelectSorgu];

            con.Close();
            return girdim;
        }

        public static DataGridView GridDoldurTaleb(DataGridView girdim, string sqlSelectSorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_talebler where talebDurumu='Onaylaniyor'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);

            girdim.DataSource = ds.Tables[sqlSelectSorgu];

            con.Close();
            return girdim;
        }

        static public bool userNameKontrol(string isim)
        {
            string sorgu = "select user_name from tbl_login where user_name=@user";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", isim);

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

        public static DataGridView searchedHukGridDoldur(DataGridView girdim, string sqlSelectSorgu, string isim)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_hukumlu where huk_isim LIKE '%"+isim+"%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);

            girdim.DataSource = ds.Tables[sqlSelectSorgu];

            con.Close();
            return girdim;
        }


        public static DataGridView taleblerGridDoldur(DataGridView girdim, string sqlSelectSorgu, string talebSahibi)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_talebler where talebSahibi= '"+talebSahibi+"' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);

            girdim.DataSource = ds.Tables[sqlSelectSorgu];

            con.Close();
            return girdim;
        }

        static public bool hukumluIsimKontrol(string isim)
        {
            string sorgu = "select huk_isim from tbl_hukumlu where huk_isim=@isim";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@isim", isim);

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
        static public bool hukumluAra(string isim, string soyIsim, string anneAdi)
        {
            string sorgu = "select huk_isim, huk_soyisim, huk_anaAdi, huk_babaAdi from tbl_hukumlu where" +
                " huk_isim=@isim and huk_soyisim=@soyIsim and huk_anaAdi=@anneAdi";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@soyIsim", soyIsim);
            cmd.Parameters.AddWithValue("@anneAdi", anneAdi);

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

        static public void talebOlustur(string eden, string edilen, string tarih, string durum)
        {
            string sql = "insert into tbl_talebler(talebSahibi, ziyaretEdilen, talebTarihi, talebDurumu) values(@talebSahibi, @ziyaretEdilen, @tarih, @durum)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@talebSahibi", eden);
            cmd.Parameters.AddWithValue("@ziyaretEdilen", edilen);
            cmd.Parameters.AddWithValue("@tarih", tarih);
            cmd.Parameters.AddWithValue("@durum", durum);

            KomutYollaParametli(sql, cmd);
        }


        static public bool kayitKontrol(string kayit)
        {
            string sorgu = "select huk_kayitNumarasi from tbl_hukumlu where huk_kayitNumarasi=@kayit";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kayit", kayit);

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

        public static void updatePass(string isim, string sifre)
        {
            

            string sql = "update tbl_login set user_pass=@sifre where user_name=@isim";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@sifre", MD5sifreleme(sifre));

            KomutYollaParametli(sql, cmd);
        }

        public static void signUp(string isim, string sifre, string soru, string cevap)
        {
            string sql = "insert into tbl_login(user_name, user_pass, sec_question, sec_answer) values(@user, @pass, @question, @answer)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", isim);
            cmd.Parameters.AddWithValue("@pass", MD5sifreleme(sifre));
            cmd.Parameters.AddWithValue("@question", soru);
            cmd.Parameters.AddWithValue("@answer", cevap);

            KomutYollaParametli(sql, cmd);

        }


        

        public static void hukumluEkle(string isim, string soyisim, int yas, string cin,
            string uyruk, string cezaS, string anaAdi, string babaAdi, string sucTipi, string islenenSuc, string dogumYeri, string kayitNum)
        {
            string sql = "insert into tbl_hukumlu(huk_isim, huk_soyisim, huk_yas, huk_cinsiyet, huk_uyruk, huk_cezaSuresi," +
                " huk_anaAdi, huk_babaAdi, huk_sucTipi, huk_islenenSuc, huk_dogumYeri, huk_kayitNumarasi) values(@isim, @soyIsim, @yas, @cin," +
                " @uyruk, @cezaS, @anaAdi, @babaAdi, @sucTipi, @islenenSuc, @dogumYeri, @kayitNum)";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@isim", isim);
            cmd.Parameters.AddWithValue("@soyIsim", soyisim);
            cmd.Parameters.AddWithValue("@yas", yas);
            cmd.Parameters.AddWithValue("@cin", cin);
            cmd.Parameters.AddWithValue("@uyruk", uyruk);
            cmd.Parameters.AddWithValue("@cezaS", cezaS);
            cmd.Parameters.AddWithValue("@anaAdi", anaAdi);
            cmd.Parameters.AddWithValue("@babaAdi", babaAdi);
            cmd.Parameters.AddWithValue("@sucTipi", sucTipi);
            cmd.Parameters.AddWithValue("@islenenSuc", islenenSuc);
            cmd.Parameters.AddWithValue("@dogumYeri", dogumYeri);
            cmd.Parameters.AddWithValue("@kayitNum", kayitNum);
            

            KomutYollaParametli(sql, cmd);
        }

        public static void huk_delete(string kayit)
        {
            string sql = "delete from tbl_hukumlu where huk_kayitNumarasi=@kayit";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@kayit", kayit);

            KomutYollaParametli(sql, cmd);
        }
    }
}
