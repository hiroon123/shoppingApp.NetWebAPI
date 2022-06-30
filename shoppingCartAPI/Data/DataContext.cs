using System;
using Microsoft.EntityFrameworkCore;

namespace shoppingCartAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<product>? Products { get; set; }

        public DbSet<product_category>? Product_Categories { get; set; }

        public DbSet<product_inventory>? Product_Inventories { get; set; }

        public DbSet<shipping_address>? Shipping_Addresses { get; set; }

        public DbSet<user>? Users { get; set; }

        public DbSet<payment_details>? payment_Details { get; set; }

        public DbSet<order_items>? Order_Items { get; set; }

        public DbSet<order_details>? Order_Details { get; set; }

        public DbSet<cart>? Carts { get; set; }

        public DbSet<admin>? Admins { get; set; }

        public DbSet<access_level>? Access_Levels { get; set; }
    }
}

