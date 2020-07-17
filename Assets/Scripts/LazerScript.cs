using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{   
 
    public GameObject lazer;
   void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.tag.Equals("Ball")){
            GameObject newLazer = Instantiate(lazer);

            GridableObject lazerGridScript = newLazer.GetComponent<GridableObject>();
            GridableObject btnGridScript = this.gameObject.GetComponent<GridableObject>();
            Debug.Log(btnGridScript.getGridY());
            lazerGridScript.setGridPosition(btnGridScript.getGridY(), btnGridScript.getGridX());
       }
        
    }

}
