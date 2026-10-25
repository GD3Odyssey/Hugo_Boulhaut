
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        GameManager.Instance.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        GameManager.Instance.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
