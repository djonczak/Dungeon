using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDEvent : MonoBehaviour
{
    public delegate void ShowMessageEventHandler(string text);
    public static event ShowMessageEventHandler OnShowMessage;

    public delegate void CloseMessageEventHandler();
    public static event CloseMessageEventHandler OnCloseMessage;

    public static void ShowMessage(string text)
    {
        OnShowMessage?.Invoke(text);
    }

    public static void CloseMessage()
    {
        OnCloseMessage?.Invoke();
    }
}
