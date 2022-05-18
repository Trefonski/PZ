using PZ.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PZ
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private DbContextOptions<AppDbContext> options;
        private IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.options = options;

            _httpContextAccessor = httpContextAccessor;
        }
    }
}