using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disableintro : MonoBehaviour
{
    public GameObject intro;

    public GameObject player;

    void Start()
    {
        if(player.GetComponent<ObjectCollider>().objectList.Contains("Camisa Final")) {
            intro.SetActive(false);
        }
    }

}
