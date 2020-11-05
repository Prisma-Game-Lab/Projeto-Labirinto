/* Script para carregar uma nova cena após completar um objegitvo*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escada : MonoBehaviour
{
    public string SceneName;
    public List<GameObject> itenList = new List<GameObject>();
    public GameObject player;
    bool cont = false;


    void OnCollisionEnter2D(Collision2D other)
    {


        //caso o player tenha os itens (que estão no script ObjectCollider) ele carregara a próxima cena
        for(int i = 0; i < itenList.Count; i++)
        {
            Debug.Log("Teste");
            if (player.GetComponent<ObjectCollider>().objectListCopy.Contains(itenList[i].name))
            {
                cont = true;
                Debug.Log("Encostou");
            }
            else
            {
                cont = false;
                Debug.Log("Deu ruim");
            }
            
        }

        if (other.gameObject.CompareTag("Player") && cont == true)
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
