using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{

    public GameObject player;
    void Start(){
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D other){
        player.GetComponent<ShooterScript>().IncreaseNumOfBalls();

        Destroy(gameObject);
    }
}
