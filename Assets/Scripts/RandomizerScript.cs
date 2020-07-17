using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        GameObject ball = other.gameObject;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        float currMag = rb.velocity.magnitude;

        float angle = Random.Range(0, 2 * Mathf.PI);

        Vector2 newVec = new Vector2(currMag * Mathf.Cos(angle), currMag * Mathf.Sin(angle));

        rb.velocity = newVec;
    }


    
}
