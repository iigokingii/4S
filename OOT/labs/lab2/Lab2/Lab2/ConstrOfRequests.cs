using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Lab2.Flat;

namespace Lab2
{
    public partial class ConstrOfRequests : Form
    {
        public ConstrOfRequests()
        {
            InitializeComponent();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Flat.flat>));
            using (FileStream fs = new FileStream("Flat.xml", FileMode.Open))
            {
                flats = serializer.Deserialize(fs) as List<Flat.flat>;
            }
        }
        List<Flat.flat> flats;
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)");
            MatchCollection match = regex.Matches(s);
            if (match.Count != 1)
            {
                errorProvider1.SetError(textBox1, "Неверный формат даты (дд.мм.19-20гг)");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            List<flat> flats;
            string temp = textBox1.Text;
            string rez = temp[0].ToString().ToUpper() + temp.Substring(1);
            if (string.IsNullOrEmpty(temp))
            {
                errorProvider2.SetError(textBox1, "Введите критерий");
            }
            XmlSerializer ser = new XmlSerializer(typeof(List<flat>));
            bool fl = false;
            using (FileStream fs = new FileStream("Flat.xml", FileMode.Open))
            {
                flats = ser.Deserialize(fs) as List<flat>;
            }




            Regex pattern = new Regex(rez);
            foreach (var flat in flats)
            {
                MatchCollection matches = pattern.Matches(Convert.ToString(flat));
                if (matches.Count > 0)
                {
                    textBox2.AppendText(flat.ToString() + "\n");
                    fl = true;
                }
                /*if (pattern.IsMatch(flat.ToString()))
                {
                    textBox2.AppendText(flat.ToString() + "\n");
                    fl = true;
                }*/
            }
            if (!fl)
                MessageBox.Show("По вашему запросу ничего не найдено");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
