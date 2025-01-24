using UnityEngine;

public class PlayerItemSelected : MonoBehaviour
{
    [SerializeField] 
    private GameObject pistol;
    [SerializeField] 
    private GameObject rifle;
    [SerializeField] 
    private GameObject grenade;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectFist();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectPistol();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectRifle();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (InventoryData.Instance.GetKitAmount() > 0)
            {
                PlayerHealth.Instance.HealthPlayer(20);
                InventoryData.Instance.MinusHealKit();
                InventoryBarUI.Instance.UpdateInventoryBarText();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (InventoryData.Instance.GetAmmoKitAmount() > 0)
            {
                InventoryData.Instance.SetPistolAmmo(
                    InventoryData.Instance.GetPistolAmmo() + 60);
                
                InventoryData.Instance.SetRifleAmmo(
                    InventoryData.Instance.GetRifleAmmo() + 120);
                
                InventoryData.Instance.MinusAmmoKit();
                
                InventoryBarUI.Instance.UpdateInventoryBarText();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectGrenade();
        }
    }

    private void SelectPistol()
    {
        pistol.SetActive(true);
        rifle.SetActive(false);
        grenade.SetActive(false);
    }

    private void SelectRifle()
    {
        pistol.SetActive(false);
        rifle.SetActive(true);
        grenade.SetActive(false);
    }

    private void SelectFist()
    {
        pistol.SetActive(false);
        rifle.SetActive(false);
        grenade.SetActive(false);
        GunHoodPanel.Instance.SelectFist();
    }

    private void SelectGrenade()
    {
        grenade.SetActive(true);
        pistol.SetActive(false);
        rifle.SetActive(false);
        GunHoodPanel.Instance.SelectGrenade();
    }
}
