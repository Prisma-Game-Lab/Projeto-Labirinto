using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    AudioSource audioSc;
    bool isMoving;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSc = GetComponent<AudioSource>();
    }

    void Update()
    {
        //checo de o player esta se movendo e atribuo a booleana
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
            isMoving = true;
        else
            isMoving = false;
        //caso ele esteja se movendo
        if (isMoving)
        {
            //e o audio ainda n tiver tocando ele toca o audio
            if (!audioSc.isPlaying)
            {
                audioSc.Play();
            }
        }
        else
            audioSc.Stop();

    }
    void FixedUpdate() {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 && inputY != 0) {
            inputX *= 0.5f;
            inputY *= 0.5f;
        }
      
        rb.velocity = new Vector2(inputX * speed, inputY * speed);
    }
}
