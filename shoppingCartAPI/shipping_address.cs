using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class shipping_address
    {
        public int id { get; set; }

        //user_id foreign key
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public user? user { get; set; }

        public string address_line1 { get; set; } = string.Empty;

        public string address_line2 { get; set; } = string.Empty;

        public string city { get; set; } = string.Empty;

        public string postal_code { get; set; } = string.Empty;

        public string country { get; set; } = string.Empty;

        public string telephone { get; set; } = string.Empty;

        public string? mobile { get; set; } = string.Empty;
    }
}

