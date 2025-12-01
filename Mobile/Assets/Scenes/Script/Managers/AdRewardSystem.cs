using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Sistema de anúncios com recompensa para jogo de pesca 2D mobile
/// Gerencia a exibição de anúncios, timer de 10 segundos e recompensa de 30 pontos
/// </summary>
public class AdRewardSystem : MonoBehaviour
{
    [Header("Configurações de Recompensa")]
    [SerializeField] private int rewardPoints = 30;
    [SerializeField] private float adDuration = 10f;

    [Header("Referências UI")]
    [SerializeField] private Button adButton;
    [SerializeField] private GameObject adPanel;
    [SerializeField] private Text timerText;
    [SerializeField] private Button closeAdButton;

    [Header("Sistema de Pontos")]
    [SerializeField] private Text pointsText;
    private int currentPoints = 0;

    private bool isWatchingAd = false;
    private float currentAdTime = 0f;

    private void Start()
    {
        // Configurar listeners dos botões
        if (adButton != null)
        {
            adButton.onClick.AddListener(OnAdButtonClicked);
        }

        if (closeAdButton != null)
        {
            closeAdButton.onClick.AddListener(OnCloseAdButtonClicked);
            closeAdButton.interactable = false; // Desabilitar até o timer acabar
        }

        // Esconder painel de anúncio no início
        if (adPanel != null)
        {
            adPanel.SetActive(false);
        }

        // Atualizar display de pontos
        UpdatePointsDisplay();
    }

    /// <summary>
    /// Chamado quando o jogador clica no botão de anúncio
    /// </summary>
    private void OnAdButtonClicked()
    {
        if (isWatchingAd)
            return;

        StartAd();
    }

    /// <summary>
    /// Inicia a exibição do anúncio
    /// </summary>
    private void StartAd()
    {
        isWatchingAd = true;
        currentAdTime = adDuration;

        // Mostrar painel de anúncio
        if (adPanel != null)
        {
            adPanel.SetActive(true);
        }

        // Desabilitar botão de fechar
        if (closeAdButton != null)
        {
            closeAdButton.interactable = false;
        }

        // Iniciar corrotina do timer
        StartCoroutine(AdTimerCoroutine());
    }

    /// <summary>
    /// Corrotina que gerencia o timer do anúncio
    /// </summary>
    private IEnumerator AdTimerCoroutine()
    {
        while (currentAdTime > 0)
        {
            // Atualizar texto do timer
            if (timerText != null)
            {
                timerText.text = $"Anúncio: {Mathf.Ceil(currentAdTime)}s";
            }

            yield return new WaitForSeconds(1f);
            currentAdTime -= 1f;
        }

        // Timer acabou
        OnAdCompleted();
    }

    /// <summary>
    /// Chamado quando o anúncio é completado (timer chegou a 0)
    /// </summary>
    private void OnAdCompleted()
    {
        // Dar recompensa ao jogador
        AddPoints(rewardPoints);

        // Atualizar UI
        if (timerText != null)
        {
            timerText.text = $"+{rewardPoints} pontos!";
        }

        // Habilitar botão de fechar
        if (closeAdButton != null)
        {
            closeAdButton.interactable = true;
        }

        isWatchingAd = false;

        // Feedback visual/sonoro (opcional)
        Debug.Log($"Anúncio completado! Recompensa: {rewardPoints} pontos");
    }

    /// <summary>
    /// Chamado quando o jogador clica no botão de fechar anúncio
    /// </summary>
    private void OnCloseAdButtonClicked()
    {
        if (adPanel != null)
        {
            adPanel.SetActive(false);
        }

        // Resetar texto do timer
        if (timerText != null)
        {
            timerText.text = "";
        }
    }

    /// <summary>
    /// Adiciona pontos ao jogador
    /// </summary>
    /// <param name="points">Quantidade de pontos a adicionar</param>
    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdatePointsDisplay();
        
        // Salvar pontos (opcional - usar PlayerPrefs ou sistema de save)
        PlayerPrefs.SetInt("PlayerPoints", currentPoints);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Atualiza o display de pontos na UI
    /// </summary>
    private void UpdatePointsDisplay()
    {
        if (pointsText != null)
        {
            pointsText.text = $"Pontos: {currentPoints}";
        }
    }

    /// <summary>
    /// Carrega os pontos salvos
    /// </summary>
    public void LoadPoints()
    {
        currentPoints = PlayerPrefs.GetInt("PlayerPoints", 0);
        UpdatePointsDisplay();
    }

    /// <summary>
    /// Retorna a quantidade atual de pontos
    /// </summary>
    public int GetCurrentPoints()
    {
        return currentPoints;
    }

    private void OnDestroy()
    {
        // Remover listeners ao destruir o objeto
        if (adButton != null)
        {
            adButton.onClick.RemoveListener(OnAdButtonClicked);
        }

        if (closeAdButton != null)
        {
            closeAdButton.onClick.RemoveListener(OnCloseAdButtonClicked);
        }
    }
}
