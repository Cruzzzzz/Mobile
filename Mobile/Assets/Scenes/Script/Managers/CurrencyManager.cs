using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    [SerializeField] private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCoins();
            UpdateUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCoins(int amount)
    {
        coins = amount;
        SaveCoins();
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();

        // Salva o valor usando o SaveSystem
        SaveSystem.instance.SaveCoins(coins);

    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
            SaveSystem.instance.SaveCoins(coins);
            return true;
        }
        return false;
    }

    public void UpdateUI()
    {
        if (coinText != null)
            coinText.text = coins.ToString();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }
}

