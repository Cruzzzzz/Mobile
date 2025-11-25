using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    private CurrencyManager currencyManager;

private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Busca o CurrencyManager na cena
        currencyManager = FindFirstObjectByType<CurrencyManager>();

        // Se achar, carrega o valor salvo
        if (currencyManager != null)
        {
            int loadedCoins = PlayerPrefs.GetInt("Coins", 0);
            currencyManager.SetCoins(loadedCoins);
        }
    }

    public void SaveCoins(int amount)
    {
        PlayerPrefs.SetInt("Coins", amount);
    }

    public int LoadCoins()
    {
        return PlayerPrefs.GetInt("Coins", 0);
    }

}



