using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

using SampleMVVM.Commands;
using System.Collections.ObjectModel;
using SampleMVVM.Models;
using SampleMVVM.Views;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        public ObservableCollection<MedCenterViewModel> _medCenterList { get; set; }
        List<MedCenter> Data;
        private string _FIO;

        public string FIO
        {
            get
            {
                return _FIO;
            }
            set
            {
                _FIO = value;
                OnPropertyChanged("FIO");
            }
        }
        public ObservableCollection<MedCenterViewModel> MedCenterList
        {
            get
            {
                return _medCenterList;
            }
            set
            {
                _medCenterList = value;
                OnPropertyChanged("MedCenterList");

            }
        }
        public MainViewModel()
        {

        }


        #region Constructor

        public MainViewModel(List<MedCenter> BDList)
        {
            MedCenterList = new ObservableCollection<MedCenterViewModel>(BDList.Select(b => new MedCenterViewModel(b)));
            Data = BDList;
            Search = new DelegateCommand(SearchByFIO);
        }

        private void SearchByFIO()
        {
            if (!_FIO.Equals(""))
                MedCenterList = new ObservableCollection<MedCenterViewModel>(Data.Where(p=>p.name == FIO).Select(b => new MedCenterViewModel(b)));
            else
            {
                MedCenterList = new ObservableCollection<MedCenterViewModel>(Data.Select(b => new MedCenterViewModel(b)));
            }
        }

        public ICommand Search { get; }


        #endregion*

    }
}
