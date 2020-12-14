using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruções : MonoBehaviour
{
    bool isActive = true;
    void Start()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    void Update()
    {
        
        if (Input.GetKeyDown("e") && isActive == true){
            Time.timeScale = 1f;
            this.gameObject.SetActive(false);
            isActive = false;
        }
        
    }
}
