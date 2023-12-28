using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.RepositoriesInterfaces
{
    public interface ISpecializationRepository
    {
        Task<List<Specialization>> GetAll();
        Task<Specialization> AddNewSpecialization(Specialization specialization);
        Task<bool> DeleteSpecilization(int specializationId);
        Task<List<Specialization>> TopSpecilization();
    }
}
