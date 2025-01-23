using UnityEngine;

public class PlayerItemSelected : MonoBehaviour
{
    [SerializeField] 
    private GameObject pistol;
    [SerializeField] 
    private GameObject rifle;
    
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
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //AmmoHeal
        }
    }

    private void SelectPistol()
    {
        pistol.SetActive(true);
        rifle.SetActive(false);
    }

    private void SelectRifle()
    {
        pistol.SetActive(false);
        rifle.SetActive(true);
    }

    private void SelectFist()
    {
        pistol.SetActive(false);
        rifle.SetActive(false);
        GunHoodPanel.Instance.SelectFist();
    }
}
