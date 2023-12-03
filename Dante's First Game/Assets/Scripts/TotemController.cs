using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TotemController : MonoBehaviour
{
    //public PlayerController playerController;
    public Transform totemMovePoint;
    //public bool canBePushed = true;
    public LayerMask stopMovement;
    [SerializeField]
    public Grid grid;
    public Vector3Int totemPos;
    public bool selected;
    public float moveSpeed = 10f;
    public Collider collider;
    public BallController ballController;
    public string totemType = "none";
    public Type totem;
    public Animator totemAnimator;
    public SwitchController switchController;

    // Start is called before the first frame update
    void Start()
    {

        totemPos = grid.WorldToCell(transform.position);

        transform.position = grid.CellToWorld(totemPos);

        switch (totemType)
        {
            case "northwest":               
                totemAnimator.SetInteger("Cardinal", 1);
                break;
            case "northeast":
                totemAnimator.SetInteger("Cardinal", 0);
                break;
            case "southwest":
                totemAnimator.SetInteger("Cardinal", 3);
                break;
            case "southeast":
                totemAnimator.SetInteger("Cardinal", 2);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {


        transform.position =
            (Vector3.MoveTowards(transform.position, totemPos, moveSpeed * Time.deltaTime));

        if (CheckRayCast(collider))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                selected = true;
            }
            

            //highlight the totem
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            selected = false;
        }


        if (selected)
        {

            if ((!Physics2D.OverlapCircle
                            (totemMovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, stopMovement.value)))
            {
                if (transform.position == totemPos)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        totemPos = grid.WorldToCell(totemPos + new Vector3(-1f, 0f, 0f));
                    }

                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        totemPos = grid.WorldToCell(totemPos + new Vector3(1f, 0f, 0f));
                    }
                    
                }
            }

            if ((!Physics2D.OverlapCircle
                            (totemMovePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, stopMovement.value)))
            {
                if (transform.position == totemPos)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        totemPos = grid.WorldToCell(totemPos + new Vector3(0f, -1f, 0f));
                    }

                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        totemPos = grid.WorldToCell(totemPos + new Vector3(0f, 1f, 0f));
                    }
                }
            }

        }
        
        if (totemPos == (ballController.transform.position) + Vector3Int.down)
        {
            ballController.moveDirection = 
            Ricochet(ballController.moveDirection, totemType);
        }
        
    }

    static bool CheckRayCast(Collider collider)
    {
        RaycastHit hit;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            

            if (hit.collider == collider)
            return true;
        }
       
        
            return false;
        
    }

    static Vector3Int Ricochet(Vector3Int ballMoveDirection, string totemType)
    {
        

        switch (totemType)
        {
            case "southwest":
                        
                if ( ballMoveDirection == Vector3Int.right)
                {
                    ballMoveDirection = Vector3Int.down;
                }
                else if (ballMoveDirection == Vector3Int.left)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.up)
                {
                    ballMoveDirection = Vector3Int.left;
                }
                else if (ballMoveDirection == Vector3Int.down)
                {
                    ballMoveDirection = Vector3Int.zero;
                }            
                break;

            case "northwest":

                if (ballMoveDirection == Vector3Int.right)
                {
                    ballMoveDirection = Vector3Int.up;
                }
                else if (ballMoveDirection == Vector3Int.left)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.up)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.down)
                {
                    ballMoveDirection = Vector3Int.left;
                }                
                break;

            case "southeast":

                if (ballMoveDirection == Vector3Int.right)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.left)
                {
                    ballMoveDirection = Vector3Int.down;
                }
                else if (ballMoveDirection == Vector3Int.up)
                {
                    ballMoveDirection = Vector3Int.right;
                }
                else if (ballMoveDirection == Vector3Int.down)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                break;

            case "northeast":

                if (ballMoveDirection == Vector3Int.right)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.left)
                {
                    ballMoveDirection = Vector3Int.up;
                }
                else if (ballMoveDirection == Vector3Int.up)
                {
                    ballMoveDirection = Vector3Int.zero;
                }
                else if (ballMoveDirection == Vector3Int.down)
                {
                    ballMoveDirection = Vector3Int.right;
                }
                break;

        }

        return ballMoveDirection;
    }

}
