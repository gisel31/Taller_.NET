using DataAccessLayer.EFModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DBContextCore : DbContext
    {
        private string _connectionString = "Server=localhost,1400;Database=practico5;User Id=sa;Password=Abc*123!;Encrypt=False;";

        public DBContextCore()
        { }

        public DBContextCore(DbContextOptions<DBContextCore> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
    }
}
