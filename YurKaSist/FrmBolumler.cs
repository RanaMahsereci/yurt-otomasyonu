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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet.Bolum' table. You can move, or remove it, as needed.
            this.bolumTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolum);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut1 = new SqlCommand("insert into Bolum (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut1.ExecuteNonQuery();//değişiklikleri kaydedecek
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
                this.bolumTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolum);
            }
            catch
            {
                MessageBox.Show("HATA! Yeniden Deneyin.");
            }
        }

        private void PcbBolumSilme_Click(object sender, EventArgs e)
        {

            try
            {

                
                SqlCommand komut2 = new SqlCommand("delete from Bolum where Bolumid = @p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtBolumId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Silindi");
                this.bolumTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolum);

            }
            catch (Exception)
            {

                MessageBox.Show("HATA! İşlem gerçekleşmedi");
            }

        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, BolumAd;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            BolumAd = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxtBolumId.Text = id;
            TxtBolumAd.Text = BolumAd;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {



            try
            {
                
                SqlCommand komut2 = new SqlCommand("update Bolum Set BolumAd=@p1 where Bolumid=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p2", TxtBolumId.Text);
                komut2.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncellendi");
                this.bolumTableAdapter.Fill(this.yurtOtomasyonDataSet.Bolum); //refresh ediyor
            }
            catch 
            {

                MessageBox.Show("HATA!");
            }

            






        }
    }
}
