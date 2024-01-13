using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodynamics : MonoBehaviour
{
    public float liftForce = 10.0f;
    public float dragForce = 5.0f;

    void FixedUpdate()
    {
        // Simulate lift
        Vector3 lift = transform.up * liftForce;
        GetComponent<Rigidbody>().AddForce(lift);

        // Simulate drag
        Vector3 drag = -GetComponent<Rigidbody>().velocity.normalized * dragForce;
        GetComponent<Rigidbody>().AddForce(drag);
    }
}
