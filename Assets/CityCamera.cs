using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCamera : MonoBehaviour
{
    [Header("Camera options")]
    public float smooth;
    public float cameraDistance;
    public float offset;
    public Transform player;
    public Transform map; 

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 math = player.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDistance + offset));
        transform.position = Vector3.Lerp(transform.position, player.position + math, smooth * Time.fixedDeltaTime);
    }
}
