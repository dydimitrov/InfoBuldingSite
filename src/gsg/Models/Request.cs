using System;
using System.ComponentModel.DataAnnotations;

namespace gsg.Models
{
    public class Request
    {
        private const int Maxlength = 250;
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(Maxlength)]
        public string Message { get; set; }
    }
}
