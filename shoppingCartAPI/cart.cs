using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class cart
    {
        public int id { get; set; }

        //product_id foreign key
        public int product_id { get; set; }
        [ForeignKey("product_id")]
        public product? product { get; set; }

        //user_id foreign key
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public user? user { get; set; }

        public int qty { get; set; }

        public DateTime created { get; set; }
    }
}

