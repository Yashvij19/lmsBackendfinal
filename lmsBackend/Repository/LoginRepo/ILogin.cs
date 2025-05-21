using lmsBackend.Models;

namespace lmsBackend.Repository.LoginRepo
{
    public interface ILogin
    {
        Task<bool> Login(string Email, string Password);
        
    }
}