﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmailOut
    {
        public string Content { get; set; }
        public string Subject { get; set; }

        public string Receiver { get; set; }
    }
}
