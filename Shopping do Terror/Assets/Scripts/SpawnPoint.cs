using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("Lista de objetos no andar")]
    public GameObject[] objList;

    [Header("Lista de spawns no andar")]
    public GameObject[] spawnList;

    private int aux;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;

        for( aux = 0; aux < objList.Length; aux++)
        {
            objList[aux].transform.position = spawnList[aux].transform.position;
        }
    }

}
