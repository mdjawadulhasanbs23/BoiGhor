using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoiGhor.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;
        private readonly AuthorService authorService;

        public BookController(BookService bookService, AuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public IActionResult Create(int id)
        {

            var author = authorService.Get(id);

            var book = new BookDTO();
            book.AuthorId = author.Id;
            book.AuthorName = author.Name;
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(BookDTO bookDTO, IFormFile upload)
        {
            if (!ModelState.IsValid)
            {
                return View(bookDTO);
            }

            if (upload != null && upload.Length > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                bookDTO.CoverImageUrl = fileName;

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    upload.CopyToAsync(fileSrteam);
                }

            }



            bookDTO.Id = 0;

            bookService.Add(bookDTO);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var author = bookService.Get(id);
            return View(author);
        }


        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {

            var book = bookService.Get(id);
            var authors = authorService.GetAuthors();
            ViewBag.Authors = authors;
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookDTO bookDTO, IFormFile upload)
        {
           /* if (!ModelState.IsValid)
            {
                return View(bookDTO);
            }*/

            if (upload != null && upload.Length > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                bookDTO.CoverImageUrl = fileName;

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    upload.CopyToAsync(fileSrteam);
                }

            }




            var author = authorService.Get(bookDTO.AuthorId);

            bookDTO.AuthorName= author.Name;
            bookService.Update(bookDTO);
            return RedirectToAction("Index");

        }


    }
}
