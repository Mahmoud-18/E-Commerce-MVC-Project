using ECommerceMVC.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Models
{
    public class StartupDBInitializer
    {
 
        private static readonly List<IdentityRole<int>> Roles = new List<IdentityRole<int>>()
        {
            new IdentityRole<int>{Name = ApplicationRoles.Admin,
                NormalizedName = ApplicationRoles.Admin.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()},

            new IdentityRole<int>{Name = ApplicationRoles.Member,
                NormalizedName = ApplicationRoles.Member.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()}
        };

        public static void SeedData(IServiceProvider serviceProvider, UserManager<Customer> userManager)
        {
            using (var dbContext =
                new EcommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<EcommerceDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        private static void AddRoles(EcommerceDbContext dbContext)
        {
            if (dbContext.Roles.Any()) return;
            foreach (var role in Roles)
            {                
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
    }
}
