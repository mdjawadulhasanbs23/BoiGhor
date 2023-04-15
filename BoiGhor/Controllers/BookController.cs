using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoiGhor.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDTO book)
        {

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            bookService.Add(book);
            return RedirectToAction("Index");   

        }
    }
}
