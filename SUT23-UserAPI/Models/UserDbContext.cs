using Microsoft.EntityFrameworkCore;

namespace SUT23_UserAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Test Data
            modelBuilder.Entity<User>().HasData(new User { ID = 1, Name = "Anas" });
            modelBuilder.Entity<User>().HasData(new User { ID = 2, Name = "Reidar" });
            modelBuilder.Entity<User>().HasData(new User { ID = 3, Name = "Pelle" });
            modelBuilder.Entity<User>().HasData(new User { ID = 4, Name = "Pär" });
        }


    }
}
