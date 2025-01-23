using UnityEngine;

public class PlayerItemSelected : MonoBehaviour
{
    [SerializeField] 
    private GameObject pistol;
    [SerializeField] 
    private GameObject rifle;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectPistol();
        }
    }

    private void SelectPistol()
    {
        pistol.SetActive(true);
        rifle.SetActive(false);
    }
}
