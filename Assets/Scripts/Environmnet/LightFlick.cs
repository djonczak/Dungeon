using UnityEngine;

public class LightFlick : DayNightObserver
{
    [SerializeField] private float _minIntensify = 1f;
    [SerializeField] private float _maxIntensify = 1.5f;
    [SerializeField] public float _flickSpeed = 9f;

    private Light _lightSource;
    private float _lightFlickCooldown = 0f;
    private bool _isDay;

    private void Awake()
    {
        _lightSource = GetComponent<Light>();
    }

    public override void OnNotify(object value, NotificationType notificationType)
    {
        if (notificationType == NotificationType.Day)
        {
            Debug.Log("Dzien");
            _lightSource.enabled = false;
            _isDay = true;
        }

        if (notificationType == NotificationType.Night)
        {
            Debug.Log("Noc");
            _lightSource.enabled = true;
            _isDay = false;
        }
    }

    private void Update()
    {
        if (_isDay == false)
        {
            _lightFlickCooldown -= Time.deltaTime;
            if (_lightFlickCooldown <= 0)
            {
                _lightSource.intensity = Random.Range(_minIntensify, _maxIntensify);
                _lightFlickCooldown = 1f / _flickSpeed;
            }
        }
    }
}
