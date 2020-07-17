using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerManifestScript : MonoBehaviour
{
    private int aliveTime;

    public int timeToLive;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("BlockTag")){
            BlockScript blockScript = other.gameObject.GetComponent<BlockScript>();
            blockScript.setHealth(blockScript.getHealth() - 1);
        }
    }

    void Start(){
        aliveTime = 0;
    }

    void Update(){
        if(aliveTime >= timeToLive){
            Destroy(this.gameObject);
        }
        aliveTime++;
    }
}
