using Backed_Developer_Project.Application.Model.UserDtos;
using Backed_Developer_Project.Domain.Entities;
using Backed_Developer_Project.Domain.Repositories;
using Backed_Developer_Project.InfraStructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Backed_Developer_Project.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IUserRepo userRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepo = userRepo;
        }

        public async Task<SignInResult> Login(LoginDto model)
        {
            var user = await _userRepo.GetDefault(x => x.UserName.Equals(model.UserName));
            if (user == null)
                return SignInResult.Failed;

            else
            {
                //var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                //return result;
                if (user.UserName == model.UserName && user.Password == model.Password)
                    return SignInResult.Success;
                else return SignInResult.Failed;
            }

        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
