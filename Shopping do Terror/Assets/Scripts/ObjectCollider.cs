using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollider : MonoBehaviour
{
    public GameManeger gameManeger;

    [Tooltip("Referencia texto que conta objetos")]
    public GameObject Object;

    public ParticleSystem Particles;

    public AudioSource somObjeto;

    public TextMeshProUGUI triggerText;

    private ObjectCount objectCountScript;

    public List<string> objectList = new List<string>();

    static private int count = 0;

    private GameObject Other;

    private bool isTrigger = false;

    public bool energy = true;


    void Start()
    {
        Particles.Stop();
        objectCountScript = Object.GetComponent<ObjectCount>();
        energy = gameManeger.eletricidade;
    }

    void Awake()
    {
        /* Recuperando os itens quando se troca de cena */
        int quantItens = PlayerPrefs.GetInt("Quant_Itens");
        for (int i = 0; i < quantItens; i++)
        {
            objectList.Add(PlayerPrefs.GetString("item_" + i));
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("Quant_Itens", objectList.Count);
        for (int i = 0; i < objectList.Count; i++)
        {
            PlayerPrefs.SetString("item_" + i, objectList[i]);
        }
    }

    void Update()
    {
        if (isTrigger)
        {
            PressZ();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Other = other.gameObject;
        if (Other.CompareTag("Object"))
        {
            isTrigger = true;
            Particles.Play();
            triggerText.gameObject.SetActive(true);
            triggerText.text = "Aperte E para interagir";
        }

        if (Other.name == "Fios")
        {
            if (energy)
            {
                Debug.Log("enconstou");
                Other.GetComponent<BoxCollider2D>().enabled = true;
                triggerText.text = "Os fios elétricos podem dar choque, desligue a eletrcidade para passar";
                triggerText.gameObject.SetActive(true);
                StartCoroutine(DisableText(triggerText.gameObject));

            }
            if (!energy)
            {
                Debug.Log("enconstou");
                Other.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            Particles.Stop();
            triggerText.gameObject.SetActive(false);
            isTrigger = false;
        }
    }

    void PressZ()
    {
        if (Input.GetKeyDown("e"))
        {
            Particles.Stop();
            if (Other.name == "Carteira")
            {
                Debug.Log("pegou a carteira.");
                objectList.Add("Cartão de funcionário");
                objectList.Add("Moeda");
                Other.SetActive(false);
                count++;
                objectCountScript.CountText(count);
                triggerText.text = "Voce achou uma carteira com moedas e um cartão de funcionário";
            }
            else if (Other.name == "Maquina de Lanches")
            {
                if (objectList.Contains("Moeda") && energy)
                {
                    objectList.Remove("Moeda");
                    objectList.Add("Lanche");
                    count++;
                    objectCountScript.CountText(count);
                    triggerText.text = "Você usou as moedas para pegar o lanche";
                }
                else if (objectList.Contains("Moeda") && !energy) {
                    triggerText.text = "A máquina não funcionará sem eletricidade";
                }
                else if (!objectList.Contains("Moeda") && energy) {
                    triggerText.text = "A máquina não funcionará sem dinheiro";
                }

                else {
                    triggerText.text = "Você não tem os itens adequados";
                }
            }
            else if (Other.name == "Chave quebrada" )
            {
                if(objectList.Contains("Super cola"))
                {
                    objectList.Remove("Chave quebrada");
                    objectList.Add("Chave inteira");
                    count++;
                    objectCountScript.CountText(count);
                    triggerText.text = "Você usou a super cola para colar a chave";
                }
                else {
                    triggerText.text = "A chave está quebrada";
                }
                
            }
            else if (Other.name == "PAINEL DE ENERGIA")
            {
                if (energy)
                {
                    energy = false;
                    gameManeger.eletricidade = energy;
                    triggerText.text = "Você ligou a energia";
                    //Debug.Log("Energia desligada");
                }
                else
                {
                    energy = true;
                    gameManeger.eletricidade = energy;
                    triggerText.text = "Você desligou a energia";
                    //Debug.Log("Energia ligada");
                }
            }
            /*
            else if (Other.name == "porta eletrica") {
                if (objectList.Contains("Cartão de funcionário") && energy) {
                    Other.SetActive(false);
                    triggerText.text = "Você usou o cartão de funcionário para abrir a porta";
                }
                else if  (objectList.Contains("Cartão de funcionário") && !energy) {
                    triggerText.text = "A trava elétrica não funciona sem eletricidade";
                }

                else if  (!objectList.Contains("Cartão de funcionário") && energy) {
                    triggerText.text = "A trava elétrica não funciona sem eletricidade";
                }

                else {
                    triggerText.text = "Você não tem os itens adequados";
                }
            }
            */
            else // camisa, taco de beisebol, super cola, pé de cabra
            {
                objectList.Add(Other.name);
                Other.SetActive(false);
                if (Other.name == "camisa" || Other.name == "super cola")    
                    triggerText.text = "Você pegou a " + Other.name;
                else
                    triggerText.text = "Você pegou o " + Other.name;
                count++;
                objectCountScript.CountText(count);
            }
            isTrigger = false;
            triggerText.gameObject.SetActive(true);
            Debug.Log(triggerText.text);
            StartCoroutine(DisableText(triggerText.gameObject));
            somObjeto.Play();
        }
    }

    private IEnumerator DisableText(GameObject texto)
    {
        yield return new WaitForSeconds(1.5f);
        texto.SetActive(false);
    }
}
