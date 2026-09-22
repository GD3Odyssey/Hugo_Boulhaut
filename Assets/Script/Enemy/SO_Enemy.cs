using UnityEngine;
 
[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class SO_Enemy : ScriptableObject
{
    [Header("Enemy Stat")]
    public float power;
    public float defense;
    public float healthPoint;
    public float speed;
 
    [Header("Appareance")]
    public Mesh mesh;
 
    public void Kratos()
    {
        power = 999;
        defense = 999;
        healthPoint = 999;
        speed = 999;
    }
 
    public void SamusAran()
    {
        power = 500;
        defense = 150;
        healthPoint = 450;
        speed = 650;
    }
 
}