using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class Assignment3DbContext : DbContext //inherit from the entityframeworkcore DbContext file
    {
        //the constructor
        public Assignment3DbContext (DbContextOptions<Assignment3DbContext> options) :base (options)
        {

        }

        public DbSet<ApplicationResponse> Movies { get; set; }

    }
}
