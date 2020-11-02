using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollider : MonoBehaviour
{
    public GameObject Object;
    
    public TextMeshProUGUI triggerText;

    private ObjectCount objectCountScript;

    static private List<GameObject> objectList = new List<GameObject>();

    static private int count = 0;

    private GameObject Other;

    private bool isTrigger = false;

    void Start() {
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
            triggerText.gameObject.SetActive(true);
            triggerText.text = "Aperte Z para interagir";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Object")) {
            triggerText.gameObject.SetActive(false);
            isTrigger = false;
        } 
    }

    void PressZ() {
        if (Input.GetKeyDown("z")) {
            objectList.Add(Other);
            Other.SetActive(false);
            count++;
            objectCountScript.CountText(count);
            triggerText.text = "Voce pegou o objeto!";
            isTrigger = false;
            triggerText.gameObject.SetActive(true);
            StartCoroutine(DisableText());
        }
    }

    private IEnumerator DisableText() {
        yield return new WaitForSeconds(1.5f);
        triggerText.gameObject.SetActive(false);
    }
}
