using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    public GameObject ball;
    public BallController ballController;
    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballController.transform.position == transform.position)
        {
            Destroy(ball);
            win = true;
        }
    }
}
