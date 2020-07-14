using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float angle = 90.0f;
    public float shootingRate = 0.2f; // how long it waits between shooting two balls
    public Transform ball;

    private int state;
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && state == 0){
            state = 1;
            float MouseX = Input.mousePosition.x/Screen.width-.5f;
            float MouseY = Input.mousePosition.y/Screen.width-(8.0f/9.0f);
            angle = Mathf.Atan(MouseY/MouseX);
            if(MouseX < 0.0f){
                angle += Mathf.PI;
            }
        }

        if(!Input.GetMouseButton(0) && state == 1){
            Instantiate(ball, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            state = 0;
        }
    }
}
