using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using Timer = System.Windows.Forms.Timer;

namespace Lab2
{
    public partial class Flat : Form
    {

        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel infAboutObj;
        ToolStripLabel lastTask;
        Timer timer;

        static int counter = 0;
        string kitchen = "нет";
        string bath = "нет";
        string toilet = "нет";
        string basement = "нет";
        string balcony = "нет";
        public static bool adess=false;
        Flat.flat Flat1;
        List<Flat.flat> flats = new List<flat>();
        public static List<Flat.flat> newFlats = new List<flat>();
        bool ok = true;
        public class flat
        {
            [IndexValidation]
            public int id { get; set; }
            public double price;
            public string country { get; set; }
            public string city { get; set; }
            public string area { get; set; }
            public string street { get; set; }
            public string house { get; set; }
            public string frame { get; set; }
            [Range(1,100)]
            public string numberOfFlat { get; set; }
            public int metr { get; set; }
            [Range(1,5)]
            public int rooms { get; set; }

            public string kitchen="нет";
            public string bath="нет";
            public string toilet="нет";
            public string basement="нет";
            public string balcony="нет";
            [RegularExpression(@"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)")]
            public string date { get; set; }
            public string material { get; set; }
            [Range(1,10)]
            public int floor { get; set; }
            flat()
            {

            }
            public flat(int _id,int _metr,int numberOfrooms,string _kitchen, string _bath,string _toilet,string _basement,string _balcony,string _date,string _type, int _floor, string _country, string _city, string _area, string _street, string _house, string _frame, string _numberOfFlat)
            {
                id = _id;
                metr= _metr;
                price = metr * 2.4 + rooms * 3 / 99;
                rooms = numberOfrooms;
                kitchen= _kitchen;
                bath= _bath;
                toilet= _toilet;
                basement= _basement;
                balcony = _balcony;
                date= _date;
                material = _type;
                floor = _floor;
                country = _country;
                city = _city;
                area = _area;
                street = _street;
                house = _house;
                frame = _frame;
                numberOfFlat = _numberOfFlat;
            }
            ///////Метод валидации
            public static bool Validate(flat fl)
            {
                var rezults = new List<ValidationResult>();
                var context = new ValidationContext(fl);
                if (!Validator.TryValidateObject(fl, context, rezults, true))
                {
                    Invalid invalid = new Invalid(rezults);
                    invalid.Show();
                    return false;
                }
                return true;
            }
            public override string ToString()
            {
                return $"  Number: {id}, price: {price}, kitchen: {kitchen}, bath: {bath}, toilet: {toilet}, basement: {basement}, balcony: {balcony}, country: {country}, city: {city}, area: {area}, street: {street}, house: {house}, frame: {frame}, number of flat: {numberOfFlat}, footage: {metr}, rooms: {rooms}, date: {date}, material: {material}, floor: {floor}\n";
                //return id.ToString()+" " + price.ToString() + " " + metr.ToString() + " " + rooms.ToString() + " " + kitchen + " " + bath + " " + toilet + " " + basement + " " + balcony + " " + date + " " + material + " " + floor.ToString() + " " + country + " " + city + " " + area + " " + street + " " + house + " " + frame + " " + numberOfFlat;
            }


        }
        public Flat()
        {
            InitializeComponent();
            
            
            FileInfo info = new FileInfo(@"D:\2k2s\OOT\labs\lab2\Lab2\Lab2\bin\Debug\Flat.xml");
            if (info.Exists)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat.flat>));
                using (FileStream fs = new FileStream("Flat.xml", FileMode.Open))
                {
                    flats = xmlSerializer.Deserialize(fs) as List<Flat.flat>;
                }
            }
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            infAboutObj = new ToolStripLabel();
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            lastTask = new ToolStripLabel();
            lastTask.Text = "Запуск приложения";
            statusStrip1.Items.Add(lastTask);
            statusStrip1.Items.Add(infAboutObj);
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        ///////Заполнение адреса
        private void button1_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Заполнение адреса";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            adess = true;
            Adress adress = new Adress(this);
            adress.Show();
        }
        static bool flag = false;
        ///////
        //////////Открытие меню с опциями(есть ли кухня туалет и тд)
        private void button2_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Открыто меню с опциями";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            if (!flag)
            {
                int x = 10;
                for (int i = 0; i < 9; i++)
                {
                    this.checkedListBox2.Visible = true;
                    this.checkedListBox2.Size = new System.Drawing.Size(160, 0 + x);
                    Thread.Sleep(80);
                    x += 10;
                }
                flag = true;
            }

            else
            {
                int x = 10;
                for (int i = 0; i < 9; i++)
                {
                    this.checkedListBox2.Size = new System.Drawing.Size(160, 100 - x);
                    Thread.Sleep(60);
                    x += 10;
                }
                this.checkedListBox2.Visible = false;
                flag = !flag;
            }
        }
        ///////
        //////////Вывод сохраненных объектов
        private void button5_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Просмотр сохраненных объектов";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            FileInfo info = new FileInfo(@"D:\2k2s\OOT\labs\lab2\Lab2\Lab2\bin\Debug\Flat.xml");
            if (info.Exists)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat.flat>));
                using (FileStream fs = new FileStream("Flat.xml", FileMode.Open))
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    flats = xmlSerializer.Deserialize(fs) as List<Flat.flat>;
                    foreach (var flat in flats)
                    {

                        dataGridView1.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
                    }
                }
                dataGridView1.Visible = true;
            }
        }
        ///////
        //////////Закрытие таблицы
        private void button6_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Закрытие таблицы с объектами";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            dataGridView1.Visible = false;
        }
        List<Adress.adress> List;
        async private void button3_Click(object sender, EventArgs e)
        {
            
            ok = true;
            textBox1_Check();
            checkedListBox2_Check();
            comboBox1_Check();
            if (ok)
            {
                if (adess == true)
                {
                    FileInfo fix = new FileInfo(@"D:\2k2s\OOT\labs\lab2\Lab2\Lab2\bin\Debug\Flat.xml");
                    if (fix.Exists)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Adress.adress>));
                        using (FileStream fs = new FileStream("Adress.xml", FileMode.Open))
                        {
                            List = serializer.Deserialize(fs) as List<Adress.adress>;
                            if (List.Count != 0)
                            {
                                double price = int.Parse(textBox1.Text) * 2.4 + trackBar2.Value * 3 / 99;
                                errorProvider4.Clear();
                                XmlSerializer Serializer = new XmlSerializer(typeof(List<Flat.flat>));
                                using (FileStream fstream = new FileStream("Flat.xml", FileMode.OpenOrCreate))
                                {
                                    List<Flat.flat> l = Serializer.Deserialize(fstream) as List<Flat.flat>;
                                    /* dataGridView1.Rows.Add(counter,price, textBox1.Text, trackBar2.Value, kitchen, bath, toilet, basement, balcony, dateTimePicker1.Value,
                                          comboBox1.SelectedItem, trackBar1.Value, List[0].country, List[0].city, List[0].area, List[0].street, List[0].house, List[0].frame, List[0].numberOfFlat);
                                    */
                                    Flat1 = new Flat.flat(l[l.Count - 1].id + 1, int.Parse(textBox1.Text), trackBar2.Value, kitchen, bath, toilet, basement, balcony, dateTimePicker1.Value.ToShortDateString(),
                                    comboBox1.SelectedItem.ToString(), trackBar1.Value, List[0].country, List[0].city, List[0].area, List[0].street, List[0].house, List[0].frame, List[0].numberOfFlat);
                                }
                            }
                        }
                        if (flat.Validate(Flat1))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat.flat>));
                            using (FileStream fs = new FileStream("Flat.xml", FileMode.OpenOrCreate))
                            {

                                flats.Add(Flat1);
                                xmlSerializer.Serialize(fs, flats);
                                MessageBox.Show("Данные успешно записаны в Flat.xml");
                            }
                            adess = false;

                        }
                    }
                    else
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Adress.adress>));
                        using (FileStream fs = new FileStream("Adress.xml", FileMode.Open))
                        {
                            List = serializer.Deserialize(fs) as List<Adress.adress>;
                            double price = int.Parse(textBox1.Text) * 2.4 + trackBar2.Value * 3 / 99;
                        }
                        Flat1 = new Flat.flat(0, int.Parse(textBox1.Text), trackBar2.Value, kitchen, bath, toilet, basement, balcony, dateTimePicker1.Value.ToShortDateString(),
                        comboBox1.SelectedItem.ToString(), trackBar1.Value, List[0].country, List[0].city, List[0].area, List[0].street, List[0].house, List[0].frame, List[0].numberOfFlat);
                        if (flat.Validate(Flat1))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Flat.flat>));
                            using (FileStream fs = new FileStream("Flat.xml", FileMode.OpenOrCreate))
                            {
                                flats.Add(Flat1);
                                xmlSerializer.Serialize(fs, flats);
                                MessageBox.Show("Данные успешно записаны в Flat.xml");
                            }
                            adess = false;
                        }
                    }
                    
                }
                else
                {
                    errorProvider4.SetError(button1,"Адресс квартиры не заполнен");
                }
                FileInfo fi = new FileInfo("Adress.xml");
                fi.Delete();
                lastTask.Text = "Сохранение объекта;";
                infAboutObj.Text = $"Количество объектов: {flats.Count}";
            }
        }
        ///////
        //////////Выбор этажа
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = String.Format("Выбранный этаж : {0}", trackBar1.Value);
        }
        ///////
        //////////Выбор комнат
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = String.Format("Количество комнат : {0}", trackBar2.Value);
        }
        ///////
        int value;
        /////////Выбор метража
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox1.Text, out value))
            {
                errorProvider1.SetError(textBox1, "Неверно введен метраж");
                ok = false;
            }
            else
            {
                lastTask.Text = "Заполнен метраж";
                infAboutObj.Text = $"Количество объектов: {flats.Count}";
                errorProvider1.Clear();
            }
        }
        
        private void textBox1_Check()
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Метраж не заполнен");
                ok = false;
            }
        }
        ///////
        //////////Заполнение полей о наличии кухни ванной и тд
        private void checkedListBox2_Check()
        {
            bool fl=true;
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {

                if (checkedListBox2.GetItemChecked(i))
                {
                    fl = false;
                    switch (checkedListBox2.Items[i].ToString())
                    {

                        case "Кухня":
                            {
                                kitchen = "есть";
                                errorProvider2.Clear();
                                break;
                            }
                        case "Ванна":
                            {
                                bath = "есть";
                                errorProvider2.Clear();
                                break;
                            }
                        case "Туалет":
                            {
                                toilet = "есть";
                                errorProvider2.Clear();
                                break;
                            }
                        case "Подвал":
                            {
                                basement = "есть";
                                errorProvider2.Clear();
                                break;
                            }
                        case "Балкон":
                            {
                                balcony = "есть";
                                errorProvider2.Clear();
                                break;
                            }
                    }
                }   
            }
            if (fl)
            {
                errorProvider2.SetError(button2, "Опции не заполнены");
                ok = false;
            }
        }
        private void comboBox1_Check()
        {
            if (comboBox1.Text == "")
            {
                errorProvider3.SetError(comboBox1, "не выбран материал");
                ok = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider3.Clear();
            lastTask.Text = "Заполнен тип материала";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }
        //////////Очистка полей формы
        private void button4_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Очистка введенных полей";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            textBox1.Text = "";
            trackBar1.Value = trackBar1.Minimum;
            label2.Text = "Количество комнат : 1";
            trackBar2.Value = trackBar2.Minimum;
            label5.Text = "Выбранный этаж : 1";
            checkedListBox2.ClearSelected();
            comboBox1.Text = "";
            dateTimePicker1.Refresh();
        }
        ///////
        //Поиск///////////////////
        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text != "")
            {
                Poisk poisk = new Poisk(flats, toolStripComboBox1.SelectedItem.ToString());
                poisk.Show();
            }   
        }

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            Poisk poisk = new Poisk(flats, toolStripComboBox2.SelectedItem.ToString());
            poisk.Show();
        }

        private void toolStripComboBox3_TextChanged(object sender, EventArgs e)
        {
            Poisk poisk = new Poisk(flats, toolStripComboBox3.SelectedItem.ToString());
            poisk.Show();
        }
        private void toolStripMenuItem2_DropDownOpened(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "";
        }

        private void toolStripMenuItem3_DropDownOpened(object sender, EventArgs e)
        {
            toolStripTextBox2.Text = "";
        }

        private void поРайонуToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            toolStripComboBox2.Text = "";
        }

        private void toolStripMenuItem4_DropDownOpened(object sender, EventArgs e)
        {
            toolStripComboBox3.Text = "";
        }
        static bool fll;
        private void toolStripTextBox2_MouseLeave(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = new ToolStripTextBox();
            textBox.Text = "Неверный формат даты (дд.мм.19-20гг)";
            textBox.Width = 300;
            textBox.ReadOnly = true;
            ToolStripSeparator separator = new ToolStripSeparator();
            String s = toolStripTextBox2.Text;
            Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)");
            MatchCollection match = regex.Matches(s);
            if (match.Count == 1)
            {
                fll = true;
                if (toolStripMenuItem3.DropDownItems.Count > 1)
                {
                    toolStripMenuItem3.DropDownItems.RemoveAt(2);
                    toolStripMenuItem3.DropDownItems.RemoveAt(1);
                }
                Poisk poisk = new Poisk(flats, toolStripTextBox2.Text);
                poisk.Show();
                toolStripTextBox2.Text = "";
            }
            else
            {
                if (!fll)
                {
                    toolStripMenuItem3.DropDownItems.Add(separator);
                    toolStripMenuItem3.DropDownItems.Add(textBox);
                    fll = true;
                }
            }
        }
        /////////////////
        
        //Поиск
        private void конструкторЗапросаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConstrOfRequests request = new ConstrOfRequests();
            request.Show();
        }
        //////////////////
        
        //Cортировка
        private void площадиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.metr)
                            .Select(t=>t);
            foreach(var flat in temp)
            {   
                dataGridView2.Rows.Add(flat.id,flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
                newFlats.Add(flat);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            lastTask.Text = "Выполнена сортировка";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }

        private void количествуКомнатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.rooms)
                            .Select(t => t);
            foreach (var flat in temp)
            {
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
                newFlats.Add(flat);
            }
        }

        private void ценеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.price)
                            .Select(t => t);
            foreach(var flat in temp)
            {
                newFlats.Add(flat);
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
            }
        }
        ////////////////////////////
        ///О программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнен запрос о версии программы ";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            MessageBox.Show("Smolik V.A.", "Version:3.9",MessageBoxButtons.OK);
        }
        ///////
        /////// Сохранение
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнено сохранение ";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Flat.flat>));
            using (FileStream fs = new FileStream("newFlat.xml",FileMode.Create))
            {
                serializer.Serialize(fs, newFlats);
                MessageBox.Show("результаты сортировок и поиска сохранены в newFlat.xml");
            }
        }
        ///////
        ///////Закрытие таблицы
        private void закрытьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }
        ////////
        ////////Очистка кода
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнена очистка введенных данных";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            textBox1.Text = "";
            trackBar1.Value = trackBar1.Minimum;
            label2.Text = "Количество комнат : 1";
            trackBar2.Value = trackBar2.Minimum;
            label5.Text = "Выбранный этаж : 1";
            checkedListBox2.ClearSelected();
            comboBox1.Text = "";
            dateTimePicker1.Refresh();
        }
        ///////
        ///////Удаление последнего элемента
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнено удаление последнего добавленного элемента";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            XmlSerializer ser = new XmlSerializer(typeof (List<Flat.flat>));
            using (FileStream fs = new FileStream("Flat.xml", FileMode.Create))
            {
                flats.RemoveAt(flats.Count - 1);
                ser.Serialize(fs, flats);
                MessageBox.Show("Удален объект, данные перезаписаны во Flat.xml");
            }
        }
        ///////
        ///////Стрелки
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Изменение следования объектов";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            dataGridView2.Visible = true;
            List<flat> temp = flats;
            flat fl = temp[0];
            temp.RemoveAt(0);
            temp.Add(fl);
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            foreach (var flat in temp)
            {
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Изменение следования объектов";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            dataGridView2.Visible = true;
            List<flat> temp = flats;
            flat fl = temp[flats.Count-1];
            temp.RemoveAt(flats.Count - 1);
            temp.Insert(0, fl);
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            foreach (var flat in flats)
            {
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
            }
        }
        ///////
        //////////Скрытие меню
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Меню скрыто";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            toolStrip1.Visible = false;
        }
        ///////
        //////////Открытие меню
        private void открытьМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Открыто меню";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
            toolStrip1.Visible = true;
        }
        ///////
        //////////Поиск и сортировка
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнен поиск";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнен поиск";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            lastTask.Text = "Выполнен поиск";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            lastTask.Text = "Изменение количества комнат";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lastTask.Text = "Изменен этаж";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }
        ///////
        //////////Изменение даты

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lastTask.Text = "Изменена дата постройки";
            infAboutObj.Text = $"Количество объектов: {flats.Count}";
        }
        ///////
        //////////Завершение работы
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void площадиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.metr)
                            .Select(t => t);
            foreach (var flat in temp)
            {
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
                newFlats.Add(flat);
            }
        }

        private void количествуКомнатToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.rooms)
                            .Select(t => t);
            foreach (var flat in temp)
            {
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
                newFlats.Add(flat);
            }
        }

        private void ценеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            var temp = flats.OrderByDescending(t => t.price)
                            .Select(t => t);
            foreach (var flat in temp)
            {
                newFlats.Add(flat);
                dataGridView2.Rows.Add(flat.id, flat.price, flat.metr, flat.rooms, flat.kitchen, flat.bath, flat.toilet, flat.basement, flat.balcony, flat.date, flat.material, flat.floor, flat.country, flat.city, flat.area, flat.street, flat.house, flat.frame, flat.numberOfFlat);
            }
        }

        private void закрытьТаблицуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
        }

        private void toolStripComboBox4_TextChanged(object sender, EventArgs e)
        {
            Poisk poisk = new Poisk(flats, toolStripComboBox4.SelectedItem.ToString());
            poisk.Show();
        }

        private void афывфыToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            toolStripComboBox4.Text = "";
        }
        private void toolStripComboBox5_TextChanged(object sender, EventArgs e)
        {
            Poisk poisk = new Poisk(flats, toolStripComboBox5.SelectedItem.ToString());
            poisk.Show();
        }
        private void поРайонуToolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            toolStripComboBox5.Text = "";
        }

        private void поГородуToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            toolStripComboBox6.Text = "";
        }

        private void toolStripComboBox6_TextChanged(object sender, EventArgs e)
        {
            Poisk poisk = new Poisk(flats, toolStripComboBox6.SelectedItem.ToString());
            poisk.Show();
        }

        private void toolStripTextBox1_MouseLeave(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = new ToolStripTextBox();
            textBox.Text = "Неверный формат даты (дд.мм.19-20гг)";
            textBox.Width = 300;
            textBox.ReadOnly = true;
            ToolStripSeparator separator = new ToolStripSeparator();
            String s = toolStripTextBox1.Text;
            Regex regex = new Regex(@"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)");
            MatchCollection match = regex.Matches(s);
            if (match.Count == 1)
            {
                fll = true;
                if (поГодуToolStripMenuItem.DropDownItems.Count > 1)
                {
                    поГодуToolStripMenuItem.DropDownItems.RemoveAt(2);
                    поГодуToolStripMenuItem.DropDownItems.RemoveAt(1);
                }
                Poisk poisk = new Poisk(flats, toolStripTextBox1.Text);
                poisk.Show();
                toolStripTextBox1.Text = "";
            }
            else
            {
                if (!fll)
                {
                    поГодуToolStripMenuItem.DropDownItems.Add(separator);
                    поГодуToolStripMenuItem.DropDownItems.Add(textBox);
                    fll = true;
                }
            }
        }
    }
}
