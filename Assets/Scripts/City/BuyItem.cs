public class BuyItem : InteractableItem
{
    public float goldCost;
    public float amount;

    private void Start()
    {
        interactText = "Press A/X/A/B to buy item " + itemName;
    }

    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(interactText);
    }

    public override void OnInteractPress()
    {
        
    }
}
