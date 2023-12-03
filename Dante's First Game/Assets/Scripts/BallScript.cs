using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ball;
    public float speed;
    public Vector3 ballVelocity = Vector3.right;
    public Transform ballMovePoint;

    // Start is called before the first frame update
    void Start()
    {
        ballMovePoint.parent = null;

    }

    // Update is called once per frame
    void Update()
    {

        //Moves ball towards its movepoint

        if (ballMovePoint.position == transform.position)
        {
            ballMovePoint.position += ballVelocity;
        }

        transform.position =
                Vector3.MoveTowards
                (transform.position, ballMovePoint.position, speed * Time.deltaTime);
        
    }
}
