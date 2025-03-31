namespace w9_assignment_ksteph.Models.Interfaces.UnitBehaviors
{
    public interface ITargetable
    {
        // Interface tha allows units to be attacked.
        public void Damage(int damage);
        public void Heal(int damage);
        void OnHealthChanged();
        void OnDeath();
        bool IsDead();

    }
}
