using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review : Entity
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public string ReviewContent { get; set; }

        public virtual User User { get; set; }  

        public virtual Book Book { get; set; }

        
    }
}
