using System.Collections.Generic;
using System;
using ASP.Net_HW_02._03._25.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net_HW_02._03._25.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
