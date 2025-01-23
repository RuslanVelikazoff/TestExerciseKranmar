using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunHoodPanel : MonoBehaviour
{
    public static GunHoodPanel Instance { get; private set; }

    [SerializeField]
    private Image ammoImage;
    [SerializeField]
    private TextMeshProUGUI ammoText;

    [Space(13)]
    
    [SerializeField] 
    private Sprite pistolSprite;
    [SerializeField] 
    private Sprite riffleSprite;
    [SerializeField] 
    private Sprite fistSprite;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateAmmoText(int ammoMagazine, int ammoLeft)
    {
        ammoText.text = ammoMagazine + "/" + ammoLeft;
        InventoryBarUI.Instance.UpdateInventoryBarText();
    }

    public void SelectPistol()
    {
        ammoImage.sprite = pistolSprite;
    }

    public void SelectRiffle()
    {
        ammoImage.sprite = riffleSprite;
    }

    public void SelectFist()
    {
        ammoImage.sprite = fistSprite;
        ammoText.text = String.Empty;
    }
}
