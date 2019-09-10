using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEvent : MonoBehaviour
{
    public delegate void InteractEventHandler(int id);
    public static event InteractEventHandler OnInteract;

    public static void PicekItem(int i)
    {
        if(OnInteract != null)
        {
            OnInteract(i);
        }
    }
}
