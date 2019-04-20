﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerCameraController : MonoBehaviour
{
    [Header("Camera options")]
    public float smooth;
    public float cameraDistance;
    public float offset;
    public Transform target;
    //public Transform spawnPoint;
    public static AdventurerCameraController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        ///transform.position = new Vector3(spawnPoint.position.x, this.transform.position.y, spawnPoint.position.z - 15f);
    }

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 math = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDistance + offset));
        transform.position = Vector3.Lerp(transform.position, target.position + math, smooth * Time.deltaTime);
    }
}
