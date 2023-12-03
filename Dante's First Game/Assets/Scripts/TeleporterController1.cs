using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController1 : MonoBehaviour
{   
    public Grid grid;
    public BallController ballController;
    public Vector3Int destination;
    public int tpNumber = 1;
    public float timeSinceTeleport = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        if (tpNumber == 1)
        {
            destination = grid.WorldToCell(GameObject.FindGameObjectWithTag("TP2").transform.position) + Vector3Int.up;
        }
        else if (tpNumber == 2)
        {
            destination = grid.WorldToCell(GameObject.FindGameObjectWithTag("TP1").transform.position) + Vector3Int.up;
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceTeleport += Time.deltaTime;
    }
}
