/* Script para carregar uma nova cena após completar um objegitvo*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escada : MonoBehaviour
{
    public string SceneName;
    [Header("Lista de intens necessários para se passar pelo obstáculo.")]
    public List<GameObject> itenList = new List<GameObject>();
    public GameObject player;
    bool cont = true;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && cont == true)
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
