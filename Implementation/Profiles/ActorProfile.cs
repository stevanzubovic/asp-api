using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

        }
    }
}
