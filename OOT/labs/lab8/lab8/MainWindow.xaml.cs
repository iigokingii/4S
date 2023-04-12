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
//для sql
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Interop;
using System.Data.Common;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnectionStringBuilder sqlConnection;
        ObservableCollection<String> Result;
        SqlConnection connection;
        StreamWriter fs;
        public MainWindow()
        {

            InitializeComponent();
            fs = new StreamWriter("App.config",false);
            Result = new ObservableCollection<string>();
            /*TestRes.ItemsSource = Result;*/
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            //Data Source=GOKING;Initial Catalog=lab8OOT;Integrated Security=True
            connectionStringBuilder.DataSource = "GOKING";
            connectionStringBuilder.InitialCatalog = "lab8OOT";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.UserID = "admin";
            connectionStringBuilder.Password = "admin";
            sqlConnection = connectionStringBuilder;
            connection = new SqlConnection(connectionStringBuilder.ConnectionString);
            try
            {
                connection.Open();
                fs.WriteLine("connection string:" + connectionStringBuilder.ConnectionString);
                fs.WriteLine("Connection opened");
            }
            catch (SqlException SE)
            {
                string errorMessage = "";
                foreach (SqlError err in SE.Errors)
                {
                    errorMessage += err.Message + " (error: " + err.Number.ToString() + ")";
                    if (err.Number == 18452)
                    {
                        MessageBox.Show("Invalid login");
                    }
                    if (err.Number == 4060)
                    {
                        CreateDB();
                    }
                }
            }
            

        }
        private void CreateDB()
        {
            sqlConnection.InitialCatalog = "master";
            using (SqlConnection con = new SqlConnection(sqlConnection.ConnectionString))
            {
                con.Open();
                SqlCommand sql = con.CreateCommand();
                sql.CommandText="CREATE DATABASE lab8OOT";
                sql.ExecuteNonQuery();
                SqlTransaction transaction = con.BeginTransaction();
                SqlCommand command = con.CreateCommand();
                try
                {
                    command.Transaction = transaction;
                    command.CommandText = "USE lab8OOT\r\nCREATE TABLE ADRESS\r\n(\r\n\tADRESS_ID INT PRIMARY KEY,\r\n\tCOUNTRY NVARCHAR(50),\r\n\tCITY NVARCHAR(50),\r\n\tDISTRINCT NVARCHAR(50),\r\n\tSTREET NVARCHAR(50),\r\n\tHOUSE NVARCHAR(50),\r\n\tNUMBER_OF_FLAT NVARCHAR(50),\r\n\tBUILDING NVARCHAR(50)\r\n)\r\nCREATE TABLE FLAT\r\n(\r\n\tFLAT_ID INT PRIMARY KEY,\r\n\tSQUARE_FOOTAGE REAL,\r\n\tNUMBER_OF_ROOMS INT,\r\n\tKITCHEN NVARCHAR(50),\r\n\tBATH NVARCHAR(50),\r\n\tTOILET NVARCHAR(50),\r\n\tBALCONY NVARCHAR(50),\r\n\tBASEMENT NVARCHAR(50),\r\n\tYEAR_OF_CONSTRUCTION DATE,\r\n\tTYPE_OF_MATERIAL NVARCHAR(50),\r\n\tFLAT_IMAGE IMAGE,\r\n\tFLOOR INT,\r\n\tADRESS_ID INT foreign KEY REFERENCES ADRESS(ADRESS_ID)\r\n)";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.ToString(), "BuildingBD", MessageBoxButton.OK);
                }


            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem();
            add.Show();
            fs.WriteLine("Add item menu opened");
        }
        public BitmapImage image { get; set; }
        public Bitmap ing { get; set; }
        public string photoPath { get; set; }
        private void imgPicture_Change(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                    image.EndInit();
                    
                    // Замораживаем изображение
                    image.Freeze();

                    // Устанавливаем изображение в качестве источника для элемента Image
                    //test_Img.Source = image;

                    photoPath = openFileDialog.FileName;

                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Connection closed", "Exit", MessageBoxButton.OK);
            connection.Close();
            this.Close();
            fs.WriteLine("Connection closed");
            fs.Close();

        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Sorting sorting = new Sorting();
            sorting.Show();
            fs.WriteLine("Sort window opened");
        }
    }
}
