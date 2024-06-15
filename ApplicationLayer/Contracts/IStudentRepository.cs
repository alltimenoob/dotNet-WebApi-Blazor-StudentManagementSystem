
using ApplicationLayer.DTOs;
using DomainLayer.Entities;

namespace ApplicationLayer.Contracts
{
    public interface IStudentRepository
    {
        Task<ServiceResponse> AddAsync(Student student);
        Task<ServiceResponse> UpdateAsync(Student student);
        Task<ServiceResponse> DeleteAsync(Guid id);
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(Guid id);
    }
}
