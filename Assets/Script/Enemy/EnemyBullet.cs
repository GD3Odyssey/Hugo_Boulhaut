
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 20;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!other.isTrigger &&
                 other.GetComponentInParent<Enemy>() == null)
        {
            Destroy(gameObject);
        }
    }
}

