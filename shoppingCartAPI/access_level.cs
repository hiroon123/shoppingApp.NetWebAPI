using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class access_level
    {
        public int id { get; set; }

        [StringLength(50)]
        public string access_level_name { get; set; } = string.Empty;
    }
}

