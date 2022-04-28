using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsavel pelas caracteristicas do player, como manusear colisoes e gerenciar sua vida, healthbar e itens pegos.
/// </summary>
public class Player : Caractere
{
    public Inventario inventarioPrefab; //Aramazena o prefab do inventario do player
    Inventario inventario; //Armazena o inventario instanciado
    public HealthBar healthBarPrefab;  //Referencia do prefab HealthBar
    HealthBar healthBar; //Armazena a healthBar instanciada
    public PontosDano pontosDano; // Tem o valor da vida do objeto

    private void Start()
    {
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = InicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = InicioPontosDano;
    }

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());
            pontosDano.valor = pontosDano.valor - dano;
            if (pontosDano.valor <= float.Epsilon)
            {
                KillCaractere();
                break;
            }
            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            Item danoObjeto = collision.gameObject.GetComponent<Consumable>().item;
            if (danoObjeto!=null)
            {
                bool DeveDesaparecer = false;
                switch (danoObjeto.tipoItem)
                {
                    case Item.TipoItem.MOEDA:
                        DeveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.HEALTH:
                        DeveDesaparecer = AjusteDanoObjeto(danoObjeto.quantidade);
                        break;
                    default:
                        break;
                }
                if (DeveDesaparecer) collision.gameObject.SetActive(false);
            }
        }
    }

    private bool AjusteDanoObjeto(int quantidade)
    {
        if (pontosDano.valor < MaxPontosDano)
        {
            pontosDano.valor = pontosDano.valor + quantidade;
            return true;
        }
        else return false;
    }
}
