using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<BookGenre> BookGenre { get; set; } = new List<BookGenre>();


    }
}
