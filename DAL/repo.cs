using DAL.DB;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class repo
    {
         ApplicationDbContext _db ;

        public repo(ApplicationDbContext db)
        {
            _db = db;
        }
       
    }
}
