using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext) => this.appDbContext = appDbContext;
        async Task<ServiceResponse> IUserRepository.checkCredentials(string UserName, string Password)
        {
            User user = await appDbContext.Users.Where(user => user.PasswordHashed == Password && user.UserName == UserName).SingleAsync();

            if (user == null) return new ServiceResponse(false, "Username or Password Incorrect!");

            return new ServiceResponse(true, "Logged In Successfully");
        }
    }
}
