using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenEvent : MonoBehaviour
{
    public delegate void BlackScreenEventHandler();
    public static event BlackScreenEventHandler OnDisperseBlackScreen;

    public static void ShowBlackScreen()
    {
        OnDisperseBlackScreen?.Invoke();
    }
}
