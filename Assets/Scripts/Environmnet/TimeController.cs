using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : Subject
{
    public Light sun;
    public Light[] lightOutSide;
    [SerializeField] private bool _isInsideBuilding = false;
    [SerializeField] private float _secondsInFullDay = 120f;
    [Range(0, 1)] [SerializeField] private float _currentTimeOfDay = 0f;
    [SerializeField] private float _timeMultiplier = 0.2f;
    private float _sunInitalIntensify;

    private void OnEnable()
    {
        DayNightCycleEvent.OnSwitchLigt += SwitchLights;
    }

    private void Start()
    {
        _currentTimeOfDay = PlayerPrefs.GetFloat("DayTime");

        if (_isInsideBuilding == false)
        {
            _sunInitalIntensify = sun.intensity;
        }
        else
        {
            _sunInitalIntensify = lightOutSide[0].intensity;
        }
    }

    private void Update()
    {
        if (_isInsideBuilding == false)
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

        _currentTimeOfDay += (Time.deltaTime / _secondsInFullDay) * _timeMultiplier;
        if (_currentTimeOfDay >= 1)
        {
            _currentTimeOfDay = 0;
        }
    }

    private void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((_currentTimeOfDay * 360f) - 90, 170, 0);

        float intesityMultiplier = 1;

        if (_currentTimeOfDay < 0.23f || _currentTimeOfDay >= 0.75f)
        {
            intesityMultiplier = 0f;
            if (observers.Count != 0)
            {
                Notify(this, NotificationType.Night);
            }
        }
        else if(_currentTimeOfDay <= 0.24f)
        {
            intesityMultiplier = Mathf.Clamp01((_currentTimeOfDay - 0.23f) * (1 / 0.02f));
            if (observers.Count != 0)
            {
                Notify(this, NotificationType.Day);
            }
        }
        else if(_currentTimeOfDay >= 0.73f)
        {
            intesityMultiplier = Mathf.Clamp01(1 - (_currentTimeOfDay - 0.73f) * (1 / 0.02f));
        }

        sun.intensity = _sunInitalIntensify * intesityMultiplier;
    }

    private void UpdateLightOutside()
    {
        float intesityMultiplier = 1;

        if (_currentTimeOfDay < 0.23f || _currentTimeOfDay >= 0.75f)
        {
            intesityMultiplier = 0.5f;
        }
        else if (_currentTimeOfDay <= 0.25f)
        {
            intesityMultiplier = Mathf.Clamp01((_currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (_currentTimeOfDay >= 0.73f)
        {
            intesityMultiplier = Mathf.Clamp01(1 - (_currentTimeOfDay - 0.73f) * (1 / 0.02f));
        }

        foreach (Light source in lightOutSide)
        {
            source.intensity = _sunInitalIntensify * intesityMultiplier;
            source.transform.localRotation = Quaternion.Euler((_currentTimeOfDay * 360f) - 90, 170, 0);
        }
    }

    public void SwitchLights()
    {
        _isInsideBuilding = !_isInsideBuilding;

        if (_isInsideBuilding == true)
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
        PlayerPrefs.SetFloat("DayTime", _currentTimeOfDay);
    }
}

