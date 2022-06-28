using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MSQL_Login_Form
{
    public partial class Giris : Form
    {
        public  int PersonelID;
        public string PersonelAD;
        public string PersonelRutbe;

        SqlDataReader sqlVeriOku;
        SqlCommand sqlKomut;



        private void Giris_Load(object sender, EventArgs e)
        {
            // veri tabanı nesne olarak tanımlama ve bagalnma
            SqlConnection baglanti = new SqlConnection("Data Source=lspdonline.mssql.somee.com;Initial Catalog=lspdonline;User ID=bobmarley_SQLLogin_1;Password=myqfg8abtj");
            //degiskeni sql komutu olarak tanımlama
            sqlKomut = new SqlCommand();
            // baglantı acma
            baglanti.Open();
            sqlKomut.Connection = baglanti;


            sqlKomut.CommandText = "Select * From surumkontrol where VERSION='1'";
            try
            {
                sqlVeriOku = sqlKomut.ExecuteReader();
                if (sqlVeriOku.Read())
                {
                    MessageBox.Show("Uygulama güncel!","Giriş Başarılı!");
                }
                else
                {
                    MessageBox.Show("Eski bir sürüm kullanıyorsunuz! Lütfen yöneticiye ulaşın!");
                    baglanti.Close();
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sürüm kontrol başarısız!");
            }


        }


        public Giris()
        {
            InitializeComponent();

        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            string kullaniciAd = txt_kullaniciAd.Text;
            string kullaniciSifre = txt_sifre.Text;


            // veri tabanı nesne olarak tanımlama ve bagalnma
            SqlConnection baglanti = new SqlConnection("Data Source=lspdonline.mssql.somee.com;Initial Catalog=lspdonline;User ID=bobmarley_SQLLogin_1;Password=myqfg8abtj");

            //degiskeni sql komutu olarak tanımlama
            sqlKomut = new SqlCommand();
            // baglantı acma
            baglanti.Open();
            sqlKomut.Connection = baglanti;
            sqlKomut.CommandText = "Select * From personelbilgi where AD='" + kullaniciAd + "'And PAROLA='" + kullaniciSifre + "'";
            Anasayfa anasayfa = new Anasayfa();
            try
            {
                sqlVeriOku = sqlKomut.ExecuteReader();
                if (sqlVeriOku.Read())
                {
                    // sql sorgusu içerisinde  çekilen ve belirlenen stünü bir değişkene atar
                    PersonelID = Convert.ToInt32(sqlVeriOku["ID"].ToString());
                    PersonelAD = sqlVeriOku["AD"].ToString();
                    PersonelRutbe = sqlVeriOku["RUTBE"].ToString();
                    // diğer formda ki nesneye ulaşmak için privateden publice aldık
                    anasayfa.lbl_TopPersonelID.Text = Convert.ToString(PersonelID);
                    anasayfa.lbl_TopPersonelAD.Text = PersonelAD;
                    anasayfa.lbl_TopPersonelRutbe.Text = PersonelRutbe;
                    anasayfa.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Bir şeyler yanlış!");
                    baglanti.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ciddi bir problem işe karşılaştık yöneticiye ulaşın!");
            }


        }





        private bool surukle = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void pnl_GirisTop_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnl_GirisTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnl_GirisTop_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }

        private void btn_GirisKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
