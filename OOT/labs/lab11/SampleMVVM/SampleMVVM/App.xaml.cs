using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            /* List<Book> books = new List<Book>()
             {
                 new Book("Пттерны проетирования", "John Gossman", 3),
                 new Book("CLR via C#", "Джеффри Рихтер", 2),
                 new Book("Исскуство программирования", "Кнут", 2)
             };*/
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "GOKING";
            connectionStringBuilder.InitialCatalog = "lab11OOT";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.UserID = "admin";
            connectionStringBuilder.Password = "admin";
            ObservableCollection<MedCenter> medCenter = new ObservableCollection<MedCenter>(); ;
            using (SqlConnection con = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT * FROM MedCenter";
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string Name = reader.GetValue(0).ToString();
                                string Department = reader.GetValue(1).ToString();
                                string Category = reader.GetValue(2).ToString();
                                string Specialization = reader.GetValue(3).ToString();
                                int Count = int.Parse(reader.GetValue(4).ToString());
                                MedCenter med = new MedCenter(Name, Department, Category, Specialization, Count);
                                medCenter.Add(med);
                            }
                        }
                        reader.Close();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        throw;
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                }

            }

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(medCenter.ToList()); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
