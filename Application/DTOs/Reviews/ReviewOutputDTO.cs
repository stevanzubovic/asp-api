using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reviews
{
    public class ReviewOutputDTO
    {
        public string UserName { get; set; }

        public string Book { get; set; }

        public string ReviewContent { get; set; }

        public string CreatedAt { get; set; }
    }
}
