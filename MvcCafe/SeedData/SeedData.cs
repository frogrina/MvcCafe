using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCafe.Data;
using System;
using System.Linq;

namespace MvcCafe.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCafeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCafeContext>>()))
            {
                // Look for any cafes.
                if (context.Cafe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cafe.AddRange(
                    new Cafe
                    {
                        Name = "Mac",
                        Description = "Was closed",
                        CurrentLoad = 0,
                        MaxLoad = 100
                    },

                    new Cafe
                    {
                        Name = "Tokyo City",
                        Description = "Food is't from Tokyo",
                        CurrentLoad = 10,
                        MaxLoad = 200
                    },

                    new Cafe
                    {
                        Name = "Teremok",
                        Description = "From Russia with love",
                        CurrentLoad = 15,
                        MaxLoad = 50
                    },

                    new Cafe
                    {
                        Name = "Bachroma",
                        Description = "Copy of Tokyo city",
                        CurrentLoad = 17,
                        MaxLoad = 250
                    }
                );
                context.SaveChanges();
            }
        }
    }
}