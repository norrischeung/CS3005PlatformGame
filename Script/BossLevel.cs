using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLevel : MonoBehaviour
{
    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject Health0;

    public WinPopUp WinPopUp;

    void Start()
    {
        Health3.SetActive(true);
        Health2.SetActive(false);
        Health1.SetActive(false);
        Health0.SetActive(false);
    }

    public void HealthBar(int health) {
        if(health == 2) {
            Health3.SetActive(false);
            Health2.SetActive(true);
            Health1.SetActive(false);
            Health0.SetActive(false);
        }
        if(health == 1) {
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(true);
            Health0.SetActive(false);
        }
        if(health == 0) {
            Health3.SetActive(false);
            Health2.SetActive(false);
            Health1.SetActive(false);
            Health0.SetActive(true);
            WinPopUp.WinPop(Scoring.score);
        }
    }
}
