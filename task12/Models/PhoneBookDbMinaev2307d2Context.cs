using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace task12.Models;

public partial class PhoneBookDbMinaev2307d2Context : DbContext
{
    public PhoneBookDbMinaev2307d2Context()
    {
    }

    public PhoneBookDbMinaev2307d2Context(DbContextOptions<PhoneBookDbMinaev2307d2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=BOB;Initial Catalog=PhoneBookDB_Minaev_2307d2;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC0753D7F05C");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
