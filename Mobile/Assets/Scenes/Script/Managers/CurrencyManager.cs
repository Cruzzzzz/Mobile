using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    [SerializeField] private TextMeshProUGUI coinText;

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    public void UpdateUI()
    {
        coinText.text = coins.ToString();
    }

    public int GetCoins()
    {
        return coins;
    }
}

