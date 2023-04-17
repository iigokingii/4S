using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class MedCenter : INotifyPropertyChanged
    {
        public string name;
        public string department;
        public string category;
        public string specialization;
        public int count=0;
        public MedCenter(string Name, string Department, string Category, string Specialization, int Count)
        {
            this.name = Name;
            this.category = Category;
            this.department = Department;
            this.specialization = Specialization;
            this.count = Count;
        }
        public MedCenter() { }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("Department");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Specialization
        {
            get { return specialization; }
            set
            {
                specialization = value;
                OnPropertyChanged("Specialization");
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
