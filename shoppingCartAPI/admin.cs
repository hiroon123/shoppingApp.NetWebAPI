using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shoppingCartAPI
{
    public class admin
    {
        public int id { get; set; }

        [StringLength(50)]
        public string first_name { get; set; } = string.Empty;

        [StringLength(50)]
        public string last_name { get; set; } = string.Empty;

        [StringLength(50)]
        public string username { get; set; } = string.Empty;

        [StringLength(100)]
        public string password { get; set; } = string.Empty;

        //access_level foreign key
        public int access_level { get; set; }
        [ForeignKey("access_level")]
        public access_level? access_level_ { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }

        public DateTime last_login { get; set; }
    }
}

