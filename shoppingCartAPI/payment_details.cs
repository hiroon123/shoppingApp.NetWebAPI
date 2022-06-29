using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class payment_details
    {
        public int id { get; set; }

        //user_id foreign key
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public user? user { get; set; }

        //order_id foreign key
        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public order_details? order_details { get; set; }

        [StringLength(100)]
        public string payment_type { get; set; } = string.Empty;

        [StringLength(100)]
        public string provider { get; set; } = string.Empty;

        [StringLength(100)]
        public string status { get; set; } = string.Empty;

        [StringLength(100)]
        public string reference { get; set; } = string.Empty;
    }
}

