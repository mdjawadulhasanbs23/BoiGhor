using DAL.DB;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class AuthorRepo: IRepo<Author, int>
    {
        private readonly ApplicationDbContext db;
        public AuthorRepo(ApplicationDbContext dbcon)
        {
            db = dbcon;
        }

        public int Add(Author obj)
        {
            db.Authors.Add(obj);
            db.SaveChanges();
            return obj.Id;
        }

        public bool Delete(int id)
        {
            var author = Get(id);
            db.Authors.Remove(author);
            return db.SaveChanges() > 0;
        }

        public List<Author> Get()
        {
            return db.Authors.ToList();
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public bool Update(Author obj)
        {
            var author = Get(obj.Id);
            db.Entry(author).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
