using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Rigidbody rb;

    public float forwardForce = 2000f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(500, 0, 0);

        }
    }
}
