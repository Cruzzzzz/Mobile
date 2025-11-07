using UnityEngine;

public class SaveSystem : MonoBehaviour, ISavable
{
    private CurrencyManager currencyManager;

    private void Start()
    {
        // Pega o gerenciador de moedas da cena
        currencyManager = Object.FindFirstObjectByType<CurrencyManager>();

        // Zera as moedas ao iniciar a cena
        if (currencyManager != null)
        {
            currencyManager.SetCoins(0);
            Debug.Log("[SaveSystem] Moedas resetadas ao iniciar a Fase1");
        }
    }

    public void SaveData()
    {
        // Não salva mais nada (porque tu quer resetar sempre)
    }

    public void LoadData()
    {
        // Também não carrega nada (começa zerado sempre)
    }

    private void OnApplicationQuit()
    {
        // Nem precisa salvar aqui mais
    }
}



