﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books
{
    public interface ICreateBookCommand : ICommand<BookDTO>
    {
    }
}