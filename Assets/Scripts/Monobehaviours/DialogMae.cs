using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// esse class controla personagem mae do jogo
/// </summary>
public class DialogMae : MonoBehaviour
{

    public GameObject Dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dialog.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialog.SetActive(false);
    }
}
