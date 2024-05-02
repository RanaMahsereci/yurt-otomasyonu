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
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam tutar 
            SqlCommand komut = new SqlCommand("Select Sum (OdemeMiktar) from Kasa",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) {

                LblPara.Text = oku[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Tekrarsız olarak ayları listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct (OdemeAy) from Kasa",bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

            /**Aylık kazanç manuel
            this.chart1.Series["Aylık"].Points.AddXY("Ocak",15);
            this.chart1.Series["Aylık"].Points.AddXY("Şubat",22);
            this.chart1.Series["Aylık"].Points.AddXY("Mart",13);
            this.chart1.Series["Aylık"].Points.AddXY("Nisan", 23);
            this.chart1.Series["Aylık"].Points.AddXY("Mayıs", 28);
            this.chart1.Series["Aylık"].Points.AddXY("Haziran", 13);
            this.chart1.Series["Aylık"].Points.AddXY("Temmuz", 3); **/

            //Grafiklere Veri Tabanından Veri Çekme

            SqlCommand komut3 = new SqlCommand("select OdemeAy, sum (OdemeMiktar) from Kasa group by OdemeAy",bgl.baglanti());
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0], oku3[1]);
            }
            bgl.baglanti().Close();
 
        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum (OdemeMiktar) from kasa where OdemeAy=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) { 
                LblAyKazanc.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
