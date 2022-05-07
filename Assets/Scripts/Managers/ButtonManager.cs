using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manager botões do jogo
/// </summary>
public class ButtonManager : MonoBehaviour
{
    /* chama primeira cena do jogo */
    public void IniciaJogo()
    {
        SceneManager.LoadScene("Lab5_RPG_Setup");
    }
    /* chama cena do credito */
    public void VaiParaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    /* chama cena Home */
    public void VaiParaHome()
    {
        SceneManager.LoadScene("Home");
    }

    
}
