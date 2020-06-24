using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDEvent : MonoBehaviour
{
    public delegate void ShowMessageEventHandler(string text);
    public static event ShowMessageEventHandler OnShowMessage;

    public delegate void CloseMessageEventHandler();
    public static event CloseMessageEventHandler OnCloseMessage;

    public delegate void ShowPotionPanelEventHandler(PotionData potion);
    public static event ShowPotionPanelEventHandler OnPotionPanel;

    public static void ShowMessage(string text)
    {
        OnShowMessage?.Invoke(text);
    }

    public static void ShowItemPanel(Item item)
    {
        OnShowPanel?.Invoke(item);
    }

    public static void CloseMessage()
    {
        OnCloseMessage?.Invoke();
    }
}
