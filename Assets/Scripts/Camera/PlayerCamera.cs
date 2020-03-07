using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera options")]
    [SerializeField] private float _smoothMovement = 15f;
    [SerializeField] private float _cameraDistance = 31f;
    [SerializeField] GameObject _target;

    private void Start()
    {
        _target = PlayerExtension.GetPlayerObject();
    }

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 cameraHeight = _target.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, _cameraDistance));
        transform.position = Vector3.Lerp(transform.position, _target.transform.position + cameraHeight, _smoothMovement * Time.fixedDeltaTime);
    }

}
