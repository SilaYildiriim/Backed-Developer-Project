using Backed_Developer_Project.Domain.Entities;
using Backed_Developer_Project.Domain.Repositories;
using Backed_Developer_Project.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.InfraStructure.Repositories
{
    public class FormRepo : IFormRepo
    {
        private readonly AppDbContext _context;
        protected DbSet<Form> _formTable;
        public FormRepo(AppDbContext context)
        {
            _context = context;
            _formTable = _context.Set<Form>();
        }
        public async Task<List<Form>> GetAlls()
        {
            return await _formTable.ToListAsync();
        }

        public async Task AddAsync(Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();
        }
    }
}
