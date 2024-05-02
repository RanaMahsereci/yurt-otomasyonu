using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YurKaSist
{
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet5.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Admin (YöneticiAd,YöneticiSifre) values (@p1,@p2)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yönetici Eklendi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Admin where Yöneticiid=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtYoneticiid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silindi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Aktarım İşlemi
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, sifre,id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtKullaniciAd.Text = ad;
            TxtSifre.Text = sifre;
            TxtYoneticiid.Text = id;


        }
        //GÜNCELLEMEDE PROBLEM VAR!
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutt = new SqlCommand("update Admin set YöneticiAd=@p1,YöneticiSifre=@p2 where Yöneticiid=@p3");
            komutt.Parameters.AddWithValue("@p1",TxtKullaniciAd.Text);
            komutt.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komutt.Parameters.AddWithValue("@p3", TxtYoneticiid.Text);
            komutt.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleştirildi");
            this.adminTableAdapter.Fill(this.yurtOtomasyonDataSet5.Admin);

        }
    }
}
