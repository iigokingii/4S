using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab91.MainWindow;

namespace Lab91
{
    internal interface IRepository<T>:IDisposable
        where T : class
    {
        List<T> GetItems();
        T GetItem(int id);
        public void Add(T book);
        void Update(T item);
        void Delete(int index);
        void Save();
    }
}
