using Dashboardmini.Models;
using Microsoft.AspNetCore.Identity;
namespace Dashboardmini.Services
{
    public static class VerifyAccount
    {
        public static string CreatePasswordHash(string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            string PasswordHash = passwordHasher.HashPassword(null,password);
            return PasswordHash;

        }
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }

    }
}


