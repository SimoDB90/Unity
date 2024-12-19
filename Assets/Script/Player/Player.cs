using UnityEngine;


public class Player : MonoBehaviour, IDamageable
{
    // Esponi le statistiche nell'Inspector
    [Header("Player Statistics")]
    public int health;
    public int mana;
    public float speed;

    private void Start()
    {
        health = StatsManager.GetStatValue(StatType.Health);
        mana = StatsManager.GetStatValue(StatType.Mana);
        speed = StatsManager.GetStatValue(StatType.Speed);
    }
    public void TakeDamage(int damage, DamageType damageType)
    {
        StatsManager.DecreaseStat(StatType.Health, damage);
        health = StatsManager.GetStatValue(StatType.Health);
        Debug.Log($"Danno subito: {damage} ({damageType}). Salute attuale: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Il giocatore è morto!");
        // Gestisci la morte del giocatore
        // Ad esempio, disabilita il personaggio o mostra la schermata di game over
    }
}