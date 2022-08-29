using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reviews
{
    public class ReviewSearchDTO
    {
        public string? BookTitle { get; set; }
        public string? Username { get; set; }

        public string? ReviewContent { get; set; }
    }
}
