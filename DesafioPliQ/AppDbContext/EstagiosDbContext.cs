using DesafioPliQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DesafioPliQ.AppDbContext
{
    public class EstagiosDbContext : DbContext
    {
        public EstagiosDbContext(DbContextOptions<EstagiosDbContext> op) : base(op)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            op.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<EstagiosCRM> Estagios { get; set; }
    }
}
