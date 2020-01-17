using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float smooth = 15f;
    [SerializeField] private float shakeTime = 0.1f;
    [SerializeField] private float shakeStrenght = 0.5f;

    public void OnEnable()
    {
        AdventurerEvent.OnPlayerHurt += Shake;
    }

    public void Shake()
    {
        StartCoroutine("ShakeCamera");
    }

    private IEnumerator ShakeCamera()
    {
        var timer = 0f;
        while (timer < shakeTime)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Random.insideUnitSphere * shakeStrenght, smooth);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0f;
    }

    private void OnDestroy()
    {
        AdventurerEvent.OnPlayerHurt -= Shake;
    }
}
