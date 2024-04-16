using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1f, 0); // Adjust the Y value to lower the center of mass.
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        Collider col = GetComponent<Collider>();
    // Assuming you have a Physics Material named "CarMaterial" in your Resources folder
        PhysicMaterial carMaterial = Resources.Load<PhysicMaterial>("CarMaterial");
         col.material = carMaterial;
    }

    void FixedUpdate()
    {
        // Get input for acceleration and turning
        float acceleration = Input.GetAxis("Vertical"); // Up and Down Arrow keys
        float steering = Input.GetAxis("Horizontal"); // Left and Right Arrow keys

        // Move the car forward
        rb.AddForce(transform.forward * acceleration * speed * Time.fixedDeltaTime);

        // Turn the car
        if (acceleration != 0) // This checks if there is some acceleration input to avoid turning the car when stationary
        {
            float direction = Mathf.Sign(Vector3.Dot(rb.velocity, transform.forward)); // This ensures the car turns correctly based on its current forward velocity
            rb.AddTorque(transform.up * steering * rotationSpeed * direction * Time.fixedDeltaTime);
        }
    }
}