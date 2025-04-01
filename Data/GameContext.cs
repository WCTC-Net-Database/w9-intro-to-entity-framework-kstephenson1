using System.Diagnostics;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace W9_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Dungeon> Dungeons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Unit> Units { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<AdjacentRoom>()
        //    .HasOne(r => r.Room)
        //    .WithMany()
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.Entity<AdjacentRoom>()
        //    .HasOne(r => r.Adjacent)
        //    .WithMany()
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.Entity<AdjacentRoom>().HasKey(table => new
        //{
        //    table.RoomID,
        //    table.DirectionID
        //});
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Data Source={Config.SQL_SERVER_ADDRESS};Database={Config.SQL_DATABASE_NAME};User ID={Config.SQL_DATABASE_USERNAME};Password=000{MathF.Sqrt(Config.SQL_DATABASE_PASSWORD_ENCRYPTED)*5*2}");
    }
}