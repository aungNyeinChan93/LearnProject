using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Learn.D2.GameStoreDb.Models;

public partial class GameStoreDbContext : DbContext
{
    public GameStoreDbContext()
    {
    }

    public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

//    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Games__3214EC07B200E142");

            entity.Property(e => e.AgeRating).HasMaxLength(50);
            entity.Property(e => e.Developer).HasMaxLength(200);
            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.Platform).HasMaxLength(100);
            entity.Property(e => e.Publisher).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
