using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// finaliza fase 2 e inicia fase 3 do jogo
/// </summary>
public class FimFase2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Fase3");
        
    }
}
