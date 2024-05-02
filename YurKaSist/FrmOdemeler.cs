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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();  

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet2.Borc' table. You can move, or remove it, as needed.
            this.borcTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borc);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;  
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); 
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtOgrid.Text = id; 
            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;  
            TxtKalan.Text = kalan;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {
            //odenen tutarı kalan tutardan düşme
            int odenen, kalan, yenıBorc;
            odenen = Convert.ToInt16(TxtOdenen.Text);
            kalan = Convert.ToInt16(TxtKalan.Text);
            yenıBorc = kalan - odenen;
            TxtKalan.Text = Convert.ToString(yenıBorc);

            //yeni tutarı veri tabanına kaydetme
            SqlCommand komut = new SqlCommand("update Borc set OgrKalanBorc=@p1 where Ogrid=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p2",TxtOgrid.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Borç Ödendi");
            this.borcTableAdapter.Fill(this.yurtOtomasyonDataSet2.Borc);

            //Kasa tablosuna ekleme yapma
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)",bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1",TxtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();



        }
    }
}
