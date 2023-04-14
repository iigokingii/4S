using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab91.MainWindow;

namespace Lab91
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int LibraryID { get; set; }
        public Library? Library { get; set; }
    }
}
