using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public static InventoryData Instance;

    private const string SaveKey = "MainSaveInventory";

    private int _ammoPistol;
    private int _ammoRifle;
    private int _kitAmount;
    private int _ammoKitAmount;

    private void Awake()
    {
        Instance = this;
        
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _ammoPistol = data.ammoPistol;
        _ammoRifle = data.ammoRifle;
        _kitAmount = data.kitAmount;
        _ammoKitAmount = data.ammoKitAmount;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey,GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            ammoPistol = _ammoPistol,
            ammoRifle = _ammoRifle,
            kitAmount = _kitAmount,
            ammoKitAmount = _ammoKitAmount
        };

        return data;
    }

    public int GetPistolAmmo()
    {
        return _ammoPistol;
    }

    public int GetRifleAmmo()
    {
        return _ammoRifle;
    }

    public int GetKitAmount()
    {
        return _kitAmount;
    }

    public int GetAmmoKitAmount()
    {
        return _ammoKitAmount;
    }

    public void SetPistolAmmo(int amount)
    {
        _ammoPistol = amount;
        Save();
    }

    public void SetRifleAmmo(int amount)
    {
        _ammoRifle = amount;
        Save();
    }

}
