using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNavController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed = 120f;
    public float stopDistance = 0.2f;
    Vector3 lastPosition;
    Vector3 velocity;
    public Vector3 destination;
    public bool reachedDestination = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            movementSpeed = Random.Range(1f, 5f);

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

            }
            else
            {
                reachedDestination = true;
            }
            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);
        }
        else
        {
            reachedDestination = true;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }
}