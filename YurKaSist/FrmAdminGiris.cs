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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select*from Admin where YöneticiAd=@p1 and YöneticiSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm anaForm = new FrmAnaForm();
                anaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre");
                TxtKullaniciAd.Clear();
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();

            }
            bgl.baglanti().Close();
        }
    }
}
