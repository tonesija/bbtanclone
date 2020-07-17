using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerScript : MonoBehaviour
{   
    public static int ROWSIZE = 7;

    public static int COLUMNSIZE = 12;
    private List<GridableObject> objs;

    private List<GameObject> temporaryObjs;
    public GameObject originalBlock;
    public GameObject TLTriangle;
    public GameObject TRTriangle;
    public GameObject BLTriangle;
    public GameObject BRTriangle;
    public GameObject AddBallCoin;

    public GameObject bouncerOriginal;

    public GameObject horLazerOriginal;

    private int counter = 0;
    public bool canShootFlag = true;
    private int health = 1;

    private bool[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new bool[COLUMNSIZE, ROWSIZE];
        objs = new List<GridableObject>();
        temporaryObjs = new List<GameObject>();
        freeGrid();
        addNewRowToList(0);
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

        bool gameEnded = false;
        for(int i=0; i<ROWSIZE; i++){
            gameEnded |= grid[COLUMNSIZE-2, i];
        }

        GameObject.Find("UIManager").GetComponent<UIManagerScript>().gameEnded = gameEnded;
    }

    

    public void moveRow(){
        //Debug.Log("Moving objects..." + objs.Count);
        
        foreach(GridableObject obj in objs){
            if(obj != null) obj.moveDown();
        }
        canShootFlag = false;
    }

    public void addNewRowToList(int row){
        destroyTempObjects();
        cleanObjsList();

        int AddBallCoinPosition = (int) Random.Range(0.0f, (float) ROWSIZE - 0.000001f);

        for(int i = 0; i < ROWSIZE; ++i){

            
            bool ObjShouldBeAdded = false;
            bool ObjIsCoin = false;
            GameObject block = gameObject;
            
            if(i==AddBallCoinPosition){
                block = Instantiate(AddBallCoin);
                ObjShouldBeAdded = true;
                ObjIsCoin = true;
            }else{
                float randomValue = Random.Range(0.0f, 10.0f);
                
                if(randomValue > 3.0f){
                    ObjShouldBeAdded = true;
                    ObjIsCoin = false;

                    if(randomValue < 8.0f){
                        block = Instantiate(originalBlock);
                    }else if(randomValue > 8.0f && randomValue < 8.5f){
                        block = Instantiate(TRTriangle);
                    }else if(randomValue > 8.5f && randomValue < 9.0f){
                        block = Instantiate(TLTriangle);
                    }else if(randomValue > 9.0f && randomValue < 9.5f){
                        block = Instantiate(BRTriangle);
                    }else if(randomValue > 9.5f){
                        block = Instantiate(BLTriangle);
                    }
                }
            }
            
            if(ObjShouldBeAdded){
                GridableObject gridable = block.GetComponent<GridableObject>();
                
                if(ObjIsCoin == false){
                    BlockScript script = block.GetComponent<BlockScript>();
                    script.setHealth(health);
                }
                gridable.setGridPosition(row, i);

                objs.Add(gridable);
            }


        }
        changeGridStatus();

        maybeCreateBouncer(1f);
        maybeCreateLazer(1f);

        health++;
    }

    private void changeGridStatus(){
        freeGrid();
        foreach(GridableObject obj in objs){
            int gridX = obj.getGridX();
            int gridY = obj.getGridY();

            grid[gridY, gridX] = true;
        }
    }

    private void cleanObjsList(){
        for(int i = objs.Count - 1; i >= 0; --i){
            if(objs[i] == null){
                objs.RemoveAt(i);
            }
        }
    }

    private void freeGrid(){
       for(int i = 0; i < ROWSIZE; ++i){
           for(int j = 0; j < COLUMNSIZE; ++j){
               grid[j, i] = false;
           }
       }
    }

    private void printGridSize(){
        int size = 0;
       for(int i = 0; i < ROWSIZE; ++i){
           for(int j = 0; j < COLUMNSIZE; ++j){
               if(grid[j, i]){
                   size++;
               }
           }
       }
       Debug.Log("Grid size: " + size);
    }

    private string matrix(){
        string toReturn = "";
        for(int i = 0; i < ROWSIZE; ++i){
            toReturn += "\n";
           for(int j = 0; j < COLUMNSIZE; ++j){
               
               if(grid[j, i]){
                   toReturn += "1";
               } else{
                   toReturn += "0";
               }
           }
       }
       return toReturn;
    }

    private void maybeCreateBouncer(float chance){
        if(chance > Random.Range(0f, 1f)){
            GridSpot toPut = getRandomAvailableSpot(7);

            GameObject bouncer = Instantiate(bouncerOriginal);
            GridableObject script = bouncer.GetComponent<GridableObject>();
            script.setGridPosition(toPut.getY() + 1, toPut.getX());

            temporaryObjs.Add(bouncer);
        }
    }

    private void maybeCreateLazer(float chance){
        if(chance > Random.Range(0f, 1f)){
            GridSpot toPut = getRandomAvailableSpot(7);

            GameObject lazer = Instantiate(horLazerOriginal);
            GridableObject script = lazer.GetComponent<GridableObject>();
            script.setGridPosition(toPut.getY() + 1, toPut.getX());

            temporaryObjs.Add(lazer);
        }
    }

    //updates grid, destroys temp objects and cleans the temporaryObjs list
    private void destroyTempObjects(){

        foreach(GameObject obj in temporaryObjs){
            GridableObject script = obj.GetComponent<GridableObject>();
            int x = script.getGridX();
            int y = script.getGridY();
            grid[y, x] = false;
            Destroy(obj);
        }
        for(int i = temporaryObjs.Count - 1; i >= 0; --i){
            temporaryObjs.RemoveAt(i);
        }
    }

    private GridSpot getRandomAvailableSpot(int maxYTreshold){
        while(true){
            int x = Random.Range(0, ROWSIZE);
            int y = Random.Range(0, maxYTreshold);

            if(!grid[y, x]){
                GridSpot toReturn = new GridSpot(x, y);
                return toReturn;
            }
        }
    }

    private struct GridSpot{

        public GridSpot(int x, int y){
            this.x = x;
            this.y = y;
        }
        int x;
        int y;

        public int getX(){
            return x;
        }
        public int getY(){
            return y;
        }
    }
}
