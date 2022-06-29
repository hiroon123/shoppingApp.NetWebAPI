using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class user
    {
        public int id { get; set; }

        [StringLength(50)]
        public string email { get; set; } = string.Empty;

        [StringLength(100)]
        public string password { get; set; } = string.Empty;

        [StringLength(30)]
        public string first_name { get; set; } = string.Empty;

        [StringLength(30)]
        public string last_name { get; set; } = string.Empty;

        public DateTime dob { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }

        public DateTime last_login { get; set; }

    }
}

