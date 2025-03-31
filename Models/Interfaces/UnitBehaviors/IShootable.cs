using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.Models.Commands.Invokers;
using w9_assignment_ksteph.Models.Commands.UnitCommands;
using w9_assignment_ksteph.Models.Interfaces;

namespace w9_assignment_ksteph.Models.Interfaces.UnitBehaviors;

public interface IShootable
{
    // Interface tha allows units to shoot.
    CommandInvoker Invoker { set; get; }
    ShootCommand ShootCommand { set; get; }
    void Shoot(IEntity target);
}
