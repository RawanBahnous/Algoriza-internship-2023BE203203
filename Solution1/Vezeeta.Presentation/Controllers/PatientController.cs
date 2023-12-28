using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("patients")]
        public async Task<IActionResult> GetPatients(int page = 1, int pageSize = 2, string search = "")
        {

            try
            {
                var patients = await _patientService.GetPatients(page, pageSize, search);

                var patientDtos = patients.Select(p => new PatientDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Gender = p.Gender,
                    Image = p.Image,
                    BirthDate = p.BirthDate,
                    Phone = p.Phone,
                    FullName = p.FullName,
                });

                return Ok(patientDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"An error occurred while processing your request. {ex.Message}");
            }
        }

        [HttpGet("patients/{id}")]
        public async Task<IActionResult> GetPatientById(string id)
        {
            try
            {
                var patientDto = await _patientService.GetPatient(id);

                if (patientDto == null)
                {
                    return NotFound(); 
                }

                return Ok(patientDto); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("PatientsCount")]
        public async Task<IActionResult> CountPatients()
        {
            var count = await _patientService.CountPatients();
            return Ok( count );
        }

    }
}
