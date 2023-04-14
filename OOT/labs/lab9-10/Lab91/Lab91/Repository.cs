using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab91.MainWindow;

namespace Lab91
{
    internal class BookRepository:IRepository<Book>
    {
        private ApplicationContext db;
        public BookRepository()
        {
            this.db = new ApplicationContext();
        }
        public List<Book> GetItems()
        {
            return db.Books.ToList();
        }
        public Book GetItem(int id)
        {
            return db.Books.Find(id);
        }
        public void Delete(int index)
        {
            Book book = db.Books.Find(index);
            if (book != null)
            {
                db.Books.Remove(book);
            }
        }
        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Add(Book book)
        {
            db.Books.Add(book);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disponsed = false;
        public virtual void Disponse(bool disposing)
        {
            if (!this.disponsed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disponsed = true;
        }
        public void Dispose()
        {
            Disponse(true);
            GC.SuppressFinalize(this);
        }
    }
}
