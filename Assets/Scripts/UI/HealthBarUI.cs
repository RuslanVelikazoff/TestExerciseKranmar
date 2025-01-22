using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] 
    private Slider healthSlider;

    public void SetHealthBar(int maxHealth, int currentHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}
