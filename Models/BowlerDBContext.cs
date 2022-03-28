using System;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public class BowlerDBContext : DbContext
    {
        public BowlerDBContext(DbContextOptions<BowlerDBContext> options) : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
    }
}
