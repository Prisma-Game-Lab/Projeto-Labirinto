using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruções : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0.0f;
    }
    void Update()
    {
        if (Input.GetKeyDown("e")){
            Time.timeScale = 1f;
        }
    }
}
