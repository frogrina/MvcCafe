#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCafe.Models;

namespace MvcCafe.Data
{
    public class MvcCafeContext : DbContext
    {
        public MvcCafeContext (DbContextOptions<MvcCafeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCafe.Models.Cafe> Cafe { get; set; }
    }
}
