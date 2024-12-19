using UnityEngine;

[CreateAssetMenu(fileName = "NPCTemplate", menuName = "Scriptable Objects/NPCTemplate")]
public class OrcTemplate : ScriptableObject
{
    public string enemyName;
    public int maxHealth;
    public int damage;
    public float speed;
}
