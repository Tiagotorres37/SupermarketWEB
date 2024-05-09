using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Models;
using System.Collections.Generic;
namespace SupermarketWEB.Data
{
    public class SupermarketContext : DbContext
    {

        public SupermarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
		public DbSet<Provider> Provider { get; set; }

        public DbSet<payMode> payMode { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Server=(localdb)\\mssqllocaldb;Database=SupermarketEF;Trusted_Connection=True;");
		}

	}
}
