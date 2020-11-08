using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private int maxRoomAmnt = 5;
    private int level = 1;
    private bool[,] roomGrid;
    private int roomCount = 0;
    public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        roomGrid = new bool[7, 7];
        generateStart(0);
        spawnRooms();
    }

    //Generates the first start room, marks it, and marks all other essential rooms
    void generateStart(int extraRooms)
    {
        maxRoomAmnt += extraRooms;
        int randStartX = UnityEngine.Random.Range(0,7);
        int randStartY = UnityEngine.Random.Range(0,7);

        roomGrid[randStartX, randStartY] = true;

        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                int chance = UnityEngine.Random.Range(1, maxRoomAmnt);

                if(chance == 1 && roomCount < maxRoomAmnt && roomGrid[x,y] != true)
                {
                    roomGrid[x, y] = true;
                    roomCount++;
                }
            }
        }
    }

    //Connects all rooms to spawn room
    void roomConnecting()
    {
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                
            }
        }
    }


    //Spawns rooms that are required to spawn
    void spawnRooms()
    {
        for(int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 7; y++)
            {
                if(roomGrid[x,y] == true)
                {
                    Instantiate(room, new Vector3(x * 40, 0, y * 40), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
