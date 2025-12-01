using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddPointsButton : MonoBehaviour
{
    [SerializeField] private Button addPointsButton;
    [SerializeField] private int amountToAdd = 30;
    [SerializeField] private TMP_Text pointsText;

    private int currentPoints;

    private void Start()
    {
        // Carrega pontuação salva
        currentPoints = PlayerPrefs.GetInt("Score", 0);
        UpdatePointsUI();

        // Listener do botão
        addPointsButton.onClick.AddListener(AddPoints);
    }

    private void AddPoints()
    {
        currentPoints += amountToAdd;

        PlayerPrefs.SetInt("Score", currentPoints);
        PlayerPrefs.Save();

        UpdatePointsUI();

        Debug.Log($"➕ Adicionado {amountToAdd} pontos! Total = {currentPoints}");
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
            pointsText.text = currentPoints.ToString();
    }
}
