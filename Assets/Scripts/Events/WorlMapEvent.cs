using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorlMapEvent : MonoBehaviour
{
    public delegate void ShowMapEventHandler();
    public static event ShowMapEventHandler OnShowMap;

    public delegate void HideMapEventHandler();
    public static event HideMapEventHandler OnHideMap;

    public static void ShowMap()
    {
        OnShowMap?.Invoke();
    }

    public static void HideMap()
    {
        OnHideMap?.Invoke();
    }
}
