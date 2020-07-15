using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridableObject : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }
    public void moveDown(){
        rb.velocity = new Vector2(0f, -1f);
    }

    public void stop(){
        rb.velocity = new Vector2(0f, 0f);
    }
}
