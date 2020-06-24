using UnityEngine.SceneManagement;

public class ExitTavern : InteractableItem
{
    private string _interactText;
    public override void ShowInfo()
    {
        HUDEvent.ShowMessage(_interactText);
    }

    public override void OnInteractPress()
    {
        SceneManager.LoadScene("CityHUB");
    }
}
