using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelEnergia : MonoBehaviour
{
    public GameManeger gameManeger;
    public bool isTrigger = true;

    void OnCollisionEnter2D(Collision2D other){
        if (isTrigger == true && Input.GetKeyDown("z")){
            gameManeger.eletricidade = false;
            isTrigger = false;
        }
        else if(isTrigger == false && Input.GetKeyDown("z")){
            gameManeger.eletricidade = true;
            isTrigger = true;
        }
    }
}
