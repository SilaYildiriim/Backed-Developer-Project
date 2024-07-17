using Backed_Developer_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.Domain.Repositories
{
    public interface IFormRepo
    {
        Task<List<Form>> GetAlls();
        Task AddAsync(Form form);
    }
}
