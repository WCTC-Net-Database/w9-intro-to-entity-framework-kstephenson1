namespace w9_assignment_ksteph.Services;

using Spectre.Console;
using w9_assignment_ksteph.Configuration;
using w9_assignment_ksteph.Models.Combat;
using w9_assignment_ksteph.Models.Inventories;
using w9_assignment_ksteph.Models.Items;
using w9_assignment_ksteph.Models.UI.Character;
using w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services.DataHelpers;

public class CharacterUtilities
{
    private CharacterUI _characterUI;
    private UnitManager _unitManager;
    private UnitClassMenu _unitClassMenu;
    // CharacterFunctions class contains fuctions that manipulate characters based on user input.

    public CharacterUtilities(CharacterUI characterUI, UnitManager unitManager, UnitClassMenu unitClassMenu)
    {
        _characterUI = characterUI;
        _unitManager = unitManager;
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
        character.Stats = new Stats();
        character.Stats.HitPoints = hitPoints;
        character.Stats.MaxHitPoints = hitPoints;
        character.Inventory = inventory;

        _unitManager.Characters.AddUnit(character);
    }

    public T CastObject<T>(object input)
    {
        return (T) input;
    }

    public void FindCharacter() // Asks the user for a name and displays a character based on input.
    {
        string characterName = Input.GetString("What is the name of the character you would like to search for? ");
        CharacterBase character = FindCharacterByName(characterName)!;
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

    private CharacterBase? FindCharacterByName(string name) // Finds and returns a character based on input.
    {
        return _unitManager.Characters.Units.Where(character => string.Equals(character.Name, name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    }

    public void LevelUp() //Asks the user for a character to level up, then displays that character.
    {
        string characterName = Input.GetString("What is the name of the character that you would like to level up? ");
        CharacterBase character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            if (character.Level < Config.CHARACTER_LEVEL_MAX)
            {
                character.Level++;
                AnsiConsole.MarkupLine($"[Green]Congratulations! {character.Name} has reached level {character.Level}[/]\n");
                _characterUI.DisplayCharacterInfo(character);
            }
            else
            {
                AnsiConsole.MarkupLine($"[Red]{character.Name} is already max level! ({Config.CHARACTER_LEVEL_MAX})[/]\n");
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

        foreach (CharacterBase character in _unitManager.Characters.Units)
        {
            _characterUI.DisplayCharacterInfo(character);
        }
    }
}
