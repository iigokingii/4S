using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using wpfLabs;

namespace labs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public ObservableCollection<Items> items { get; set; }
        public static string _Name="";
        public static string _Type { get; set; }
        public static string _Rating { get; set; }
        public static string _Color { get; set; }
        public static string _Number { get; set; }
        public static string _ImagePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<Items>
            {
                new Items { ID="ID: 0",Name = "груша", Type = "Фрукт", Rating = "Рейтинг: 4", Color = "Цвет:желто-красный", Number = "Штук в наличии:102", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\gr.jpg" },
                new Items { ID="ID: 1",Name = "яблоко", Type = "Фрукт", Rating = "Рейтинг: 6", Color = "Цвет:красный", Number = "Штук в наличии:94", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\apple.jpg" },
                new Items { ID="ID: 2",Name = "авокадо", Type = "Фрукт", Rating = "Рейтинг: 7", Color = "Цвет:зеленый", Number = "Штук в наличии:12", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\avokado.jpg" },
                new Items { ID="ID: 3",Name = "киви", Type = "Ягода", Rating = "Рейтинг: 8", Color = "Цвет:коричневый", Number = "Штук в наличии:20", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\kiwi.jpg" },
                new Items { ID="ID: 4",Name = "клубника", Type = "многоорешек", Rating = "Рейтинг: 3", Color = "Цвет:красный", Number = "Штук в наличии:1000", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\klub.jpg" },
                new Items { ID="ID: 5",Name = "Лимон", Type = "Ягода", Rating = "Рейтинг: 5.5", Color = "Цвет:желтый", Number = "Штук в наличии:15", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\lemon.jpg" },
                new Items { ID="ID: 6",Name = "Апельсин", Type = "Фрукт", Rating = "Рейтинг: 6.4", Color = "Цвет:Оранжевый", Number = "Штук в наличии:40", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\orange.jpg" },
                new Items { ID="ID: 7",Name = "Перец", Type = "Фрукт", Rating = "Рейтинг: 9", Color = "Цвет:Красный", Number = "Штук в наличии:60", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\perec.jpg" },
                new Items { ID="ID: 8",Name = "Персик", Type = "Фрукт", Rating = "Рейтинг: 10", Color = "Цвет:Желто-оранжевый", Number = "Штук в наличии:3", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\persik.jpg" },
                new Items { ID="ID: 9",Name = "Виноград", Type = "Ягода", Rating = "Рейтинг: 10", Color = "Цвет:Зеленый", Number = "Штук в наличии:19", ImagePath = "D:\\2k2s\\OOT\\labs\\lab4-7\\labs\\labs\\images\\vinogr.jpg" },

            };
            FileInfo file = new FileInfo("D:\\2k2s\\OOT\\labs\\wpfLabs\\labs\\labs\\bin\\Debug\\Items.xml");
            if (file.Exists)
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Items>));
                using (FileStream fs = new FileStream("Items.xml",FileMode.Open))
                    items = ser.Deserialize(fs) as ObservableCollection<Items>;
            }
            else
            {
                using (FileStream fs = new FileStream("Items.xml", FileMode.Create))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Items>));
                    ser.Serialize(fs, items);
                }
                /* items = new ObservableCollection<Items>();
                 FileStream file1 = File.Create("D:\\2k2s\\OOT\\labs\\wpfLabs\\labs\\labs\\bin\\Debug\\Items.xml");
                 file1.Close();*/
            }
            ItemsList.ItemsSource = items;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Save;
            commandBinding.Executed += CommandBind_Save;
            Saver.CommandBindings.Add(commandBinding);

            CommandBinding commandBinding2 = new CommandBinding();
            commandBinding2.Command = ApplicationCommands.Delete;
            commandBinding2.Executed += CommandBind_Delete ;
            Deleter.CommandBindings.Add(commandBinding2);

            this.Resources = new ResourceDictionary() { Source = new Uri("Resources/ResourceDict/DynamicStyles.xaml", UriKind.Relative) };
            //Темы
            var uri = new Uri("Resources/Theme/light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);

        }
        private void CommandBind_Save(object sender, ExecutedRoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("Saver.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Items>));
                ser.Serialize(fs, items);
            }
            MessageBox.Show("data has been saved to Saver.xml","Saver",MessageBoxButton.OKCancel,MessageBoxImage.Information,MessageBoxResult.OK);
        }
        private void CommandBind_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            FileInfo fi = new FileInfo("D:\\2k2s\\OOT\\labs\\wpfLabs\\labs\\labs\\bin\\Debug\\Saver.xml");
            fi.Delete();
            MessageBox.Show("data has been deleted by Deleter", "Deleter", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.OK);
        }


        private void But1_Click(object sender, RoutedEventArgs e)
        {
            AddItem item = new AddItem();
            bool ?res=item.ShowDialog();
            if (res.HasValue && !res.Value)
            {
                AddItem();
            }
        }
        public void AddItem()
        {
            if (_Name != "")
            {
                Items item = new Items { Name = _Name, Type = _Type, Rating = "Рейтинг: " + _Rating, Color = _Color, Number = "Штук в наличии: " + _Number, ImagePath = _ImagePath.ToString() };
                Items temp =items.Last();
                char[] sep = { ' ', ':' };
                string[] t = temp.ID.Split(sep);
                int idNumb=int.Parse(t.Last())+1;
                item.ID = "ID: " + idNumb;
                items.Add(item);
                using (FileStream fs = new FileStream("Items.xml", FileMode.Create))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Items>));
                    ser.Serialize(fs, items);
                }
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            ObservableCollection<Items> itemp = new ObservableCollection<Items>();
            if (e.Key == Key.Enter)
            {
                foreach(var elem in items)
                {
                    if (elem.Name == Search.Text)
                    {
                        itemp.Add(elem);
                    }
                }
                ItemsList.ItemsSource = itemp;
                Search.Text = "";
            }
        }
        private void SearchByType(object sender, KeyEventArgs e)
        {
            ObservableCollection<Items> itemp = new ObservableCollection<Items>();
            if (e.Key == Key.Enter)
            {
                foreach (var elem in items)
                {
                    if (elem.Type == ByTyp.Text)
                    {
                        itemp.Add(elem);
                    }
                }
                ItemsList.ItemsSource = itemp;
                Search.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            XmlSerializer sereal = new XmlSerializer(typeof(ObservableCollection<Items>));
            using (FileStream fs = new FileStream("Items.xml", FileMode.OpenOrCreate))
            {
                items=sereal.Deserialize(fs) as ObservableCollection<Items>;
            }
            ItemsList.ItemsSource = items;
        }
        private void SortByName(object sender,RoutedEventArgs e)
        {
            var q = items.OrderBy(t => t.Name);
            ItemsList.ItemsSource = q;
        }
        private void SortByRait(object sender, RoutedEventArgs e)
        {
            var q = items.OrderBy(t => t.Rating);
            ItemsList.ItemsSource = q;
        }
        private void SortByCol(object sender, RoutedEventArgs e)
        {
            var q = items.OrderBy(t => t.Color);
            ItemsList.ItemsSource = q;
        }
        private void SortByType(object sender, RoutedEventArgs e)
        {
            var q = items.OrderBy(t => t.Type);
            ItemsList.ItemsSource = q;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Item_List item_ = new Item_List(items);
            item_.Show();
        }
        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Items it = (Items)ItemsList.SelectedItem;
            Item Temporary = new Item(it);
            Temporary.Show();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Pen;
        }

        private void ru_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri("Resources/Dictionary/lang.ru-RU.xaml", UriKind.Relative);
            }
            catch(Exception ex)
            {
                MessageBox.Show("change lang Err");
            }
        }
        private void en_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Resources.MergedDictionaries[1].Source = new Uri("Resources/Dictionary/lang.en-US.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show("change lang Err");
            }
        }

        private void light_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/Theme/light.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void dark_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("Resources/Theme/dark.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void TextReverse_Click(object sender, RoutedEventArgs e)
        {
            ReverseWind reverse = new ReverseWind();
            reverse.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
        }

        private void Routedev_Click(object sender, RoutedEventArgs e)
        {
            RoutEvents routEvents = new RoutEvents(); 
            routEvents.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Tunneling tunneling = new Tunneling();
            tunneling.Show();
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string t = "Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString();
            MessageBox.Show(t, "Exit", MessageBoxButton.OKCancel);
            this.Close();
        }
    }

    public class Items
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Rating { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public string ImagePath { get; set; }
    }
    public class WindowCommands
    {
        static WindowCommands()
        {
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }
        public static RoutedCommand Exit { get; set; }

    }



}
