﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenagerScript : MonoBehaviour
{   
    public static int ROWSIZE = 7;

    public static int COLUMNSIZE = 12;
    private List<GridableObject> objs;
    public GameObject originalBlock;
    public GameObject TLTriangle;
    public GameObject TRTriangle;
    public GameObject BLTriangle;
    public GameObject BRTriangle;
    public GameObject AddBallCoin;

    private int counter = 0;
    public bool canShootFlag = true;
    private int health = 1;

    private bool[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new bool[COLUMNSIZE, ROWSIZE];
        objs = new List<GridableObject>();
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
    }

    

    public void moveRow(){
        //Debug.Log("Moving objects..." + objs.Count);
        
        foreach(GridableObject obj in objs){
            if(obj != null) obj.moveDown();
        }
        canShootFlag = false;
    }

    public void addNewRowToList(int row){
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
        health++;
    }

    private void changeGridStatus(){
        freeGrid();
        foreach(GridableObject obj in objs){
            int gridX = obj.getGridX();
            int gridY = obj.getGridY();

            grid[gridX, gridY] = true;
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
}
