using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для Sorting.xaml
    /// </summary>
    public partial class Sorting : Window
    {
        SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        DataView dataView = null;
        public Sorting()
        {
            InitializeComponent();
            //Data Source=GOKING;Initial Catalog=lab8OOT;Integrated Security=True
            connectionStringBuilder.DataSource = "GOKING";
            connectionStringBuilder.InitialCatalog = "lab8OOT";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.UserID = "admin";
            connectionStringBuilder.Password = "admin";
            //CreateProc();
            UpdateDate();
        }

        private void CreateProc()
        {
            string proc = @"
                            CREATE PROC [DBO].[UPDATE]
                                AS
                            begin
                            SELECT* FROM ADRESS INNER JOIN FLAT ON ADRESS.ADRESS_ID=FLAT.ADRESS_ID
                            end
                            ";
            using (SqlConnection con = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.ExecuteNonQuery();
            }
        }

        private void UpdateDate()
        {
            String sql = "SELECT* FROM ADRESS INNER JOIN FLAT ON ADRESS.ADRESS_ID=FLAT.ADRESS_ID";
            using (SqlConnection con = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                ItemsGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                dataView = dataSet.Tables[0].DefaultView;
            }
        }
        private void SortBy(object criterion)
        {
            using (SqlConnection con = new SqlConnection(connectionStringBuilder.ConnectionString))
            {
                con.Open();
                String STR = "SELECT* FROM ADRESS INNER JOIN FLAT ON ADRESS.ADRESS_ID=FLAT.ADRESS_ID ORDER BY "+criterion+" DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(STR, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                ItemsGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
        }
        private void square_Click(object sender, RoutedEventArgs e)
        {
            SortBy("SQUARE_FOOTAGE");
        }

        private void numberRoom_Click(object sender, RoutedEventArgs e)
        {
            SortBy("NUMBER_OF_ROOMS");
        }

        private void floor_Click(object sender, RoutedEventArgs e)
        {
            SortBy("FLOOR");
        }

        private void Distri_Click(object sender, RoutedEventArgs e)
        {
            SortBy("DISTRINCT");
        }

        private void numbFlat_Click(object sender, RoutedEventArgs e)
        {
            SortBy("NUMBER_OF_FLAT");
        }
    }
}
