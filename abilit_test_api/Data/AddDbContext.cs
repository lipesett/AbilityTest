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
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AbilitTest"));
        }

        public DbSet<GeneroTB> GeneroTB { get; set; }
        public DbSet<FuncionarioTB> FuncionarioTB { get; set; }
        public DbSet<DependentesTB> DependentesTB { get; set; }
    }
}
