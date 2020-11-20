using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    /* Variaveis para o timer */
    [System.NonSerialized]
    public float seg = 0.0f;
    [System.NonSerialized]
    public float min = 0.0f;
    [System.NonSerialized]
    public float hora = 0.0f;
    public Text UITempo;


    /* Variaveis para a energia */
    public bool eletricidade = true;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
