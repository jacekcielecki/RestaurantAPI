using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }


        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants.Add(
                new Restaurant()
                {
                    Name = "KFC",
                    Description = "KFC (short for Kentucky Fried Chicken is an American fast food restaurant chain",
                    Category = "Fast Food",
                    HasDelivery = true,
                    ContactEmail = "contact@kfc.com",
                    Dishes = new List<Dish>()
                    {
                        new Dish() { Name = "Nashville Hot Chicken", Price = 10.30M },
                        new Dish() { Name ="Chicken Nuggets", Price = 5.30M },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001",
                    }
                });
            restaurants.Add(
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald's is an American multinational fast food corporation, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                    HasDelivery = true,
                    ContactEmail = "contact@mcdonald.com",
                    Dishes = new List<Dish>()
                    {
                        new Dish() { Name = "Big Mac", Price = 8.00M },
                        new Dish() { Name ="Large Fries", Price = 2.20M },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Szewska 2",
                        PostalCode = "30-002",
                    }
                });
            
            return restaurants;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role (){Name = "User"},
                new Role (){Name = "Manager"},
                new Role (){Name = "Admin"}
            };
            return roles;
        }
    }
}
