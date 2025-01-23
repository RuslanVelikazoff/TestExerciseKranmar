using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pistol : MonoBehaviour
{
    [Header("Weapon Components")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField] 
    private Camera mainCamera;
    [SerializeField] 
    private Transform spawnBullet;
    [SerializeField]
    private WeaponHood weaponHood;

    [Space(13)]
    
    [Header("Shoot")]
    [SerializeField] 
    private float shootForce;
    [SerializeField]
    private float spread;

    [Space(13)]
    
    [Header("Ammo")]
    [SerializeField] 
    private int ammoMagazine = 7;
    private int maxAmmoMagazine = 7;
    private int ammoInventory;

    [Space(13)]
    
    [Header("Reload")]
    [SerializeField] 
    private float reloadTime;
    private float currentReloadTime = 0;
    private bool reload = false;

    private void OnEnable()
    {
        ammoInventory = InventoryData.Instance.GetPistolAmmo();
        GunHoodPanel.Instance.SelectPistol();
        GunHoodPanel.Instance.UpdateAmmoText(ammoMagazine, ammoInventory);
        weaponHood.UpdateReloadText(currentReloadTime);
    }

    private void OnDisable()
    {
        InventoryData.Instance.SetPistolAmmo(ammoInventory);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoMagazine > 0 && !reload)
            {
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentReloadTime <= 0)
            {
                reload = true;
                currentReloadTime = reloadTime;
            }
        }

        if (currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
            weaponHood.UpdateReloadText(currentReloadTime);
            if (currentReloadTime <= 0)
            {
                Reload();
            }
        }
    }

    private void Reload()
    {
        if (ammoInventory > 0)
        {
            if (ammoInventory >= maxAmmoMagazine)
            {
                if (ammoMagazine > 0)
                {
                    int remainingAmmo = maxAmmoMagazine - ammoMagazine;
                    ammoInventory -= remainingAmmo;
                    ammoMagazine = maxAmmoMagazine;
                }
                else
                {
                    ammoInventory -= maxAmmoMagazine;
                    ammoMagazine = maxAmmoMagazine;
                }
            }
            else
            {
                ammoMagazine = ammoInventory;
                ammoInventory = 0;
            }
        }
        else
        {
            Debug.Log("Нет патронов в инвентаре");
        }
        
        GunHoodPanel.Instance.UpdateAmmoText(ammoMagazine, ammoInventory);
        reload = false;
    }

    private void Shoot()
    {
        ammoMagazine--;
        GunHoodPanel.Instance.UpdateAmmoText(ammoMagazine, ammoInventory);
        
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        float xSpread = Random.Range(-spread, spread);
        float ySpread = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(xSpread, ySpread, 0);

        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, quaternion.identity);

        currentBullet.transform.forward = dirWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
}
