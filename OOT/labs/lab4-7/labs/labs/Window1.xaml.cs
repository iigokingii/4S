using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace labs
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Stack<Items> RedoWatcher = new Stack<Items>();
        Stack<Items> UndoWatcher = new Stack<Items>();
        ObservableCollection<Items> items;
        public Window1()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("Items.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Items>));
                items = serializer.Deserialize(fs) as ObservableCollection<Items>;
            }
            ItemsLit.ItemsSource = items;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool? delete = DataTriggerS.IsChecked;
            bool? change = DataTrigger.IsChecked;
            if (delete.HasValue && delete.Value)
            {
                int i;
                if (!int.TryParse(textId.Text,out i))
                {
                    textId.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    textId.Background = new SolidColorBrush(Colors.White);
                }
                bool find=false;
                int t = int.Parse(textId.Text);
                foreach(var ts in items)
                {
                    if(t==int.Parse(ts.ID.Split(':',' ').Last()))
                    {
                        UndoWatcher.Push(ts);
                        items.Remove(ts);
                        find = true;
                        break;
                    }
                }
            }
            else if(change.HasValue && change.Value)
            {
                int p1;
                double p2;
                if (!int.TryParse(Number.Text, out p1))
                {
                    Number.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    Number.Background = new SolidColorBrush(Colors.White);
                }

                if (!double.TryParse(Rating.Text, out p2))
                {
                    Rating.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    Rating.Background = new SolidColorBrush(Colors.White);
                }
                bool find = false;
                int t = int.Parse(textId.Text);
                foreach (var ts in items)
                {
                    if (t == int.Parse(ts.ID.Split(':', ' ').Last()))
                    {
                        Items item = new Items();
                        item.Number = ts.Number;
                        item.Color = ts.Color;
                        item.ImagePath = ts.Color;
                        item.ID = ts.ID;
                        item.Rating = ts.Rating;
                        item.Type = ts.Type;
                        item.Name = ts.Name;
                        item.ImagePath = ts.ImagePath;
                        UndoWatcher.Push(item);

                        int tempIndex = items.IndexOf(ts);
                        items.Remove(ts);
                        ts.Name = Name.Text;
                        Name.Text = "";
                        ts.Number = Number.Text;
                        Number.Text = "";
                        ts.Color = Color.Text;
                        Color.Text = "";
                        ts.Rating = Rating.Text;
                        Rating.Text = "";
                        ts.Type = Type.Text;
                        Type.Text = "";
                        
                        items.Insert(tempIndex, ts);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите операцию","Операция",MessageBoxButton.OKCancel);
            }
        }
        
        private void Redo_Click(object sender, RoutedEventArgs e) //Вперед
        {
            if (RedoWatcher.Count > 0)
            {
                var item = RedoWatcher.Pop();
                bool find = false;
                foreach(var t in items)
                {
                    if (item.ID == t.ID)
                    {
                        UndoWatcher.Push(t);
                        int index = items.IndexOf(t);
                        items.RemoveAt(index);
                        if(item.Type!=t.Type || item.Name != t.Name)                        
                            items.Insert(index, item);                       
                        break;

                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно перейти вперед", "RedoWatcher", MessageBoxButton.OKCancel);
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)//назад
        {
            if (UndoWatcher.Count > 0)
            {
                var item = UndoWatcher.Pop();
                bool find = false;
                foreach(var t in items)
                {
                    if (item.ID == t.ID)
                    {
                        int index = items.IndexOf(t);
                        items.Remove(t);
                        RedoWatcher.Push(t);
                        items.Insert(index, item);
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    RedoWatcher.Push(item);
                    items.Add(item);
                    var it = items.OrderBy(t => int.Parse(t.ID.Split(' ', ':').Last()));
                    ObservableCollection<Items> asd = new ObservableCollection<Items>();
                    foreach (var i in it)
                    {
                        asd.Add(i);
                    }
                    items.Clear();
                    for (int i = 0; i < asd.Count; i++)
                    {
                        items.Add(asd[i]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно перейти назад", "UndoWatcher", MessageBoxButton.OKCancel);
            }
        }
    }
}
