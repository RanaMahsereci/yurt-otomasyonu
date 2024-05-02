using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurKaSist
{
    public partial class FrmOgrListe : Form
    {
        public FrmOgrListe()
        {
            InitializeComponent();
        }

        private void FrmOgrListe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet3.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtOtomasyonDataSet3.Ogrenci);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            secilen = dataGridView1.SelectedCells[0].RowIndex;//hangi hücreyi seçtiysem o hücreyi hafızaya alsın
            //diğer forma göndericez
            FrmOgrDuzenle fr = new FrmOgrDuzenle();
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            fr.ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            fr.TC = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            fr.odaNo = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            fr.veliAdSoyad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            fr.telefon = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();  
            fr.Show();

        }
    }
}
