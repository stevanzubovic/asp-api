using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class LogDTO
    {
        public int ActorId { get; set; }
        public string UseCaseName { get; set; }
        public int UseCaseId { get; set; }
        public DateTime Created { get; set; }
        public string Data { get; set; }
    }
}
