using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Core.DTOs;
using Vezeeta.Core.Interfaces.ServiceInterfaces;
using Vezeeta.Core.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Vezeeta.Presentation.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Vezeeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }


        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDiscount([FromBody] AddDiscountDto discountDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                 _discountService.AddDiscount(discountDTO);

               return Ok($"Discount added successfully with ID: {discountDTO}");
               
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] AddDiscountDto discountDTO)
        {
            try
            {
                _discountService.UpdateDiscount(id, discountDTO);

               return Ok($"Discount with ID {id} updated successfully.");
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            try
            {
                    _discountService.DeleteDiscount(id);

                    return Ok($"Discount with ID {id} deleted successfully.");
             
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpGet("Deactivate")]
        public async Task<IActionResult> DeactivateDiscount(int id)
        {
            try
            {
                _discountService.DeactivateDiscount(id);
                return Ok($"Discount with ID {id} deactivated successfully.");
                //if (result)
                //{
                //    return Ok($"Discount with ID {id} deactivated successfully.");
                //}
                //else
                //{
                //    return NotFound($"Discount with ID {id} not found.");
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
