using lmsBackend.DataAccessLayer;
using lmsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace lmsBackend.Repository.LoginRepo
{
    public class LoginService : ILogin
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(string Email, string Password)
        {
            // Count occurrences of the provided email
            int emailCount = await _context.Users.CountAsync(u => u.Email == Email);

            if (emailCount == 0)
            {
                return false; // Email not found
            }

            if (emailCount > 1)
            {
                return false; // Duplicate email found, shouldn't allow login
            }

            // Retrieve the user record
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);

            if (user.Password != Password)
            {
                return false; // Incorrect password
            }

            return true; // Successful login
        }
    }
}