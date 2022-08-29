﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<BookAuthor> AuthorBook { get; set; } = new List<BookAuthor>();
    }
}
