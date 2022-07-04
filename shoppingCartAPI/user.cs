using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class user
    {
        public int id { get; set; }

        [StringLength(50)]
        public string email { get; set; } = string.Empty;

        public byte[] passwordHash { get; set; } = new byte[32];

        public byte[] passwordSalt { get; set; } = new byte[32];

        [StringLength(30)]
        public string first_name { get; set; } = string.Empty;

        [StringLength(30)]
        public string last_name { get; set; } = string.Empty;

        public DateTime dob { get; set; }

        [StringLength(30)]
        public string? gender { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }

        public DateTime? last_login { get; set; }

        public string? verification_token { get; set; } = string.Empty;

        public DateTime? verfied_at { get; set; }

        public string? password_reset_token { get; set; } = string.Empty;

        public DateTime? reset_token_expires { get; set; }

    }
}

