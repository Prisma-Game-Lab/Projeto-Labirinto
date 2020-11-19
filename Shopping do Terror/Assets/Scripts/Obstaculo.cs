using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculo : MonoBehaviour
{
    [Header("Lista de intens necessários para se passar pelo obstáculo.")]
    public List<GameObject> itenList = new List<GameObject>();
    public GameObject player;
    [Header("Obstaulo que será desligado para deixar o player passar")]
    public GameObject obstaculo;
    [Header("Precisa da energia para passar pelo obsstaculo?")]
    public bool energy;
    bool cont = false;


    void OnCollisionEnter2D(Collision2D other)
    {
        //caso o player tenha os itens (que estão no script ObjectCollider) ele desliga o objeto e permite o player passar
        for(int i = 0; i < itenList.Count; i++)
        {
            if (player.GetComponent<ObjectCollider>().objectListCopy.Contains(itenList[i].name))
            {
                cont = true;
            }
            else
            {
                cont = false;
                Debug.Log("não tem os itens necessários");
                //break;
            }
            
        }

        if (other.gameObject.CompareTag("Player") && cont == true)
        {
            obstaculo.SetActive(false);
        }
    }
}

