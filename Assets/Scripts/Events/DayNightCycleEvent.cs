using UnityEngine;

    public class DayNightCycleEvent : MonoBehaviour
    {
        public delegate void SwitchLightEventHandler();
        public static event SwitchLightEventHandler OnSwitchLight;

        public static void SwitchLight()
        {
            OnSwitchLight?.Invoke();
        }
    }
