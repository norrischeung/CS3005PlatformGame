using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class FloorController : MonoBehaviour
{
    SpriteRenderer cloud;
    public int isTouch = 0;

    public Scoring Scoring;

    public AudioSource HitFloorSound;

     // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<SpriteRenderer>();
        cloud.material.color = new Color(0.5f,0.5f,0.5f,1f);
    } 

    void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {  
            isTouch ++;
            if(isTouch==1) {
                cloud.material.color = Color.white;
                HitFloorSound.Play();
                Scoring.UpdateScore(1);
            }
        }       
    }
}
