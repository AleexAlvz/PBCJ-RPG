using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /*o iniciar o player, configura seus componentes*/
    private void Start()
    {
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = InicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    /*Reseta o player, sua vida e seu inventario*/
    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = InicioPontosDano;
    }

    /*Mata o player, destruindo seu gameObject*/
    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
        SceneManager.LoadScene("TelaDerrota");
    }

    /*Responsavel por dar o dano no player, dando uma animacaozinha breve*/
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

    /*Reconhece trigger de contato com coletaveis, tratando a coleta para cada caso.*/
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
                    case Item.TipoItem.COLAR:
                        DeveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.CHAVE:
                        DeveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.PERGAMINHO:
                        DeveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.TABUA:
                        DeveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    default:
                        break;
                }
                if (DeveDesaparecer) collision.gameObject.SetActive(false);
            }
        }
    }

    /*Ajusta a vida do usuario com coletaveis de saúde*/
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
