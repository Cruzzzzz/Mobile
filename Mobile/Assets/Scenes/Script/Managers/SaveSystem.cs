using UnityEngine;

public class SaveSystem : MonoBehaviour, ISavable
{
    private CurrencyManager currencyManager;

    private void Start()
    {
        currencyManager = FindObjectOfType<CurrencyManager>();
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Coins", currencyManager.GetCoins());
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        int savedCoins = PlayerPrefs.GetInt("Coins", 0);
        for (int i = 0; i < savedCoins; i++)
            currencyManager.AddCoins(1);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}

