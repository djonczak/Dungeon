using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerCameraController : MonoBehaviour
{
    [Header("Camera options")]
    public float smooth;
    public float cameraDistance;
    public float offset;
    public Transform target;
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
    }

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 math = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDistance + offset));
        transform.position = Vector3.Lerp(transform.position, target.position + math, smooth * Time.fixedDeltaTime);
    }

    public IEnumerator CameraShake()
    {
        var timer = 0f;
        while (timer < 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Random.insideUnitSphere * 0.5f, smooth);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0f;
    }
}
