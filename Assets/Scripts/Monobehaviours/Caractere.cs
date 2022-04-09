using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe abstrata com caracteristicas básicas de todo caractere, na qual todos caracteres devem herdar.
/// </summary>
public abstract class Caractere : MonoBehaviour
{
    public PontosDano pontosDano; // Tipo que armazena o valor do objeto script
    public float InicioPontosDano; //Quantidade inicial de pontos dano do caractere
    public float MaxPontosDano; //Quantidade máxima de pontos dano do caractere

}
