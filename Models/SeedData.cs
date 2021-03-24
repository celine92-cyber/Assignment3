using Assignment3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleScheduler.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            Assignment3DbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Assignment3DbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Responses.Any())
            {
                context.Responses.AddRange(
                    new ApplicationResponse
                    {
                        BookId = 1,
                        Category = "Action/Adventure",
                        Title = "Avengers, The",
                        Year = 2012,
                        Director = "Joss Whedon",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = "",

                    }
                ); 

                context.SaveChanges();
            }
        }
    }
}