using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{

    public GameObject player;
    void Awake(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D other){
        player.GetComponent<ShooterScript>().IncreaseNumOfBalls();

        Debug.Log("This object destroyed me: " + other);
        Destroy(gameObject);
    }
}
