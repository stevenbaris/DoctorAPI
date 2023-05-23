using DoctorAPI.Data;
using DoctorAPI.DTO;
using DoctorAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace DoctorAPI.Repository.MsSQL
{
    public class AccountDbRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DDbContext _context;

        public AccountDbRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<ApplicationUser> FindUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> SignInUser(LoginDTO loginDTO)
        {
            return await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> SignUpUser(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
