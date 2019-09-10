using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public static Map instance;
    public TimeController timeController;
    private bool canColor;

    public GameObject canvas;
    public GameObject mapCamera;
    public Image fog;

    private Color fogMainColor;
    private Color alphaColor = new Color(0f, 0f, 0f, 0f);
    private float t;
    public GameObject[] objectToDeactivate;
    public GameObject[] objectToActivate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fogMainColor = fog.color;
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (canColor)
        {
            t += Time.deltaTime / 1f;
            fog.color = Color.Lerp(fogMainColor, alphaColor, t);
        }
    }

    // TODO: Hide city hud and show map

    public void DisperseFogMap()
    {
        mapCamera.SetActive(true);
        canvas.SetActive(true);
        timeController.enabled = false;
        StartCoroutine("FogDisperse");
        foreach(GameObject subject in objectToDeactivate)
        {
            subject.SetActive(false);
        }
    }

    private IEnumerator FogDisperse()
    {
        yield return new WaitForSeconds(0.5f);
        canColor = true;
        yield return new WaitForSeconds(1.5f);
        canColor = false;
        t = 0f;
        foreach (GameObject subject in objectToActivate)
        {
            subject.SetActive(true);
        }
    }

    //  Functions for buttons

    // TODO : Hide map go back to city

    public void DisperseFogCity()
    {
        foreach (GameObject subject in objectToActivate)
        {
            subject.SetActive(false);
        }
        mapCamera.SetActive(false);
        canColor = true;
        StartCoroutine("FogDisperseCity");
    }

    private IEnumerator FogDisperseCity()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject subject in objectToDeactivate)
        {
            subject.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        canColor = false;
        t = 0f;
        canvas.SetActive(false);
        timeController.enabled = true;
    }
}
