using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WinPopUp : MonoBehaviour
{   
    public GameObject WinPopUpBox;
    public TMP_Text FinalScoreText;
    public TMP_Text BestScoreText;
    public AudioSource WinSound;
    public AudioSource BgSound;

    void Start() {
        WinPopUpBox.SetActive(false);
        WinSound.Stop();
    }

    public void WinPop(int score) {
        WinPopUpBox.SetActive(true);
        FinalScoreText.text = score.ToString();
        SetBestScore(score);
        BgSound.Stop();
        WinSound.Play();
    }

    public void PlayAgain() {
        SceneManager.LoadScene(0);
    }

    public void SetBestScore(int score) {
        if(score > Scoring.bestscore) {
            Scoring.bestscore = score;
        }
        BestScoreText.text = "Best Score : " + Scoring.bestscore;
    }
    
}
