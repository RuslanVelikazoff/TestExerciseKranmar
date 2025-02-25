using TMPro;
using UnityEngine;

public class InventoryBarUI : MonoBehaviour
{
    public static InventoryBarUI Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI pistolAmmoText;
    [SerializeField] 
    private TextMeshProUGUI rifleAmmoText;
    [SerializeField]
    private TextMeshProUGUI kitAmountText;
    [SerializeField]
    private TextMeshProUGUI kitAmmoAmountText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateInventoryBarText();
        GunHoodPanel.Instance.SelectFist();
    }

    public void UpdateInventoryBarText()
    {
        pistolAmmoText.text = InventoryData.Instance.GetPistolAmmo().ToString();
        rifleAmmoText.text = InventoryData.Instance.GetRifleAmmo().ToString();
        kitAmountText.text = InventoryData.Instance.GetKitAmount().ToString();
        kitAmmoAmountText.text = InventoryData.Instance.GetAmmoKitAmount().ToString();
    }
}
