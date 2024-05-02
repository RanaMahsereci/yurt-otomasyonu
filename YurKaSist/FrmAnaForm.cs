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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonDataSet1.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtOtomasyonDataSet1.Ogrenci);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle frm = new FrmYoneticiDuzenle();
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MsPaint.exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL= "http://eskiweb.radyo.itu.edu.tr/flash/klasik/index.html";
            

        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://eskiweb.radyo.itu.edu.tr/flash/klasik/index.html";
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://eskiweb.radyo.itu.edu.tr/flash/klasik/index.html";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayit fr = new FrmOgrKayit();
            fr.Show();

        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr = new FrmOgrListe();    
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrListe fr = new FrmOgrListe();
            fr.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrDuzenle fr = new FrmOgrDuzenle();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler frm = new FrmOdemeler();
            frm.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider frm = new FrmGider();
            frm.Show();
        }

        private void giderİstatislikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListeleme frm = new FrmGiderListeleme();
            frm.Show();
        }

        private void gelirİstatislikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirİstatistik frm = new FrmGelirİstatistik();
            frm.Show();
        }

        private void giderİstatislikleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel frm = new FrmPersonel();
            frm.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle frm = new FrmNotEkle();
            frm.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program Rana Mahsereci tarafından 22 Aralık 2022'de tamamlanmıştır.","Öğrenci Yurt Otomasyonu",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
    }

