using DIT.Domain.Context;
using DIT.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIT.API
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<DitContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                User user = new User()
                {
                    Email = "illia@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Illia"
                };
                userManager.CreateAsync(user, "Google.com500");
            }
        }
    }
}
