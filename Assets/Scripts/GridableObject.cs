using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public float distanceToTravel = 2f;
    private float distance = 0;
    public float speed = 0.1f;

    public float cellW = 1f;
    public float cellH = 1f;
    public float cellOffset = 0.05f;
    private bool move = false;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update(){
        if(move){
            rb.MovePosition(new Vector2(rb.position.x, rb.position.y - speed));
            distance += speed;
            Debug.Log(distance);
        }

        if(distance >= distanceToTravel){
            move = false;
            distance = 0;
        }
    }
    public void moveDown(){
        move = true;
    }

    public void stop(){
        rb.velocity = new Vector2(0f, 0f);
    }

    public void setGridPosition(float row, float column){
        float x = (column - 1) * cellW + cellOffset * column;
        float y = (row - 1) * cellH + cellOffset * row + 6.5f;

        rb.MovePosition(new Vector2(x, y));
    }
}
