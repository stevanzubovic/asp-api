using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookGenreDTO
    {
        public int BookId { get; set; }

        public int GenreId { get; set; }

        public string? Genre { get; set; }
    }
}
