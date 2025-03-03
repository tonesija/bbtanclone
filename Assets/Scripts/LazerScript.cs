﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{   
 
    public GameObject lazer;

    public bool IsHorizontal = true;
    private AudioSource LazerSound;
    private void Awake(){
        LazerSound = GameObject.Find("LazerSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.tag.Equals("Ball")){
            GameObject newLazer = Instantiate(lazer);
            LazerSound.Play();

            GridableObject lazerGridScript = newLazer.GetComponent<GridableObject>();
            GridableObject btnGridScript = this.gameObject.GetComponent<GridableObject>();
            Debug.Log(btnGridScript.getGridY());
            
            // lazerGridScript.setGridPosition(btnGridScript.getGridY(), btnGridScript.getGridX());

            if(IsHorizontal){
                lazerGridScript.setGridPosition(btnGridScript.getGridY(), 3);
            }else{
                lazerGridScript.setGridPosition(5, btnGridScript.getGridX());
            }
       }
        
    }

}
