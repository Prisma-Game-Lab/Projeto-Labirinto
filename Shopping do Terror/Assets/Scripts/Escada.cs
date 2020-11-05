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


    void OnCollisionEnter2D(Collision2D other)
    {
        bool cont = false;

        Debug.Log("Encostou");

        for(int i = 0; i < itenList.Count; i++)
        {
            if (!player.GetComponent<ObjectCollider>().objectListCopy.Contains(itenList[i]))
            {
                cont = false;
            }
            else
            {
                cont = true;
            }
            
        }

        if (other.gameObject.CompareTag("Player") && cont)
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
