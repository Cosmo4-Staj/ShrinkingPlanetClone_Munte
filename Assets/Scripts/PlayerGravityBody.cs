using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerGravityBody : MonoBehaviour
{
    private GravityAttractor gravityAttractor;
    public bool placeOnSurface= false;

    // private varaibles
    private Rigidbody rb;

    void Start()
    {
        // get the only instance of attractor
        gravityAttractor = GravityAttractor.instance;

        // setup the rigidbody consraints
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
        {
            gravityAttractor.PlaceOnSurface(rb);
        }
        else
        {
            gravityAttractor.Attract(rb);
        }
    }
}
