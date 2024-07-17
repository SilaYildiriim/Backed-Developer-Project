using Backed_Developer_Project.Application.Model.UserDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.Application.Services.UserService
{
    public interface IUserService
    {
        Task<SignInResult> Login(LoginDto model);
        Task LogOut();
    }
}
