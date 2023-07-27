

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using USSDCSharp.Models;

namespace USSDCSharp.DBContext
{
    public class UssdDBContext : DbContext
    {
        public UssdDBContext()
        {
        }

        //private readonly IConfiguration _configuration;

        //public UssdDBContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public UssdDBContext(DbContextOptions<UssdDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UssdSession> UssdSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Access the connection string from appsettings.json
                //string connectionString = _configuration.GetConnectionString("USSDConnection");
                string connectionString = AppSettings.USSDConnection;

                //enabling transient error resiliency by adding 'EnableRetryOnFailure()'

                optionsBuilder.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);

                    });

                //builder => builder.EnableRetryOnFailure());

            }
        }
    }
}
