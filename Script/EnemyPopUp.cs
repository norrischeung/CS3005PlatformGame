using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPopUp : MonoBehaviour
{   
    public GameObject EnemyBox;

    void Start() {
        EnemyBox.SetActive(false);
    }

    public void popUpEnemy() {
        EnemyBox.SetActive(true);
        //animator.SetTrigger("pop");
    }    
}
