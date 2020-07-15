using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlockScript : MonoBehaviour
{
    private int health;
    private TextMeshPro tm;
    
    void Start()
    {
        health = 20;
        tm = GetComponentInChildren<TextMeshPro>();
        tm.SetText(health + "");
    }


    void OnCollisionEnter2D(Collision2D other) {
        
        health--;
        
        if(health == 0){
            Destroy(this.gameObject);
        }
        
        tm.SetText(health.ToString());
    }

    /// <summary>
    /// Should be called after Instantiating the block.
    /// </summary>
    public void setHealth(int health){
        this.health = health;
    }

    

}
