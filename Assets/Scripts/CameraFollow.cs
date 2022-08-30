using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
