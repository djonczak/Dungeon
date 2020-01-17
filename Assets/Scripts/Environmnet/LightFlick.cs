using UnityEngine;

public class LightFlick : DayNightObserver
{
    [SerializeField] private float minIntensify = 1f;
    [SerializeField] private float maxIntensify = 1.5f;
    [SerializeField] public float flickSpeed = 9f;

    private Light lightSource;
    private float lightFlickCooldown = 0f;
    private bool isDay;

    private void Awake()
    {
        lightSource = GetComponent<Light>();
    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.Day)
        {
            Debug.Log("Dzien");
            lightSource.enabled = false;
            isDay = true;
        }

        if (notificationType == NotificationType.Night)
        {
            Debug.Log("Noc");
            lightSource.enabled = true;
            isDay = false;
        }
    }

    private void Update()
    {
        if (isDay == false)
        {
            lightFlickCooldown -= Time.deltaTime;
            if (lightFlickCooldown <= 0)
            {
                lightSource.intensity = Random.Range(minIntensify, maxIntensify);
                lightFlickCooldown = 1f / flickSpeed;
            }
        }
    }
}
