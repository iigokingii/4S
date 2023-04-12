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
    /// Логика взаимодействия для Tunneling.xaml
    /// </summary>
    public partial class Tunneling : Window
    {
        public Tunneling()
        {
            InitializeComponent();
        }
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "Sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "Sender: " + e.Source.ToString() + "\n\n";
        }
    }
}
