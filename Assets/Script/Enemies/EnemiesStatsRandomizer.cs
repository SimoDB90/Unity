using UnityEngine;

public class EnemiesStatsRandomizer : MonoBehaviour, IDamageable
{
    public OrcTemplate enemyData; // Riferimento al file .asset
    public int currentHealth;
    public int damage;
    public float moveSpeed;

    public void TakeDamage(int damageTaken, DamageType damageType)
    {
        currentHealth -= damageTaken;
        currentHealth = Mathf.Max(currentHealth, 0); // Non scendere sotto 0
        Debug.Log($"{enemyData.enemyName} Health: {currentHealth}");

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{enemyData.enemyName} is dead!");
        Destroy(gameObject); // Elimina l'NPC dalla scena
    }

    private void Start()
    {
        currentHealth = enemyData.maxHealth + Random.Range(-10, 10);
        damage = enemyData.damage + Random.Range(-3, 3);
        moveSpeed = enemyData.speed + Random.Range(-2, 2);
    }
}
