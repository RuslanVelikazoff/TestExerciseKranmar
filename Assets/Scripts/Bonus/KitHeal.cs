using UnityEngine;

public class KitHeal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            InventoryData.Instance.PlusHealKit();
            InventoryBarUI.Instance.UpdateInventoryBarText();
        }
    }
}
