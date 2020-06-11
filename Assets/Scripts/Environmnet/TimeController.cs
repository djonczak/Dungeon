using System.Collections;
using UnityEngine;

public class TimeController : Subject
{
    [Header("Light sources")]
    [SerializeField] private Light _sun;
    [SerializeField] private Light[] _lightsOutside;
    [Header("Cycle options")]
    [SerializeField] private float _secondsInFullDay = 120f;
    [SerializeField] private float _timeMultiplier = 0.2f;
    [Range(0, 1)] [SerializeField] private float _currentTimeOfDay = 0f;

    private bool _isSunLight = true;
    private float _sunInitalIntensify;
    private Coroutine _timeCoroutine;

    private void OnEnable()
    {
        DayNightCycleEvent.OnSwitchLight += SwitchLights;
    }

    private void Start()
    {
        _currentTimeOfDay = PlayerPrefs.GetFloat("DayTime");
        _sunInitalIntensify = _sun.intensity;
        if (_currentTimeOfDay < 0.23f || _currentTimeOfDay >= 0.75f)
        {
            _timeCoroutine = StartCoroutine(NightCycle());
        }
        else if (_currentTimeOfDay >= 0.24f && _currentTimeOfDay <= 0.73f)
        {
            _timeCoroutine = StartCoroutine(DayCycle());
        }
        else if (_currentTimeOfDay >= 0.73f && _currentTimeOfDay <= 0.75f)
        {
            _timeCoroutine = StartCoroutine(EveningCycle());
        }
    }

    private IEnumerator DayCycle()
    {
        Notify(this, NotificationType.Day);
        while (_currentTimeOfDay > 0.24f && _currentTimeOfDay <= 0.73f)
        {
            _currentTimeOfDay += (Time.deltaTime / _secondsInFullDay) * _timeMultiplier;
            float intesityMultiplier = Mathf.Clamp01(1 - (_currentTimeOfDay - 0.73f) * (1 / 0.02f));

            Light(intesityMultiplier);

            yield return null;
        }
        StartCoroutine(EveningCycle());
    }

    private IEnumerator EveningCycle()
    {
        Notify(this, NotificationType.Night);
        while (_currentTimeOfDay >= 0.73f && _currentTimeOfDay <= 0.75f)
        {
            _currentTimeOfDay += (Time.deltaTime / _secondsInFullDay) * _timeMultiplier;
            float intesityMultiplier = Mathf.Clamp01((_currentTimeOfDay - 0.23f) * (1 / 0.02f));

            Light(intesityMultiplier);

            yield return null;
        }
        _timeCoroutine = StartCoroutine(NightCycle());
    }

    private IEnumerator NightCycle()
    {
        float intesityMultiplier = 0;
        while (_currentTimeOfDay < 0.24f || _currentTimeOfDay >= 0.75f)
        {
            _currentTimeOfDay += (Time.deltaTime / _secondsInFullDay) * _timeMultiplier;
            intesityMultiplier = Mathf.Clamp01((_currentTimeOfDay - 0.23f) * (1 / 0.02f));

            Light(intesityMultiplier);

            ResetTime();
            yield return null;
        }
        _timeCoroutine = StartCoroutine(DayCycle());
    }

    private void Light(float intesityMultiplier)
    {
        if (_isSunLight)
        {
            _sun.transform.localRotation = Quaternion.Euler((_currentTimeOfDay * 360f) - 90, 170, 0);
            _sun.intensity = _sunInitalIntensify * intesityMultiplier;
        }
        else
        {
            foreach (Light light in _lightsOutside)
            {
                light.transform.localRotation = Quaternion.Euler((_currentTimeOfDay * 360f) - 90, 170, 0);
                light.intensity = _sunInitalIntensify * intesityMultiplier;
            }
        }
    }

    private void ResetTime()
    {
        if (_currentTimeOfDay >= 1)
        {
            _currentTimeOfDay = 0;
        }
    }

    private void SwitchLights()
    {
        _isSunLight = !_isSunLight;
        if (_isSunLight)
        {
            _sun.enabled = true;
            foreach (Light light in _lightsOutside)
            {
                light.enabled = false;
            }
        }
        else
        {
            _sun.enabled = false;
            foreach (Light light in _lightsOutside)
            {
                light.enabled = true;
            }
        }
    }

    private void OnDestroy()
    {
        DayNightCycleEvent.OnSwitchLight -= SwitchLights;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("DayTime", _currentTimeOfDay);
    }
}

