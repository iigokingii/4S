using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab91.MainWindow;
namespace Lab91
{
    internal class LibRepository:IRepository<Library>
    {
        private ApplicationContext db;
        public LibRepository()
        {
            this.db = new ApplicationContext();
        }
        public List<Library> GetItems()
        {
            return db.Libraries.ToList();
        }
        public Library GetItem(int id)
        {
            return db.Libraries.Find(id);
        }
        public void Delete(int index)
        {
            Library lib = db.Libraries.Find(index);
            if (lib != null)
            {
                db.Libraries.Remove(lib);
            }
        }
        public void Update(Library item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Add(Library lib)
        {
            db.Libraries.Add(lib);
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
