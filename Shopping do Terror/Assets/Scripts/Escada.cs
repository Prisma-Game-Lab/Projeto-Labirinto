/* Script para carregar uma nova cena após completar um objegitvo*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escada : MonoBehaviour
{
    public string SceneName;


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Encostou");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
