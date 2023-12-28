using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vezeeta.Core.Models
{

    public class ApplicationUser :IdentityUser
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped] 
        public IFormFile ImageFile { get; set; } 

        public string? Image { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Phone]
        public string Phone { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender? Gender { get; set; }
    }
}
