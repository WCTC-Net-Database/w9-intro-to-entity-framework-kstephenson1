using w9_assignment_ksteph.DataTypes;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Models.Items.WeaponItems;

namespace w9_assignment_ksteph.Models.Combat;

public class Encounter
{
    // The encounter class is used to store and calculate information about combat encounters.  This object takes in an attacking attackingUnit,
    // defendingUnit attackingUnit and will be able to generate combat chances and damages.

    private Random _generator = new Random();
    private Dictionary<Tuple<WeaponType, WeaponType>, int> dict = new();
    public int Roll;
    public IEntity Unit { get; set; }
    public IEntity Target { get; set; }
    public int Damage => RollDamage();
    public IEquippableItem? UnitWeapon { get; set; }
    public IEquippableItem? TargetWeapon { get; set; }

    public Encounter(IEntity unit, IEntity target)
    {
        Roll = _generator.Next(100) + 1;
        Unit = unit;
        Target = target;

        try
        {
            Unit.Inventory.IsEquipped(out IEquippableItem unitEquippedItem);
            UnitWeapon = unitEquippedItem;
            Target.Inventory.IsEquipped(out IEquippableItem targetEquippedItem);
            TargetWeapon = targetEquippedItem;
        }
        catch
        {
            return;
        }

        Tuple<WeaponType, WeaponType> swordVsAxe = new(WeaponType.Sword, WeaponType.Axe);
        Tuple<WeaponType, WeaponType> swordVsLance = new(WeaponType.Sword, WeaponType.Lance);
        Tuple<WeaponType, WeaponType> axeVsSword = new(WeaponType.Axe, WeaponType.Sword);
        Tuple<WeaponType, WeaponType> axeVsLance = new(WeaponType.Axe, WeaponType.Lance);
        Tuple<WeaponType, WeaponType> LanceVsSword = new(WeaponType.Lance, WeaponType.Sword);
        Tuple<WeaponType, WeaponType> LanceVsAxe = new(WeaponType.Lance, WeaponType.Axe);

        Tuple<WeaponType, WeaponType> eleVsLight = new(WeaponType.Elemental, WeaponType.Light);
        Tuple<WeaponType, WeaponType> eleVsDark = new(WeaponType.Elemental, WeaponType.Dark);
        Tuple<WeaponType, WeaponType> lightVsEle = new(WeaponType.Light, WeaponType.Elemental);
        Tuple<WeaponType, WeaponType> lightVsDark = new(WeaponType.Light, WeaponType.Dark);
        Tuple<WeaponType, WeaponType> darkVsEle = new(WeaponType.Dark, WeaponType.Elemental);
        Tuple<WeaponType, WeaponType> darkVsLight = new(WeaponType.Dark, WeaponType.Light);

        dict.Add(swordVsAxe, 1);
        dict.Add(axeVsLance, 1);
        dict.Add(LanceVsSword, 1);
        dict.Add(swordVsLance , -1);
        dict.Add(LanceVsAxe, -1);
        dict.Add(axeVsSword , -1);

        dict.Add(eleVsLight , 1);
        dict.Add(lightVsDark, 1);
        dict.Add(darkVsEle, 1);
        dict.Add(eleVsDark , -1);
        dict.Add(darkVsLight, -1);
        dict.Add(lightVsEle , -1);
    }


    public int RollDamage()
    {
        if (IsCrit())
        {
            if (UnitWeapon is WeaponItem)
            {
                return (int)MathF.Max(GetDamage(), 0) + (int)MathF.Max(GetDamage(), 0);
            }
            else if (UnitWeapon is MagicWeaponItem)
            {
                return (int)MathF.Max(GetMagicDamage(), 0) + (int)MathF.Max(GetMagicDamage(), 0);
            }
            
        }
        else if (IsHit())
        {
            if (UnitWeapon is WeaponItem)
            {
                return (int)MathF.Max(GetDamage(), 0);
            }
            else if (UnitWeapon is MagicWeaponItem)
            {
                return (int)MathF.Max(GetMagicDamage(), 0);
            }
        }
        return 0;
    }

    public bool IsCrit()
    {
        bool crit = Roll > MathF.Abs(GetDisplayedCrit() - 100) ? true : false;
        return crit;
    }

    public bool IsHit()
    {
        bool hit = Roll > MathF.Abs(GetDisplayedHit() - 100) ? true : false;
        return hit;
    }

    public int GetTriangleDamageModifier()
    {

        if (UnitWeapon == null || TargetWeapon == null) return 0;

        Tuple<WeaponType,WeaponType> weapons = new(UnitWeapon.WeaponType, TargetWeapon.WeaponType);
        dict.TryGetValue(weapons, out int value);
        if (value != 0) return value;
        return 0;
    }

    public int GetTriangleHitModifier()
    {
        return GetTriangleDamageModifier() * 15;
    }

    public int GetAttack()
    {
        // Attack damage = Attacking unit's strength + (Equipped item's might + bonus if the weapon type has an advantage against the defender's)
        int weaponEfficiency = 1; // for future implementation?
        return Unit.Stats.Strength + weaponEfficiency * (UnitWeapon.Might + GetTriangleDamageModifier());
    }

    public int GetMagicAttack()
    {
        // Attack damage = Attacking unit's magic + (Equipped item's might + bonus if the weapon type has an advantage against the defender's)
        int weaponEfficiency = 1; // for future implementation?
        return Unit.Stats.Magic + weaponEfficiency * (UnitWeapon.Might + GetTriangleDamageModifier());
    }

    public int GetPhysicalResiliance(IEntity unit)
    {
        // Physical Resiliance = unit's Defense stat
        int terrainBonus = 1; // for future implementation?
        return unit.Stats.Defense * terrainBonus;
    }

    public int GetMagicResiliance(IEntity unit)
    {
        // Magic Resiliance = Resistance stat
        int terrainBonus = 1; // for future implementation?
        return unit.Stats.Resistance * terrainBonus;
    }

    public int GetDamage()
    {
        // Damage = Attacking Unit's Attack minus Defending Unit's Physical Resiliance
        return GetAttack() - GetPhysicalResiliance(Target);
    }

    public int GetMagicDamage()
    {
        // Damage = Attacking Unit's Attack minus Defending Unit's Physical Resiliance
        return GetMagicAttack() - GetMagicResiliance(Target);
    }

    public int GetAttackSpeed()
    {
        // Attack speed = speed - (weapon's weight - unit's constitution [min 0])
        return Unit.Stats.Speed - (int)MathF.Max(UnitWeapon.Weight - Unit.Stats.Constitution, 0);
    }

    public int GetHit()
    {
        // Hit chance = weapon's hit + 2 x attacking unit's DEX + attacking unit's LCK / 2 + weapon advantage modifier of 15%
        return UnitWeapon.Hit + 2 * Unit.Stats.Dexterity + Unit.Stats.Luck / 2 + GetTriangleHitModifier();
    }

    public int GetAvoid()
    {
        // Avoid = 2 * Atk Speed + Luck + Terrain Modifier
        int terrainAvoidModifier = 0;// for future implementation?
        return 2 * GetAttackSpeed() + Unit.Stats.Luck + terrainAvoidModifier;
    }

    public int GetDisplayedHit()
    {
        return GetHit() - GetAvoid();
    }

    public int GetCrit()
    {
        return UnitWeapon.Crit + Unit.Stats.Dexterity * 2;
    }

    public int GetCritAvoid()
    {
        return Unit.Stats.Luck;
    }

    public int GetDisplayedCrit()
    {
        return GetHit() / 100 * GetCrit();
    }
}
