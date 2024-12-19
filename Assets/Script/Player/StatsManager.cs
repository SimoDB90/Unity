using System;
using System.Collections.Generic;


public static class StatsManager
{
    private static readonly Dictionary<StatType, int> stats = new();
    static StatsManager()
    {
        stats[StatType.Health] = 100;
        stats[StatType.Mana] = 100;
        stats[StatType.Speed] = 10;
    }
    public static int GetStatValue(StatType type)
    {
        if(stats.ContainsKey(type)) return stats[type];
        else throw new Exception($"Statistica {type} non trovata!");
    }
    public static void SetStatValue(StatType statType, int value)
    {
        if (stats.ContainsKey(statType))
        {
            stats[statType] = value;
        }
        else
        {
            throw new Exception($"Statistica {statType} non trovata!");
        }
    }

    // Metodo per aumentare una statistica
    public static void IncreaseStat(StatType statType, int amount)
    {
        if (stats.ContainsKey(statType))
        {
            stats[statType] += amount;
        }
        else
        {
            throw new Exception($"Statistica {statType} non trovata!");
        }
    }

    // Metodo per diminuire una statistica
    public static void DecreaseStat(StatType statType, int amount)
    {
        if (stats.ContainsKey(statType))
        {
            stats[statType] -= amount;
            if (stats[statType] < 0)
                stats[statType] = 0; // Non permettere valori negativi
        }
        else
        {
            throw new Exception($"Statistica {statType} non trovata!");
        }
    }
}