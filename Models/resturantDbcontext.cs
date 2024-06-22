namespace my_resturant.Models
{
    using Microsoft.EntityFrameworkCore;
    public class resturantDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Menulist> Menulist{ get; set; }

        public DbSet<Order> Orders { get; set; }

        public resturantDbContext(DbContextOptions<resturantDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    username = "roaa",
                    Email = "roaaabuarra0@gmail.com",
                    Password = "00000"
                }
                );

            modelBuilder.Entity<Menulist>().HasData(
                new Menulist
                {
                    Id = 1,
                    Name = "Pasta",
                    Description = "Fast food",
                    Price = 50,
                }
                );

            modelBuilder.Entity<Menulist>().HasData(
                new Menulist
                {
                    Id = 2,
                    Name = "Pizza",
                    Description = "Fast food",
                    Price = 30,
                }
                );

            modelBuilder.Entity<Menulist>().HasData(
                new Menulist
                {
                    Id = 3,
                    Name = "Burger",
                    Description = "Fast food",
                    Price = 25,
                }
                );

            modelBuilder.Entity<Menulist>().HasData(
                new Menulist
                {
                    Id = 4,
                    Name = "Grilled chicken with rice",
                    Description = "Family meal",
                    Price = 70,
                }
                );

        }

    }
}
