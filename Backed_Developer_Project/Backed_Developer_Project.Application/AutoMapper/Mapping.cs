using AutoMapper;
using Backed_Developer_Project.Application.Model.FormDtos;
using Backed_Developer_Project.Application.Model.UserDtos;
using Backed_Developer_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.Application.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // UserService
            CreateMap<User, LoginDto>().ReverseMap();

            // FormService
            CreateMap<Form, FormAllDto>().ReverseMap();
            CreateMap<AddFormDto, Form>().ReverseMap();


            // FormFieldService
        }
    }
}
