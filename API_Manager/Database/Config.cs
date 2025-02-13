using API_Manager.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Manager.Database
{
    public class Config : DbContext
    {
        public Config(DbContextOptions<Config> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        //Mapeamento para o Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
        }
    }
}
