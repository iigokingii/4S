using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleMVVM.Models
{
    class MedCenter
    {
        /*public string Title { get; set; }
        public string Author { get; set; }
        public int Count { get; set; }

        public Book(string title, string author, int count)
        {
            this.Title = title;
            this.Author = author;
            this.Count = count;
        }*/
        public string name;
        public string department;
        public string category;
        public string specialization;
        public int count = 0;
        public MedCenter(string Name, string Department, string Category, string Specialization, int Count)
        {
            this.name = Name;
            this.category = Category;
            this.department = Department;
            this.specialization = Specialization;
            this.count = Count;
        }


    }
}
