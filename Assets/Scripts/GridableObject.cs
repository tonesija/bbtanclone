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

    private int gridX;
    private int gridY;
    
    void Awake()
    {
        gridY = -1;
        gridX = -1;
        rb = GetComponent<Rigidbody2D>(); 

        cellW = ViewportWidth/MenagerScript.ROWSIZE;
        cellH = cellW;
        distanceToTravel = cellH;
        // Debug.Log(distanceToTravel);
        speed = distanceToTravel/20.0f;
    }

    void Update(){
        if(move){
            //rb.MovePosition(new Vector2(rb.position.x, rb.position.y - speed));
            Vector2 curr = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector2(curr.x, curr.y - speed);
            distance += speed;
        }

        if(distance >= distanceToTravel){
            gridY++;
            setGridPosition(gridY, gridX);
            //rb.MovePosition(new Vector2(rb.position.x, tempVector.y - distanceToTravel));
            move = false;
            distance = 0;
        }
    }
    public void moveDown(){
        move = true;
        //tempVector = rb.position;
    }


    public void setGridPosition(int row, int column){
        gridX = column;
        gridY = row;
        float x = (column) * cellW - (ViewportWidth - cellW)/2.0f;
        float y = -(row) * distanceToTravel + (ViewportHeight - distanceToTravel)/2.0f ;

        this.gameObject.transform.position = new Vector3(x, y, 0.0f);
    }

    public int getGridX(){
        return gridX;
    }

    public int getGridY(){
        return gridY;
    }
}
