using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlick : MonoBehaviour
{
    private Light lightSource;
    public float minIntensify;
    public float maxIntensify;

    private float lightFlickCooldown;
    public float flickSpeed;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lightFlickCooldown -= Time.deltaTime;
        if (lightFlickCooldown <= 0)
        {
            lightSource.intensity = Random.Range(minIntensify, maxIntensify);
            lightFlickCooldown = 1f / flickSpeed;
        }
    }
}
