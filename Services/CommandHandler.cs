using w9_assignment_ksteph.Models.Commands.ItemCommands;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;
using w9_assignment_ksteph.Models.Interfaces.Commands;
using w9_assignment_ksteph.Models.Interfaces.ItemBehaviors;
using w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;
using w9_assignment_ksteph.Models.UI;
using w9_assignment_ksteph.Services.DataHelpers;

namespace w9_assignment_ksteph.Services;

public class CommandHandler
{
    private UserInterface _userInterface;
    public CommandHandler(UserInterface userInterface)
    {
        _userInterface = userInterface;
    }
    public void HandleCommand(ICommand command, IUnit unit)
	{
        // If the unit is able to move, the unit moves.
        if (command.GetType() == typeof(MoveCommand))
        {
            unit.Move();
        }

        // If the unit has a usable item, it can use an item.
        else if (command.GetType() == typeof(UseItemCommand))
        {
            if (unit.Inventory.Items!.Count > 0)
            {
                // Shows a list of items that are in the selected unit's inventory and asks the user to select an item.
                IItem item = _userInterface.InventoryMenu.Display(unit, $"Select item for {unit.Name}.", "[[Go Back]]");

                // Item is null if the user selects go back.
                if (item != null)
                {
                    // Checks the items to see what commands are allowed, displays those commands to the user and asks for a selection
                    ICommand itemCommand = _userInterface.ItemCommandMenu.Display(item, $"Select action for {unit.Name} to use on {item.Name}", "[[Go Back]]");

                    // Command is null if the user selects "Go Back"
                    if (itemCommand != null)
                    {
                        // The selected command is executed by the selected unit.
                        switch (itemCommand)
                        {
                            case EquipCommand:
                                unit.Equip((item as IEquippableItem)!);
                                break;
                            case UseItemCommand:
                                unit.UseItem(item);
                                break;
                            case TradeItemCommand:
                                IUnit tradeTarget = _userInterface.UnitSelectionMenu.Display($"Select unit to trade {item} to.", "[[Go Back]]");
                                unit.TradeItem(item, tradeTarget);
                                break;
                            case DropItemCommand:
                                unit.DropItem(item);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"{unit.Name} has no usable items!");
            }

        }// If the unit is able to attack, it attacks.
        else if (command.GetType() == typeof(AttackCommand))
        {
            if (unit is IAttack)
            {
                IUnit targetUnit = _userInterface.UnitSelectionMenu.Display($"Select unit being attacked by {unit.Name}", "[[Go Back]]");
                if (targetUnit != null)
                {
                    unit.Attack(targetUnit);
                }
            }
        }
        // If the unit is able to heal, it heals.
        else if (command.GetType() == typeof(HealCommand))
        {
            IUnit targetUnit = _userInterface.UnitSelectionMenu.Display($"Select unit being healed by {unit.Name}", "[[Go Back]]");
            if (targetUnit != null)
            {
                ((IHeal)unit).Heal(targetUnit);
            }
        }
        // If the unit is able to cast spells, it casts a spell.
        else if (command.GetType() == typeof(CastCommand))
        {
            string spell = Input.GetString($"Enter name of spell being cast by {unit.Name}: ");
            ((ICastable)unit).Cast(spell);
        }
    }
}
