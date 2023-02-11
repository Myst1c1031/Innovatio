using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Force forceAdded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(forceAdded, forceAdded[1], forceAdded[2]);
    }
}
