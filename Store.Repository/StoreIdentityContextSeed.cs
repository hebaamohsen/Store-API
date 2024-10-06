using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Heba Mohsen",
                    Email = "heba@gmail.com",
                    UserName = "hebamohsen",
                    Address = new Address
                    {
                        FirstName = "Heba",
                        LastName = "Mohsen",
                        City = "Minya",
                        State = "Minya",
                        Street = "3",
                        PostalCode = "12345"
                    }
                };

                await userManager.CreateAsync(user,"Password123!");
            }
        }
    }
}
