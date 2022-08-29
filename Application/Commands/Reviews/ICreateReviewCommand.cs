using Application.DTOs.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Reviews
{
    public interface ICreateReviewCommand : ICommand<ReviewDTO>
    {
    }
}
