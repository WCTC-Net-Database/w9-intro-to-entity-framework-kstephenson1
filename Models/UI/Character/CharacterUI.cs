using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Units.Abstracts;
using W9_assignment_template.Data;

namespace w9_assignment_ksteph.Models.UI.Character;

public class CharacterUI
{
    private GameContext _db;
    // CharacterUI helps display character information in a nice little table.
    public CharacterUI(GameContext context)
    {
        _db = context;
    }

    public void DisplayCharacterInfo(Unit unit) // Displays the character's info
    {
        // Builds a character table with 2 lines: Name, Level and Class.
        Grid charTable = new Grid().Width(25).AddColumn();
        charTable
            .AddRow(new Text(unit.Name).Centered())
                .AddRow(new Text($"Level {unit.Level} {unit.Class}").Centered());

        Stat stat = _db.Stats.FirstOrDefault(s => s.UnitId == unit.UnitId);
        // Builds an hp table that contains the health of the character
        Grid hpTable = new Grid().Width(15).AddColumn();
        hpTable
            .AddRow(new Text($"Hit Points:").Centered())
                .AddRow(new Text($"{stat.HitPoints}/{stat.MaxHitPoints}").Centered());

        //Creates a table that just says "Inventory:" This may be redesigned later.
        Grid invHeader = new Grid().Width(25).AddColumns(2);
        invHeader
            .AddRow(new Text($"  MOV: {stat.Movement}").LeftJustified(), new Text($"CON: {unit.Stat.Constitution}").LeftJustified())
            .AddRow(new Text($"  STR: {stat.Strength}").LeftJustified(), new Text($"MAG: {unit.Stat.Magic}").LeftJustified())
            .AddRow(new Text($"  DEX: {stat.Dexterity}").LeftJustified(), new Text($"SPD: {unit.Stat.Speed}").LeftJustified())
            .AddRow(new Text($"  DEF: {stat.Defense}").LeftJustified(), new Text($"RES: {unit.Stat.Resistance}").LeftJustified())
            .AddRow(new Text($"  LCK: {stat.Luck}").LeftJustified());


        // Creates an inventory table that lists all the items in the character's inventory.
        Grid invTable = new Grid();
        invTable.AddColumn();

        Inventory inventory = _db.Inventories.FirstOrDefault(i => i.UnitId == unit.UnitId);

        if (unit.Inventory.Items!.Count != 0)
        {
            foreach (IItem item in unit.Inventory.Items!)
            {
                invTable.AddRow(item.Name);
            }
        }
        else
        {
            invTable.AddRow("(No Items)");
        }

        // Creates a display table that contains all the other tables to create a nice little display.
        Table displayTable = new Table();
        displayTable
            .AddColumn(new TableColumn(charTable))
            .AddColumn(new TableColumn(hpTable))
            .AddRow(invHeader, invTable);

        // Displays the table to the user.
        AnsiConsole.Write(displayTable);
    }
}
