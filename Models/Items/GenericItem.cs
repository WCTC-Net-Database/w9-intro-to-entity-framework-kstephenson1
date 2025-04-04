namespace w9_assignment_ksteph.Models.Items
{
    public class GenericItem : Item
    {
        public override string ItemType { get; set; } = "GenericItem";
        public GenericItem(string name) : base(name)
        {

        }

        public GenericItem(string name, string desc) : base(name, desc)
        {

        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
