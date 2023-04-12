using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class Adress : Form
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        List<Adress.adress> list=new List<Adress.adress>();
        public static Adress instance;
       
        int numbOfFlat;
        int index = -1;
        public class adress
        {
            public string country { get; set; }
            public string city { get; set; }
            public string area { get; set; }
            public string street { get; set; }
            public string house { get; set; }
            public string frame { get; set; }
            public string numberOfFlat { get; set; }
            adress()
            {

            }
            public adress(string _country, string _city, string _area, string _street, string _house, string _frame, string _numberOfFlat)
            {
                country = _country;
                city = _city;
                area = _area;
                street = _street;
                house = _house;
                frame = _frame;
                numberOfFlat = _numberOfFlat;
            }
        }
        bool ok = true;
        
        public Adress()
        {
            InitializeComponent();
            instance = this;
        }
        public Adress(Flat flat)
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            ok = true;
            groupBox1_Check(false) ;
            domainUpDown1_Check();
            textBox5_Check();
            numericUpDown1_Сheck();
            comboBox1_Check();
            if (ok)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Adress.adress>));
                using (FileStream fs = new FileStream("Adress.xml", FileMode.Create))
                {
                    string country = "Беларусь";
                    string city = (string)domainUpDown1.SelectedItem;
                    string area = groupBox1.Controls[index].Text;
                    string street = (string)comboBox1.SelectedItem;
                    string house = textBox5.Text;
                    string frame = trackBar1.Value.ToString();
                    string numberOfFlat = numericUpDown1.Value.ToString();
                    Adress.adress Adress = new Adress.adress(country,city,area,street,house,frame,numberOfFlat);
                    list.Add(Adress);
                    serializer.Serialize(fs, list);
                    MessageBox.Show("Данные успешно записаны в Adress.xml");
                    Flat.adess = true;
                }
                this.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1_Check(true);
            domainUpDown1.Text = "";

            if(index!=-1)
                ((RadioButton)groupBox1.Controls[index]).Checked = false;
            comboBox1.Text = "";
            textBox5.Text = "";
            trackBar1.Value = trackBar1.Minimum;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = String.Format("Выбранный корпус : {0}", trackBar1.Value);
        }

        private void numericUpDown1_Сheck()
        {
            string[] temp = label6.Text.Split();
            int value=0;
            foreach (string s in temp)
            {
                if (s == "1" || s == "2" || s == "3" || s == "4")
                {
                     value= int.Parse(s);
                }
            }
            if (numericUpDown1.Value > 25 && value==1)
            {
                errorProvider2.SetError(numericUpDown1, "Неверный номер квартиры, для данного корпуса");
                ok = false;
            }
            else if(!(25< numericUpDown1.Value && numericUpDown1.Value < 50) && value == 2)
            {
                errorProvider2.SetError(numericUpDown1, "Неверный номер квартиры, для данного корпуса");
                ok = false;
            }
            else if (!(50 < numericUpDown1.Value && numericUpDown1.Value < 75) && value == 3)
            {
                errorProvider2.SetError(numericUpDown1, "Неверный номер квартиры, для данного корпуса");
                ok = false;
            }
            else if (!(75 < numericUpDown1.Value && numericUpDown1.Value < 101) && value == 4)
            {
                errorProvider2.SetError(numericUpDown1, "Неверный номер квартиры, для данного корпуса");
                ok = false;
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox5.Text, out numbOfFlat)||textBox5.Text=="")
            {
                errorProvider1.SetError(textBox5, "Неверно введен номер дома");
                ok = false;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void groupBox1_Check(bool? b)
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if (((RadioButton)groupBox1.Controls[i]).Checked == true)
                {
                    index = i;
                }
            }
            if (index == -1 && b==false)
            {
                errorProvider3.SetError(groupBox1, "Выберите район");
                ok = false;
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void domainUpDown1_Check()
        {
            if (domainUpDown1.Text == "")
            {
                ok = false;
                errorProvider4.SetError(domainUpDown1, "Выберите город");
            }
            else
            {
                errorProvider4.Clear();
            }
        }
        private void textBox5_Check()
        {
            if (textBox5.Text == "")
            {
                ok = false;
                errorProvider5.SetError(textBox5, "Выберите дом");
            }
            else
            {
                errorProvider5.Clear();
            }
        }
        private void comboBox1_Check()
        {
            if (comboBox1.Text == "")
            {
                ok = false;
                errorProvider6.SetError(comboBox1, "Выберите дом");
            }
            else
            {
                errorProvider6.Clear();
            }
        }
    }
}
