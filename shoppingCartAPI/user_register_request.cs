using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class user_register_request
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        public string first_name { get; set; } = string.Empty;

        public string last_name { get; set; } = string.Empty;

        public DateTime dob { get; set; }

        public string? gender { get; set; }
    }
}

