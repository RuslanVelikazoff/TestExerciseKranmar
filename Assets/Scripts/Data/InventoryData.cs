using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public static InventoryData Instance;

    private const string SaveKey = "MainSaveInventory";

    private int _ammoPistol;
    private int _ammoRifle;
    private int _kitAmount;

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
            kitAmount = _kitAmount
        };

        return data;
    }

    public int GetPistolAmmo()
    {
        return _ammoPistol;
    }

    public void SetPistolAmmo(int amount)
    {
        _ammoPistol = amount;
        Save();
    }
}
