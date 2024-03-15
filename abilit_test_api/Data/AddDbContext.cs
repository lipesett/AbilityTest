using abilit_test_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace abilit_test_api.Data
{
    public class AddDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AddDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AbilitTest"));
        }

        public DbSet<GeneroTB> GenerosTB { get; set; }
        public DbSet<FuncionarioTB> FuncionariosTB { get; set; }
        public DbSet<DependentesTB> DependentesTB { get; set; }
    }
}
