﻿using DAL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 100 characters.")]
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
