using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kulAdi = "1";
            string sifre = "1";

            if (textBox1.Text == kulAdi && textBox2.Text == sifre)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();

            }
            else
            {
                label3.Visible = true;
                label3.Text = "Kullanıcı adı veya şifre hatalı.";
            }
        }
    }
}
