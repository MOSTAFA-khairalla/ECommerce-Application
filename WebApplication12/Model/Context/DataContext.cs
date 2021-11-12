using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Model.Entites;

namespace WebApplication12.Model.Context
{
    public class DataContext:IdentityDbContext
    {

        public DataContext( DbContextOptions<DataContext> options ) : base(options)
        {


        }

        public DbSet<carousel> Carousels { get; set; }
        public DbSet<NewsProduct>  NewsProducts { get; set; }
        public DbSet<OldProduct> OldProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Featured_Product> Featured_Products { get; set; }

    }
}
