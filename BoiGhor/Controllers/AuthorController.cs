using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoiGhor.Controllers
{
    public class AuthorController : Controller
    {

        private readonly AuthorService authorService;

        public AuthorController(AuthorService authorService)
        {
            this.authorService = authorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorDTO author)
        {

            if (!ModelState.IsValid)
            {
                return View(author);
            }

            authorService.Add(author);
            return RedirectToAction("Index");

        }
    }
}
