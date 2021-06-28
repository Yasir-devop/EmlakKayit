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

namespace EmlakKayit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Zambak")
            {
                siteZambak.BackColor = Color.Green;
                sitePapatya.BackColor = Color.MistyRose;
                siteGül.BackColor = Color.MistyRose;
                siteMenekşe.BackColor = Color.MistyRose;
            }
            if (comboBox1.Text == "Papatya")
            {
                siteZambak.BackColor = Color.MistyRose;
                sitePapatya.BackColor = Color.Green;
                siteGül.BackColor = Color.MistyRose;
                siteMenekşe.BackColor = Color.MistyRose;
            }
            if (comboBox1.Text == "Gül")
            {
                siteZambak.BackColor = Color.MistyRose;
                sitePapatya.BackColor = Color.MistyRose;
                siteGül.BackColor = Color.Green;
                siteMenekşe.BackColor = Color.MistyRose;
            }
            if (comboBox1.Text == "Menekşe")
            {
                siteZambak.BackColor = Color.MistyRose;
                sitePapatya.BackColor = Color.MistyRose;
                siteGül.BackColor = Color.MistyRose;
                siteMenekşe.BackColor = Color.Green;
            }
        }

        SqlConnection baglanti = new SqlConnection("Data Source=YASIR;Initial Catalog=Emlak;Integrated Security=True");

        private void veriGoruntule()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from siteBilgi",baglanti);
            SqlDataReader veriOku = komut.ExecuteReader();

            while (veriOku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = veriOku["id"].ToString();
                ekle.SubItems.Add(veriOku["siteAd"].ToString());
                ekle.SubItems.Add(veriOku["oda"].ToString());
                ekle.SubItems.Add(veriOku["metrekare"].ToString());
                ekle.SubItems.Add(veriOku["fiyat"].ToString());
                ekle.SubItems.Add(veriOku["blok"].ToString());
                ekle.SubItems.Add(veriOku["daireNo"].ToString());
                ekle.SubItems.Add(veriOku["adSoyad"].ToString());
                ekle.SubItems.Add(veriOku["telefon"].ToString());
                ekle.SubItems.Add(veriOku["Eknot"].ToString());
                ekle.SubItems.Add(veriOku["satKira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void veriKaydet()
        {
            
            baglanti.Open();
            string sqlSorgu = "Insert into siteBilgi (id,siteAd,oda,metrekare,fiyat,blok,daireNo,adSoyad,telefon,Eknot,satKira) values ('" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox7.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox2.Text.ToString() + "')";
            SqlCommand komut = new SqlCommand(sqlSorgu,baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();


            veriGoruntule();
        }

        private void veriSil()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From siteBilgi where id=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();



            veriGoruntule();
        }

        private void veriGuncelle()
        {
            baglanti.Open();
            string sqlSorgu =  "Update siteBilgi set id='" + textBox3.Text.ToString()+ "', siteAd='" + comboBox1.Text.ToString() + "', oda='" + comboBox3.Text.ToString() + "', metrekare='" + textBox1.Text.ToString() + "', fiyat='" + textBox2.Text.ToString() + "', blok='" + comboBox7.Text.ToString() + "', daireNo='" + textBox7.Text.ToString() + "', adSoyad='" + textBox6.Text.ToString() + "', telefon='" + textBox5.Text.ToString() + "', Eknot='" + textBox4.Text.ToString() + "', satKira='" + comboBox2.Text.ToString() + "'where id='" + id + "'";
            SqlCommand komut = new SqlCommand(sqlSorgu,baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();


            veriGoruntule();
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            veriGoruntule();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            veriKaydet();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            veriSil();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); 
            veriGuncelle();
        }


        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox7.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }
    }
}
