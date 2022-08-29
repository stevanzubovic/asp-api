using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log : Entity
    {

        public int ActorId { get; set; }

        public string UseCase { get; set; }

        public int UseCaseId { get; set; }

        public string Data { get; set; }
    }
}
