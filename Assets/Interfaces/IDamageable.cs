public enum DamageType
{
    Slashing = 0,
    Fire,
    Cold,
    Electricity,
    Water,
    Blunt,
    Piercing,
    
}
public interface IDamageable
{
    void TakeDamage(int damage, DamageType damageType = DamageType.Slashing);
}
