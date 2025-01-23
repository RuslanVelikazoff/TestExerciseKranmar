using UnityEngine;

public class KitAmmo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            InventoryData.Instance.PlusAmmoKit();
            InventoryBarUI.Instance.UpdateInventoryBarText();
        }
    }
}
