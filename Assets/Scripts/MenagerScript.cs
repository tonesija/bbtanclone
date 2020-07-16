using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerScript : MonoBehaviour
{   
    public static int ROWSIZE = 7;
    private List<GridableObject> objs;
    public GameObject originalBlock;

    private int counter = 0;
    public bool canShootFlag = true;
    private int health = 1;
    // Start is called before the first frame update
    void Start()
    {
        objs = new List<GridableObject>();
        addNewRowToList(1);
        moveRow();
    }

    void Update(){
        if(!canShootFlag){    
            counter++;
            if(counter == 20){
                counter = 0;
                canShootFlag = true;
            }
        }
    }

    

    public void moveRow(){
        //Debug.Log("Moving objects..." + objs.Count);
        foreach(GridableObject obj in objs){
            if(obj != null) obj.moveDown();
        }
        canShootFlag = false;
    }

    public void addNewRowToList(int row){
        for(int i = 0; i < ROWSIZE; ++i){
            GameObject block = Instantiate(originalBlock);
            GridableObject gridable = block.GetComponent<GridableObject>();
            BlockScript script = block.GetComponent<BlockScript>();

            script.setHealth(health);
            
            //Debug.Log(script);
            gridable.setGridPosition(row, i + 1);

            objs.Add(gridable);
        }
        health++;
    }
}
