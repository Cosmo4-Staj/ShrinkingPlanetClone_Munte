using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range(0, 15)]
    public float moveSpeed = 10f;

    [Range(50, 250)]
    public float rotationSpeed = 10f;

    private Rigidbody rb;
    private float rotation;

    public GameObject deathEffect;

    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;

    public AudioClip crashSound;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //TO DO : mousebuttondown
        //rotation = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                /*touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;*/

                rotation = theTouch.deltaPosition.x * 0.1f;

            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (-this.transform.right) * moveSpeed * Time.fixedDeltaTime);

        Vector3 rotationY = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            AudioSource.PlayClipAtPoint(crashSound, transform.position, 1);
            Instantiate(deathEffect, transform.position, transform.rotation);
            GameManager.instance.OnLevelFailed();

            Destroy(gameObject);            
        }
    }
}