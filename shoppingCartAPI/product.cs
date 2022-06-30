using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class product
    {
        public int id { get; set; }

        [StringLength(100)]
        public string product_name { get; set; } = string.Empty;

        [StringLength(500)]
        public string product_desc { get; set; } = string.Empty;

        //category_id foreign key
        public int category_id { get; set; }
        [ForeignKey("category_id")]
        public product_category? category { get; set; }

        //inventory_id foreign key
        public int inventory_id { get; set; }
        [ForeignKey("inventory_id")]
        public product_inventory? inventory { get; set; }

        public float price { get; set; }

        public string? img1_url { get; set; } = string.Empty;

        public string? img2_url { get; set; } = string.Empty;

        public string? img3_url { get; set; } = string.Empty;

        public DateTime created { get; set; }

        public DateTime modified { get; set; }

        public DateTime? deleted { get; set; }

        public bool active { get; set; }

    }
}

