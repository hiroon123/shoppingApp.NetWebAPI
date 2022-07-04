using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class user_login_request
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}

