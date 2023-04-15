using DAL.DB;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class BookRepo : IRepo<Book, int>
    {
        private readonly ApplicationDbContext db;
        public BookRepo(ApplicationDbContext dbcon)
        {
            db = dbcon;
        }

        public int Add(Book obj)
        {
            db.Books.Add(obj);
            db.SaveChanges();
            return obj.Id;
        }

        public bool Delete(int id)
        {
            var author = Get(id);
            if (author == null) return false;

            db.Entry(author).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        public List<Book> Get()
        {
           return db.Books.ToList();    
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public bool Update(Book obj)
        {
            var book = Get(obj.Id);
            db.Entry(book).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
