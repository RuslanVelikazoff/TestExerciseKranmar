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

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateAmmoText(int ammoMagazine, int ammoLeft)
    {
        ammoText.text = ammoLeft + "/" + ammoLeft;
    }

    public void SelectPistol()
    {
        ammoImage.sprite = pistolSprite;
    }

    public void SelectRiffle()
    {
        ammoImage.sprite = riffleSprite;
    }
}
