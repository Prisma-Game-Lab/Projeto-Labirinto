using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource _as;
    public AudioClip[] RdSpookySounds;
    bool PrimeiraVez;

// Start is called before the first frame update
void Start()
    {
        PrimeiraVez = true;
        StartCoroutine("PlaySound");
    }


    IEnumerator PlaySound()
    {
        if (PrimeiraVez == true)
        {
            PrimeiraVez = false;
            yield return new WaitForSeconds(20f);
        }
        for (; ; )
        { 
         _as.clip = RdSpookySounds[Random.Range(0, RdSpookySounds.Length - 1)];
         _as.PlayOneShot(_as.clip);
         yield return new WaitForSeconds(35f);
        }
    }
}
