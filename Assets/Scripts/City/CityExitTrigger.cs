using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityExitTrigger : InteractableItem
{
    public override void ShowInfo()
    {
        interactText = "Press E to exit city";
    }

    public override void OnInteractPress()
    {
        Map.instance.DisperseFogMap();
    }

}
