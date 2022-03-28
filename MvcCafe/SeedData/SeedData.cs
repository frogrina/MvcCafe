using Microsoft.EntityFrameworkCore;
using MvcCafe.Data;

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
                if (!context.Cafes.Any())
                {
                    context.Cafes.AddRange(
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
                }

                if (!context.Users.Any())
                {
                    context.Users.Add(new User
                    {
                        Login = "Admin",
                        PasswordHash = "938c2cc0dcc05f2b68c4287040cfcf71",
                        Cafes = context.Cafes.ToList()
                    });
                }

                context.SaveChanges();
            }
        }
    }
}