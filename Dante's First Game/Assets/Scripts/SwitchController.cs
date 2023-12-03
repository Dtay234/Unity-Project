using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField]
    public Grid grid;
    public Vector3Int switchPos;
    public BallController ballController;
    //public TotemController totemController;
    public string switchType = "none";
    //public Totem[] totem;
    public TotemController[] totemArray;
    

    // Start is called before the first frame update
    void Start()
    {
        switchPos = grid.WorldToCell(transform.position);
        totemArray = GameObject.FindObjectsOfType<TotemController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPos == ((ballController.transform.position) + Vector3Int.down))
        {

            ballController.moveDirection = -ballController.moveDirection;

            foreach (TotemController controller in totemArray)
            {
                

                CardinalChange(controller);
            }
        }
    }

    public void CardinalChange(TotemController controller)
    {
        if (ballController.moveDirection == Vector3Int.down
                ||
                ballController.moveDirection == Vector3Int.up)
        {
            
            
            
            switch (controller.totemType)
            {
                case "northwest":
                    controller.totemType = "northeast";
                    controller.totemAnimator.SetInteger("Cardinal", 0);
                    break;
                case "northeast":
                    controller.totemType = "northwest";
                    controller.totemAnimator.SetInteger("Cardinal", 1);
                    break;
                case "southwest":
                    controller.totemType = "southeast";
                    controller.totemAnimator.SetInteger("Cardinal", 2);
                    break;
                case "southeast":
                    controller.totemType = "southwest";
                    controller.totemAnimator.SetInteger("Cardinal", 3);
                    break;
            }
               
        }

        if (ballController.moveDirection == Vector3Int.right
                ||
                ballController.moveDirection == Vector3Int.left)
        {
            //ballController.moveDirection = -ballController.moveDirection;

            switch (controller.totemType)
            {
                case "southeast":
                    controller.totemType = "northeast";
                    break;
                case "southwest":
                    controller.totemType = "northwest";
                    break;
                case "northeast":
                    controller.totemType = "southeast";
                    break;
                case "northwest":
                    controller.totemType = "southwest";
                    break;
            }

        }
    }
}
