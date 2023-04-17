using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace lab11
{
    internal class MedcenterModel : INotifyPropertyChanged
    {
        private MedCenter selectedMedCentr;
        public ObservableCollection<MedCenter> medcenters { get; set; }
        public MedCenter SelectedMedCentr
        {
            get { return selectedMedCentr; }
            set
            {
                selectedMedCentr = value;
                OnPropertyChanged("SelectedMedCentr");
            }
        }
        public MedcenterModel()
        {
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
            medcenters = medCenter;
        }
        

        private RelayCommand getTicket;
        public RelayCommand GetTicket
        {
            get
            {
                return getTicket ?? (getTicket = new RelayCommand(obj =>
                {
                    MedCenter med = new MedCenter();
                    medcenters.Add(med);
                    selectedMedCentr = med;

                    /*MedCenter med;
                    if (obj is MedCenter)
                    {
                        med = (MedCenter)obj;
                        med.Count--;
                    }*/

                }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

















        /*private RelayCommand getTicket;
        public RelayCommand GetTicket
        {
            get
            {
                return GetTicket ?? (getTicket = new RelayCommand(obj =>
                {
                    MedCenter? med = obj as MedCenter;
                    if (med != null)
                    {
                        med.Count--;
                    }
                }));
            }
        }













        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(MedcenterModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var curr = d as MedcenterModel;
            if (curr != null)
            {
                curr.Items.Filter = null;
                curr.Items.Filter = curr.Filter;
            }
        }



        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(MedcenterModel), new PropertyMetadata(null));

        public MedcenterModel()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "GOKING";
            connectionStringBuilder.InitialCatalog = "lab11OOT";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.UserID = "admin";
            connectionStringBuilder.Password = "admin";
            List<MedCenter> medCenter = new List<MedCenter>(); ;
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
            Items = CollectionViewSource.GetDefaultView(medCenter);
            Items.Filter = Filter;
        }
        private bool Filter(object o)
        {
            bool res = true;
            MedCenter medCenter = o as MedCenter;
            if (!string.IsNullOrWhiteSpace(FilterText) && medCenter != null && !medCenter.Name.Contains(FilterText))
            {
                res = false;
            }
            return res;
        }
    }*/
    }
}
