
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData",
    menuName = "Scriptable Objects/Weapon")]
public class SO_Weapon : ScriptableObject
{
    public string weaponName = "Pistol";
    public int ammo = 6;
    public float damage = 25f;
    public float fireRate = 0.25f;
    public GameObject weaponPrefab;
}