using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject slotPrefab;  //Objeto prefab do slot.
    public const int numSlot = 5; //Numero fixo de slots
    Image[] itemImages = new Image[numSlot]; //Array de imagens
    Item[] itens = new Item[numSlot]; //Array de itens
    GameObject[] slots = new GameObject[numSlot]; //Array de slots

    // Start is called before the first frame update
    void Start()
    {
        CriaSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cria a quantidade certa de slots, de acordo com a variavel numSlot.
    public void CriaSlots()
    {
        if (slotPrefab != null) //Verifica se o slotPrefab foi definido
        {
            for(int i = 0; i<numSlot; i++) //Loop para a quantidade de slots definida
            {
                GameObject newSlot = Instantiate(slotPrefab); //Instancia um slot
                newSlot.name = "ItemSlot_" + i;
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = newSlot;
                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>(); 
            }
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i<itens.Length; i++)
        {
            if (itens[i] != null && itens[i].tipoItem == item.tipoItem && item.empilhavel == true)
            {
                itens[i].quantidade = itens[i].quantidade + item.quantidade;
                Slot slotScript = slots[i].GetComponent<Slot>();
                Text qtdTexto = slotScript.QuantidadeTexto;
                qtdTexto.enabled = true;
                qtdTexto.text = itens[i].quantidade.ToString();
                return true;
            }
            if (itens[i] == null)
            {
                itens[i] = Instantiate(item);
                itens[i].quantidade = item.quantidade;
                Slot slotScript = slots[i].GetComponent<Slot>();
                Text qtdTexto = slotScript.QuantidadeTexto;
                qtdTexto.text = itens[i].quantidade.ToString();
                itemImages[i].sprite = item.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }

}
