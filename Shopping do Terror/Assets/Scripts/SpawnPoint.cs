using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    [Header("Lista de objetos no andar")]
    public GameObject[] objList;

    [Header("Lista de spawns no andar")]
    public GameObject[] spawnList;

    private int aux;

    public GameObject CheckPoint;

    public static bool Checked = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player"); // isso eh muito feio, ass: Vinny
        player.transform.position = this.transform.position;
        


        /* Verificar se o player já pegou os itens do andar */
        /* Caso o player não tenha já pegado os itens o spawn deles sera feito */
        for( aux = 0; aux < objList.Length; aux++)
        {
            if (!player.GetComponent<ObjectCollider>().objectList.Contains(objList[aux].name)){
                objList[aux].transform.position = spawnList[aux].transform.position;
            }
        }

        if(player.GetComponent<ObjectCollider>().objectList.Contains("Camisa Final")) {
            SetupCheckpoint(player);
        }
    }

    private void SetupCheckpoint(GameObject player) {
        player.transform.position = new Vector2(CheckPoint.transform.position.x,CheckPoint.transform.position.y);
        Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name == "04 - Level 03") {
            GameManeger.seg = 600;
        }
    }

}
