using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool spawnPlayer;
    public bool spawnIten;
    [Header("Item ou player a ser spawnado")]
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPlayer == true && spawnIten == false)
        {
            obj.transform.position = this.transform.position;
        }
        else if (spawnIten == true && spawnPlayer == false)
        {
            //Instantiate(obj,this.transform);
            obj.transform.position = this.transform.position;
        }
    }

}
