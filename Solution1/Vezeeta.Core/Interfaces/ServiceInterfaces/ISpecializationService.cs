using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;

namespace Vezeeta.Core.Interfaces.ServiceInterfaces
{
    public interface ISpecializationService
    {
        Task<IActionResult> GetAll();
        Task<Specialization> AddNewSpecialization(Specialization specialization);
        Task<bool> DeleteSpecilization(int specializationId);
        Task<List<Specialization>> TopSpecilization();
    }

}
