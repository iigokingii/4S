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
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public Editing()
        {
            InitializeComponent();
            Update();
        }
        private void Update()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var libraries = db.Libraries.ToList();
                Libraries.ItemsSource = libraries;
                var books = db.Books.ToList();
                Books.ItemsSource = books;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }

        private void insertDate_Click(object sender, RoutedEventArgs e)
        {
            int id;
            ID.Background = new SolidColorBrush(Colors.White);
            if (!int.TryParse(ID.Text, out id))
            {
                ID.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                Book books= db.Books.FirstOrDefault(t => t.Id == id);
                if (books != null)
                {
                    BookName.Text = books.Name;
                    BookAuthor.Text = books.Author;
                    int libId = books.LibraryID;
                    Library lib = db.Libraries.Where(t => t.Id == libId).First();
                    LibAddr.Text = lib.Adress;
                }
            }
        }
        private void UpdateDate_Click(object sender, RoutedEventArgs e)
        {
            int idl ;
            if (!int.TryParse(ID.Text, out idl))
            {
                ID.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                ID.Background = new SolidColorBrush(Colors.White);
            }
            string patternForAdress = "^((у|У)л|(п|П)р). *([а-яА-Я])+ +([0-9])+ *, *(([а-яА-Я])+)$";
            if (!Regex.IsMatch(LibAddr.Text, patternForAdress))
            {
                LibAddr.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                LibAddr.Background = new SolidColorBrush(Colors.White);
            }
            string patternForString = "^[а-я:А-Я ]+$";
            if (!Regex.IsMatch(BookName.Text, patternForString))
            {
                BookName.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                BookName.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(BookAuthor.Text, patternForString))
            {
                BookAuthor.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                BookAuthor.Background = new SolidColorBrush(Colors.White);
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                Book? book = db.Books.FirstOrDefault(t => t.Id == idl);
                if(book != null)
                {
                    Library lib = db.Libraries.FirstOrDefault(t => t.Id == book.LibraryID);
                    Book book1 = new Book { Author = BookAuthor.Text, Name = BookName.Text, Library = lib };
                    db.Books.Remove(book);
                    db.Books.Add(book1);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены в бд", "saver", MessageBoxButton.OK);
                    Update();
                }
            }
        }
    }
}
