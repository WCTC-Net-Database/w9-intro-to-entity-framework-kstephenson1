using Spectre.Console;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.UI.Character;

public class CharacterUI
{
    // CharacterUI helps display character information in a nice little table.

    public void DisplayCharacterInfo(CharacterBase character) // Displays the character's info
    {
        // Builds a character table with 2 lines: Name, Level and Class.
        Grid charTable = new Grid().Width(25).AddColumn();
        charTable
            .AddRow(new Text(character.Name).Centered())
                .AddRow(new Text($"Level {character.Level} {character.Class}").Centered());

        // Builds an hp table that contains the health of the character
        Grid hpTable = new Grid().Width(15).AddColumn();
        hpTable
            .AddRow(new Text($"Hit Points:").Centered())
                .AddRow(new Text($"{character.Stats.HitPoints}/{character.Stats.MaxHitPoints}").Centered());

        //Creates a table that just says "Inventory:" This may be redesigned later.
        Grid invHeader = new Grid().Width(25).AddColumns(2);
        invHeader
            .AddRow(new Text($"  MOV: {character.Stats.Movement}").LeftJustified(), new Text($"CON: {character.Stats.Constitution}").LeftJustified())
            .AddRow(new Text($"  STR: {character.Stats.Strength}").LeftJustified(), new Text($"MAG: {character.Stats.Magic}").LeftJustified())
            .AddRow(new Text($"  DEX: {character.Stats.Dexterity}").LeftJustified(), new Text($"SPD: {character.Stats.Speed}").LeftJustified())
            .AddRow(new Text($"  DEF: {character.Stats.Defense}").LeftJustified(), new Text($"RES: {character.Stats.Resistance}").LeftJustified())
            .AddRow(new Text($"  LCK: {character.Stats.Luck}").LeftJustified());


        // Creates an inventory table that lists all the items in the character's inventory.
        Grid invTable = new Grid();
        invTable.AddColumn();

        if (character.Inventory.Items!.Count != 0)
        {
            foreach (IItem item in character.Inventory.Items!)
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
