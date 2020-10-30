using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float cronometro;
    public Text UISeg;
    public Text UIMin;
    public Text UIHora;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void FixedUpdate()
    {
        cronometro += Time.deltaTime;
        UISeg.text = ":" + Mathf.Floor(cronometro % 60).ToString("00");
        UIMin.text = "" + Mathf.Floor(cronometro / 60).ToString("00");
    }
    
}
