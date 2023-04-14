using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab91
{
    public class Library
    {
        public int Id { get; set; }
        public string? Adress { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
