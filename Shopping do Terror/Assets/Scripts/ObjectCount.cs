using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCount : MonoBehaviour
{
    public Text countText;

    public void CountText(int num) {
        countText.text = "Objetos: " + num.ToString();
    }

}
