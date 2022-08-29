using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<BookAuthorDTO> BookAuthors { get; set; } = new List<BookAuthorDTO>();
        public ICollection<BookGenreDTO> BookGenres { get; set; } = new List<BookGenreDTO>();


    }
}
