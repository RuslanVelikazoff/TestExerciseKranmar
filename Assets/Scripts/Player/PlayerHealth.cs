using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] 
    private int maxHealth;
    private int currentHealth;

    [SerializeField]
    private HealthBarUI healthBar;

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        healthBar.SetHealthBar(maxHealth, currentHealth);
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //Lose
        }
        healthBar.UpdateHealthBar(currentHealth);
    }

    public void HealthPlayer(int health)
    {
        currentHealth += health;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.UpdateHealthBar(currentHealth);
    }
}
