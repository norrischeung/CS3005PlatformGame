using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPopUp : MonoBehaviour
{   
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text NewScoreText;
    public TMP_Text BestScoreText;

    public void popUp(int score) {
        popUpBox.SetActive(true);
        NewScoreText.text = score.ToString();
        SetBestScore(score);
        animator.SetTrigger("pop");
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }

    public void SetBestScore(int score) {
        if(score > Scoring.bestscore) {
            Scoring.bestscore = score;
        }
        BestScoreText.text = "Best Score : " + Scoring.bestscore;
    }
    
}
