using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{

    public GameObject player;
    private AudioSource CoinSound;
    void Awake(){
        player = GameObject.Find("Player");
        CoinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        player.GetComponent<ShooterScript>().IncreaseNumOfBalls();
        
        CoinSound.Play();
        Debug.Log("This object destroyed me: " + other);
        Destroy(gameObject);
    }
}
