using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter the language.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Language must be between 2 and 20 characters.")]
        public string? Language { get; set; }

        public string? CoverImageUrl { get; set; }

        public string? AuthorName { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author? Author { get; set; }
    }
}
