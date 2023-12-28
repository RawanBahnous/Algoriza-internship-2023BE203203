using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs
{
    public class RegisterModel 
    {
        public string Id { get; set; }  
        [Required]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public string? Image { get; set; }
        [Required]
        public string Username { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Phone]
        public string Phone { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender? Gender { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
