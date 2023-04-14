using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab91.MainWindow;
using static Lab91.BookRepository;
using static Lab91.LibRepository;
namespace Lab91
{
    internal class UnitOfWork:IDisposable
    {
        private ApplicationContext db = new ApplicationContext();
        private BookRepository bookRepo;
        private LibRepository libRepo;
        public BookRepository Books
        {
            get
            {
                if(bookRepo == null)
                    bookRepo = new BookRepository(); 
                return bookRepo;
            }
        }
        public LibRepository Libs
        {
            get
            {
                if (libRepo == null)
                    libRepo = new LibRepository();
                return libRepo;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
