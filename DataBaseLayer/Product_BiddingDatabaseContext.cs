using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Bidding.BusinessLayer;

namespace Product_Bidding.Models
{
    //Connects the business layer to the databse and handles the CRUD operations.
    public class Product_BiddingDatabaseContext : DbContext
    {
        public Product_BiddingDatabaseContext (DbContextOptions<Product_BiddingDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Bidding.BusinessLayer.Bid> Bid { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Buyer> Buyer { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Product> Product { get; set; }

        public DbSet<Product_Bidding.BusinessLayer.Seller> Seller { get; set; }
    }
}
