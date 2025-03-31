using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w9_assignment_ksteph.FileIO.Csv;

namespace w9_assignment_ksteph.DataTypes.Structs;

public struct Position
{
    // Position is a simple struct that holds an x and z value.  This class includes a few operator methods to make Position manipulating easier.

    public int x;
    public int z;

    public Position(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    // Checks to see if a Position and an Object are equal
    public override bool Equals(object? obj)
    {
        return obj is Position position &&
            x == position.x &&
            z == position.z;
    }

    // Checks to see if two Positions are equal
    public bool Equals(Position position)
    {
        return this == position;
    }

    // An operator that takes in two positions and returns whether it is equal.
    public static bool operator == (Position a, Position b)
    {
        return a.x == b.x && a.z == b.z;
    }

    // An operator that takes in two positions and returns whether it is not equal.
    public static bool operator != (Position a, Position b)
    {
        return !(a == b);
    }

    // An operator that takes in two positions and returns the sum.
    public static Position operator + (Position a, Position b)
    {
        return new Position(a.x + b.x, a.z + b.z);
    }

    // An operator that takes in two positions and returns the difference.
    public static Position operator - (Position a, Position b)
    {
        return new Position(a.x - b.x, a.z - b.z);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public override string ToString()
    {
        return $"[{x}, {z}]";
    }
}
