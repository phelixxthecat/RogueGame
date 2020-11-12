using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private int maxRoomAmnt = 5;
    private int level = 1;
    private bool[,] roomGrid;
    private System.Numerics.Vector2[,] roomsVec2;

    private System.Numerics.Vector2[] graphPos;
    private System.Numerics.Vector2[] cameFrom;
    private int positions = 0;
    private int roomCount = 0;
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {   
        //True false Grid for rooms, Vec2 values for rooms, Edge Ids (1 = Up, 2 = Right, 3 = Down, 4 = Left)
        roomGrid = new bool[7, 7];
        roomsVec2 = new System.Numerics.Vector2[7, 7];
        cameFrom = new System.Numerics.Vector2[];
        graphPos = new System.Numerics.Vector2[49];
        generateStartandRooms(0);
        SpawnRooms();
    }

    //Generates the first start room, marks it, and marks all other essential rooms
    void generateStartandRooms(int extraRooms)
    {
        maxRoomAmnt += extraRooms;
        int randStartX = UnityEngine.Random.Range(0,7);
        int randStartY = UnityEngine.Random.Range(0,7);

        roomGrid[randStartX, randStartY] = true;

        //frontierCreation(randStartX, randStartY);

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    int chance = UnityEngine.Random.Range(1, maxRoomAmnt + 7);

                    
                    
                    if (chance == 1 && roomCount < maxRoomAmnt && roomGrid[x,y] != true)
                    {
                        //Makes maxRoomAmnt + 7 rooms at a chance in each of the rooms.
                        roomGrid[x, y] = true;
                        roomCount++;
                    }

                //adds + 1 to positon in graphPos to keep adding Vector2's
                positions++;
                }
            }

    }

    void CreateGrid()
    {
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                roomsVec2[x, y] = new System.Numerics.Vector2(x - 3, y - 3);

            }
        }
    }

    //Spawns rooms that are required to spawn
    void SpawnRooms()
    {
        for(int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                if(roomGrid[x,y] == true)
                {
                    Instantiate(room, new UnityEngine.Vector3(x * 40, 0, y * 40), UnityEngine.Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
