using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float movingSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
    }

    public void SpeedUp(int speed) {
        movingSpeed += speed;
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
    }
}
