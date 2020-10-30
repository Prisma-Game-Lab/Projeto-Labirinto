/* Script para carregar uma nova cena após completar um objegitvo*/


using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escada : MonoBehaviour
{
    public string SceneName;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SceneName", LoadSceneMode.Single);
        }
    }
}
