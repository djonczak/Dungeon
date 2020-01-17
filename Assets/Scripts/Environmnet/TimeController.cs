using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : Subject
{
    public Light sun;
    public Light[] lightOutSide;
    [SerializeField] private bool isInsideBuilding = false;
    [SerializeField] private float secondsInFullDay = 120f;
    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0f;
    [SerializeField] private float timeMultiplier = 0.2f;
    private float sunInitalIntensify;

    private void OnEnable()
    {
        DayNightCycleEvent.OnSwitchLigt += SwitchLights;
    }

    private void Start()
    {
        currentTimeOfDay = PlayerPrefs.GetFloat("DayTime");

        if (isInsideBuilding == false)
        {
            sunInitalIntensify = sun.intensity;
        }
        else
        {
            sunInitalIntensify = lightOutSide[0].intensity;
        }
    }

    private void Update()
    {
        if (isInsideBuilding == false)
        {
            if (sun != null)
            {
                UpdateSun();
            }
        }
        else
        {
            UpdateLightOutside();
        }

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    private void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intesityMultiplier = 1;

        if (currentTimeOfDay < 0.23f || currentTimeOfDay >= 0.75f)
        {
            intesityMultiplier = 0f;
            if (observers.Count != 0)
            {
                Notify(this, NotificationType.Night);
            }
        }
        else if(currentTimeOfDay <= 0.24f)
        {
            intesityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
            if (observers.Count != 0)
            {
                Notify(this, NotificationType.Day);
            }
        }
        else if(currentTimeOfDay >= 0.73f)
        {
            intesityMultiplier = Mathf.Clamp01(1 - (currentTimeOfDay - 0.73f) * (1 / 0.02f));
        }

        sun.intensity = sunInitalIntensify * intesityMultiplier;
    }

    private void UpdateLightOutside()
    {
        float intesityMultiplier = 1;

        if (currentTimeOfDay < 0.23f || currentTimeOfDay >= 0.75f)
        {
            intesityMultiplier = 0.5f;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intesityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intesityMultiplier = Mathf.Clamp01(1 - (currentTimeOfDay - 0.73f) * (1 / 0.02f));
        }

        foreach (Light source in lightOutSide)
        {
            source.intensity = sunInitalIntensify * intesityMultiplier;
            source.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        }
    }

    public void SwitchLights()
    {
        isInsideBuilding = !isInsideBuilding;

        if (isInsideBuilding == true)
        {
            sun.enabled = false;
            foreach (Light source in lightOutSide)
            {
                source.enabled = true;
            }
        }
        else
        {
            sun.enabled = true;
            foreach (Light source in lightOutSide)
            {
                source.enabled = false;
            }
        }
    }

    private void OnDestroy()
    {
        DayNightCycleEvent.OnSwitchLigt -= SwitchLights;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("DayTime", currentTimeOfDay);
    }
}

