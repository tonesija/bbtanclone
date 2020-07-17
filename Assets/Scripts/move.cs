using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject player;
    public float Velocity = 5.0f;
    public Rigidbody2D rb;

    public int WallCollisionThreshold = 10;
    private int wallCollisionCounter = 0;
    

    private MenagerScript menagerScript;

    void Start()
    {
        menagerScript = GameObject.Find("LevelMenager").GetComponent<MenagerScript>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        float AngleInRad = player.GetComponent<ShooterScript>().angle;
        rb.AddForce(new Vector3(Velocity*Mathf.Cos(AngleInRad), Velocity*Mathf.Sin(AngleInRad), 0.0f), ForceMode2D.Force);
    }

    void Update(){
        if(transform.position.y < player.transform.position.y){
            if(player.GetComponent<ShooterScript>().XNeedsChange){
                player.GetComponent<ShooterScript>().XToChangeTo = transform.position.x;
                player.GetComponent<ShooterScript>().XNeedsChange = false;
            }
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.tag != "BlockTag"){
            wallCollisionCounter++;
        }else{
            wallCollisionCounter = 0;
        }

        if(wallCollisionCounter >= WallCollisionThreshold){
            menagerScript.addBouncerByPosition(transform.position.y);
            wallCollisionCounter = 0;
        }

    }

}
