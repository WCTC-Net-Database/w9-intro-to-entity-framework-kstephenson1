using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using w9_assignment_ksteph.Models.Units.Abstracts;

namespace w9_assignment_ksteph.Models.Combat;

public class Stat
{
    [Key, ForeignKey("Unit")]
    public int UnitId { get; set; }

    // Navigation
    public Unit Unit { get; set; }

    // Health Stats
    public int HitPoints  { get; set; }         //  HP
    public int MaxHitPoints { get; set; }       // MHP
    public int Movement { get; set; }           // MOV

    // Primary Stats
    public int Constitution { get; set; }       // CON
    public int Strength { get; set; }           // STR
    public int Magic { get; set; }              // MAG
    public int Dexterity { get; set; }          // DEX
    public int Speed { get; set; }              // SPD
    public int Luck { get; set; }               // LCK
    public int Defense { get; set; }            // DEF
    public int Resistance { get; set; }         // RES

    public Stat()
    {

    }
}