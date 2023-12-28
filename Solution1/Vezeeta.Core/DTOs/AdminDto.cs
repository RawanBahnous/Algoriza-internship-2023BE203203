using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vezeeta.Core.DTOs
{
    public class AdminDto
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender? Gender { get; set; }
        public string UserName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
