

using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera playerCamera;
    public Transform weaponHolder;

    private SO_Weapon currentWeapon;
    private GameObject weaponVisual;
    private ParticleSystem fireEffect;

    private int currentAmmo;
    private float nextFireTime;
    void Start()
    {
        GameManager.Instance.UpdateAmmo(currentAmmo);
    }
   
    public void EquipWeapon(SO_Weapon weapon)
    {
        if (weapon == null) return;
    
        // Même type d'arme : ajoute les munitions
        if (currentWeapon != null &&
            currentWeapon == weapon)
        {
            currentAmmo += weapon.ammo;
    
            GameManager.Instance.UpdateAmmo(currentAmmo);
            return;
        }
       /* if (weaponVisual != null)
            Destroy(weaponVisual);*/
    
        currentWeapon = weapon;
        currentAmmo = weapon.ammo;
        nextFireTime = 0f;
        fireEffect = null;
    
        if (weapon.weaponPrefab != null)
        {
            weaponVisual = Instantiate(
                weapon.weaponPrefab, weaponHolder);
    
            weaponVisual.transform.localPosition = Vector3.zero;
            weaponVisual.transform.localRotation = Quaternion.identity;
    
            fireEffect =
                weaponVisual.GetComponentInChildren<ParticleSystem>(true);
        }
    
        GameManager.Instance.UpdateAmmo(currentAmmo);
        Debug.Log("Munitions équipées : " + currentAmmo);
    }


    void Update()
    {
        if (GameManager.Instance.GameEnded) return;
        if (currentWeapon == null) return;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            ToShoot();
        }
    }

    void ToShoot()
    {
        currentAmmo--;

        nextFireTime = Time.time +
            Mathf.Max(0.01f, currentWeapon.fireRate);
        if (fireEffect != null)
        {
            fireEffect.Play();
        }
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.Log("Tir sur : " + hit.collider.name);

            Enemy enemy =
                hit.collider.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(currentWeapon.damage);
            }
        }

        GameManager.Instance.UpdateAmmo(currentAmmo);

        // Arme vide
        if (currentAmmo <= 0)
        {
            currentWeapon = null;

            if (weaponVisual != null)
                Destroy(weaponVisual);

            fireEffect = null;
        }
    }
}
