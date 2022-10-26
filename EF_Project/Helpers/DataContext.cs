using EF_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EF_Project.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext()
        {
        }

        public DataContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            Configuration = configuration;
        }

        //NEW
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //connect to sql server with connection string from app settings
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            options.UseSqlServer(@"Server=.;Database=FirstDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region Old

        //OLD
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //// Get the connection string from configuration 
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=FirstDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        //}

        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
