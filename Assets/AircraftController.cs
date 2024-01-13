using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour
{
    public float rollSpeed = 100.0f;
    public float pitchSpeed = 100.0f;
    public float yawSpeed = 100.0f;

    public float thrustForce = 100.0f;

    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    void Update()
    {
        float roll = controls.Player.Roll.ReadValue<float>() * rollSpeed * Time.deltaTime;
        float pitch = controls.Player.Pitch.ReadValue<float>() * pitchSpeed * Time.deltaTime;
        float yaw = controls.Player.Yaw.ReadValue<float>() * yawSpeed * Time.deltaTime;

        transform.Rotate(-pitch, yaw, -roll);
    }

    void FixedUpdate()
    {
        // Simulate thrust
        Vector3 thrust = transform.forward * thrustForce;
        GetComponent<Rigidbody>().AddForce(thrust);
    }
}
