using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float angle = 90.0f;
    public float shootingRate = 0.2f; // how long it waits between shooting two balls
    public Transform ball;

    private MenagerScript menagerScript;
    
    private int numOfBalls;
    private int score;
    private float timeWaited;
    private int counter;

    private int state;
    private float aspectRatio;
    private float MouseX = 0.0f;
    private float MouseY = 0.0f;
    private float MouseXOff = 0.0f;
    private float MouseYOff = 0.0f;
    private GameObject arrow;

    public bool XNeedsChange = false;
    public float XToChangeTo = 0.0f;

    void Start()
    {
        state = 0;
        score = 0;
        numOfBalls = 1;
        timeWaited = 0.0f;
        counter = 0;

        arrow = transform.Find("Arrow").gameObject;

        aspectRatio = (float)Screen.height/Screen.width;

        menagerScript = GameObject.Find("LevelMenager").GetComponent<MenagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0) && state == 0){
            state = 1;
            MouseX = Input.mousePosition.x/Screen.width;
            MouseY = Input.mousePosition.y/Screen.width;

            arrow.GetComponent<SpriteRenderer>().enabled = true;
        }

        if(Input.GetMouseButton(0) && state == 1){
            float InputX = Input.mousePosition.x/Screen.width;
            float InputY = Input.mousePosition.y/Screen.width;
            MouseXOff = MouseX - InputX;
            MouseYOff = MouseY - InputY;
            
            if(MouseXOff != 0.0f){
                angle = Mathf.Atan(MouseYOff/MouseXOff);
            }else{
                if(MouseYOff > 0.0f){
                    angle = Mathf.PI/2.0f;
                }else{
                    angle = -Mathf.PI/2.0f;
                }
            }
            if(MouseXOff < 0.0f){
                angle += Mathf.PI;
            }

            float MouseOffLength = Mathf.Sqrt(MouseXOff*MouseXOff + MouseYOff*MouseYOff);
            arrow.transform.localScale = new Vector3(2.0f, 1.5f + MouseOffLength, 1.0f);
            arrow.transform.localPosition = new Vector3(0.0f, 5 + MouseOffLength * 4.0f, 0.0f);
            if(MouseYOff <= 0.0f){
                arrow.GetComponent<SpriteRenderer>().enabled = false;
            }else{
                arrow.GetComponent<SpriteRenderer>().enabled = true;
            }

            transform.Rotate(0.0f, 0.0f, Mathf.Rad2Deg * (angle - Mathf.PI) - transform.rotation.eulerAngles.z + 90.0f, Space.Self);
        }

        if(!Input.GetMouseButton(0) && state == 1){
            if(MouseYOff > 0.0f){
                state = 2;
                counter = 0;
                XNeedsChange = true;
            }else{
                state = 0;
                counter = 0;
                XNeedsChange = false;
            }
        }

        if(state == 2){
            if(timeWaited == 0.0f){
                var prefabObject = Instantiate(ball, new Vector3(transform.position.x, transform.position.y, 0.0f), Quaternion.identity);
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
            if(transform.childCount < 2){
                score++;
                if(score > PlayerPrefs.GetInt("HighScore", 0)){
                    PlayerPrefs.SetInt("HighScore", score);
                }
                
                arrow.GetComponent<SpriteRenderer>().enabled = false;
                transform.SetPositionAndRotation(new Vector3(XToChangeTo, transform.position.y, 0.0f), Quaternion.identity);
                menagerScript.addNewRowToList(0);
                menagerScript.moveRow();
                state = 4;
            }
        }

        if(state == 4){
            if(menagerScript.canShootFlag){
                state = 0;
            }
        }

        // if state is equal to 5, that means the game is over
        
    }

    public void IncreaseNumOfBalls(){
        numOfBalls++;
    }

    public void setState(int n){
        state = n;
    }

    public int getScore(){
        return score;
    }
}
