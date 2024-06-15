
using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext dbContext)
        {
            this._appDbContext = dbContext; 
        }

        public async Task<ServiceResponse> AddAsync(Student student)
        {
            _appDbContext.Students.Add(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Student Added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var studentToDelete = await _appDbContext.Students.FindAsync(id);
            if(studentToDelete == null)
            {
                return new ServiceResponse(false, "Student Not Available");
            }

            _appDbContext.Students.Remove(studentToDelete);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Student Deleted");
        }

        public async Task<List<Student>> GetAsync() => await _appDbContext.Students.AsNoTracking().ToListAsync();

        public async Task<Student> GetByIdAsync(Guid id) => await _appDbContext.Students.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Student student)
        {
           _appDbContext.Update(student);
            await SaveChangesAsync();
            return new ServiceResponse(true,"Student Updated");
        }

        private async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();

        
    }
}
