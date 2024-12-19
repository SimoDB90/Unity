using UnityEngine;

[RequireComponent(typeof(EnemiesStatsRandomizer))]
public class ContactWound : MonoBehaviour
{
    private EnemiesStatsRandomizer stats;
    private void Awake()
    {
        stats = GetComponent<EnemiesStatsRandomizer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(stats.damage);
        }
    }
    
}
