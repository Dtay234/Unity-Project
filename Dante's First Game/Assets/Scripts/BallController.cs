using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public StartController start;
    public float speed = 5f;
    public Vector3Int newBallPos;
    public Grid grid;
    //public Collider2D collider;
    public Vector3Int moveDirection;
    public bool gameOver = false;
    public TeleporterController1 teleporterController;

    // Start is called before the first frame update
    void Start()
    {
        newBallPos = grid.WorldToCell(transform.position);
    }

   
    void Update()
    {
        

        if (!start.play)
        {
            return;
        }

        if (moveDirection == Vector3Int.zero)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            //END THE GAME
        }
        
        if (newBallPos == transform.position)
        {
            newBallPos = newBallPos += moveDirection;
        }
        
        transform.position =
            (Vector3.MoveTowards(transform.position, newBallPos, speed * Time.deltaTime));
        
        if (grid.WorldToCell(teleporterController.transform.position) == ((transform.position) + Vector3Int.down) && 
            teleporterController.timeSinceTeleport > 1
            )
        {

            transform.position = teleporterController.destination;
            newBallPos = teleporterController.destination + moveDirection;
            Debug.Log("Hello");
            //ballController.moveDirection = Vector3Int.zero;

            teleporterController.timeSinceTeleport = 0;
        }
        else
        {
        
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameOver = true;
    }
}
