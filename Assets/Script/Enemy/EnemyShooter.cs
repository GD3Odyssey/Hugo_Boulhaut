
using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    public float shootInterval = 2f;
    public float bulletSpeed = 12f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Transform player;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        if (obj != null)
        {
            player = obj.transform;
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(
                Mathf.Max(0.1f, shootInterval));

            if (player == null || bulletPrefab == null ||
                firePoint == null) continue;

            // Position enregistrée au moment du tir
            Vector3 targetPosition = player.position;

            Vector3 direction =
                (targetPosition - firePoint.position).normalized;

            GameObject bullet = Instantiate(
                bulletPrefab, firePoint.position,
                Quaternion.LookRotation(direction));

            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.useGravity = false;
                rb.linearVelocity = direction * bulletSpeed;
            }
        }
    }
}
