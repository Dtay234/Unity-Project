using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController2 : MonoBehaviour
{
    public Grid grid;
    public Vector3Int TP2Pos;
    public TeleporterController1 TPController1;
    public BallController ballController;
    public Vector3Int destination;

    // Start is called before the first frame update
    void Start()
    {
        /*
        TP2Pos = grid.WorldToCell(transform.position);
        TPController1.TP1Pos = grid.WorldToCell(TPController1.transform.position);
        destination = TPController1.TP1Pos + Vector3Int.up;
        TPController1.destination = TP2Pos + Vector3Int.up;
        */
        destination = grid.WorldToCell(GameObject.FindGameObjectWithTag("TP1").transform.position) + Vector3Int.up;

    }

    // Update is called once per frame
    void Update()
    {



        if (TP2Pos == ((ballController.transform.position) + Vector3Int.down))
        {
            ballController.transform.position = destination;
            ballController.newBallPos = destination;
            Console.WriteLine("a");
        }
    }
}
