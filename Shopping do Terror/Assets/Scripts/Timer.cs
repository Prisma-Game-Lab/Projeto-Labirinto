using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float seg = 0;
    public float min = 0;
    public float hora = 0;

   void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void FixedUpdate()
    {
        seg += Time.deltaTime;

        if(seg > 60.0f)
        {
            seg = 0.0f;
            min++;
        }
        if(min > 60.0f)
        {
            min = 0.0f;
            hora++;
        }
    }
    
}
