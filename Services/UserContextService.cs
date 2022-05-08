﻿using System.Security.Claims;

namespace RestaurantAPI.Services
{
    public interface IUserContextService
    {
        IHttpContextAccessor _httpContextAccessor { get; set; }
        int? GetUserId { get; }
        ClaimsPrincipal User { get; }
    }

    public class UserContextService : IUserContextService
    {
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
