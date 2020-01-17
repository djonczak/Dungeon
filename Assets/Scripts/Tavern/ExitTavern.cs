using UnityEngine.SceneManagement;

public class ExitTavern : InteractableItem
{
    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(interactText);
    }

    public override void OnInteractPress()
    {
        SceneManager.LoadScene("CityHUB");
    }
}
