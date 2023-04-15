using DAL.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {

        public int Id { get; set; }


        public string? Title { get; set; }


        public string? Language { get; set; }

        public string? CoverImageUrl { get; set; }

        public int AuthorId { get; set; }

        public virtual AuthorDTO? Author { get; set; }
    }

}
