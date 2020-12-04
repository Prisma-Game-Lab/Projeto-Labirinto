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

    static public List<string> objectList = new List<string>();
    [HideInInspector]
    public List<string> objectListCopy = new List<string>();

    static private int count = 0;

    private GameObject Other;

    private bool isTrigger = false;

    void Start() {
        Particles.Stop();
        objectCountScript = Object.GetComponent<ObjectCount>();
    }

    void Update() {
        if (isTrigger) { 
            PressZ();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Other = other.gameObject;
        if (Other.CompareTag("Object")) {
            isTrigger = true;
            Particles.Play();
            triggerText.gameObject.SetActive(true);
            triggerText.text = "Aperte E para interagir";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Object")) {
            Particles.Stop();
            triggerText.gameObject.SetActive(false);
            isTrigger = false;
        } 
    }

    void PressZ() {
        if (Input.GetKeyDown("e")) {
            Particles.Stop();
            if (Other.name == "Carteira"){
                objectList.Add("Cartão de funcionário");
                objectListCopy.Add("Cartão de funcionário");
                objectList.Add("Moeda");
                objectListCopy.Add("Moeda");
                Other.SetActive(false);
                count++;
                objectCountScript.CountText(count);
                triggerText.text = "Voce pegou dois objetos!";
            }
            else if (Other.name == "Máquina de Lanches" && objectList.Contains("Moeda") && gameManeger.eletricidade  == true){
                objectList.Remove("Moeda");
                objectListCopy.Remove("Moeda");
                objectList.Add("Lanche");
                objectListCopy.Add("Lanche");
                count++;
                objectCountScript.CountText(count);
                triggerText.text = "Voce ganhou um Lanche!";
            }
            else if (Other.name == "Chave quebrada" && objectList.Contains("Super cola")){
                objectList.Remove("Chave quebrada");
                objectListCopy.Remove("Chave quebrada");
                objectList.Add("Chave inteira");
                objectListCopy.Add("Chave inteira");
                count++;
                objectCountScript.CountText(count);
                triggerText.text = "Voce o objeto!";
            }
            else{
                objectList.Add(Other.name);
                objectListCopy.Add(Other.name);
                Other.SetActive(false);
                count++;
                objectCountScript.CountText(count);
                triggerText.text = "Voce pegou o objeto!";
            }
            isTrigger = false;
            triggerText.gameObject.SetActive(true);
            StartCoroutine(DisableText());
            somObjeto.Play();
        }
    }

    private IEnumerator DisableText() {
        yield return new WaitForSeconds(1.5f);
        triggerText.gameObject.SetActive(false);
    }
}
