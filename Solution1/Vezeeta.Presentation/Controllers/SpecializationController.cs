using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using System;
using System.Threading.Tasks;
using Vezeeta.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        private readonly VezeetaDbContext _dbContext;

        public SpecializationController(ISpecializationService specializationService, VezeetaDbContext dbContext)
        {
            _specializationService = specializationService;
            _dbContext = dbContext;
        }



        [HttpPost("AddSpecialization")]
        public async Task<IActionResult> AddNewSpecilization([FromForm] SpecializeDto specialization)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var specializeToAdd = new Specialization
                {
                    //Id= specialization.Id,
                    Description = specialization.Description,
                    Name = specialization.Name,
                    AdminId= specialization.AdminId,
                };

                var result = _specializationService.AddNewSpecialization(specializeToAdd);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("TopSpecilization")]
        public async Task<ActionResult> TopSpecilization()
        {
            try
            {
                var result = await _specializationService.TopSpecilization();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
