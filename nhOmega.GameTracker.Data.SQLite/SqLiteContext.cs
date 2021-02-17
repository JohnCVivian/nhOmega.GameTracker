using Microsoft.EntityFrameworkCore;
using nhOmega.GameTracker.Data.SQLite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite
{
    public class SqLiteContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameImage> GameImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<GameImage>().ToTable("GameImages");
        }
    }
}
