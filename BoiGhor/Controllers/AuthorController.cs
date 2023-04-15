﻿using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BoiGhor.Controllers
{
    public class AuthorController : Controller
    {

        private readonly AuthorService authorService;
        private readonly IWebHostEnvironment _env;

        public AuthorController(AuthorService authorService, IWebHostEnvironment env)
        {
            this.authorService = authorService;
            _env = env;
        }



        public IActionResult Index()
        {
            var authors = authorService.GetAuthors();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(AuthorDTO authorDto, IFormFile upload)
        {
            if (!ModelState.IsValid)
            {
                return View(authorDto);
            }

            if (upload != null && upload.Length > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                authorDto.ImageUrl = filePath;

                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                   upload.CopyToAsync(fileSrteam);
                }
              
            }





            authorService.Add(authorDto);
            return RedirectToAction("Index");
        }

    }
}
