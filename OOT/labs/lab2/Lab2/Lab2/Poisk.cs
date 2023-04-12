using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab2.Flat;
using System.Xml.Serialization;

namespace Lab2
{
    public partial class Poisk : Form
    {
        public Poisk()
        {
            InitializeComponent();
        }
        public Poisk(List<Flat.flat> flats,string criterion)
        {
            InitializeComponent();
            textBox2.Text = criterion;
            textBox2.ReadOnly = true;
            string s = "";
            foreach (var flat in flats)
            { 
                if (flat.material == criterion || flat.area==criterion || flat.city == criterion || (flat.date.ToString()) == criterion)
                {
                    s=$"Number: {flat.id}, price: {flat.price}, kitchen: {flat.kitchen}, bath: {flat.bath}, toilet: {flat.toilet}, basement: {flat.basement}, balcony: {flat.balcony}, country: {flat.country}, city: {flat.city}, area: {flat.area}, street: {flat.street}, house: {flat.house}, frame: {flat.frame}, number of flat: {flat.numberOfFlat}, footage: {flat.metr}, rooms: {flat.rooms}, date: {flat.date}, material: {flat.material}, floor: {flat.floor}\n";
                    this.textBox1.AppendText(s);
                    textBox1.AppendText("\n");
                    Flat.newFlats.Add(flat);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.Close();
        }
    }
}
