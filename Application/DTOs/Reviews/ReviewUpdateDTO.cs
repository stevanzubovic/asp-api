using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reviews
{
    public class ReviewUpdateDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ReviewContent { get; set; }
    }
}
