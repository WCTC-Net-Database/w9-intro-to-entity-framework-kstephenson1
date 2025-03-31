using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;
using w9_assignment_ksteph.DataTypes.Structs;
using w9_assignment_ksteph.FileIO.Csv.Converters;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Commands.Invokers;
using w9_assignment_ksteph.Models.Commands.ItemCommands;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.InventoryBehaviors;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Models.Interfaces.Rooms;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Models.Inventories;

namespace w9_assignment_ksteph.Models.Units.Abstracts;

public abstract class UnitBase : IEntity, ITargetable, IAttack, IHaveInventory
{
    // Unit is an abstract class that holds basic unit properties and functions.

    [Name("Name")]                                          // CsvHelper Attribute
    public virtual string Name { get; set; }

    [Name("Class")]                                         // CsvHelper Attribute
    public virtual string Class { get; set; }

    [Name("Level")]                                         // CsvHelper Attribute
    public virtual int Level { get; set; }

    [Name("Inventory")]                                     // CsvHelper Attribute
    [JsonPropertyName("Inventory")]                         // Json Atribute
    [TypeConverter(typeof(CsvInventoryConverter))]          // CsvHelper Attribute that helps CsvHelper import a new inventory object instead of a string.
    public virtual Inventory Inventory { get; set; } = new();

    [Name("Position")]                                         // CsvHelper Attribute
    [JsonPropertyName("Position")]                         // Json Atribute
    [TypeConverter(typeof(CsvPositionConverter))]          // CsvHelper Attribute that helps CsvHelper import a new Position struct instead of a string.

    [Ignore]
    [JsonIgnore]
    public IRoom? CurrentRoom { get; set; }
    public virtual Position Position { get; set; } = new();

    [Ignore]
    [JsonIgnore]
    public virtual CommandInvoker Invoker { get; set; } = new();

    [Ignore]
    [JsonIgnore]
    public virtual UseItemCommand UseItemCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public virtual EquipCommand EquipCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]

    public virtual DropItemCommand DropItemCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public virtual TradeItemCommand TradeItemCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public virtual AttackCommand AttackCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public virtual MoveCommand MoveCommand { get; set; } = null!;

    public Stats Stats { get; set; } = null!;

    public UnitBase()
    {
        Inventory.Unit = this;
    }

    public UnitBase(string name, string characterClass, int level, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Inventory.Unit = this;
    }

    public UnitBase(string name, string characterClass, int level, Inventory inventory, Position position, Stats stats)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        Inventory = inventory;
        Position = position;
        Stats = stats;
        Inventory.Unit = this;
    }

    // Attacks the target unit.
    public virtual void Attack(IEntity target)
    {
        AttackCommand = new(this, target);
        Invoker.ExecuteCommand(AttackCommand);
    }

    // Moves the unit to a position.
    public virtual void Move()
    {
        MoveCommand = new(this);
        Invoker.ExecuteCommand(MoveCommand);
    }

    // Has the unit take damage then check if it is dead.
    public virtual void Damage(int damage)
    {
        Stats.HitPoints -= damage;
        OnHealthChanged();

        if (IsDead())
            OnDeath();
    }

    public virtual void Heal(int heal)
    {
        Stats.HitPoints += heal;
        OnHealthChanged();
    }

    // Triggers every time this unit takes damage.
    public virtual void OnHealthChanged()
    {
        if (Stats.HitPoints > Stats.MaxHitPoints)
            Stats.HitPoints = Stats.MaxHitPoints;
        if (Stats.HitPoints <= 0)
            Stats.HitPoints = 0;
    }

    // Triggers when this unit dies.
    public virtual void OnDeath()
    {

    }

    // Function to check to see if unit should be dead.
    public bool IsDead()
    {
        return Stats.HitPoints <= 0;
    }

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{Stats.HitPoints},{Inventory}";
    }

    public string GetHealthBar()
    {
        string bar = "[[";
        for (int i = 0; i < Stats.MaxHitPoints; i++)
        {
            if (i != 0 && i % 30 == 0)
                bar += "\n  ";
            if (i < Stats.HitPoints)
                bar += "[green]■[/]";
            else
                bar += "[red3]■[/]";
        }
        bar += "]]";

        if (Stats.HitPoints <= 0)
        {
            return $"[dim]{bar}[/]";
        }
        return bar;
    }

    public void Equip(IEquippableItem item)
    {
        EquipCommand = new(this, item);
        Invoker.ExecuteCommand(EquipCommand);
    }

    public void DropItem(IItem item)
    {
        DropItemCommand = new(this, item);
        Invoker.ExecuteCommand(DropItemCommand);
    }

    public void TradeItem(IItem item, IEntity target)
    {
        TradeItemCommand = new(this, item, target);
        Invoker.ExecuteCommand(TradeItemCommand);
    }

    public void UseItem(IItem item)
    {
        UseItemCommand = new(item);
        Invoker.ExecuteCommand(UseItemCommand);
    }

}
