using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public GameObject Object;

    private ObjectCount objectCountScript;

    private List<GameObject> objectList = new List<GameObject>();

    private int count = 0;

    private GameObject Other;

    private bool isTrigger = false;

    void Start() {
        objectCountScript = Object.GetComponent<ObjectCount>();
    }

    void Update() {
        if (isTrigger)
            PressZ();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Other = other.gameObject;
        if (Other.CompareTag ("Object")) {
            isTrigger = true;
            Debug.Log("Aperte Z para interagir");
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag ("Object")) 
            isTrigger = false;
    }

    void PressZ() {
        if (Input.GetKeyDown("z")) {
            objectList.Add(Other);
            Other.SetActive(false);
            count++;
            objectCountScript.CountText(count);
            isTrigger = false;
        }
    }
}
