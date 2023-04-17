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
using Brushes = System.Drawing.Brushes;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public class Validation : IDataErrorInfo
        {
            public string Kitch { get;set; }
            public string this[string ColumnName]
            {
                get
                {
                    string pattern = "([a-z])+|([а-я])+|([A-Z])+|([А-Я])+";
                    Regex regex = new Regex(pattern);
                    string err = string.Empty;
                    switch (ColumnName)
                    {
                        case "Kitch":
                            {
                                if (!Regex.IsMatch(Kitch, pattern))
                                    err = "Неверный ввод";
                                break;
                            }
                    }
                    return err;
                }
            }
            public string Error
            {
                get { throw new NotImplementedException(); }
            }


        }



        SqlConnectionStringBuilder sqlConnection;
        SqlConnection connection;
        ObservableCollection<String> Result;
        static int id = 0;
        public AddItem()
        {

            InitializeComponent();
            this.DataContext = this;
            
            //для дат
            DateTime start = DateTime.Now;
            DateTime end = DateTime.MaxValue;
            CalendarDateRange range = new CalendarDateRange(start, end);
            data.BlackoutDates.Add(range);
            //
            
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            //Data Source=GOKING;Initial Catalog=lab8OOT;Integrated Security=True
            connectionStringBuilder.DataSource = "GOKING";
            connectionStringBuilder.InitialCatalog = "lab8OOT";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.UserID = "admin";
            connectionStringBuilder.Password = "admin";
            sqlConnection = connectionStringBuilder;
            Result=new ObservableCollection<String>();
            Result.Add("Window started");
            TestRes.ItemsSource = Result;
            try
            {
                connection = new SqlConnection(connectionStringBuilder.ConnectionString);
                Result.Add("Connection opened");
                connection.Open();

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
                }
                MessageBox.Show(errorMessage);
            }
            finally
            {
                connection.Close();
                    UpdateDate();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public BitmapImage image { get; set; }
        public Bitmap ing { get; set; }
        public string photoPath = "";
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
                    test_Img.Source = image;

                    photoPath = openFileDialog.FileName;

                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            val.Content = "Choosen number:" + ((int)sl.Value);
        }

        private void AddDef_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                
                connection.Open();
                id++;
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand transCommand = connection.CreateCommand();
                transCommand.Transaction = transaction;
                
                try
                {
                    Country.Text = "BELARUS";
                    City.Text = "VILEYKA";
                    Distrinct.Text = "ZENIT";
                    Street.Text = "NEZALEJNOSTY";
                    House.Text = "14";
                    NumOfFl.Text = "64";
                    Building.Text = "2";
                    sl2.Value = 31;
                    val2.Content = "Choosen square:" + sl2.Value;
                    sl.Value = 4;
                    val.Content = "Choosen number:" + sl.Value;
                    kitch.Text = "ЕСТЬ";
                    bath.Text = "ЕСТЬ";
                    toil.Text = "ЕСТЬ";
                    Balc.Text = "ЕСТЬ";
                    Base.Text = "ЕСТЬ";
                    data.Text = "2022-01-22";
                    type.Text = "КВАРЦ";
                    Floor.Text = "5";

                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri("D:\\2k2s\\OOT\\labs\\images\\4-5\\foouter\\qwe.jpg", UriKind.RelativeOrAbsolute);
                    image.EndInit();

                    // Замораживаем изображение
                    image.Freeze();
                    test_Img.Source=image;

                    transCommand.CommandText = "SELECT COUNT(*) FROM ADRESS";
                    int id = (int)transCommand.ExecuteScalar();
                    ID.Text = id.ToString();
                    id++;

                    transCommand.CommandText = "INSERT INTO ADRESS(ADRESS_ID,COUNTRY,CITY,DISTRINCT,STREET,HOUSE,NUMBER_OF_FLAT,BUILDING)" +
                                               "VALUES (@ID,'BELARUS','VILEYKA','ZENIT','NEZALEJNOSTY','14',64,'2')";
                    transCommand.Parameters.Add("@ID", SqlDbType.Int, sizeof(Int32));
                    transCommand.Parameters["@ID"].Value = id;
                    transCommand.ExecuteNonQuery();

                    transCommand.CommandText = "INSERT INTO FLAT(FLAT_ID,SQUARE_FOOTAGE,NUMBER_OF_ROOMS,KITCHEN,BATH,TOILET,BALCONY,BASEMENT,YEAR_OF_CONSTRUCTION,TYPE_OF_MATERIAL,FLAT_IMAGE,FLOOR,ADRESS_ID)" +
                                               "VALUES (@ID,31,4,'ЕСТЬ','ЕСТЬ','ЕСТЬ','ЕСТЬ','ЕСТЬ','2022-01-22','КВАРЦ',@IMG,5,@ID)";
                    
                    byte[] imageData;
                    photoPath = "D:\\2k2s\\OOT\\labs\\images\\4-5\\foouter\\qwe.jpg";
                    using (FileStream fs = new FileStream(photoPath, FileMode.Open))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                        transCommand.Parameters.Add("@IMG", SqlDbType.Image, Convert.ToInt32(fs.Length));
                    }
                    transCommand.Parameters["@IMG"].Value = imageData;
                    transCommand.ExecuteNonQuery();


                    transaction.Commit();
                    UpdateDate();
                    Result.Add("Commit");
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Result.Add("Rollback");
                    Result.Add(ex.Message);
                }
            }
        }
        private void UpdateDate()
        {
            String sql = "SELECT* FROM ADRESS INNER JOIN FLAT ON ADRESS.ADRESS_ID=FLAT.ADRESS_ID";
            using (SqlConnection con = new SqlConnection(sqlConnection.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                ItemsGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
        }

        private void sl2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            val2.Content = "Choosen square:" + sl2.Value;
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            but.IsEnabled = true;
            Change.IsEnabled = true;
            Delete.IsEnabled = true;
            ID.IsReadOnly = false;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            but.IsEnabled = false;
            ID.IsReadOnly = true;
            Change.IsEnabled = false;
            Delete.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(ID.Text, out id))
            {
                ID.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                ID.Background = new SolidColorBrush(Colors.White);
                using (SqlConnection con = new SqlConnection(sqlConnection.ConnectionString))
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    SqlTransaction transaction = con.BeginTransaction();
                    try
                    {
                        command.Transaction = transaction;
                        command.CommandText = "SELECT * FROM FLAT " +
                                                "INNER JOIN ADRESS " +
                                                "ON FLAT.ADRESS_ID=ADRESS.ADRESS_ID " +
                                                "WHERE FLAT.FLAT_ID=@ID";
                        command.Parameters.Add("@ID", SqlDbType.Int, sizeof(Int32));
                        command.Parameters["@ID"].Value = id;
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var square = reader.GetValue(1);

                                var numroom = reader.GetValue(2);
                                var kitchen = reader.GetValue(3);
                                var bath1 = reader.GetValue(4);
                                var toilet1 = reader.GetValue(5);
                                var balcony1 = reader.GetValue(6);
                                var basement1 = reader.GetValue(7);
                                var year = reader.GetValue(8);
                                var type1 = reader.GetValue(9);
                                var image = reader.GetValue(10);
                                var floor = reader.GetValue(11);
                                var country = reader.GetValue(14);
                                var city = reader.GetValue(15);
                                var distr = reader.GetValue(16);
                                var street = reader.GetValue(17);
                                var house = reader.GetValue(18);
                                var numbofFlat = reader.GetValue(19);
                                var building = reader.GetValue(20);
                                Country.Text = country.ToString();
                                City.Text = city.ToString();
                                Distrinct.Text = distr.ToString();
                                Street.Text = street.ToString();
                                House.Text = house.ToString();
                                NumOfFl.Text = numbofFlat.ToString();
                                Building.Text = building.ToString();
                                kitch.Text = kitchen.ToString();
                                bath.Text = bath1.ToString();
                                toil.Text = toilet1.ToString();
                                Balc.Text = balcony1.ToString();
                                Base.Text = basement1.ToString();
                                data.Text = year.ToString();
                                type.Text = type1.ToString();
                                Floor.Text = floor.ToString();
                                string t;
                                t = numroom.ToString();
                                sl.Value = double.Parse(t);
                                val.Content = "Choosen number:" + sl.Value;
                                t = square.ToString();
                                sl2.Value = double.Parse(t);
                                val2.Content = "Choosen square:" + sl2.Value;
                                t = image.ToString();
                                // byte[]->img
                                byte[] d = (byte[])image;
                                MemoryStream stream = new MemoryStream(d);
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.EndInit();
                                test_Img.Source = bitmap;
                            }
                            reader.Close();
                        }
                        transaction.Commit();
                        UpdateDate();
                        Result.Add("Commit");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Result.Add("Rollback");
                        Result.Add(ex.Message);
                    }
                }
            }
        }
        private int CheckValid()
        {
            int id,floor;
            //string pattern = "([a-z])+|([а-я])+|([A-Z])+|([А-Я])+";
            string pattern = "^[а-яА-Я ]*$";
            if (!int.TryParse(ID.Text, out id))
            {
                ID.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                ID.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(kitch.Text, pattern))
            {
                kitch.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                kitch.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(bath.Text, pattern))
            {
                bath.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                bath.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(toil.Text, pattern))
            {
                toil.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                toil.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Balc.Text, pattern))
            {
                Balc.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Balc.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Base.Text, pattern))
            {
                Base.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Base.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(type.Text, pattern))
            {
                type.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                type.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(bath.Text, pattern))
            {
                bath.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                bath.Background = new SolidColorBrush(Colors.White);
            }
            if (!int.TryParse(Floor.Text,out floor))
            {
                Floor.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Floor.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Country.Text, pattern))
            {
                Country.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Country.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(City.Text, pattern))
            {
                City.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                City.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Distrinct.Text, pattern))
            {
                Distrinct.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Distrinct.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Street.Text, pattern))
            {
                Street.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Street.Background = new SolidColorBrush(Colors.White);
            }
            if (!Regex.IsMatch(Country.Text, pattern))
            {
                Country.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Country.Background = new SolidColorBrush(Colors.White);
            }
            int house;
            if (!int.TryParse(House.Text,out house))
            {
                House.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                House.Background = new SolidColorBrush(Colors.White);
            }
            int numbOfFlt;
            if (!int.TryParse(NumOfFl.Text, out numbOfFlt))
            {
                NumOfFl.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                NumOfFl.Background = new SolidColorBrush(Colors.White);
            }
            int build;
            if (!int.TryParse(Building.Text, out build))
            {
                Building.Background = new SolidColorBrush(Colors.Red);
                return -1;
            }
            else
            {
                Building.Background = new SolidColorBrush(Colors.White);
            }
            return 1;
        }


        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValid() == 1)
            {
                int id = int.Parse(ID.Text);
                using (SqlConnection con = new SqlConnection(sqlConnection.ConnectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();
                    SqlCommand command = con.CreateCommand();
                    command.Transaction = transaction;
                    try
                    {
                        command.CommandText = "DELETE FROM FLAT WHERE FLAT.ADRESS_ID=@ID;";
                        command.Parameters.Add("@ID", SqlDbType.Int, sizeof(Int32));
                        command.Parameters["@ID"].Value = id;
                        command.ExecuteNonQuery();

                        command.CommandText = "DELETE FROM ADRESS WHERE ADRESS.ADRESS_ID=@ID;";
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO ADRESS(ADRESS_ID,COUNTRY,CITY,DISTRINCT,STREET,HOUSE,NUMBER_OF_FLAT,BUILDING)" +
                                                   "VALUES (@ID,@country,@city,@distr,@street,@house,@numbOfFla,@building)";

                        command.Parameters.Add("@country", SqlDbType.NVarChar, Convert.ToInt32(Country.Text.Length));
                        command.Parameters.Add("@city", SqlDbType.NVarChar, Convert.ToInt32(City.Text.Length));
                        command.Parameters.Add("@distr", SqlDbType.NVarChar, Convert.ToInt32(Distrinct.Text.Length));
                        command.Parameters.Add("@street", SqlDbType.NVarChar, Convert.ToInt32(Street.Text.Length));
                        command.Parameters.Add("@house", SqlDbType.NVarChar, Convert.ToInt32(House.Text.Length));
                        command.Parameters.Add("@numbOfFla", SqlDbType.NVarChar, Convert.ToInt32(NumOfFl.Text.Length));
                        command.Parameters.Add("@building", SqlDbType.NVarChar, Convert.ToInt32(Building.Text.Length));

                        command.Parameters["@country"].Value = Country.Text;
                        command.Parameters["@city"].Value = City.Text;
                        command.Parameters["@distr"].Value = Distrinct.Text;
                        command.Parameters["@street"].Value = Street.Text;
                        command.Parameters["@house"].Value = House.Text;
                        command.Parameters["@numbOfFla"].Value = NumOfFl.Text;
                        command.Parameters["@building"].Value = Building.Text;

                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO FLAT(FLAT_ID,SQUARE_FOOTAGE,NUMBER_OF_ROOMS,KITCHEN,BATH,TOILET,BALCONY,BASEMENT,YEAR_OF_CONSTRUCTION,TYPE_OF_MATERIAL,FLAT_IMAGE,FLOOR,ADRESS_ID)" +
                                                   "VALUES (@ID,@square,@numberRom,@k,@b,@t,@balc,@basem,@constYear,@type,@IMG,@floor,@ID)";

                        command.Parameters.Add("@square", SqlDbType.Real, sizeof(double));
                        command.Parameters.Add("@numberRom", SqlDbType.Int, sizeof(int));
                        command.Parameters.Add("@k", SqlDbType.NVarChar, Convert.ToInt32(kitch.Text.Length));
                        command.Parameters.Add("@b", SqlDbType.NVarChar, Convert.ToInt32(bath.Text.Length));
                        command.Parameters.Add("@t", SqlDbType.NVarChar, Convert.ToInt32(toil.Text.Length));
                        command.Parameters.Add("@balc", SqlDbType.NVarChar, Convert.ToInt32(Balc.Text.Length));
                        command.Parameters.Add("@basem", SqlDbType.NVarChar, Convert.ToInt32(Base.Text.Length));
                        command.Parameters.Add("@constYear", SqlDbType.Date);
                        command.Parameters.Add("@type", SqlDbType.NVarChar, Convert.ToInt32(type.Text.Length));
                        byte[] imageData;
                        if (photoPath != "")
                        {
                            using (FileStream fs = new FileStream(photoPath, FileMode.Open))
                            {
                                imageData = new byte[fs.Length];
                                fs.Read(imageData, 0, imageData.Length);
                                command.Parameters.Add("@IMG", SqlDbType.Image, Convert.ToInt32(fs.Length));
                            }
                        }
                        else
                        {

                            photoPath = "D:\\2k2s\\OOT\\labs\\images\\4-5\\foouter\\qwe.jpg";
                            using (FileStream fs = new FileStream(photoPath, FileMode.Open))
                            {
                                imageData = new byte[fs.Length];
                                fs.Read(imageData, 0, imageData.Length);
                                command.Parameters.Add("@IMG", SqlDbType.Image, Convert.ToInt32(fs.Length));
                            }
                            command.Parameters["@IMG"].Value = imageData;
                        }

                        command.Parameters.Add("@floor", SqlDbType.Int, sizeof(Int32));

                        command.Parameters["@square"].Value = sl2.Value;
                        command.Parameters["@numberRom"].Value = sl.Value;
                        command.Parameters["@k"].Value = kitch.Text;
                        command.Parameters["@b"].Value = bath.Text;
                        command.Parameters["@t"].Value = toil.Text;
                        command.Parameters["@balc"].Value = Balc.Text;
                        command.Parameters["@basem"].Value = Base.Text;
                        command.Parameters["@constYear"].Value = data.SelectedDate;
                        command.Parameters["@type"].Value = type.Text;
                        command.Parameters["@floor"].Value = int.Parse(Floor.Text);
                        command.Parameters["@IMG"].Value = imageData;

                        command.ExecuteNonQuery();

                        transaction.Commit();
                        UpdateDate();
                        Result.Add("Commit");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Result.Add("Rollback");
                        Result.Add(ex.Message);
                    }
                }
            }

            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        { 
            int id;
            if (!int.TryParse(ID.Text, out id))
            {
                ID.Background = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                ID.Background = new SolidColorBrush(Colors.White);
            }
            using (SqlConnection con = new SqlConnection(sqlConnection.ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                SqlCommand command = con.CreateCommand();
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "DELETE FROM FLAT WHERE FLAT.ADRESS_ID=@ID;";
                    command.Parameters.Add("@ID", SqlDbType.Int, sizeof(Int32));
                    command.Parameters["@ID"].Value = id;
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM ADRESS WHERE ADRESS.ADRESS_ID=@ID;";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    UpdateDate();
                    Result.Add("Commit");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Result.Add("Rollback");
                    Result.Add(ex.Message);
                }
            }
        }

     /*   private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validation val = new Validation();
            val.Kitch = kitch.Text;
            this.DataContext = val;
        }*/

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
