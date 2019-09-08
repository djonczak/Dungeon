using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlick : Observer
{
    private Light lightSource;
    public float minIntensify;
    public float maxIntensify;

    private float lightFlickCooldown;
    public float flickSpeed;
    private bool isDay;

    void Start()
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

    // Update is called once per frame
    void Update()
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
