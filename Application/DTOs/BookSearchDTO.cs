using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookSearchDTO
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public string? Language { get; set; }

        //public DateTime releseDate { get; set; }
    }
}
