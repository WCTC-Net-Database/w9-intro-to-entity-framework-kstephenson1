using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace w9_assignment_ksteph.DataTypes
{
    public enum WeaponRank
    {
        [EnumMember(Value = "E")]
        E = 0,
        [EnumMember(Value = "D")]
        D = 1,
        [EnumMember(Value = "C")]
        C = 2,
        [EnumMember(Value = "B")]
        B = 3,
        [EnumMember(Value = "A")]
        A = 4,
        [EnumMember(Value = "S")]
        S = 5,
    }
}
