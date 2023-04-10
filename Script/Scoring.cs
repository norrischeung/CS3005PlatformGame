using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int score;
    public static int bestscore;

    public Text scoreText;

    void Start()
    {
        Scoring.score = 0;
        scoreText.text = Scoring.score.ToString();
    }

    public void UpdateScore(int sc) {
        score += sc;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
}

