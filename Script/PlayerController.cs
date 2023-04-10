using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 12f;
    public float jumpSpeed = 22f;
    public float direction = 0f;

    public Transform Floorcheck;
    public float FloorcheckRadius;
    public LayerMask FloorLayer;
    public bool isFloor;

    private Animator animator;

    public Scoring Scoring;
    public GameOverPopUp GameOverPopUp;
    public CameraMovement CameraMovement;
    public EnemyPopUp EnemyPopUp;

    public Camera maincam;

    public AudioSource GetCoinSound;
    public AudioSource StageSound;
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

        //GameOver when player too slow
        if(maincam.transform.position.x > this.transform.position.x + 20) {
            GameOverPopUp.popUp(Scoring.score);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        //Detect Falling
        if(collision.tag == "FallDetector") {
            GameOverPopUp.popUp(Scoring.score);
            Destroy(gameObject,1);
        }
        //Go to Stage2 + Speed Up
        if(collision.tag == "Stage2Detector") {
            StageSound.Play();
            speed = 15f;
            CameraMovement.SpeedUp(3);
            Destroy(collision.gameObject);
            Debug.Log("Stage2");
        }
        //Go to Stage3 + Speed Up
        if(collision.tag == "Stage3Detector") {
            StageSound.Play();
            speed = 18f;
            CameraMovement.SpeedUp(1);
            EnemyPopUp.popUpEnemy();
            Destroy(collision.gameObject);
            Debug.Log("Stage3");
        }
        //Get Coin
        if(collision.tag == "coin") {
            Scoring.UpdateScore(3);
            GetCoinSound.Play();
            Destroy(collision.gameObject);
        }
        //Kill Enemy
        if(collision.tag == "KillEnemy") {
            Scoring.UpdateScore(5);
            KillEnemySound.Play();
            Destroy(collision.transform.parent.gameObject);
        }
        //Kill by enemy
        if(collision.tag == "EnemyAttack") {
            GameOverPopUp.popUp(Scoring.score);
            Destroy(gameObject);
        }
        //Go to Boss Level
        if(collision.tag == "BossDetector") {
            SceneManager.LoadScene(2);
            Destroy(collision.gameObject);
        }
    }  
}