using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoiGhorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BookService bookService;
        private readonly AuthorService authorService;

        public BookController(BookService bookService, AuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BookDTO bookDTO, [FromForm(Name = "file")] IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);
                bookDTO.CoverImageUrl = fileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            bookDTO.Id = 0;

            bookService.Add(bookDTO);

            return Ok(bookDTO);
        }


        [HttpGet("id")]
        public IActionResult Details(int id)
        {
            var book = bookService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            bool b=bookService.Delete(id);
            if (b)
            {
                return Ok("The Book is Deleted");
            }
            else
            {
                return BadRequest("Book is not Found");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] BookDTO bookDTO, [FromForm(Name = "file")] IFormFile file)
        {
            var existingBook = bookService.Get(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);
                bookDTO.CoverImageUrl = fileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            existingBook.Title = bookDTO.Title;
            existingBook.AuthorName = bookDTO.AuthorName;
            existingBook.AuthorId = bookDTO.AuthorId;
            existingBook.Language = bookDTO.Language;
            existingBook.CoverImageUrl = bookDTO.CoverImageUrl;
       

            bookService.Update(existingBook);

            return Ok(existingBook);
        }


    }
}
