using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBossLevel : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 18f;
    public float jumpSpeed = 22f;
    public float direction = 0f;

    public Transform Floorcheck;
    public float FloorcheckRadius;
    public LayerMask FloorLayer;
    public bool isFloor;

    public int BossHealth = 3;

    private Animator animator;

    public Scoring Scoring;
    public GameOverPopUp GameOverPopUp;
    public BossLevel BossLevel;

    public AudioSource GetCoinSound;
    public AudioSource KillEnemySound;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FloorCheck return boolean
        isFloor = Physics2D.OverlapCircle(Floorcheck.position, FloorcheckRadius, FloorLayer);

        //Horizontal
        direction = Input.GetAxis("Horizontal");
        if(direction > 0f) {
            //Right
            player.velocity = new Vector2(speed * direction, player.velocity.y);
        } 
        else if(direction < 0f) {
            //Left
            player.velocity = new Vector2(speed * direction, player.velocity.y);
        }
        else {
            //stop
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isFloor) {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        
        //animation
        animator.SetTrigger("idle");
        animator.ResetTrigger("jump");
        animator.ResetTrigger("run");
        if(!isFloor) {
            animator.SetTrigger("jump"); 
            animator.ResetTrigger("idle");
        }
        if(direction!=0){
            animator.SetTrigger("run");
            animator.ResetTrigger("idle");
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //Detect Falling
        if(collision.tag == "FallDetector") {
            GameOverPopUp.popUp(Scoring.score);
            Destroy(gameObject,1);
        }
        //Get Coin
        if(collision.tag == "coin") {
            Scoring.UpdateScore(3);
            GetCoinSound.Play();
            Destroy(collision.gameObject);
        }
        //Kill by boss
        if(collision.tag == "BossAttack") {
            GameOverPopUp.popUp(Scoring.score);
            Destroy(gameObject);
            Debug.Log("Die");
        }
        //Kill Boss
        if(collision.tag == "KillBoss") {
            BossHealth --;
            Scoring.UpdateScore(10);
            KillEnemySound.Play();
            if(BossHealth > 0) {
                BossLevel.HealthBar(BossHealth);
            }
            else {
                if(BossHealth <= 0) {
                    BossLevel.HealthBar(0);
                    Destroy(collision.transform.parent.gameObject);
                    Destroy(gameObject);
                    Debug.Log("win");
                }
            }
            
        }
    }  
}