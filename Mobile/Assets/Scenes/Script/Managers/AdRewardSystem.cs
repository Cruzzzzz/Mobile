using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AdRewardSystem : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject adPanel;

    [Header("Buttons")]
    [SerializeField] private Button rewardButton;
    [SerializeField] private Button closeAdButton;

    [Header("Counter TMP")]
    [SerializeField] private TMP_Text contadorTMP;

    [Header("Reward")]
    [SerializeField] public int rewardAmount = 30;
    [SerializeField] private int adSeconds = 10;

    private Coroutine adCoroutine;
    private bool rewarded = false;

    private void Start()
    {
        // Painel do ad começa DESATIVADO
        adPanel.SetActive(false);

        // Botão de fechar escondido no começo
        closeAdButton.gameObject.SetActive(false);

        contadorTMP.text = "";

        rewardButton.onClick.AddListener(OnRewardClicked);
        closeAdButton.onClick.AddListener(OnCloseAdClicked);
    }

    private void OnRewardClicked()
    {
        // Abre painel do ad
        adPanel.SetActive(true);

        // Esconde botão de fechar até acabar o tempo
        closeAdButton.gameObject.SetActive(false);

        // Mostra contador
        contadorTMP.gameObject.SetActive(true);

        rewarded = false;

        // Reinicia coroutine se tiver uma rodando
        if (adCoroutine != null)
            StopCoroutine(adCoroutine);

        adCoroutine = StartCoroutine(AdTimer());
    }

    private IEnumerator AdTimer()
    {
        int t = adSeconds;

        while (t > 0)
        {
            contadorTMP.text = t.ToString();
            yield return new WaitForSecondsRealtime(1f);
            t--;
        }

        contadorTMP.text = "Pronto!";

        // Agora sim mostra o botão de fechar
        closeAdButton.gameObject.SetActive(true);

        // Dá a recompensa
        if (!rewarded)
        {
            rewarded = true;
            GiveReward();
        }

        adCoroutine = null;
    }

    public void GiveReward()
    {
        ScoreManager.AddScore(rewardAmount);
        Debug.Log("Reward dado! Pontos atuais: " + ScoreManager.currentScore);
    }

    private void OnCloseAdClicked()
    {
        // Para coroutine caso ainda exista
        if (adCoroutine != null)
        {
            StopCoroutine(adCoroutine);
            adCoroutine = null;
        }

        // Some painel do ad
        adPanel.SetActive(false);

        // Some botão e texto
        closeAdButton.gameObject.SetActive(false);
        contadorTMP.text = "";

        // Volta pra loja
        if (shopPanel != null)
            shopPanel.SetActive(true);
    }
}
