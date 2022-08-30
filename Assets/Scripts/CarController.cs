using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 1500f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private WheelJoint2D backWheel;
    [SerializeField] private WheelJoint2D frontWheel;
    private float _movement = 0f;
    private float _rotation = 0f;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = -Input.GetAxisRaw("Vertical") * speed;
        _rotation = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_movement == 0f)
            UseMotor(false);
        else
            UseMotor(true);

        JointMotor2D motor = new JointMotor2D { motorSpeed = _movement, maxMotorTorque = 10000 };
        backWheel.motor = motor;
        frontWheel.motor = motor;

        _rigidbody.AddTorque(-_rotation * rotationSpeed * Time.fixedDeltaTime);
    }

    private void UseMotor(bool motorState)
    {
        backWheel.useMotor = motorState;
        frontWheel.useMotor = motorState;
    }
}
