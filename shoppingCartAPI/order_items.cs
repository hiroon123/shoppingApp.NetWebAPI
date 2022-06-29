using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class order_items
    {
        public int id { get; set; }

        //order_id foreign key
        public int order_id { get; set; }
        [ForeignKey("order_id")]
        public order_details? order_details { get; set; }

        //product_id foreign key
        public int product_id { get; set; }
        [ForeignKey("product_id")]
        public product? product { get; set; }

        public int qty { get; set; }

        public DateTime created { get; set; }
    }
}

