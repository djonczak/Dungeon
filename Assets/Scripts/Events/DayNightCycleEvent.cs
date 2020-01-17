using UnityEngine;

public class DayNightCycleEvent : MonoBehaviour
{
    public delegate void SwitchLightEventHandler();
    public static event SwitchLightEventHandler OnSwitchLigt;

    public static void SwitchLight()
    {
        OnSwitchLigt?.Invoke();
    }
}
