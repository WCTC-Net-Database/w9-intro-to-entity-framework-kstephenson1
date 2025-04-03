using System.Diagnostics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace W9_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Dungeon> Dungeons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<Unit>()
        //    .HasOne(u => u.Stat) // Navigation property
        //    .WithOne(s => s.Unit) // Navigation property
        //    .HasForeignKey<Stat>(s => s.StatId); // Foreign key property
            //.HasForeignKey<Unit>(u => u.StatId);
        // Google AI assisted me with setting up the one-to-one relationship between Unit and Stats
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Data Source={Config.SQL_SERVER_ADDRESS};Database={Config.SQL_DATABASE_NAME};User ID={Config.SQL_DATABASE_USERNAME};Password=000{MathF.Sqrt(Config.SQL_DATABASE_PASSWORD_ENCRYPTED)*5*2}");
    }
}