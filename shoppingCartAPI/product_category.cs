using System;
using System.ComponentModel.DataAnnotations;

namespace shoppingCartAPI
{
    public class product_category
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cat_name { get; set; } = String.Empty;

        [StringLength(150)]
        public string cat_desc { get; set; } = String.Empty;

        [StringLength(50)]
        public DateTime created { get; set; }

        [StringLength(50)]
        public DateTime modified { get; set; }

        [StringLength(50)]
        public DateTime deleted { get; set; }
    }
}

