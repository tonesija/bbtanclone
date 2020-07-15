using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerScript : MonoBehaviour
{   
    private int ROWSIZE = 7;
    private List<GridableObject> objs;
    public GameObject originalBlock;

    // Start is called before the first frame update
    void Start()
    {
        objs = new List<GridableObject>();
    }

    

    public void moveRow(){
        Debug.Log("Moving objects..." + objs.Count);
        foreach(GridableObject obj in objs){
            obj.moveDown();
        }
    }

    public void addNewRowToList(){
        for(int i = 0; i < ROWSIZE; ++i){
            GameObject block = Instantiate(originalBlock);
            GridableObject script = block.GetComponent<GridableObject>();
            Debug.Log(script);
            script.setGridPosition(0f, i - 2f);

            objs.Add(script);
        }
    }
}
