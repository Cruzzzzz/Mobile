using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private string shopSceneName = "Shop";

    public void OpenShop()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.PauseGameAndSave();

        SceneManager.LoadSceneAsync(shopSceneName, LoadSceneMode.Additive);
    }

    public void CloseShop()
    {
        SceneManager.UnloadSceneAsync(shopSceneName).completed += (op) =>
        {
            if (GameManager.Instance != null)
                GameManager.Instance.ResumeGame();
        };
    }

    public void OpenShop_FullScene()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.PauseGameAndSave();

        SceneManager.LoadSceneAsync(shopSceneName);
    }

    public void BackToGameplay_FullScene()
    {
        SceneManager.LoadSceneAsync("Fase1");
        // o GameManager persiste e volta automaticamente a rodar
    }
}


