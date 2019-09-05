using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public string itemName;

    public string interactText;

    public virtual void OnInteractPress() { }

    public virtual void OnInteractHold() { }

    public virtual void ShowInfo() { }
}
