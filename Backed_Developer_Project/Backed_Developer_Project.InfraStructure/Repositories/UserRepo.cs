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
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        protected DbSet<User> _userTable;
        public UserRepo(AppDbContext context)
        {
            _context = context;
            _userTable = _context.Set<User>();
        }
        public async Task<User> GetDefault(Expression<Func<User, bool>> expression)
        {
            return await _userTable.FirstOrDefaultAsync(expression);
        }
    }
}
