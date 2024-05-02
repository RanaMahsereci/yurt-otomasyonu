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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        

        public string elektrik, su, dogalgaz, gida, personel, internet,id ,diger;

        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {

            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtSu.Text = su;
            TxtGaz.Text = dogalgaz;
            TxtGida.Text = gida;
            TxtPersonel.Text = personel;
            TxtNet.Text = internet;
            TxtDiger.Text = diger;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,Gıda=@p4,Personel=@p5,Internet=@p6,Diger=@p7 where Odemeid=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p8", TxtGiderid.Text);

                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtGaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtGida.Text);
                komut.Parameters.AddWithValue("@p5", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p6", TxtNet.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncellendi");
            }
            catch (Exception)
            {

                MessageBox.Show("HATA! Yeniden deneyin.");
            }
            
        }
    }
}
