using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.DB;
using System.Collections.Generic;

namespace BLL.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _db;

        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Add(AuthorDTO authorDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>());
            var mapper = new Mapper(config);
            var author = mapper.Map<Author>(authorDto);
            var result = DataAccessFactory.AuthorDataAccess(_db).Add(author);
            return result;
        }

        public List<AuthorDTO> GetAuthors()
        {
            var data = DataAccessFactory.AuthorDataAccess(_db).Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>());
            var mapper = new Mapper(config);
            var authors = mapper.Map<List<AuthorDTO>>(data);
            return authors;
        }

        public bool Update(AuthorDTO authorDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AuthorDTO, Author>());
            var mapper = new Mapper(config);
            var author = mapper.Map<Author>(authorDto);
            var result = DataAccessFactory.AuthorDataAccess(_db).Update(author);
            return result;
        }

        public AuthorDTO Get(int id)
        {
            var data = DataAccessFactory.AuthorDataAccess(_db).Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>());
            var mapper = new Mapper(config);
            var res = mapper.Map<AuthorDTO>(data);
            return res;
        }

        public bool Delete(int id)
        {
            var result = DataAccessFactory.AuthorDataAccess(_db).Delete(id);
            return result;
        }
    }
}
