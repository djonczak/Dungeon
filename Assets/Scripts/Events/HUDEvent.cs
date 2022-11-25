using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI 
{

    public class HUDEvent : MonoBehaviour
    {
        public delegate void ShowMessageEventHandler(string text);
        public static event ShowMessageEventHandler OnShowMessage;

        public delegate void CloseMessageEventHandler();
        public static event CloseMessageEventHandler OnCloseMessage;

        public delegate void ShowPotionPanelEventHandler(Shop.PotionData potion);
        public static event ShowPotionPanelEventHandler OnPotionPanel;

        public static void ShowMessage(string text)
        {
            OnShowMessage?.Invoke(text);
        }

        public static void ShowItemPanel(Shop.PotionData potion)
        {
            OnPotionPanel?.Invoke(potion);
        }

        public static void CloseMessage()
        {
            OnCloseMessage?.Invoke();
        }
    }
}
