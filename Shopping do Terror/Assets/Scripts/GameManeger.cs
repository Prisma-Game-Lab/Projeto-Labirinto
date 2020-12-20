using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    /* Variaveis para o timer */
    [System.NonSerialized]
    static public float seg = 0.0f;
    public GameObject CanvasUI;
    public Text UITempo;
    /* Variaveis para a energia */
    public bool eletricidade = false;
    /* Variaveis para terimnar o jogo*/
    public GameObject GameOverUI;
    public float bateryTimeMin;
    public Image batteryImage;
    public Image batteryImage2;

    private bool CanBlink = true;

    void Awake()
    {
        //Debug.Log("Valor eletricidade " + PlayerPrefs.HasKey("Eletricidade"));
        //PlayerPrefs.DeleteKey("Eletricidade");
        GameOverUI.SetActive(false);
    }

    void Start() {
       bateryTimeMin *= 60;
       batteryImage.material.color = Color.white;
       batteryImage2.material.color = Color.white;
    }

    void Update()
    {
        
    }

    private IEnumerator BlinkBattery() {
        CanBlink = false;
        batteryImage.gameObject.SetActive(false);
        batteryImage2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        CanBlink = true;
        batteryImage.gameObject.SetActive(true);
        batteryImage2.gameObject.SetActive(true);
    }
       

    void FixedUpdate()
    {
        seg += Time.deltaTime;

        if (seg/bateryTimeMin >= 0.5) {
            batteryImage.material.color = Color.red;
            batteryImage2.material.color = Color.red;
        }
        if(seg/bateryTimeMin >= 0.8 && CanBlink) {
            StartCoroutine(BlinkBattery());
        }
        batteryImage.fillAmount = 1 - seg/bateryTimeMin;
        if(seg >= bateryTimeMin)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        Pause.cantPause = true;
        batteryImage.material.color = Color.white;
        batteryImage2.material.color = Color.white;

    }

    public void Continue() {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        Pause.cantPause = false;
    }

    /*
    void OnDestroy()
    {
        
        if(eletricidade == true)
        {
            PlayerPrefs.SetInt("Eletricidade", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Eletricidade", 1);
            Debug.Log("vini amor da minha vida");
        } 
        Debug.Log("fui destruido");

    }
    */
}
