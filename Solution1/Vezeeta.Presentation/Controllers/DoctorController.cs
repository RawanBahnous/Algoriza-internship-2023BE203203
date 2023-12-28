using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.RepositoriesInterfaces;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using Vezeeta.Core.Services;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository auth;


        public DoctorController(IDoctorService doctorservice, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IUserRepository auth)
        {
            _doctorservice = doctorservice;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            this.auth = auth;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromForm] AddDoctorDto addDoctor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var imageFile = addDoctor.ImageFile;

                if (imageFile != null && imageFile.Length > 0)
                {
                    var imagePath = ProcessImageFile(imageFile);
                    addDoctor.Image = imagePath;
                }

                var user = new ApplicationUser
                {
                    FirstName = addDoctor.FirstName,
                    LastName = addDoctor.LastName,
                    Email = addDoctor.Email,
                    Image = addDoctor.Image,
                    Phone = addDoctor.Phone,
                    UserName = addDoctor.UserName,
                    Gender = addDoctor.Gender,
                };

                var result = await _userManager.CreateAsync(user, addDoctor.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Failed to create Doctor", Errors = result.Errors });
                }

                await _userManager.AddToRoleAsync(user, "Doctor");

                var doctorToAdd = new Doctor
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Image = user.Image,
                    Phone = user.Phone,
                    Gender = user.Gender,
                    UserName = user.UserName,
                    SpecializeId = addDoctor.SpecializeId,
                };

                var addDoctorResult = _doctorservice.AddDoctor(addDoctor);

                if (!addDoctorResult)
                {
                    await _userManager.DeleteAsync(user);
                    return BadRequest("Failed to add doctor.");
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }


        private string ProcessImageFile(IFormFile imageFile)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return $"/images/{uniqueFileName}";
        }



        [HttpGet("GetPaginatedDoctors")]
        public async Task<IActionResult> GetDoctors(int page = 1, int pageSize = 2, string search = "")
        {
            try
            {
                var paginatedDoctors = _doctorservice.GetDoctors(page, pageSize, search);
                return Ok(paginatedDoctors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }




        [HttpGet("doctorsCount")]
        public async Task<IActionResult> CountDoctors()
        {
            try
            {
                var count = _doctorservice.CountDoctors();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetDoctor(string id)
        {
            try
            {
                var doctor = _doctorservice.GetDoctor(id);

                if (doctor == null)
                {
                    return NotFound();
                }

                var doctorDto = new DoctorDto()
                {
                    Id = doctor.Id,
                    BirthDate = doctor.BirthDate,
                    Image = doctor.Image,
                    Gender = doctor.Gender,
                    Email = doctor.Email,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Phone = doctor.Phone,
                    UserName = doctor.UserName,
                    SpecializeId = doctor.SpecializeId,
                };

                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPost("search")]
        public async Task<IActionResult> SearchDoctor([FromForm] string name)
        {
            try
            {
                var doctor =  _doctorservice.SearchDoctor(name);

                if (doctor == null)
                {
                    return NotFound();
                }

                var doctorDto = new DoctorDto()
                {
                    Id = doctor.Id,
                    BirthDate = doctor.BirthDate,
                    Image = doctor.Image,
                    Gender = doctor.Gender,
                    Email = doctor.Email,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Password = doctor.PasswordHash,
                    Phone = doctor.Phone
                };
                

                return Ok(doctorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("topDoctors")]
        public async Task<IActionResult> TopDoctors()
        {
            try
            {
                var topDoctors = _doctorservice.TopDoctors();
                return Ok(topDoctors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpDelete("DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            try
            {
                var result =  _doctorservice.DeleteDoctor(id);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> UpdateDoctor(string id, [FromBody] DoctorDto doctordto)
        {
            try
            {
                var result = _doctorservice.UpdateDoctor(id, doctordto);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
