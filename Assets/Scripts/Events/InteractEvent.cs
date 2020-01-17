using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEvent : MonoBehaviour
{
    public delegate void InteractEventHandler(int id);
    public static event InteractEventHandler OnInteract;

    public static void PicekItem(int i)
    {
        OnInteract?.Invoke(i);
    }
}
