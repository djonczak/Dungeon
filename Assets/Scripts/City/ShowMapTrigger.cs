
public class ShowMapTrigger: InteractableItem
{
    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(interactText);
    }

    public override void OnInteractPress()
    {
        WorlMapEvent.ShowMap();
    }

}
