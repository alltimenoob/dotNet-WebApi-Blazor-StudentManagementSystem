
using ApplicationLayer.DTOs;

namespace ApplicationLayer.Contracts
{
    public interface IUserRepository
    {
        Task<ServiceResponse> checkCredentials(string Username,string Password);

    }
}
