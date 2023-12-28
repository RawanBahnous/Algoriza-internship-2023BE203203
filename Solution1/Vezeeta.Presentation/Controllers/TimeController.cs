using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Models;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly VezeetaDbContext _context;

        public TimeController(VezeetaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTime([FromBody] TimeRequestModel appointment )
        {

            var existingAppointment = await _context.Appointments.FindAsync(appointment.AppointmentId);
            if (existingAppointment == null)
            {
                return NotFound("Appointment not found");
            }

            var newTime = new TimesAppointment
            {
                DateTime = appointment.Time, 
                
                AppointmentId = appointment.AppointmentId,
            };

            _context.Times.Add(newTime);
            await _context.SaveChangesAsync();
            return Ok(newTime);
        }
    }


   
}
