using cookie_stand_api.Model;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Data
{
    public class CookieDbContext: DbContext 
    {

        //Constructor calling the Base DbContext Class Constructor
        public CookieDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //OnConfiguring() method is used to select and configure the data source
      
        //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CookieStand>().HasData(
                new CookieStand()
                {
                    Id = 1,
                    Location = "Barcelona",
                    Description = "",
                    MinimumCustomersPerHour = 3,
                    MaximumCustomersPerHour = 7,
                    AverageCookiesPerSale = 2.5,
                    Owner = ""
                },
                 new CookieStand()
                 {
                     Id = 2,
                     Location = "maxico",
                     Description = "",
                     MinimumCustomersPerHour = 2,
                     MaximumCustomersPerHour = 8,
                     AverageCookiesPerSale = 3,
                     Owner = ""
                 },
                  new CookieStand()
                  {
                      Id = 3,
                      Location = "Chickgio",
                      Description = "",
                      MinimumCustomersPerHour = 3,
                      MaximumCustomersPerHour = 7,
                      AverageCookiesPerSale = 3.5,
                      Owner = ""
                  });
            modelBuilder.Entity<HourlySales>().HasData(
       new HourlySales
       {
           Id = 1,
           CookieStandId = 1, // Link to the CookieStand with ID 1
           hour=5,
           SalesAmount = 17
       },
       new HourlySales
       {
           Id = 2,
           CookieStandId = 2, // Link to the CookieStand with ID 1
           hour=4,
           SalesAmount = 7
       },
        new HourlySales
        {
            Id = 3,
            CookieStandId = 3, // Link to the CookieStand with ID 1
            hour=1,
            SalesAmount = 6
        });

        }
        //Adding Domain Classes as DbSet Properties
        public DbSet<CookieStand> CookieStand { get; set; }
        public DbSet<HourlySales> HourlySales { get; set; }
    }


}
