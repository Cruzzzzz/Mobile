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
    public void AbrirOp��es()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void FecharOp��es()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
