using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : InteractableItem
{
    public float goldCost;
    public float amount;

    public override void ShowInfo()
    {
        interactText = "Press A/X/A/B to buy item " + itemName;
    }

    public override void OnInteractPress()
    {
        
    }
}
