using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float seg = 0.0f;
    public float min = 0.0f;
    public float hora = 0.0f;
    public Text UITempo;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void FixedUpdate()
    {
        seg += Time.deltaTime;
        UITempo.text = Mathf.Floor(hora).ToString("00") + ":" + Mathf.Floor(min).ToString("00") + ":" + Mathf.Floor(seg).ToString("00");

        if (seg > 60.0f)
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
