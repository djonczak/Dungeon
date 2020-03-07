using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _smooth = 15f;
    [SerializeField] private float _shakeTime = 0.1f;
    [SerializeField] private float _shakeStrenght = 0.5f;

    public void OnEnable()
    {
        AdventurerEvent.OnPlayerHurt += Shake;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        var timer = 0f;
        while (timer < _shakeTime)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Random.insideUnitSphere * _shakeStrenght, _smooth);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    private void OnDestroy()
    {
        AdventurerEvent.OnPlayerHurt -= Shake;
    }
}
