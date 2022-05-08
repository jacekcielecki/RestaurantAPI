using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Authorization
{
    public class MinimumCreatedRestaurantsHandler : AuthorizationHandler<MinimumCreatedRestaurants>
    {
        private readonly RestaurantDbContext _context;
        private readonly IUserContextService _userContextService;
        public MinimumCreatedRestaurantsHandler(RestaurantDbContext dbContext, IUserContextService userContextService)
        {
            _context = dbContext;
            _userContextService = userContextService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumCreatedRestaurants requirement)
        {
            var RestaurantsCreated = _context.Restaurants.Count(r => r.CreatedById == _userContextService.GetUserId);
            if (RestaurantsCreated >= requirement.MinimumCreated)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
