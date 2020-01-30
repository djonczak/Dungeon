using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera options")]
    [SerializeField] private float smoothMovement = 15f;
    [SerializeField] private float cameraDistance = 31f;
    [SerializeField] GameObject target;

    private void Start()
    {
        target = PlayerExtension.GetPlayerObject();
    }

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 cameraHeight = target.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDistance));
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraHeight, smoothMovement * Time.fixedDeltaTime);
    }

}
