using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Authorization
{
    public class MinimumCreatedRestaurants : IAuthorizationRequirement
    {
        public int MinimumCreated { get; }
        public MinimumCreatedRestaurants(int minimumCreated)
        {
            MinimumCreated = minimumCreated;
        }
    }
}
