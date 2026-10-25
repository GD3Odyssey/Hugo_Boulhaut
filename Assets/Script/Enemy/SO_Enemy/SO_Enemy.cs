using UnityEngine;
 
[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class SO_Enemy : ScriptableObject
{
    [Header("Enemy Stat")]
    public float damage;
    public float healthPoint;
 
    public void Kratos()
    {
        damage = 50;
        healthPoint = 50;
    }
 
}