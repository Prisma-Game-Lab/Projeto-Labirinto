using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public GameObject Object;

    private ObjectCount objectCountScript;

    private List<GameObject> objectList = new List<GameObject>();

    private int count = 0;

    void Start() {
        objectCountScript = Object.GetComponent<ObjectCount>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag ("Object")) {
            objectList.Add(other.gameObject);
            other.gameObject.SetActive(false);
            count++;
            objectCountScript.CountText(count);
        }
    }
}
