using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingFloor : MonoBehaviour
{
    SpriteRenderer cloud;
    public int isTouch = 0;

    public Scoring Scoring;

    public Rigidbody2D rb;

    public AudioSource HitFloorSound;

     // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<SpriteRenderer>();
        cloud.material.color = new Color(0.5f,0.5f,0.5f,1f);
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    } 

    void OnCollisionEnter2D (Collision2D collision) { 
        isTouch ++;
        if(isTouch==1) {
            cloud.material.color = Color.white; 
            HitFloorSound.Play();
            Scoring.UpdateScore(1);
        }
        //FloorFall
        rb.isKinematic = false;
    }

    void OnCollisionExit2D(Collision2D collision) {
        rb.isKinematic = true;
    }
}

