using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookAuthorDTO
    {
        //public int Id { get; set; }

        public int BookId{ get; set; }

        public int AuthorId { get; set; }

        public string? Name { get; set; }
    }
}
