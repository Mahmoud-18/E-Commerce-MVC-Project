using ECommerceMVC.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Models
{
    public class StartupDBInitializer
    {
        EcommerceDbContext dbContext;
        public StartupDBInitializer(EcommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        List<IdentityRole<int>> Roles = new List<IdentityRole<int>>()
        {
            new IdentityRole<int>
            {
                
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },

            new IdentityRole<int>
            {
                
                Name = "Member",
                NormalizedName = "Member".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole<int>
            {
                
                Name = "Vendor",
                NormalizedName = "Vendor".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        };
      
        public void AddRoles()
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
