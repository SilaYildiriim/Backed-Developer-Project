using Backed_Developer_Project.Application.Model.FormDtos;
using Backed_Developer_Project.Domain.Entities;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.Application.Services.FormServices
{
    public interface IFormService
    {
        Task<List<FormAllDto>> GetAll();
        Task AddForm(AddFormDto formDto);
    }
}
