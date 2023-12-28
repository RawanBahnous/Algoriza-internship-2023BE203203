using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Presentation.DTOs;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository auth;

        public AppointmentController(IAppointmentService appointmentService, UserManager<ApplicationUser> userManager, IUserRepository auth)
        {
            _appointmentService = appointmentService;
            _userManager = userManager;
            this.auth = auth;
        }


        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments =  _appointmentService.GetAllAppointments();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


//        {
//  "days": 3,
//  "price": 190,
//  "doctorId": "f1a556c4-37b1-414b-9eae-df641183b534",
//  "booked": false
//         }
    [HttpPost("AddNewAppointment")]
        public async Task<IActionResult> AddNewAppointment([FromBody] AddAppoinmentDto newAppointment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var addedAppointment = _appointmentService.AddNewAppointment(newAppointment);

                return Ok(addedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppoinmentDto updatedAppointment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = _appointmentService.UpdateAppointment(id, updatedAppointment);
                if (result is null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                _appointmentService.DeleteAppointment(id);
                return Ok();
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




        [HttpGet("GetAppointment/{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            try
            {
                var appointment = await _appointmentService.GetAppoinmentById(id);

                if (appointment == null)
                    return NotFound();

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        //[Authorize(Roles = "Patient")]
        [HttpGet("searchAppoinment")]
        public async Task<IActionResult> SearchAppointments( Days day)
        {
            try
            {
                //var user = await _userManager.GetUserAsync(HttpContext.User);
                //if (user == null)
                //{
                //    return Unauthorized(); 
                //}

                //if (!string.IsNullOrEmpty(patientId) && user.Id != patientId)
                //{
                //    return Forbid(); 
                //}

                var appointments = _appointmentService.SearchAppointments(day);

                if (appointments == null || !appointments.Any())
                {
                    return NotFound();
                }

                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




    }
}
