using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;
using System.Windows;
using System.Xml.Linq;

namespace SampleMVVM.ViewModels
{
    class MedCenterViewModel : ViewModelBase
    {
        public MedCenter medCenter;

        public MedCenterViewModel(MedCenter med)
        {
            this.medCenter = med;
        }
        public string Name
        {
            get { return medCenter.name; }
            set
            {
                medCenter.name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Department
        {
            get { return medCenter.department; }
            set
            {
                medCenter.department = value;
                OnPropertyChanged("Department");
            }
        }
        public string Category
        {
            get { return medCenter.category; }
            set
            {
                medCenter.category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Specialization
        {
            get { return medCenter.specialization; }
            set
            {
                medCenter.specialization = value;
                OnPropertyChanged("Specialization");
            }
        }
        public int Count
        {
            get { return medCenter.count; }
            set
            {
                medCenter.count = value;
                OnPropertyChanged("Count");
            }
        }
        /*public string Title
        {
            get { return Book.Title; }
            set 
            {
                Book.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Author
        {
            get { return Book.Author; }
            set
            {
                Book.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public int Count
        {
            get { return Book.Count; }
            set
            {
                Book.Count = value;
                OnPropertyChanged("Count");
            }
        }*/
        #region Commands

        #region Забрать
        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
        }

        #endregion

        #region Выдать

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }

        #endregion

        #endregion
    }
}
