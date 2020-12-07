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


        /* Verificar se o player já pegou os itens do andar */
        /* Caso o player não tenha já pegado os itens o spawn deles sera feito */
        for( aux = 0; aux < objList.Length; aux++)
        {
            if (!player.GetComponent<ObjectCollider>().objectListCopy.Contains(objList[aux].name)){
                objList[aux].transform.position = spawnList[aux].transform.position;
            }
        }
    }

}
