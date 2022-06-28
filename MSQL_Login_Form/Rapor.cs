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
using System.IO;

namespace MSQL_Login_Form
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=5.180.105.138;Initial Catalog=LSPDONLINE;User ID=sa;Password=QwErTyWU54!!");


 




      

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            string aktiflik = "1";
            if (chb_Gorevde.Checked == true)
            {
                aktiflik = "1";
            }
            else
            {
                aktiflik = "0";
            }



            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bilgiler kayıt edilsin mi?", "Kayıt", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data Source=5.180.105.138;Initial Catalog=LSPDONLINE;User ID=sa;Password=QwErTyWU54!!");
                try
                {
                    MessageBox.Show("Veri güncellendi");
                }
                catch
                {
                    MessageBox.Show("HATA!");
                }
            }
            else
            {
                MessageBox.Show("İşlem Yapılmadı!");
            }



        }

        private bool surukle = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        private void pnl_AnasayfaTop_MouseDown(object sender, MouseEventArgs e)
        {
            surukle = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnl_AnasayfaTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (surukle)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnl_AnasayfaTop_MouseUp(object sender, MouseEventArgs e)
        {
            surukle = false;
        }

        private void btn_AnasayfaCikis_Click(object sender, EventArgs e)
        {
            //komple kapatma
            Application.ExitThread();
        }

        private void btn_Profil_Rapor_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }
    }
}
