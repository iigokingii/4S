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
using System.Windows.Shapes;

namespace labs
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public string nam;
        public AddItem()
        {
            InitializeComponent();
            this.Cursor = Cursors.Pen;
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            name.Background = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numb;
                ImageSource t = UsCont.image;
                if (int.TryParse(number.Text, out numb))
                {
                    if (name.Text != "" && type.Text != "" && rating.Text != "" && color.Text != "" && t.ToString() != "")
                    {
                        MainWindow._Name = name.Text;
                        MainWindow._Type = type.Text;
                        MainWindow._Rating = rating.Text;
                        MainWindow._Color = color.Text;
                        MainWindow._Number = numb.ToString();
                        MainWindow._ImagePath = t.ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля верно!");
                }
            }
            catch(Exception eop)
            {
                MessageBox.Show(eop.Message);
            }

            
        }
    }
}
