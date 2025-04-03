namespace w9_assignment_ksteph.Services;

using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.UI.Character;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services.DataHelpers;
using W9_assignment_template.Data;

public class CharacterUtilities
{
    private CharacterUI _characterUI;
    private GameContext _db;
    private LevelUpMenu _levelUpMenu;
    private UnitClassMenu _unitClassMenu;
    // CharacterFunctions class contains fuctions that manipulate characters based on user input.

    public CharacterUtilities(CharacterUI characterUI, GameContext db, UnitClassMenu unitClassMenu, LevelUpMenu levelUpMenu)
    {
        _characterUI = characterUI;
        _db = db;
        _levelUpMenu = levelUpMenu;
        _unitClassMenu = unitClassMenu;
    }
    public void NewCharacter() // Creates a new character.  Asks for name, class, level, hitpoints, and items.
    {
        string name = Input.GetString("Enter your character's name: ");
        Type characterClass = _unitClassMenu.Display($"Please select a class for {name}", "[[Cancel Character Creation]]");
        if (characterClass == null) return;
        int level = Input.GetInt("Enter your character's level: ", 1, Config.CHARACTER_LEVEL_MAX, $"character level must be 1-{Config.CHARACTER_LEVEL_MAX}");
        int hitPoints = Input.GetInt("Enter your character's maximum hit points: ", 1, "must be greater than 0");
        Inventory inventory = new();

        while (true)
        {
            string? newItem = Input.GetString($"Enter the name of an item in {name}'s inventory. (Leave blank to end): ", false);
            if (newItem != "")
            {
                inventory.AddItem(new Item(newItem));
                continue;
            }
            break;
        }

        Console.Clear();
        Console.WriteLine($"\nWelcome, {name} the {characterClass.Name}! You are level {level} and your equipment includes: {string.Join(", ", inventory)}.\n");

        //_unitManager.Characters.AddUnit(new(name, characterClass, level, hitPoints, inventory));
        dynamic character = Activator.CreateInstance(characterClass);
        character.Name = name;
        character.Class = characterClass.Name;
        character.Level = level;
        character.Stats = new Stat();
        character.Stats.HitPoints = hitPoints;
        character.Stats.MaxHitPoints = hitPoints;
        character.Inventory = inventory;

        _db.Units.Add(character);
    }

    public T CastObject<T>(object input)
    {
        return (T) input;
    }

    public void FindCharacter() // Asks the user for a name and displays a character based on input.
    {
        string characterName = Input.GetString("What is the name of the character you would like to search for? ");
        Unit character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            _characterUI.DisplayCharacterInfo(character);
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}\n[/]");
        }
    }

    private Unit? FindCharacterByName(string name) // Finds and returns a character based on input.
    {
        var unit = _db.Units.Where(c => c.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
        return unit;
    }

    public void LevelUp() //Asks the user for a character to level up, then displays that character.
    {
        string characterName = Input.GetString("What is the name of the character that you would like to level up? ");
        Unit unit = FindCharacterByName(characterName)!;
        Console.Clear();

        if (unit != null)
        {
            if (unit.Level < Config.CHARACTER_LEVEL_MAX)
            {
                int levelModifier = _levelUpMenu.Display($"Choose how to change the level for {unit.Name}", "Go Back");
                _db.Units.Update(unit);
                unit.Level += levelModifier;
                switch (levelModifier)
                {
                    case -1:
                        AnsiConsole.MarkupLine($"[Red]Yikes! {unit.Name} has been demoted to level {unit.Level}[/]\n");
                        break;
                    case 1:
                        AnsiConsole.MarkupLine($"[Green]Congratulations! {unit.Name} has reached level {unit.Level}[/]\n");
                        break;
                    default:
                        AnsiConsole.MarkupLine($"[White]{unit.Name} remains the same level[/]\n");
                        break;
                }
                _characterUI.DisplayCharacterInfo(unit);
                _db.SaveChanges();
            }
            else
            {
                AnsiConsole.MarkupLine($"[Red]{unit.Name} is already max level! ({Config.CHARACTER_LEVEL_MAX})[/]\n");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}[/]\n");
        }
    }

    public void DisplayCharacters()                       //Displays each c's information.
    {
        Console.Clear();
        var units = _db.Units.ToList();

        foreach (Unit unit in units)
        {
            _characterUI.DisplayCharacterInfo(unit);
        }
    }
}
