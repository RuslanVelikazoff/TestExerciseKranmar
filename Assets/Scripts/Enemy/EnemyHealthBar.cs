using TMPro;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] 
    private TextMeshPro healthText;
    private int maxHealth;

    public void SetHealthText(int currentHealth, int maxHealth)
    {
        this.maxHealth = maxHealth;
        healthText.text = currentHealth + "/" + maxHealth;
    }

    public void UpdateHealthText(int currentHealth)
    {
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
