using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Lab91.MainWindow;

namespace Lab91
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
       
        private void LibAdd_Click(object sender, RoutedEventArgs e)
        {
            string patternForAdress = "^((у|У)л|(п|П)р). *([а-яА-Я])+ +([0-9])+ *, *(([а-яА-Я])+)$";
            if (!Regex.IsMatch(LibraryAdress.Text, patternForAdress))
            {
                LibraryAdress.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                LibraryAdress.Background = new SolidColorBrush(Colors.White);
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                Library lib = new Library { Adress = LibraryAdress.Text };
                db.Libraries.Add(lib);
                db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены в бд", "saver", MessageBoxButton.OK);
            }
        }

        private void BookAdd_Click(object sender, RoutedEventArgs e)
        {
            string patternForString = "^[а-яА-Я ]+$";
            if (!Regex.IsMatch(BookName.Text, patternForString))
            {
                BookName.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                BookName.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(AuthorName.Text, patternForString))
            {
                AuthorName.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                AuthorName.Background = new SolidColorBrush(Colors.White);
            }
            int id;
            if (!int.TryParse(BookLibrary.Text, out id))
            {
                BookLibrary.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
                BookLibrary.Background = new SolidColorBrush(Colors.White);

            using (ApplicationContext db = new ApplicationContext())
            {
                Library? l = db.Libraries.FirstOrDefault(t => t.Id == id);
                if (l == null)
                {
                    BookLibrary.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    BookLibrary.Background = new SolidColorBrush(Colors.White);
                    Book book = new Book { Author = AuthorName.Text, Name = BookName.Text, Library = l };
                    db.Books.Add(book);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены в бд", "saver", MessageBoxButton.OK);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
