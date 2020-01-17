using System.Collections.Generic;
using UnityEngine;

public abstract class DayNightObserver : MonoBehaviour
{
    public abstract void OnNotify(object value, NotificationType notificationType);
}

public enum NotificationType
{
    Day,
    Night,
};

public abstract class Subject : MonoBehaviour
{
    public List<DayNightObserver> observers = new List<DayNightObserver>();

    public void RegisterObserver(DayNightObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify(object value, NotificationType notificationType)
    {
        foreach(var observer in observers)
        {
            observer.OnNotify(value, notificationType);
        }
    }
}
