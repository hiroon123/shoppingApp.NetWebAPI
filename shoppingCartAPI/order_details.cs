using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class order_details
    {
        public int id { get; set; }

        //user_id foreign key
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public user? user { get; set; }

        public float amount { get; set; }

        [StringLength(20)]
        public string status { get; set; } = string.Empty;

        public DateTime created { get; set; }
    }
}

