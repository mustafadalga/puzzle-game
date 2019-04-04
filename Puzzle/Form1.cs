using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        int hamle;
        Random rnd = new Random();
        Point konum = new Point();
        Point gecicikonum = new Point();
        Point[] konumlar = new Point[8];
        public void OyunBaslat()
        {
            hamle = 0;
            konum = new Point(300, 0);
            gecicikonum = new Point(0, 0);
            konumlar = new Point[8] { new Point(0, 0), new Point(150, 0), new Point(0, 150), new Point(150, 150), new Point(300, 150), new Point(0, 300), new Point(150, 300), new Point(300, 300) };
        }

        public void Kontrol()
        {
            if (button1.Location==new Point(0,0) && button2.Location==new Point(150,0) &&  button4.Location==new Point(0,150)
               && button5.Location==new Point(150,150) && button6.Location==new Point(300,150) && button7.Location==new Point(0,300)
               && button8.Location==new Point(150,300) && button9.Location==new Point(300,300) )
            {
                MessageBox.Show("Tebrikler, Puzzle parçalarını düzgün bir şekilde yerlerine yerleştirdiniz!", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblhamlesayisi.Text = hamle + " hamlede tamamlandı";
                lblgecensure.Text = hour + ":" + minute + ":" + second + " sürede tamamlandı";
                tmrsure.Enabled = false;
                panel1.Enabled = false;
            }
        }

        public void kisaltilmiskod()
        {
            konum = gecicikonum;
            hamle++;
            lblhamlesayisi.Text = hamle + ". hamle";
            Kontrol();
        }

        public void Zaman()
        {
            if (Convert.ToString(saat).Length == 1) hour = "0" + saat.ToString();
            else hour = saat.ToString();
            if (Convert.ToString(dakika).Length == 1) minute = "0" + dakika.ToString();
            else minute = dakika.ToString();
            if (Convert.ToString(saniye).Length == 1) second = "0" + saniye.ToString();
            else second = saniye.ToString();
            lblgecensure.Text = hour + ":" + minute + ":" + second;
        }



        private void btnkaristir_Click(object sender, EventArgs e)
        {
            OyunBaslat();
            saniye=0;
            dakika = 0;
            saat = 0;
            hamle = 0;
            panel1.Enabled = true;
            tmrsure.Enabled = true;
            lblhamlesayisi.Text = hamle.ToString();
            Zaman();
           

            for (int i = 0; i < 8; i++)
            {
                int index = rnd.Next(8);
                Point temp = konumlar[index];
                konumlar[index] = konumlar[i];
                konumlar[i] = temp;
            }
            button1.Location = konumlar[0];
            button2.Location = konumlar[1];
            button4.Location = konumlar[2];
            button5.Location = konumlar[3];
            button6.Location = konumlar[4];
            button7.Location = konumlar[5];
            button8.Location = konumlar[6];
            button9.Location = konumlar[7];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gecicikonum = button1.Location;
            button1.Location = konum;
            kisaltilmiskod();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gecicikonum = button2.Location;
            button2.Location = konum;
            kisaltilmiskod();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            gecicikonum = button4.Location;
            button4.Location = konum;
            kisaltilmiskod();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gecicikonum = button5.Location;
            button5.Location = konum;
            kisaltilmiskod();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gecicikonum = button6.Location;
            button6.Location = konum;
            kisaltilmiskod();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gecicikonum = button7.Location;
            button7.Location = konum;
            kisaltilmiskod();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gecicikonum = button8.Location;
            button8.Location = konum;
            kisaltilmiskod();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gecicikonum = button9.Location;
            button9.Location = konum;
            kisaltilmiskod();
        }


        int saniye = 0, dakika = 0, saat = 0;
        string second, minute, hour;

        private void tmrsure_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }
            if (dakika == 60)
            {
                saniye = 0;
                dakika = 0;
                saat++;
            }
            Zaman();
        }
    }
}
