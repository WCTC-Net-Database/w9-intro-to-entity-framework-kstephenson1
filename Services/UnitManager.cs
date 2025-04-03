using w9_assignment_ksteph.FileIO;
using w9_assignment_ksteph.Models;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Services;

public class UnitManager
{
    // The UnitManager class is a static class that holds lists of units for reference.
    private FileManager<Unit> _unitFileManager;
    public UnitSet<Character> Characters { get; private set; } = new();
    public UnitSet<Monster> Monsters { get; private set; } = new();

    public UnitManager(FileManager<Unit> unitFileManager)
    {
        _unitFileManager = unitFileManager;
    }


    public void ImportUnits()                           //Imports the characters from the csv file and stores them.
    {
        List<Unit> importedUnits = _unitFileManager.Import<Unit>();

        foreach (Unit unit in importedUnits)
        {
            if (unit is Character character)
            {
                Characters.AddUnit(character);
            }

            if (unit is Monster monster)
            {
                Monsters.AddUnit(monster);
            }
        }

        foreach (Unit unit in Characters.Units)
        {
            unit.Stat.MaxHitPoints = unit.Stat.HitPoints;
            unit.Inventory.Unit = unit;
            foreach (IItem item in unit.Inventory.Items!)
            {
                item.Inventory = unit.Inventory;
            }
        }

        foreach (Unit unit in Monsters.Units)
        {
            unit.Stat.MaxHitPoints = unit.Stat.HitPoints;
        }
    }

    public void ExportUnits()                           //Exports the stored characters into the specified csv file
    {
        List<Unit> unitList = new();
        foreach (Unit character in Characters.Units)
        {
            unitList.Add(character);
        }

        foreach (Monster monster in Monsters.Units)
        {
            unitList.Add(monster);
        }
        _unitFileManager.Export(unitList);
    }
}
