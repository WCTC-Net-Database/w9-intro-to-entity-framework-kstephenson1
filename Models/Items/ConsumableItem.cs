namespace w9_assignment_ksteph.Models.Items;

public abstract class ConsumableItem : Item
{
    public virtual int MaxUses { get; set; }
    public virtual int UsesLeft { get; set; }
    protected ConsumableItem()
    {
        
    }

    protected ConsumableItem(string name, string desc) : base(name, desc)
    {
        
    }
}
