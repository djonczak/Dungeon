using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWorldMap : MonoBehaviour
{
    public GameObject mapCanvas;
    public GameObject[] cityObjects;

    [SerializeField] private List<GameObject> _mapObjects = new List<GameObject>();
    [SerializeField] private float _timeToShow = 1.5f;

    [SerializeField] private bool _cityActive = true;
    [SerializeField] private bool _mapActive = false;

    private void OnEnable()
    {
        WorlMapEvent.OnShowMap += ActivateMap;
        WorlMapEvent.OnHideMap += DeactivateMap;
    }

    private void Start()
    {
        mapCanvas.SetActive(false);
        foreach(Transform child in transform)
        {
            _mapObjects.Add(child.gameObject);
        }
    }

    // TODO: Hide city elements and show map

    public void ActivateMap()
    {
        StartCoroutine("ActivaterTimer", _timeToShow);
    }

    private IEnumerator ActivaterTimer(float time)
    {
        BlackScreenEvent.ShowBlackScreen();
        CheckMapElements();
        _mapActive = true;
        CheckCityElements();
        _cityActive = false;
        mapCanvas.SetActive(true);
        yield return new WaitForSeconds(time);
    }

    // TODO : Hide map elements and activate city

    public void DeactivateMap()
    {
        StartCoroutine("DeactivateTimer", _timeToShow);
    }

    private IEnumerator DeactivateTimer(float time)
    {
        _mapActive = false;
        _cityActive = true;
        BlackScreenEvent.ShowBlackScreen();
        CheckMapElements();
        yield return new WaitForSeconds(time);
        CheckCityElements();
        mapCanvas.SetActive(false);
    }

    //TODO: Check map elements

    private void CheckMapElements()
    {
        if (_mapActive == false)
        {
            foreach (GameObject subject in _mapObjects)
            {
                subject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject subject in _mapObjects)
            {
                subject.SetActive(false);
            }
        }
    }

    //TODO: Check city elements

    private void CheckCityElements()
    {
        if (_cityActive == false)
        {
            foreach (GameObject subject in cityObjects)
            {
                subject.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject subject in cityObjects)
            {
                subject.SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        WorlMapEvent.OnShowMap -= ActivateMap;
        WorlMapEvent.OnHideMap -= DeactivateMap;
    }
}
