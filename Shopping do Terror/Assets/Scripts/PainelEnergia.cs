using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainelEnergia : MonoBehaviour
{
    public GameManeger gameManeger;
    public bool isTrigger = true;
    /*
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            if(isTrigger == true && Input.GetKeyDown("z")){
                gameManeger.eletricidade = false;
                isTrigger = false;
                Debug.Log("Encostou");
            }
        else if (isTrigger == false && Input.GetKeyDown("z"))
            {
                gameManeger.eletricidade = true;
                isTrigger = true;
                Debug.Log("Encostou");
            }
        }
    }
    */
}
