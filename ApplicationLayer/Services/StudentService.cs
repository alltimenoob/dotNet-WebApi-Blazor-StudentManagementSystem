
using ApplicationLayer.Contracts;
using ApplicationLayer.DTOs;
using DomainLayer.Entities;
using System.Net.Http.Json;

namespace ApplicationLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly  HttpClient _httpClient;
        public StudentService(HttpClient client)
        { 
            _httpClient = client;
        }

        async Task<ServiceResponse> IStudentService.AddAsync(Student student)
        {
            var data = await _httpClient.PostAsJsonAsync("api/student", student);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        async Task<ServiceResponse> IStudentService.DeleteAsync(Guid id)
        {
            var data = await _httpClient.PostAsJsonAsync($"api/student/{id}", id);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        async Task<List<Student>> IStudentService.GetAsync() => await _httpClient.GetFromJsonAsync<List<Student>>("api/student");

        async Task<Student> IStudentService.GetByIdAsync(Guid id) => await _httpClient.GetFromJsonAsync<Student>($"api/student/{id}");

        async Task<ServiceResponse> IStudentService.UpdateAsync(Student student)
        {
            var data = await _httpClient.PutAsJsonAsync("api/student", student);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
