using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private int level = 1;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject ground;
    private bool[] edges;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        edges = new bool[4] {false, false, false, false};
        if(gameManagerScript.roomCount < 10)
        {
            roomCreation(ground);
        }
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

        if (gameManagerScript.roomCount < 10)
        {
            if (edges[0] == true)
            {
                Instantiate(room, new UnityEngine.Vector3(0, 0, 40), UnityEngine.Quaternion.identity);
                gameManagerScript.roomCount++;
            }
            if (edges[1] == true)
            {
                Instantiate(room, new UnityEngine.Vector3(40, 0, 0), UnityEngine.Quaternion.identity);
                gameManagerScript.roomCount++;
            }
            if (edges[2] == true)
            {
                Instantiate(ground, new UnityEngine.Vector3(0, 0, -40), UnityEngine.Quaternion.identity);
                gameManagerScript.roomCount++;
            }
            if (edges[3] == true)
            {
                Instantiate(room, new UnityEngine.Vector3(-40, 0, 0), UnityEngine.Quaternion.identity);
                gameManagerScript.roomCount++;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
