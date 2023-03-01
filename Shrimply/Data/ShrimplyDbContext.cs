﻿using Microsoft.EntityFrameworkCore;
using Shrimply.Models.Domain;

namespace Shrimply.Data
{
    public class ShrimplyDbContext : DbContext
    {
        public ShrimplyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Shrimp> Shrimps { get; set; }
    }
}
