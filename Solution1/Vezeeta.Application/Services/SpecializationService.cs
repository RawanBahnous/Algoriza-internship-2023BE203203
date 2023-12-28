using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Application.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _repository;

        public SpecializationService(ISpecializationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Specialization> AddNewSpecialization(Specialization specialization)
        {
            try
            {
                return await _repository.AddNewSpecialization(specialization);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding specialization: {ex}");
                throw;
            }
        }

        public async Task<bool> DeleteSpecilization(int specialization)
        {
           return await _repository.DeleteSpecilization(specialization);   
        }

        public async Task<IActionResult> GetAll()
        {
            var specializations = await _repository.GetAll();
            var specializeDtos = specializations.Select(s => new SpecializeDto
            {
                Name = s.Name,
                Description = s.Description,
            }).ToList();

            return new OkObjectResult(specializeDtos);
        }

        public async Task<List<Specialization>> TopSpecilization()
        {
            return await _repository.TopSpecilization();
        }
    }

}
