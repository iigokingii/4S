using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Item_List.xaml
    /// </summary>
    public partial class Item_List : Window
    {
        public Item_List()
        {
            InitializeComponent();
            this.Cursor = Cursors.Pen;
        }
        public Item_List(ObservableCollection<Items> items)
        {
            InitializeComponent();
            ItemsGrid.ItemsSource = items;
            this.Cursor = Cursors.Pen;
        }
    }
}
