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
       
        public ObservableCollection<MedCenterViewModel> medCenterList { get; set; }
        #region Constructor

        public MainViewModel(List<MedCenter> BDList)
        {
            medCenterList = new ObservableCollection<MedCenterViewModel>(BDList.Select(b => new MedCenterViewModel(b)));
        }

        #endregion*

    }
}
