using UnityEngine;
public class Weapons : MonoBehaviour
{
    public SO_Weapon weaponData;
    public float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Shoot player = other.GetComponentInParent<Shoot>();

        if (player != null && weaponData != null)
        {
            player.EquipWeapon(weaponData);
            Destroy(gameObject);
        }
    }
}


