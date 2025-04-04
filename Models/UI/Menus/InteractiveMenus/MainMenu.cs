﻿using w9_assignment_ksteph.FileIO;
using w9_assignment_ksteph.Models.UI.Character;
using w9_assignment_ksteph.Models.Units.Abstracts;
using w9_assignment_ksteph.Services;

namespace w9_assignment_ksteph.Models.UI.Menus.InteractiveMenus;

public class MainMenu : InteractiveMenu
{
    // The MainMenu contains items that have 4 parts, the index, the name, the description, and the action that
    // is completed when that menu item is chosen.  It loops until the menu is exited.
    private CharacterUtilities _characterUtilities;
    private FileManager<Unit> _unitFileManager;
    private RoomFactory _roomFactory;
    private RoomUI _roomUI;
    public MainMenu(CharacterUtilities characterUtilities, FileManager<Unit> unitFileManager, RoomFactory roomFactory, RoomUI roomUI)
    {
        _characterUtilities = characterUtilities;
        _unitFileManager = unitFileManager;
        _roomFactory = roomFactory;
        _roomUI = roomUI;
    }
    public void AddMenuItem(string name, string desc, Action action)
    {
        _menuItems.Add(new InteractiveSelectionMenuItem<Action>(_menuItems.Count, name, desc, action));
    }

    public void Action(int selection)
    {
        // The Action method takes in a selecion from the main menu, then triggers the action associated with that menu item.
        List<InteractiveSelectionMenuItem<Action>> menuItems = new();

        foreach (MenuItem item in _menuItems) // Casts each of the MenuItems into MainMenuItems so the actions can work.
        {
            menuItems.Add((InteractiveSelectionMenuItem<Action>)item);
        }

        menuItems[selection].Selection(); // Runs the action selected.
    }

    public override void Update(string exitMessage)
    {
        _menuItems = new();
        AddMenuItem("Display Characters", "Displays all characters and items in their inventory.", _characterUtilities.DisplayCharacters);
        AddMenuItem("Display Rooms", "Displays all rooms and their descriptions.", _roomUI.DisplayRooms);
        AddMenuItem("Find Character", "Finds an existing character by name.", _characterUtilities.FindCharacter);
        AddMenuItem("New Character", "Creates a new character.", _characterUtilities.NewCharacter);
        AddMenuItem("New Room", "Creates a new room.", _roomFactory.CreateRoomAndAddToContext);
        AddMenuItem("Level Up Chracter", "Levels an existing character.", _characterUtilities.LevelUp);
        //AddMenuItem("Change File Format", "Changes the file format between Csv and Json", _unitFileManager.SwitchFileType);
        AddMenuItem(exitMessage, "", DoNothing);
        BuildTable(exitMessage);
    }

    protected override bool MenuSelectEnter()
    {
        Action(_selectedIndex);
        return _selectedIndex == _menuItems.Count - 1 ? true : false;
    }

    private void DoNothing() { } // This method does nothing...  or does it?
}

