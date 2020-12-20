using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Obstaculo : MonoBehaviour
{
    public GameObject player;

    [Header("Obstáculo que será desligado para deixar o player passar")]
    public GameObject obstaculo;

    [Header("Conecte o gameManeger aqui")]
    public GameManeger gameManeger;

    [Header("Lista de intens necessários para se passar pelo obstáculo.")]
    public List<GameObject> itenList;

    [Header("Precisa da energia para passar pelo obstáculo?")]
    public bool energy;

    [Header("É indiferente a energia?")]
    public bool indiferente;

    private bool cont = false;

    private ObjectCollider playerCollider;

    private Dictionary<string,List<string>> frasesObj = new Dictionary<string,List<string>>();

    public TextMeshProUGUI triggerText2;

    public GameObject PortaEletricaAberta;

    private void Start()
    {
        playerCollider = player.GetComponent<ObjectCollider>();

        frasesObj.Add("Poça", new List<string> {"O chão está muito escorregadio, você não consegue passar","Você usou a camiseta para secar o chão"});
        frasesObj.Add("Madeira", new List<string> {"A escada está bloqueada","Você usou o pé de cabra para quebrar as tábuas"});
        frasesObj.Add("Ratos", new List<string> {"Os ratos não de deixam passar, tente usar algo para afastá-los","Você usou o lanche para afastar os ratos"});
        frasesObj.Add("Cadeado", new List<string> {"A porta está trancada","Você usou a chave para abrir a porta"});
        frasesObj.Add("Vidro", new List<string> {"O vidro está rachado, será que você consegue quebrá-lo?","Você usou o taco de beisebol para quebrar o vidro"});
        frasesObj.Add("Porta eletrica", new List<string> {"Você não possui os items necessários","A trava elétrica não funciona sem eletricidade","A trava elétrica não destrava sem o cartão","Você usou o cartão do funcionário para abrir a porta"});
        for (int i = 0; i < itenList.Count; i++)
        {
            if (playerCollider.objectList.Contains(itenList[i].name) && itenList[i].name != "Cartao de funcionario")
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //caso o player tenha os itens (que estão no script ObjectCollider) ele desliga o objeto e permite o player passar
        for(int i = 0; i < itenList.Count; i++)
        {
            if (playerCollider.objectList.Contains(itenList[i].name))
            {
                cont = true;
                if (obstaculo.name == "Porta eletrica")
                    triggerText2.text = frasesObj[obstaculo.name][3];
                else
                    triggerText2.text = frasesObj[obstaculo.name][1];
                triggerText2.gameObject.SetActive(true);
                StartCoroutine(DisableText(triggerText2.gameObject));
                
            }
            else
            {
                cont = false;
                if (obstaculo.name == "Porta eletrica") {
                    if(!playerCollider.objectList.Contains("Cartao de funcionario"))
                        triggerText2.text = frasesObj[obstaculo.name][2];
                    else if (!ObjectCollider.energy)
                        triggerText2.text = frasesObj[obstaculo.name][1];
                    else if (!ObjectCollider.energy && !playerCollider.objectList.Contains("Cartao de funcionario"))
                        triggerText2.text = frasesObj[obstaculo.name][0];
                }
                else
                    triggerText2.text = frasesObj[obstaculo.name][0];
                triggerText2.gameObject.SetActive(true);
                StartCoroutine(DisableText(triggerText2.gameObject));
            }
            
        }

        if (other.gameObject.CompareTag("Player") && cont && indiferente){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(other.gameObject.CompareTag("Player") && cont && energy && gameManeger.eletricidade){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(other.gameObject.CompareTag("Player") && cont && energy && !gameManeger.eletricidade){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator DisableText(GameObject texto)
    {
        yield return new WaitForSeconds(1.5f);
        texto.SetActive(false);
    }
}

