using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.DB;


namespace BLL.Services
{
    public class BookService
    {

        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Add(BookDTO book)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Book>(book);
            var result = DataAccessFactory.BookDataAccess(_db).Add(data);
            return result;
        }

        public List<BookDTO> GetBooks()
        {
            var data = DataAccessFactory.BookDataAccess(_db).Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            var mapper = new Mapper(config);
            var books = mapper.Map<List<BookDTO>>(data);
            return books;

        }

        public bool Update(BookDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, Book>());
            var mapper = new Mapper(config);
            var data = mapper.Map<Book>(dto);
            var result = DataAccessFactory.BookDataAccess(_db).Update(data);
            return result;

        }

        public BookDTO Get(int id)
        {
            var data = DataAccessFactory.BookDataAccess(_db).Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            var mapper = new Mapper(config);
            var res = mapper.Map<BookDTO>(data);
            return res;
        }

        public bool Delete(int id)
        {

            var result = DataAccessFactory.BookDataAccess(_db).Delete(id);
            return result;

        }

    }
}
