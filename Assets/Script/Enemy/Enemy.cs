
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SO_Enemy enemyData;

    [Header("Hit Flash")]
    [SerializeField] private Renderer enemyRenderer;
    [SerializeField] private Material flashMaterial;

    private Material originalMaterial;
    private float currentHealth;
    private float flashTimer;

    void Start()
    {
        currentHealth = enemyData.healthPoint;
        originalMaterial = enemyRenderer.sharedMaterial;
    }

    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;

            if (flashTimer <= 0)
                enemyRenderer.sharedMaterial = originalMaterial;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        enemyRenderer.sharedMaterial = flashMaterial;
        flashTimer = 0.1f;

        if (currentHealth <= 0)
        {
            GameManager.Instance.EnemyKilled();
            Destroy(gameObject);
        }
    }
}

