using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlockScript : MonoBehaviour
{
    private int health;
    private int maxHealth;
    private TextMeshPro tm;
    private SpriteRenderer sr;

    private AudioSource PopSound;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        tm = GetComponentInChildren<TextMeshPro>();
        tm.SetText(health.ToString());
        sr.color = Color.HSVToRGB(0.94f, 0.87f, 0.96f);
        tm.color = sr.color;
        PopSound = GameObject.Find("PopSound").GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D other) {
        
        health--;

        PopSound.Play();

        updateColors();
        
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
        maxHealth = health;
        tm.SetText(health.ToString());
        
    }

    public void takeDamage(){
        health--;
        
        if(health == 0){
            Destroy(this.gameObject);
        }
        
        tm.SetText(health.ToString());
        updateColors();
    }

    private void updateColors(){
        sr.color = Color.HSVToRGB(0.94f-0.3f*(1.0f-(health/(float)maxHealth)), 0.87f, 0.96f);
        tm.color = sr.color;
    }



    

}
