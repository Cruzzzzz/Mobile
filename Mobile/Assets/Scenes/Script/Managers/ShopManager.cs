using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private Button adButton;
    [SerializeField] private int adReward = 50;

    public void BuyItem(int price)
    {
        currencyManager.SpendCoins(price);
    }

    public void GetAdReward()
    {
        currencyManager.AddCoins(adReward);
    }
}
