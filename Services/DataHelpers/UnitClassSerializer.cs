namespace w9_assignment_ksteph.Services.DataHelpers;

using w9_assignment_ksteph.Models.Units.Characters;
using w9_assignment_ksteph.Models.Units.Monsters;

public static class UnitClassSerializer
{
    // UnitClassSerializer contains fuctions to turn a string into UnitClassType and vice versa.
    public static Type Deserialize(string inventoryString)         // Converts String into UnitClassType
    {
        return inventoryString switch
        {
            "Characters.Cleric" => typeof(Cleric),
            "Characters.Fighter" => typeof(Fighter),
            "Characters.Knight" => typeof(Knight),
            "Characters.Rogue" => typeof(Rogue),
            "Characters.Wizard" => typeof(Wizard),

            "Monsters.EnemyArcher" => typeof(EnemyArcher),
            "Monsters.EnemyCleric" => typeof(EnemyCleric),
            "Monsters.EnemyGhost" => typeof(EnemyGhost),
            "Monsters.EnemyGoblin" => typeof(EnemyGoblin),
            "Monsters.EnemyMage" => typeof(EnemyMage),
            _ => throw new NotSupportedException($"Type {inventoryString} is not supported")
        };
        throw new NotSupportedException($"Type {inventoryString} is not supported");
    }

    public static string? Serialize(Type unitType)                // Converts Inventories into String
    {
        return unitType.ToString();
    }

}
