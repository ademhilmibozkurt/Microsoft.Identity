using Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Contexts
{
    public class IdContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public IdContext(DbContextOptions<IdContext> options) : base(options)
        {
            
        }
    }
}
