using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : PlayerGravityBody
{
    //public SphereCollider sphereCol;

    //public bool placeOnSurface = false;

    void OnCollisionEnter(Collision collision)
    {
        Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
        rot *= Quaternion.Euler(90f, 0f, 0f);

		//sphereCol.enabled = false;

		this.enabled = false;

		Destroy(gameObject, 4f);
    }

}
