using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// finaliza fase 1 do jogo e inicia fase2
/// </summary>
public class FimFase1 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Fase2");
    }

}
