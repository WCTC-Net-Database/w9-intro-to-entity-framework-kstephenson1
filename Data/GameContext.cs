using Microsoft.EntityFrameworkCore;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Dungeons;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.Items.ConsumableItems;
using w9_assignment_ksteph.Models.Items.WeaponItems;
using w9_assignment_ksteph.Models.Rooms;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Models.Units.Characters;
using w9_assignment_ksteph.Models.Units.Monsters;

namespace W9_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Dungeon> Dungeons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    public GameContext() { }
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Unit>()
            .HasDiscriminator(unit => unit.UnitType)
            .HasValue<Cleric>(nameof(Cleric))
            .HasValue<Fighter>(nameof(Fighter))
            .HasValue<Knight>(nameof(Knight))
            .HasValue<Rogue>(nameof(Rogue))
            .HasValue<Wizard>(nameof(Wizard))

            .HasValue<EnemyArcher>(nameof(EnemyArcher))
            .HasValue<EnemyCleric>(nameof(EnemyCleric))
            .HasValue<EnemyGhost>(nameof(EnemyGhost))
            .HasValue<EnemyGoblin>(nameof(EnemyGoblin))
            .HasValue<EnemyMage>(nameof(EnemyMage));

        builder.Entity<Item>()
            .HasDiscriminator(item => item.ItemType)
            .HasValue<GenericItem>(nameof(GenericItem))

            .HasValue<ItemBook>(nameof(ItemBook))
            .HasValue<ItemLockpick>(nameof(ItemLockpick))
            .HasValue<ItemPotion>(nameof(ItemPotion))

            .HasValue<MagicWeaponItem>(nameof(MagicWeaponItem))
            .HasValue<WeaponItem>(nameof(WeaponItem));
    }
}