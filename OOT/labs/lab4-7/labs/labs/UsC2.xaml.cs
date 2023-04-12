using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labs
{
    /// <summary>
    /// Логика взаимодействия для UsC2.xaml
    /// </summary>
    public partial class UsC2 : UserControl
    {
        public ImageSource image { get; set; }
        public UsC2()
        {
            InitializeComponent();
        }
        private void imgPicture_Change(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                imgPicture.Source =
                    new BitmapImage(new Uri(ofdPicture.FileName));
                image = new BitmapImage(new Uri(ofdPicture.FileName));
            }
                
        }
    }
}
