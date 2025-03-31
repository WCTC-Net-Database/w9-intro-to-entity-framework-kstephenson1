using Microsoft.EntityFrameworkCore;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Rooms;

namespace W9_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Dungeon> Dungeons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    //public DbSet<UnitBase> Characters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Data Source={Config.SQL_SERVER_ADDRESS};Database={Config.SQL_DATABASE_NAME};User ID={Config.SQL_DATABASE_USERNAME};{MathF.Sqrt(Config.SQL_DATABASE_PASSWORD_ENCRYPTED)*5*2}");
    }
}