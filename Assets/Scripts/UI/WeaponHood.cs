using TMPro;
using UnityEngine;

public class WeaponHood : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI reloadText;

    public void UpdateReloadText(float reloadTimer)
    {
        if (reloadTimer <= 0)
        {
            reloadText.gameObject.SetActive(false);
        }
        else
        {
            reloadText.gameObject.SetActive(true);
            reloadText.text =  reloadTimer.ToString("#.#") + "s";
        }
    }
}
