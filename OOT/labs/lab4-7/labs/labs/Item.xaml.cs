using System;
using System.Collections.Generic;
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

namespace labs
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        public Items item;
        public int Id { get; set; }
        public Item()
        {
            InitializeComponent();
            this.Cursor = Cursors.Pen;
        }
        public Item(Items _item)
        {
            InitializeComponent();
            item = new Items { ID=_item.ID,Name = _item.Name, Color = _item.Color, Type = _item.Type, Rating = _item.Rating, ImagePath = _item.ImagePath, Number = _item.Number };
            name.Text=item.Name;
            this.DataContext = item;
            this.Cursor = Cursors.Pen;
            Id =int.Parse(item.ID.Split(' ',':').Last());
            item.ID = Id.ToString();
        }
        public void Add_Context()
        {
            name.Text = item.Name;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
