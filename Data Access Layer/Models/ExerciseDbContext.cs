using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ExerciseDbContext: DbContext
    {
        public ExerciseDbContext() { }

        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
