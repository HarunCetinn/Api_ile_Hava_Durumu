using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Api_Hava_Durumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Şehir = textBox1.Text;
            string api = "ece0061022206f8ba4fff52c62fc6179";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=" + Şehir + "&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(connection);
            var sicaklık = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label3.Text = sicaklık + " °";
            var rüzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            label5.Text = rüzgar + " m/s";
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            label7.Text = nem + " %";
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            label9.Text = durum.ToString();
            var yagis = hava.Descendants("clouds").ElementAt(0).Attribute("value").Value;
            label11.Text = yagis+ " %";
            var hissedilen = hava.Descendants("feels_like").ElementAt(0).Attribute("value").Value;
            label13.Text = hissedilen + " °";

            if (durum =="açık")
            {
                pictureBox1.ImageLocation = @"C:\Users\harun\Desktop\güneş.png";
            }

            if (durum == "bulutlu" || durum== "parçalı az bulutlu" || durum == "parçalı bulutlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\harun\Desktop\bulutlu.png";
            }

            if (durum == "karlı")
            {
                pictureBox1.ImageLocation = @"C:\Users\harun\Desktop\karlı.png";
            }

            if (durum == "kapalı" || durum == "hafif yağmur" || durum == "yağmur")
            {
                pictureBox1.ImageLocation = @"C:\Users\harun\Desktop\yağmur.png";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToShortDateString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
