using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private int maxRoomAmnt = 7;
    private int level = 1;
    private int roomCount = 0;
    private bool[] edges;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        edges = new bool[4];
    }


    void edgeChance()
    {
        for(int edge = 0; edge < 4; edge++)
        {
            int chance = UnityEngine.Random.Range(1, 4);

            if(chance == 1)
            {
                edges[edge] = true;
            }
        }

    }

    void roomCreation(GameObject room)
    {
        edgeChance();
        Instantiate(ground);

        for(int x = 0; x < 4; x++)
        {
            if (edges[x] == true)
            {

                Instantiate(ground, new UnityEngine.Vector3(0,0,1));
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
