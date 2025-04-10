using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;
    public void Play()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void AbrirOpções()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void FecharOpções()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
