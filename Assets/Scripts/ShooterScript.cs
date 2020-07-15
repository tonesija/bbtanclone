using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float angle = 90.0f;
    public float shootingRate = 0.2f; // how long it waits between shooting two balls
    public Transform ball;
    
    private int numOfBalls;
    private int score;
    private float timeWaited;
    private int counter;

    private int state;
    private float aspectRatio;
    void Start()
    {
        state = 0;
        score = 0;
        numOfBalls = 1;
        timeWaited = 0.0f;
        counter = 0;

        aspectRatio = (float)Screen.height/Screen.width;
        Debug.Log(aspectRatio);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && (state == 0 || state == 1)){
            state = 1;
            float MouseX = Input.mousePosition.x/Screen.width-.5f;
            float MouseY = Input.mousePosition.y/Screen.width-.1f*(aspectRatio/2.0f);
            angle = Mathf.Atan(MouseY/MouseX);
            if(MouseX < 0.0f){
                angle += Mathf.PI;
            }
        }

        if(!Input.GetMouseButton(0) && state == 1){
            state = 2;
            counter = 0;
        }

        if(state == 2){
            if(timeWaited == 0.0f){
                var prefabObject = Instantiate(ball, new Vector3(0.0f, -4.5f, 0.0f), Quaternion.identity);
                prefabObject.transform.parent = gameObject.transform;
                counter++;
            }

            if(counter == numOfBalls){
                state = 3;
            }else{
                timeWaited += Time.deltaTime;
                if(timeWaited >= shootingRate) timeWaited = 0.0f;
            }
        }

        if(state == 3){
            if(transform.childCount == 0){
                score++;
                state = 0;
            }
        }
    }

    public void IncreaseNumOfBalls(){
        numOfBalls++;
    }
}
