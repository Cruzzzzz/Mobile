using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Painel da Loja (UI)")]
    public GameObject shopPanel;

    // Abre a loja sem trocar de cena
    public void OpenShop()
    {
        if (shopPanel != null)
            shopPanel.SetActive(true);

        // pausa o jogo se quiser evitar peixes andando
        Time.timeScale = 0f;
    }

    // Fecha a loja e volta ao jogo
    public void CloseShop()
    {
        if (shopPanel != null)
            shopPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}

