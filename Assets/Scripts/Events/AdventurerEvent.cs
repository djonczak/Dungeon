using UnityEngine;

public class AdventurerEvent : MonoBehaviour
{
    public delegate void DamageEventHandler();
    public static event DamageEventHandler OnPlayerHurt;

    public static void PlayerHit()
    {
        OnPlayerHurt?.Invoke();
    }
}
