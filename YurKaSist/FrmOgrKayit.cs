using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurKaSist
{
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Bölümleri Listeleme Komutları           
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolum",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader(); //parametrelerin okunma işlemini gerçekleştiriyor.

            while(oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            //Boş Odaları Listeleme Komutları            
            SqlCommand komut2 = new SqlCommand("Select OdaNo From Oda Where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            //Öğrenci bilgilerinin kayıt edilme komutları 
            try
            {
               
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgerSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                komutkaydet.ExecuteNonQuery(); //Sorgular üzerinde değişiklikleri gerçekleştiriyor ve bağlantı 
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt başarıyla oluşturuldu");

                //Öğrenci id'yi labele çekme
                SqlCommand komut = new SqlCommand("select Ogrid from Ogrenci", bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();

                //Öğrenci Borç Alanı Oluşturma
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borc  (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)",bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1",label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();


            }
            catch (Exception)
            {
                 MessageBox.Show("HATA! Lütfen yeniden deneyin.");
            }


            //Öğrenci Oda Kontenjanı Arttırma
            SqlCommand komutoda = new SqlCommand("update Oda set OdaAktif = OdaAktif+1  where OdaNo=@oda1", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@oda1",CmbOdaNo.Text); //seçtiğimiz odanın
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();
            
        }

    }
}
