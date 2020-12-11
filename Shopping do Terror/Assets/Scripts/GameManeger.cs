using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    /* Variaveis para o timer */
    [System.NonSerialized]
    static public float seg = 0.0f;
    [System.NonSerialized]
    static public float min = 0.0f;
    [System.NonSerialized]
    static public float hora = 0.0f;
    public GameObject CanvasUI;
    public Text UITempo;

    /* Variaveis para a energia */
    public bool eletricidade = true;

    /* Variaveis para terimnar o jogo*/
    public GameObject GameOverUI;
    public float bateryTimeMin;

    void Awake()
    {
        GameOverUI.SetActive(false);
        int elet = PlayerPrefs.GetInt("Eletricidade");
        if (elet == 0)
        {
            eletricidade = true;
        }
        else if(elet == 1)
        {
            eletricidade = false;
        }
    }

    void Update()
    {
        if(min == bateryTimeMin)
        {
            GameOver();
        }
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

    void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    void OnDestroy()
    {
        if(eletricidade == true)
        {
            PlayerPrefs.SetInt("Eletricidade", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Eletricidade", 1);
        } 
    }
}
