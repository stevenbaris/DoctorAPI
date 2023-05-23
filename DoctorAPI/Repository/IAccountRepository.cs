using DoctorAPI.DTO;
using DoctorAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace DoctorAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpUser(ApplicationUser user, string password);
        Task<SignInResult> SignInUser(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmail(string email);
    }
}
