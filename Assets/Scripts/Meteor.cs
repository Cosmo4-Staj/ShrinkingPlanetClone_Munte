using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : PlayerGravityBody
{
    public GameObject explosion;
    public SphereCollider sphereCol;
    public ParticleSystem trail;

    void OnCollisionEnter(Collision collision)
    {
        /*Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
        rot *= Quaternion.Euler(90f, 0f, 0f);*/

        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        sphereCol.enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
