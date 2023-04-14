using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
//entity framework
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lab91
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOfWork unit;
        StreamWriter sw = new StreamWriter("config.txt", false);
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            unit = new UnitOfWork();
            Update();
        }
        private void Update()
        {
            Libraries.ItemsSource = unit.Libs.GetItems();
            Books.ItemsSource = unit.Books.GetItems();
        }

        private void default_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Library lib = new Library { Adress = "пр. Независимости 116, Минск" };
                unit.Libs.Add(lib);
                Book book1 = new Book { Author = "Анджей Сапковский", Name = "Ведьмак:Последнее желание", Library = lib };
                Book book2 = new Book { Author = "Анджей Сапковский", Name = "Ведьмак:Меч предназначения", Library = lib };
                unit.Books.Add(book1);
                unit.Books.Add(book2);
                unit.Books.Save();
                unit.Libs.Save();
                unit.Save();
            }
            catch(Exception ex)
            {
                /*MessageBox.Show(ex.Message);*/
            }
            finally
            {
                Update();
            }
        }
        private void Add_Click(object sender,RoutedEventArgs e)
        {
            Add add = new Add();
            bool ?close =add.ShowDialog();
            if(close.HasValue && close.Value)
            {
                Update();
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            LibraryID.Background =new SolidColorBrush(Colors.White);
            BookID.Background = new SolidColorBrush(Colors.White);
            int idLib;
            int idBook;
            if (LibraryID.Text!=""&& BookID.Text != "")
            {
                if (!int.TryParse(LibraryID.Text, out idLib))
                {
                    LibraryID.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    LibraryID.Background = new SolidColorBrush(Colors.White);
                }
                if (!int.TryParse(BookID.Text, out idBook))
                {
                    BookID.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    BookID.Background = new SolidColorBrush(Colors.White);
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    Book? book = db.Books.FirstOrDefault(t=>t.LibraryID==idLib && t.Id==idBook);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                    }
                    Update();
                }
            }
            else if (LibraryID.Text != "")
            {
                if (!int.TryParse(LibraryID.Text, out idLib))
                {
                    LibraryID.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    LibraryID.Background = new SolidColorBrush(Colors.White);
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    var libraryToDel = db.Libraries.FirstOrDefault(t => t.Id == idLib);
                    if (libraryToDel != null)
                    {
                        var books = db.Books.Where(t => t.Id == libraryToDel.Id).ToList();
                        db.Books.RemoveRange(books);
                        db.Libraries.Remove(libraryToDel);
                        db.SaveChanges();
                    }       
                }
                Update();
            }
            else if (BookID.Text != "")
            {
                if (!int.TryParse(BookID.Text, out idBook))
                {
                    BookID.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    BookID.Background = new SolidColorBrush(Colors.White);
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    var book = db.Books.FirstOrDefault(t => t.Id == idBook);
                    if (book != null)
                    {
                        db.Books.Remove(book);
                        db.SaveChanges();
                    }    
                }
                Update();
            }
            else
            {
                LibraryID.Background = new SolidColorBrush(Colors.Red);
                BookID.Background = new SolidColorBrush(Colors.Red );
            }
        }

        private void Editing_Click(object sender, RoutedEventArgs e)
        {
            Editing edit = new Editing();
            bool?response=edit.ShowDialog();
            if(response.HasValue && response.Value)
            {
                Update();
            }
        }

        private void SortBylibID_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Libs.GetItems().OrderByDescending(t => t.Id).ToList();
                Libraries.ItemsSource = tempdb;
            }
        }

        private void SortByAdress_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Libs.GetItems().OrderByDescending(t => t.Adress).ToList();
                Libraries.ItemsSource = tempdb;
            }
        }

        private void SortByBookID_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Books.GetItems().OrderByDescending(t => t.Id).ToList();
                Books.ItemsSource = tempdb;
            }
        }

        private void SortByBookName_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Books.GetItems().OrderByDescending(t => t.Name).ToList();
                Books.ItemsSource = tempdb;
            }
        }

        private void SortByAuthor_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Books.GetItems().OrderByDescending(t => t.Author).ToList();
                Books.ItemsSource = tempdb;
            }
        }

        private void SortByLibIDInBook_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var tempdb = unit.Books.GetItems().OrderByDescending(t => t.LibraryID).ToList();
                Books.ItemsSource = tempdb;
            }
        }

        private void ToDef_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Books.ItemsSource = unit.Books.GetItems();
                Libraries.ItemsSource = unit.Libs.GetItems();
            }
        }
        string Result { get; set; }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Res.Text = "";
            int Libid;
            SearchLibId.Background = new SolidColorBrush(Colors.White);
            SearchBookName.Background = new SolidColorBrush(Colors.White);
            if (SearchLibId.Text!=""&& SearchBookName.Text != "")
            {
                if (!int.TryParse(SearchLibId.Text, out Libid))
                {
                    SearchLibId.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    SearchLibId.Background = new SolidColorBrush(Colors.White);
                }
                using(ApplicationContext db = new ApplicationContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        string command = "SELECT * FROM Books\r\n\tWHERE NAME LIKE @name\r\n\t\tAND LibraryID=@ID";
                           string searchStr = "%" + SearchBookName.Text + "%";
                        try
                        {
                            SqlParameter param = new SqlParameter("@name", searchStr);
                            SqlParameter id = new SqlParameter("@ID", Libid);
                            var t = db.Books.FromSqlRaw(command,param,id).ToList();
                            foreach(Book b in t)
                            {
                                Res.Text += b.Id + " " + b.Name + " " + b.Author + " " + b.LibraryID+"; ";
                            }
                        }
                        catch(Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else if (SearchLibId.Text != "")
            {
                if (!int.TryParse(SearchLibId.Text, out Libid))
                {
                    SearchLibId.Background = new SolidColorBrush(Colors.Red);
                    return;
                }
                else
                {
                    SearchLibId.Background = new SolidColorBrush(Colors.White);
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        string command = "SELECT * FROM Books\r\n\tWHERE LibraryID=@ID";
                        
                        try
                        {
                            SqlParameter param = new SqlParameter("@ID", Libid);
                            var t = db.Books.FromSqlRaw(command, param).ToList();
                            foreach (Book b in t)
                            {
                                Res.Text += b.Id + " " + b.Name + " " + b.Author + " " + b.LibraryID + "; ";
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else if (SearchBookName.Text != "")
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        string command = "SELECT * FROM Books\r\n\tWHERE NAME LIKE @name";
                        string searchStr = "%" + SearchBookName.Text + "%";
                        try
                        {
                            SqlParameter param = new SqlParameter("@name", searchStr);
                            var t = db.Books.FromSqlRaw(command, param).ToList();
                            foreach (Book b in t)
                            {
                                Res.Text += b.Id + " " + b.Name + " " + b.Author + " " + b.LibraryID + "; ";
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                SearchLibId.Background = new SolidColorBrush(Colors.Red);
                SearchBookName.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
