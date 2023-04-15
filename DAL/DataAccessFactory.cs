using DAL.DB;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Book, int> BookDataAccess(ApplicationDbContext db)
        {
            return new BookRepo(db);
        }


    }
}
