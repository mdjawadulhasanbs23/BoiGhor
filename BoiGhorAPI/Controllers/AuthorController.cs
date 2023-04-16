using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BoiGhorAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService authorService;

        public AuthorController(AuthorService authorService)
        {

            this.authorService = authorService;
        }
        [HttpGet]
        public IActionResult All()
        {
            var authors = authorService.GetAuthors();
            if (authors == null)
            {
                return NotFound();
            }
            return Ok(authors);
        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var author = authorService.Get(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }




        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            bool b = authorService.Delete(id);
            if (b)
            {
                return Ok("The Author is Deleted");
            }
            else
            {
                return BadRequest("Author is not Found");
            }
        }




    }
}