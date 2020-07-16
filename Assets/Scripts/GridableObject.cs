using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public float distanceToTravel = 1.0f;
    private float distance = 0;
    public float speed = 0.1f;

    public float cellW = 1f;
    public float cellH = 1f;
    private bool move = false;

    public float ViewportWidth = 5.625f;
    public float ViewportHeight = 10.0f;
    private Vector2 tempVector;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 

        cellW = ViewportWidth/MenagerScript.ROWSIZE;
        cellH = cellW;
        distanceToTravel = cellH;
        Debug.Log(distanceToTravel);
        speed = distanceToTravel/20.0f;
    }

    void Update(){
        if(move){
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y - speed));
            distance += speed;
            Debug.Log(distance);
        }

        if(distance >= distanceToTravel){
            rb.MovePosition(new Vector2(rb.position.x, tempVector.y - distanceToTravel));
            move = false;
            distance = 0;
        }
    }
    public void moveDown(){
        move = true;
        tempVector = rb.position;
    }

    public void stop(){
        rb.velocity = new Vector2(0f, 0f);
    }

    public void setGridPosition(int row, int column){
        float x = (column - 1) * cellW - (ViewportWidth - cellW)/2.0f;
        float y = (row + 1) * cellH + (ViewportHeight - cellH)/2.0f ;

        rb.MovePosition(new Vector2(x, y));
    }
}
