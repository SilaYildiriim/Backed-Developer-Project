using AutoMapper;
using Backed_Developer_Project.Application.Model.FormDtos;
using Backed_Developer_Project.Domain.Entities;
using Backed_Developer_Project.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.Application.Services.FormServices
{
    public class FormService : IFormService
    {
        private readonly IFormRepo _formRepo;
        private readonly IMapper _mapper;

        public FormService(IFormRepo formRepo, IMapper mapper)
        {
            _formRepo = formRepo;
            _mapper = mapper;
        }

        public async Task<List<FormAllDto>> GetAll()
        {
            var forms = await _formRepo.GetAlls();
            return _mapper.Map<List<FormAllDto>>(forms);
        }

        public async Task AddForm(AddFormDto formDto)
        {
            var form = _mapper.Map<Form>(formDto);
            await _formRepo.AddAsync(form);
        }
    }
}
