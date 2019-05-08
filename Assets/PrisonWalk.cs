using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonWalk : MonoBehaviour
{

    public Transform centerPoint;
    public float walkSpeed;

    void Update()
    {
        transform.RotateAround(centerPoint.position, Vector3.up, walkSpeed * Time.deltaTime);
    }
}
